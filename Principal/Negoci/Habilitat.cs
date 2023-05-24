using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Habilitat
    {
        //Atributs i propietats
        public int Id { get; set; }
        public int Cooldown { get; set; }
        public int Dany { get; set; }
        public string Descripcio { get; set; }
        public string Nom { get; set; }

        //Constructors
        public Habilitat() 
        {
            this.Id = 0;
            this.Nom = "";
            this.Dany = 0;
            this.Cooldown = 0;
            this.Descripcio = "";
        }
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
