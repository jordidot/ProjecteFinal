using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    /// <summary>
    /// Classe Mazo
    /// </summary>
    public class Mazo
    {
        //Atributs i propietats
        /// <summary>
        /// Id del mazo
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nom del mazo
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Llista de Cartes Mazo
        /// </summary>
        public Cartes Cartes { get; set; }
        /// <summary>
        /// Usuari dle Mazo
        /// </summary>
        public Usuari Usuari { get; set; }

        //Constructor
        /// <summary>
        /// Constructor Mazo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cartes"></param>
        /// <param name="nom"></param>
        /// <param name="usuari"></param>
        public Mazo(int id, Cartes cartes, string nom, Usuari usuari)
        {
            this.Id = id;
            this.Cartes = cartes;
            this.Nom = nom;
            this.Usuari = usuari;
        }

    }
}
