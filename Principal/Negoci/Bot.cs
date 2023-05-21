using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Bot
    {
        //Atributs
        private Cartes cartes;
        private string imatge;
        private string nom;

        //Constructors
        /// <summary>
        /// Constructor buit 
        /// </summary>
        public Bot(Cartes cartes)
        {
            //Cada vegada que inicialitzo el Bot li asigno tots els atributs random, el nom, l'imatge i les cartes.
            GenerarNom();
            GenerarImatge();
            GenerarCartes(cartes);
        }
        /// <summary>
        /// Propietat de Cartes
        /// </summary>
        public Cartes Cartes
        {
            get { return cartes; }
            set { cartes = value; }
        }
        /// <summary>
        /// Propietat de imatges
        /// </summary>

        public string Imatge
        {
            get { return imatge; }
            set { imatge = value; }
        }
        /// <summary>
        /// Nom propietat
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        //Metodes
        /// <summary>
        /// Metode per generar cartes random
        /// </summary>
        public void GenerarCartes(Cartes cartes)
        {
            //Creo un random per poder asignar cartes random  a la llista de cartes de l'usuari.
            Random random = new();
            //Per no posar-ho 5 cops faig un bucle.
            for (int i = 0; i < 5; i++)
            {
                this.Cartes.LlistaCartes.Add(cartes.LlistaCartes[random.Next(0, cartes.LlistaCartes.Count)]);
            }

        }
        /// <summary>
        /// Metode per generar imatges random
        /// </summary>
        public void GenerarImatge()
        {
            //Hem optat per una api en web que et genera les imatges random només a través del link.
            this.Imatge = "https://picsum.photos/200/300?random=1";
        }
        /// <summary>
        /// Metode per generar un nom random
        /// </summary>
        public void GenerarNom()
        {
            //Creo una llista i vaig afegint noms.
            List<string> llistaNoms = new List<string>();
            llistaNoms.Add("Eustaquio");
            llistaNoms.Add("Paco No falla");
            llistaNoms.Add("Aitor Menta");
            llistaNoms.Add("Pene Lope");
            llistaNoms.Add("Tommy Nabo");
            llistaNoms.Add("Armando Distancia");
            llistaNoms.Add("Helena Nito");
            llistaNoms.Add("Querry Caverga");
            llistaNoms.Add("Ana Bohueles");
            llistaNoms.Add("Elver Galarga");
            llistaNoms.Add("Debora Melo");
            llistaNoms.Add("Ana Lisa Melano");
            llistaNoms.Add("Jorge Nitales");
            llistaNoms.Add("Elgar Gajo");
            llistaNoms.Add("Lola Mento");
            llistaNoms.Add("Rosa Melano");
            llistaNoms.Add("Edi Ficio");
            llistaNoms.Add("Elton Tito");
            llistaNoms.Add("Belen Jenna");
            llistaNoms.Add("Elvis Teck");
            llistaNoms.Add("Dolores Delano");
            llistaNoms.Add("Debora Teste");
            llistaNoms.Add("Paca Garte");
            //Creo un random per escollir el nom del bot amb un qualsevol de la llista.
            Random random = new();
            //Asigno aquest nom random a el nom del bot.
            this.Nom = llistaNoms[random.Next(0, llistaNoms.Count)];

        }
    }
}
