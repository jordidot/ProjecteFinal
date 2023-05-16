using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Carta
    {
        //Atributs
        private int id;
        private string descripcio;
        private string imatge;
        private Habilitats habilitats;
        private string nom;

        //Constructor
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Carta()
        {
            habilitats = new Habilitats();
        }
        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="id">Atribut descrìpcio, id de la carta </param>
        /// <param name="descripcio">Atribut descrìpcio, resum de la carta </param>
        /// <param name="imatge"> Atribut imatge, url de la imatge</param>
        /// <param name="habilitats">Atribut habilitats, provee de la classe habilitats</param>
        /// <param name="nom">Atribut nom, nom de la carta</param>
        public Carta(int id, string nom, string descripcio, string imatge, Habilitats habilitats)
        {
            this.id = id;
            this.descripcio = descripcio;
            this.imatge = imatge;
            this.habilitats = habilitats;
            this.nom = nom;
        }

        //Propietats
        /// <summary>
        /// Propietat id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Propietat descripcio
        /// </summary>
        public string Descripcio
        {
            get { return descripcio; }
            set { descripcio = value; }
        }

        /// <summary>
        /// Propietat Imatge
        /// </summary>
        public string Imatge
        { get { return imatge; } set { imatge = value; } }


        /// <summary>
        /// Propietat de Habilitats
        /// </summary>
        public Habilitats Habilitats
        {

            get { return habilitats; }
            set
            {
                habilitats = value;
            }
        }
        /// <summary>
        /// Propietat del nom
        /// </summary>
        public string Nom

        { get { return nom; } set { nom = value; } }

    }
}
