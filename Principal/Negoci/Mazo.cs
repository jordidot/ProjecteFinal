using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Mazo
    {
        //Atributs

        public int id;
        public Cartes cartes;
        public string nom;
        public Usuari usuari;

        //Constructor
        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="cartes">Atribut cartes,prove de la classe cartes</param>
        /// <param name="nom">Atribut nom, nom del mazo</param>
        /// <param name="usuari">Atribut usuari,prove de la classe usuari</param>

        public Mazo(Cartes cartes, string nom, Usuari usuari, int id)
        {
            cartes = new Cartes();
        }

        public Mazo(int id, Cartes cartes, string nom, Usuari usuari)
        {
            this.id = id;
            this.cartes = cartes;
            this.nom = nom;
            this.usuari = usuari;
        }
        //Propietats
        /// <summary>
        /// Propietat de l'atribut id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }

        }
        /// <summary>
        /// Propietat de l'atribut llistacartes
        /// </summary>
        public Cartes Cartes
        {
            get { return cartes; }
            set { cartes = value; }

        }
        /// <summary>
        /// propietat de l'atribut usuari
        /// </summary>
        public Usuari Usuari
        {
            get { return usuari; }
            set { usuari = value; }



        }
        /// <summary>
        /// propietat de l'atribut nom
        /// </summary>
        public string Nom
        { get { return nom; } set { nom = value; } }

    }
}
