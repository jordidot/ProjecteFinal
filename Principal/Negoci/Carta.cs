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
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Imatge { get; set; }
        public string Descripcio { get; set; }
        public Habilitats Habilitats { get; set; }

        //Constructor
        public Carta()
        {
            this.Id = 0;
            this.Nom = "";
            this.Imatge = "";
            this.Descripcio = "";
            Habilitats = new Habilitats();
        }
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
