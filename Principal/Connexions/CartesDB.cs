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
    public class CartesDB
    {
        //Atributs
        private Cartes cartes;
        private ConnexioDB connexioBD;

        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public CartesDB()
        {
            connexioBD = new ConnexioDB("", "localhost", "cartesdb", "root");
            cartes = new Cartes();
        }
        /// <summary>
        /// Propietat de cartes.
        /// </summary>
        public Cartes Cartes { get { return cartes; } set { this.cartes = value; } }
        /// <summary>
        /// Propietat de connexioBD.
        /// </summary>
        public ConnexioDB ConnexioBD { get { return connexioBD; } set { this.connexioBD = value; } }


        //Mètodes
        public void AfegirCartaBD(Carta carta)
        {
            cartes.LlistaCartes.Add(carta);
        }

        public Cartes RecuperarCartes(Mazo mazo)
        {
            Cartes cartes = new();
            try
            {
                //Obro amb el using i realitzo la query passant-li la connexio i tanco un cop llegit.
                var comanda = new MySqlCommand("SELECT * FROM cartes;", ConnexioBD.Connectar());
                //Executo la query i guardo totes les dades en un MySqlDataReader.
                var llegir = comanda.ExecuteReader();
                //Començo bucle per anar recuperant els camps de cada fila.
                while (llegir.Read())
                {
                    HabilitatsDB habilitats  = new();
                    //Creo la carta i li passo tots els parametres.
                    Carta carta = new(llegir.GetInt32(0), llegir.GetString(1), llegir.GetString(2), llegir.GetString(3), habilitats.Habilitats);
                    carta.Habilitats = habilitats.RecuperarHabilitats(carta);
                    //Afegeixo la carta a la llista de cartes.
                    cartes.LlistaCartes.Add(carta);

                }
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
            return cartes;
        }
        public Cartes RecuperarTotesCartes()
        {
            Cartes cartes = new();
            try
            {
                //Obro amb el using i realitzo la query passant-li la connexio i tanco un cop llegit.
                var comanda = new MySqlCommand("SELECT * FROM cartes;", ConnexioBD.Connectar());
                //Executo la query i guardo totes les dades en un MySqlDataReader.
                var llegir = comanda.ExecuteReader();
                //Començo bucle per anar recuperant els camps de cada fila.
                while (llegir.Read())
                {
                    HabilitatsDB habilitats = new();
                    //Creo la carta i li passo tots els parametres.
                    Carta carta = new(llegir.GetInt32(0), llegir.GetString(1), llegir.GetString(2), llegir.GetString(3), habilitats.Habilitats);
                    carta.Habilitats = habilitats.RecuperarHabilitats(carta);
                    //Afegeixo la carta a la llista de cartes.
                    cartes.LlistaCartes.Add(carta);

                }
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
            return cartes;
        }
    }
}
