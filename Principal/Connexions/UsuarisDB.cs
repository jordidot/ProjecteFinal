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
        public void AfegirUsuariBD(Usuari usuaris)
        {

        }
        /// <summary>
        /// Metode per afegir Usuaris
        /// </summary>
        /// <param name="usuaris">Usuaris a afegir</param>
        public void AfegirUsuarisBD(Usuaris usuaris)
        {
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
        public void ModificarUsuari(Usuari usari) { }

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

                    Partides partides = new Partides();
                    //PartidesDB partidesdb = new PartidesDB();
                    //partidesdb.RecuperarPartides();
                    //foreach (Partida p in partidesdb.Partides.LlistaPartides)
                    //{
                    //    if (p.Usuari.Id == reader.GetInt32(0)) partides.LlistaPartides.Add(p);
                    //}

                    Mazos mazos = new();
                    //MazosDB mazosdb = new MazosDB();
                    //mazosdb.RecuperarMazos();
                    //foreach (Mazo m in mazosdb.Mazos.LlistaMazos)
                    //{
                    //    if (m.Usuari.Id == reader.GetInt32(2)) mazos.LlistaMazos.Add(m);
                    //}

                    Usuari usuari = new Usuari(reader.GetInt32(0), reader.GetString(4), reader.GetString(2), reader.GetString(1), mazos, partides, reader.GetInt32(6), reader.GetString(3), reader.GetInt32(5));
                    usuaris.Add(usuari);
                }
                Usuaris.Llistausuaris = usuaris;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }
    }
}
