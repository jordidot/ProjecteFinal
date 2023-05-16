using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Habilitat
    {
        //Atributs
        private int id;
        private int cooldown;
        private int dany;
        private string descripcio;
        private string nom;

        //Constructors
        /// <summary>
        /// Constructor buit.
        /// </summary>
        public Habilitat() { }
        /// <summary>
        /// Constructor ple per emplenar la classe habilitat.
        /// </summary>
        /// <param name="cooldown">Atribut cooldown,que serveix per saber quants cops pots utilitzar una habilitat</param>
        /// <param name="dany">Atribut dany,que serveix per saber quanta vida treus a l'oponent </param>
        /// <param name="descripcio">Atribut descripció,et dona informació sobre quina utitlitat tenen les habilitats</param>
        /// <param name="nom"> Atribut  nom,et dona un nom per posar  a la habilitat </param>
        public Habilitat(int id, int cooldown, int dany, string descripcio, string nom)
        {
            this.id = id;
            this.cooldown = cooldown;
            this.dany = dany;
            this.descripcio = descripcio;
            this.nom = nom;
        }

        //Propietats
        /// <summary>
        /// Propietat de l'atribut id, que serveix per identificar aquesta habilitat.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }

        }
        /// <summary>
        /// Propietat de l'atribut cooldown, que serveix per saber quants cops pots utilitzar una habilitat.
        /// </summary>
        public int Cooldown
        {
            get { return cooldown; }
            set { cooldown = value; }

        }

        /// <summary>
        /// Propietat de l'atribut dany, que serveix per saber quanta vida treus a l'oponent,
        /// </summary>

        public int Dany
        {
            get { return dany; }
            set { dany = value; }

        }

        /// <summary>
        /// Propietat de l'atribut descripció, et dona informació sobre quina utitlitat tenen les habilitats
        /// </summary>
        public string Descripcio
        {
            get { return descripcio; }
            set
            {
                descripcio = value;
            }
        }

        /// <summary>
        /// Propietat de l'altribut nom, et dona un nom per posar  a la habilitat
        /// </summary>

        public string Nom
        { get { return nom; } set { nom = value; } }
    }
}
