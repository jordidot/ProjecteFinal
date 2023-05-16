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
        public Bot()
        {
        }

        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="cartes">Atribut cartes, prove de la classe cartes</param>
        /// <param name="imatge"> Atribut imatge, enllaç de la imatge</param>
        /// <param name="nom">Atribut nom, dona un nom al bot</param>
        public Bot(Cartes cartes, string imatge, string nom)
        {
            this.cartes = cartes;
            this.imatge = imatge;
            this.nom = nom;
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
        public void GenerarCartes()
        {
            // Lógica para generar las cartas del bot
        }
        /// <summary>
        /// Metode per generar imatges random
        /// </summary>
        public void GenerarImatge()
        {
            // Lógica para generar la imagen del bot
        }
        /// <summary>
        /// Metode per generar un nom random
        /// </summary>
        public void GenerarNom()
        {
            // Lógica para generar el nombre del bot
        }
    }
}
