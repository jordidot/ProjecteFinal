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

        public void RecuperarCartes()
        {
            List<Carta> cartes = new List<Carta>();
            try
            {
                //Obro amb el using i realitzo la query passant-li la connexio i tanco un cop llegit.
                var comanda = new MySqlCommand("SELECT * FROM cartes;", ConnexioBD.Connectar());
                //Executo la query i guardo totes les dades en un MySqlDataReader.

                var llegir = comanda.ExecuteReader();
                //Començo bucle per anar recuperant els camps de cada fila.
                while (llegir.Read())
                {
                    //Creo habilitats pero poder afegir-li a Carta.
                    Habilitats habilitats = new Habilitats();
                    //Busco les habilitats que hi han a la base de dades.
                    HabilitatsDB habilitatsBD = new HabilitatsDB();
                    habilitatsBD.RecuperarHabilitats();
                    //Recorro aquestes habilitats i vaig afegint-les a la llista habilitats que li passaré a la carta.
                    foreach (Habilitat h in habilitatsBD.Habilitats.LListahabilitats)
                    {
                        if (h.Id == llegir.GetInt32(4)) habilitats.LListahabilitats.Add(h);
                    }
                    foreach (Habilitat h in habilitatsBD.Habilitats.LListahabilitats)
                    {
                        if (h.Id == llegir.GetInt32(5)) habilitats.LListahabilitats.Add(h);
                    }
                    foreach (Habilitat h in habilitatsBD.Habilitats.LListahabilitats)
                    {
                        if (h.Id == llegir.GetInt32(6)) habilitats.LListahabilitats.Add(h);
                    }
                    foreach (Habilitat h in habilitatsBD.Habilitats.LListahabilitats)
                    {
                        if (h.Id == llegir.GetInt32(7)) habilitats.LListahabilitats.Add(h);
                    }

                    //Creo la carta i li passo tots els parametres.
                    Carta carta = new(llegir.GetInt32(0), llegir.GetString(1), llegir.GetString(2), llegir.GetString(3), habilitats);
                    //Afegeixo la carta a la llista de cartes.
                    cartes.Add(carta);

                }
                //Assigno la llista de cartes recuperada de la base de dades a la de la classe.
                Cartes.LlistaCartes = cartes;

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
