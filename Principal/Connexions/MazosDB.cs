using Principal.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;
using System.CodeDom;

namespace Principal.Connexions
{
    public class MazosDB
    {
        //Atributs
        private Mazos mazos;
        private ConnexioDB connexioBD;
        public int Quantitat { get; set; }

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
            try
            {
                var comanda = new MySqlCommand("INSERT INTO mazos VALUES(" + mazo.Id + ",'" + mazo.Nom + "'," + mazo.Usuari.Id + "," + mazo.Cartes.LlistaCartes[0].Id + "," + mazo.Cartes.LlistaCartes[1].Id + "," + mazo.Cartes.LlistaCartes[2].Id + "," + mazo.Cartes.LlistaCartes[3].Id + "," + mazo.Cartes.LlistaCartes[4].Id + ");", ConnexioBD.Connectar());
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
        /// Metode per eliminar mazo a la bd
        /// </summary>
        /// <param name="Mazo">mazo a eliminar</param>
        public void EliminarMazoBD(Mazo mazo)
        {
            try
            {
                var comanda = new MySqlCommand("DELETE FROM mazos WHERE id="+mazo.Id+";", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar el mazo." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
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
        public Mazos RecuperarMazos(Usuari usuari)
        {
            Mazos mazos = new();
            try
            {

                //Obro amb el using i realitzo la query passant-li la connexio i tanco un cop llegit.
                var comanda = new MySqlCommand("SELECT *,(SELECT * FROM mazos) FROM mazos WHERE id_usuari =" + usuari.Id + ";", ConnexioBD.Connectar());
                //Executo la query i guardo totes les dades en un MySqlDataReader.
                var llegir = comanda.ExecuteReader();
                //Començo bucle per anar recuperant els camps de cada fila.
                while (llegir.Read())
                {
                    //Creo Cartes per poder afegir-li al Mazo.
                    Cartes cartes = new Cartes();
                    Mazo mazo = new Mazo(llegir.GetInt32(0), cartes, llegir.GetString(1), usuari);
                    mazo.Cartes = cartes.RecuperarCartes(mazo);
                    //Afegeixo la carta a la llista de cartes.
                    mazos.LlistaMazos.Add(mazo);
                    Quantitat = llegir.GetInt32(8);
                }
                //Assigno la llista de cartes recuperada de la base de dades a la de la classe.

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
            return mazos;
        }
    }
}
