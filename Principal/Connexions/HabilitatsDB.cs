using Principal.Negoci;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Principal.Connexions
{
    public class HabilitatsDB
    {
        //Atributs
        private Habilitats habilitats;
        private ConnexioDB connexioBD;
        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public HabilitatsDB()
        {
            habilitats = new Habilitats();
            connexioBD = new ConnexioDB("", "localhost", "cartesdb", "root");
        }

        //Propietats
        /// <summary>
        /// Propietat del atribut habilitats
        /// </summary>
        public Habilitats Habilitats
        {
            get { return habilitats; }
            set { habilitats = value; }
        }
        /// <summary>
        /// Propietat de l'atribut Connexio
        /// </summary>
        public ConnexioDB ConnexioBD
        {
            get { return connexioBD; }
            set { connexioBD = value; }
        }


        //Metodes
        /// <summary>
        /// Metode per afegir habilitat a la BD
        /// </summary>
        /// <param name="habilitat">habilitat a afegir</param>
        public void AfegirHabilitatBD(Habilitat habilitat)
        {

        }

        /// <summary>
        /// Metode per afegir habilitats
        /// </summary>
        /// <param name="habilitats">habilitats a afegir</param>
        public void AfegirHabilitatsBD(List<Habilitat> habilitats)
        {

        }
        /// <summary>
        /// Metode per eliminar habilitat
        /// </summary>
        /// <param name="habilitat">habilitat a eliminar </param>
        public void EliminarHabilitatBD(Habilitat habilitat)
        {

        }
        /// <summary>
        /// Metode per modificar habilitat a la BD
        /// </summary>
        /// <param name="habilitat">habilitat a modificar</param>
        public void ModificarHabilitatBD(Habilitat habilitat)
        {

        }
        /// <summary>
        /// Metode per recuperar habilitat de la bd
        /// </summary>
        /// <returns></returns>
        public Habilitats RecuperarHabilitats(Carta carta)
        {
            Habilitats habilitats = new();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM habilitats;", ConnexioBD.Connectar());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Habilitat habilitat = new Habilitat(reader.GetInt32(0), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(2), reader.GetString(1));
                    habilitats.LListahabilitats.Add(habilitat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
            return habilitats;
        }
    }
}
