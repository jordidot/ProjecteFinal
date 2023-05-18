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
    public class UsuarisDB
    {
        //Atributs
        private Usuaris usuaris;
        private ConnexioDB connexioBD;
        public int QuantitatTotal { get; set; }

        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public UsuarisDB()
        {
            connexioBD = new ConnexioDB("", "127.0.0.1", "cartesdb", "root");
            usuaris = new Usuaris();
        }

        //Propietats
        /// <summary>
        ///Propietat de l'atribut Usuaris
        /// </summary>
        public Usuaris Usuaris
        {
            get { return usuaris; }
            set { usuaris = value; }
        }
 
        /// <summary>
        /// Propietat de l'atribut connexioBD
        /// </summary>
        public ConnexioDB ConnexioBD { get { return connexioBD; } set { connexioBD = value; } }

        //Metodes
        /// <summary>
        /// Metode per afegir usuari
        /// </summary>
        /// <param name="usuaris">usuari a afegir</param>
        public void AfegirUsuariBD(Usuari usuari)
        {
            try
            {
                var comanda = new MySqlCommand("INSERT INTO usuaris VALUES(" + usuari.Id + ",'" + usuari.NomUsuari + "','" + usuari.Contrasenya + "','" + usuari.ImatgePerfil + "','" + usuari.Alias + "'," + usuari.EsAdministrador + "," + usuari.Punts+ ");", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir l'usuari." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }
        /// <summary>
        /// Metode per eliminar usaris
        /// </summary>
        /// <param name="usari">usuari a eliminar</param>
        public void EliminarUsariBD(Usuari usari) { }

        /// <summary>
        /// Metode per modificar usuaris
        /// </summary>
        /// <param name="usari">usuari a modificar</param>
        public void ModificarUsuari(Usuari usuari)
        {
            try
            {
                var comanda = new MySqlCommand("UPDATE usuaris SET imatgeperfil ='"+usuari.ImatgePerfil+ "', alias='" + usuari.Alias + "',esAdministrador="+ usuari.EsAdministrador+ ",punts="+usuari.Punts+" WHERE id="+usuari.Id+";", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut modificar l'usuari." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }

        /// <summary>
        /// Metode per recuperar usuariBD
        /// </summary>
        /// <returns></returns>
        public void RecuperarUsuariBD()
        {
            List<Usuari> usuaris = new List<Usuari>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM usuaris;", ConnexioBD.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Mazos mazos = new();
                    Partides partides = new();
                    Usuari usuari = new Usuari(reader.GetInt32(0), reader.GetString(4), reader.GetString(2), reader.GetString(1), mazos, partides, reader.GetInt32(6), reader.GetString(3), reader.GetInt32(5));
                    usuaris.Add(usuari);
                }
                Usuaris.Llistausuaris = usuaris;
                this.QuantitatTotal = Usuaris.Llistausuaris.Count;
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
        }
    }
}
