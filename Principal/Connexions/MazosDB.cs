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
        public int Quantitat { get; set; }
        public Mazos Mazos { get; set; }
        public ConnexioDB ConnexioBD { get; set; }
        public Cartes TotesCartes { get; set; }
        //Constructors
        public MazosDB(Cartes cartes)
        {
            this.TotesCartes = cartes;
            ConnexioBD = new ConnexioDB("", "127.0.0.1", "cartesdb", "root");
            Mazos = new Mazos();
        }
        //Metodes
        /// <summary>
        /// Mètode de la classe MazosDB que afegeix un mazo a la base de dades.
        /// </summary>
        /// <param name="mazo">Classe Mazo que conté tota l'informació d'aquest.</param>
        public void AfegirMazoBD(Mazo mazo)
        {
            try
            {
                var comanda = new MySqlCommand("INSERT INTO mazos VALUES(" + mazo.Id + ",'" + mazo.Nom + "'," + mazo.Usuari.Id + "," + mazo.Cartes.LlistaCartes[0].Id + "," + mazo.Cartes.LlistaCartes[1].Id + "," + mazo.Cartes.LlistaCartes[2].Id + "," + mazo.Cartes.LlistaCartes[3].Id + "," + mazo.Cartes.LlistaCartes[4].Id + ");", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir el mazo." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }


        }
        /// <summary>
        /// Mètode de la classe MazosDB que eliminar un mazo a la base de dades per l'id de l'usuari.
        /// </summary>
        /// <param name="usuari">Classe Usuari que conté informació d'aquest.</param>
        public void EliminarMazoUsuariBD(Usuari usuari)
        {
            try
            {
                var comanda = new MySqlCommand("DELETE FROM mazos WHERE id_usuari=" + usuari.Id + ";", ConnexioBD.Connectar());
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
        /// Mètode de la classe MazosDB que eliminar un mazo a la base de dades per l'id del mazo.
        /// </summary>
        /// <param name="usuari">Classe Mazo que conté informació d'aquest.</param>
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
        /// Mètode de la classe MazosDB que recupera el mazo d'un Usuari.
        /// </summary>
        /// <param name="usuari">Classe Usuari que conté les dades d'aquest.</param>
        /// <returns>Retorn un classe Mazo amb l'informació d'aquest.</returns>
        public Mazos RecuperarMazos(Usuari usuari)
        {
            Mazos mazos = new();
            try
            {

                //Obro amb el using i realitzo la query passant-li la connexio i tanco un cop llegit.
                var comanda = new MySqlCommand("SELECT *,(SELECT count(*) FROM mazos) FROM mazos WHERE id_usuari =" + usuari.Id + ";", ConnexioBD.Connectar());
                //Executo la query i guardo totes les dades en un MySqlDataReader.
                var llegir = comanda.ExecuteReader();
                //Començo bucle per anar recuperant els camps de cada fila.
                while (llegir.Read())
                {
                    //Creo Cartes per poder afegir-li al Mazo.
                    Cartes cartes = new Cartes();
                    cartes.LlistaCartes.Add(TotesCartes.LlistaCartes[llegir.GetInt32(3) - 1]);
                    cartes.LlistaCartes.Add(TotesCartes.LlistaCartes[llegir.GetInt32(4) - 1]);
                    cartes.LlistaCartes.Add(TotesCartes.LlistaCartes[llegir.GetInt32(5) - 1]);
                    cartes.LlistaCartes.Add(TotesCartes.LlistaCartes[llegir.GetInt32(6) - 1]);
                    cartes.LlistaCartes.Add(TotesCartes.LlistaCartes[llegir.GetInt32(7) - 1]);

                    Mazo mazo = new Mazo(llegir.GetInt32(0), cartes, llegir.GetString(1), usuari);;
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
                MySqlConnection.ClearAllPools();
            }
            return mazos;
        }
    }
}
