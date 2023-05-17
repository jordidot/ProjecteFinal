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
    public class MazosDB
    {
        //Atributs
        private Mazos mazos;
        private ConnexioDB connexioBD;

        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public MazosDB()
        {
            connexioBD = new ConnexioDB("", "127.0.0.1", "cartesdb", "root");
            mazos = new Mazos();
        }

        //Propietats
        /// <summary>
        /// Propietat de l'atribut mazosbd
        /// </summary>
        public Mazos Mazos
        { get { return mazos; } set { mazos = value; } }
        /// <summary>
        /// Propietat de l'atribut connexiobd
        /// </summary>
        public ConnexioDB ConnexioBD { get { return connexioBD; } set { connexioBD = value; } }

        //Metodes
        /// <summary>
        /// Metode per afegir mazo a la bd
        /// </summary>
        /// <param name="mazo">mazo a afegir</param>
        public void AfegirMazoBD(Mazo mazo)
        {
            var comanda = new MySqlCommand("INSERT INTO mazos VALUES("+mazo.Id+","+mazo.Nom+"," + mazo.Usuari.Id + "," + mazo.Cartes.LlistaCartes[0].Id + "," + mazo.Cartes.LlistaCartes[1].Id + "," + mazo.Cartes.LlistaCartes[2].Id + "," + mazo.Cartes.LlistaCartes[3].Id + "," + mazo.Cartes.LlistaCartes[4].Id + ");", ConnexioBD.Connectar());
            comanda.ExecuteNonQuery();
        }
        /// <summary>
        /// Metode per afegir mazos a la bd
        /// </summary>
        /// <param name="mazo">mazos a afegir</param>
        public void AfegirMazosBD(Mazo mazo)
        {

        }
        /// <summary>
        /// Metode per eliminar mazo a la bd
        /// </summary>
        /// <param name="Mazo">mazo a eliminar</param>
        public void EliminarMazoBD(Mazo Mazo)
        {

        }
        /// <summary>
        /// Metode per modificar un mazo de la bd
        /// </summary>
        /// <param name="Mazo">Mazo per modificar</param>
        public void ModificarMazoBD(Mazo Mazo)
        {

        }

        /// <summary>
        /// Metode per recuperar mazos
        /// </summary>
        /// <returns></returns>
        public void RecuperarMazos()
        {
            List<Mazo> mazos = new List<Mazo>();
            try
            {
                //Obro amb el using i realitzo la query passant-li la connexio i tanco un cop llegit.
                var comanda = new MySqlCommand("SELECT * FROM mazos;", ConnexioBD.Connectar());
                //Executo la query i guardo totes les dades en un MySqlDataReader.
                var llegir = comanda.ExecuteReader();
                //Començo bucle per anar recuperant els camps de cada fila.
                while (llegir.Read())
                {
                    //Creo Cartes per poder afegir-li al Mazo.
                    Cartes cartes = new Cartes();
                    ////Busco les habilitats que hi han a la base de dades.
                    CartesDB cartesBD = new CartesDB();
                    cartesBD.RecuperarCartes();
                    foreach (Carta c in cartesBD.Cartes.LlistaCartes)
                    {
                        if (c.Id == llegir.GetInt32(3)) cartes.LlistaCartes.Add(c);
                    }
                    foreach (Carta c in cartesBD.Cartes.LlistaCartes)
                    {
                        if (c.Id == llegir.GetInt32(4)) cartes.LlistaCartes.Add(c);
                    }
                    foreach (Carta c in cartesBD.Cartes.LlistaCartes)
                    {
                        if (c.Id == llegir.GetInt32(5)) cartes.LlistaCartes.Add(c);
                    }
                    foreach (Carta c in cartesBD.Cartes.LlistaCartes)
                    {
                        if (c.Id == llegir.GetInt32(6)) cartes.LlistaCartes.Add(c);
                    }
                    foreach (Carta c in cartesBD.Cartes.LlistaCartes)
                    {
                        if (c.Id == llegir.GetInt32(7)) cartes.LlistaCartes.Add(c);
                    }

                    Usuari usuariMazo = new();
                    UsuarisDB usuaribd = new();
                    usuaribd.RecuperarUsuariBD();
                    foreach (Usuari u in usuaribd.Usuaris.Llistausuaris)
                    {
                        if (u.Id == llegir.GetInt32(2)) usuariMazo = u;
                    }

                    //Creo la carta i li passo tots els parametres.
                    Mazo mazo = new Mazo(llegir.GetInt32(0), cartes, llegir.GetString(1), usuariMazo);
                    //Afegeixo la carta a la llista de cartes.
                    mazos.Add(mazo);

                }
                //Assigno la llista de cartes recuperada de la base de dades a la de la classe.
                Mazos.LlistaMazos = mazos;

            }
            catch (Exception ex)
            {
                //Capturo el missatge d'error.
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Tanco la connexio a la BD.
                ConnexioBD.Connectar().Close();
            }
        }
    }
}
