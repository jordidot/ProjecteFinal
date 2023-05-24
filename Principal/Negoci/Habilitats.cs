using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Principal.Negoci
{
    public class Habilitats
    {
        //Atributs
        private List<Habilitat> llistahabilitats;
        //Constructors
        /// <summary>
        /// Creacio de contructor buit per emplenar habilitats
        /// </summary>
        public Habilitats()
        {
            llistahabilitats = new List<Habilitat>();

        }
        /// <summary>
        /// Creacio de contructor ple per emplenar habilitats
        /// </summary>
        /// <param name="list">Paramatra per emplenar la llista </param>
        public Habilitats(List<Habilitat> list)
        {
            this.llistahabilitats = list;
        }

        //Propietats 
        /// <summary>
        /// Crreacio de propietats llistahabilitats , per tenir una llista de habilitats
        /// </summary>
        public List<Habilitat> LListahabilitats
        {
            get { return llistahabilitats; }


            set { llistahabilitats = value; }

        }

        //Metodes 

        /// <summary>
        /// Metode per afegir habilitats a la llista
        /// </summary>
        /// <param name="habilitat">Parametre de la llista habilitats </param>
        public void AfegirHabilitat(Habilitat habilitat)
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.AfegirHabilitatBD(habilitat);

        }
        /// <summary>
        /// Metode per eliminar habilitats de la llista
        /// </summary>
        /// <param name="habilitat">Parametre per eliminar la llista</param>
        public void EliminarHabilitat(Habilitat habilitat)
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.EliminarHabilitatBD(habilitat);
        }
        /// <summary>
        /// Metode per modificar habilitats de la llista
        /// </summary>
        /// <param name="habilitat">Parametre per modificar la llista</param>
        public void ModificarHabilitats(Habilitats habilitats)
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.ModificarHabilitats(habilitats);
        }
        public List<Habilitat> RecuperarHabilitats(Carta carta)
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.RecuperarHabilitats(carta);
            return habilitatsdb.Habilitats.LListahabilitats;
        }
    }
}
