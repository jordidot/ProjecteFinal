using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    /// <summary>
    /// Classe Habilitat
    /// </summary>
    public class Habilitat
    {
        //Atributs i propietats
        /// <summary>
        /// Id de l'habilitat
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Cooldown de l'habilitat
        /// </summary>
        public int Cooldown { get; set; }
        /// <summary>
        /// Dany de l'habilitat
        /// </summary>
        public int Dany { get; set; }
        /// <summary>
        /// Descripcio de l'habilitat
        /// </summary>
        public string Descripcio { get; set; }
        /// <summary>
        /// Nom de l'habilitat
        /// </summary>
        public string Nom { get; set; }

        //Constructors
        /// <summary>
        /// Constructor Habilitat
        /// </summary>
        public Habilitat() 
        {
            this.Id = 0;
            this.Nom = "";
            this.Dany = 0;
            this.Cooldown = 0;
            this.Descripcio = "";
        }
        /// <summary>
        /// Constructor Habilitat
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cooldown"></param>
        /// <param name="dany"></param>
        /// <param name="descripcio"></param>
        /// <param name="nom"></param>
        public Habilitat(int id, int cooldown, int dany, string descripcio, string nom)
        {
            this.Id = id;
            this.Nom = nom;
            this.Dany = dany;
            this.Cooldown = cooldown;
            this.Descripcio = descripcio;
        }
    }
}
