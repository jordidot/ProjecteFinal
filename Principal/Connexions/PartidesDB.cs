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
        public Partides TotesPartides { get; set; }


        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public PartidesDB(Cartes cartes,Partida partida)
        {
            TotesPartides = new();
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
        public void AfegirPartidaBD(Partida partida)
        {
            try
            {
                var comanda = new MySqlCommand("INSERT INTO partides VALUES(" + partida.Id + ",'" + partida.Bot.Nom + "'," + partida.Usuari.Id + ",'" + partida.EstatPartida + "');", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir la partida." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
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
  
        ///// <summary>
        ///// Metode per recuperar partides d'un usuari de la bd
        ///// </summary>
        ///// <returns></returns>
        //public Partides RecuperarPartides(Usuari usuari)
        //{
        //    Partides partides = new Partides();
        //    try
        //    {
        //        MySqlCommand command = new MySqlCommand("SELECT *,(SELECT count(*) FROM partides) FROM partides WHERE id_usuari="+usuari.Id+";", ConnexioBD.Connectar());
        //        MySqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Bot bot = new Bot(TotesCartes);
        //            bot.Nom = reader.GetString(1);

        //            Cartes cartesBot = new Cartes();

        //            Mazo mazoUsuari = new(reader.GetInt32(2), cartesBot, "MazoUsuari", usuari);

        //            Partida partida = new Partida(reader.GetInt32(0), bot, 1500,usuari, 1500, reader.GetString(3));
        //            partides.LlistaPartides.Add(partida);
        //            Quantitat = reader.GetInt32(4);
        //        }
        //        this.Partides = partides;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        ConnexioBD.Connectar().Close();
        //        MySqlConnection.ClearAllPools();
        //    }
        //    return partides;
        //}
        /// <summary>
        /// Metode per recuperar usuariBD
        /// </summary>
        /// <returns></returns>
        public List<Partida> RecuperarPartides(Usuari usuari, Cartes cartes)
        {
            List<Partida> partidesList = new List<Partida>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM partides;", ConnexioBD.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Bot bot = new(cartes);
                    bot.Nom = reader.GetString(1);
                    Mazos mazos = new();
                    Partides partides = new();
                    usuari.Id = reader.GetInt32(2);
                    Partida partida = new(reader.GetInt32(0),bot,1500,usuari,1500,reader.GetString(3));
                    partidesList.Add(partida);
                }
                
                TotesPartides.LlistaPartides = partidesList;
                this.Quantitat = TotesPartides.LlistaPartides.Count;
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
            return TotesPartides.LlistaPartides;
        }

    }
}
