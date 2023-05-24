using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Mazo
    {
        //Atributs i propietats

        public int Id { get; set; }
        public string Nom { get; set; }
        public Cartes Cartes { get; set; }
        public Usuari Usuari { get; set; }

        //Constructor
        public Mazo(int id, Cartes cartes, string nom, Usuari usuari)
        {
            this.Id = id;
            this.Cartes = cartes;
            this.Nom = nom;
            this.Usuari = usuari;
        }

    }
}
