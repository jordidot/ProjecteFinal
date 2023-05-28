using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    /// <summary>
    /// Classe Carta
    /// </summary>
    public class Carta
    {
        //Atributs
        /// <summary>
        /// Id de la carta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nom de la carta
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Imatge de la carta
        /// </summary>
        public string Imatge { get; set; }
        /// <summary>
        /// Descripcio de la carta
        /// </summary>
        public string Descripcio { get; set; }
        /// <summary>
        /// Llista d'habilitats de la carta.
        /// </summary>
        public Habilitats Habilitats { get; set; }

        //Constructor
        /// <summary>
        /// Constructor Carta
        /// </summary>
        public Carta()
        {
            this.Id = 0;
            this.Nom = "";
            this.Imatge = "";
            this.Descripcio = "";
            Habilitats = new Habilitats();
        }
        /// <summary>
        /// Constructor Carta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="descripcio"></param>
        /// <param name="imatge"></param>
        /// <param name="habilitats"></param>
        public Carta(int id, string nom, string descripcio, string imatge, Habilitats habilitats)
        {
            this.Id = id;
            this.Nom = nom;
            this.Imatge = imatge;
            this.Descripcio = descripcio;
            this.Habilitats = habilitats;
        }
    }
}
