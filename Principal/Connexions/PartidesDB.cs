using Principal.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace Principal.Connexions
{
    public class PartidesDB
    {
        //Atributs 
        private Partides partides;
        private ConnexioDB connexioBD;
        public Cartes TotesCartes { get; set; }
        public int Quantitat { get; set; }


        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public PartidesDB(Cartes cartes)
        {
            connexioBD = new ConnexioDB("", "127.0.0.1", "cartesdb", "root");
            partides = new Partides();
            this.TotesCartes = cartes;
        }

        //Propietats
        /// <summary>
        /// Propietat de l'atribut partides
        /// </summary>
        public Partides Partides
        {
            get { return partides; }
            set { partides = value; }
        }
        /// <summary>
        /// Propietat del atribut connexioBD
        /// </summary>
        public ConnexioDB ConnexioBD
        { get { return connexioBD; } set { connexioBD = value; } }

        //Metodes
        /// <summary>
        /// Metode per afegir partida a la bd
        /// </summary>
        public void AfegirPartidaBD()
        {

        }
        /// <summary>
        /// Metode per eliminar una partida de la bd
        /// </summary>
        /// <param name="Partida">partida a eliminar</param>
        public void EliminarPartidaBD(Partida Partida)
        {

        }
        /// <summary>
        /// Metode per modificar una partida de la bd
        /// </summary>
        /// <param name="partida">Partida a modifcar</param>
        public void ModificarPartidaBD(Partida partida)
        {
        }
  
        /// <summary>
        /// Metode per recuperar partides d'un usuari de la bd
        /// </summary>
        /// <returns></returns>
        public Partides RecuperarPartides(Usuari usuari)
        {
            Partides partides = new Partides();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT *,(SELECT count(*) FROM partides) FROM partides WHERE id_usuari="+usuari.Id+";", ConnexioBD.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Bot bot = new Bot(TotesCartes);
                    bot.Nom = reader.GetString(1);

                    Cartes cartesBot = new Cartes();

                    Mazo mazoUsuari = new(reader.GetInt32(2), cartesBot, "MazoUsuari", usuari);

                    Partida partida = new Partida(reader.GetInt32(0), bot, 1500,usuari, 1500, reader.GetString(3));
                    partides.LlistaPartides.Add(partida);
                    Quantitat = reader.GetInt32(4);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
                MySqlConnection.ClearAllPools();
            }
            return partides;
        }
        
    }
}
