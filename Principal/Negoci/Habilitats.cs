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
        public void Afegir(Habilitat h)
        {
            HabilitatsDB habilitatsdb = new HabilitatsDB();
            bool habilitatTrobada = false;
            habilitatsdb.RecuperarHabilitats();
            foreach (Habilitat habilitat in habilitatsdb.Habilitats.LListahabilitats)
            {
                if (h.Id == habilitat.Id)
                    habilitatTrobada = true;
            }

            if (habilitatTrobada)
            {
                MessageBox.Show("L'id es el mateix, no es pot afegir.");
            }
            else
                llistahabilitats.Add(h);

        }
        /// <summary>
        /// Metode per eliminar habilitats de la llista
        /// </summary>
        /// <param name="habilitat">Parametre per eliminar la llista</param>
        public void Eliminar(Habilitat habilitat)
        {
            HabilitatsDB habilitatsbd = new HabilitatsDB();
            bool habilitatTrobada = false;
            habilitatsbd.RecuperarHabilitats();
            foreach (Habilitat h in habilitatsbd.Habilitats.LListahabilitats)
            {
                if (habilitat.Id != h.Id)
                    habilitatTrobada = true;
            }

            if (habilitatTrobada)
            {
                MessageBox.Show("No s'ha trobat l'id, no es pot afegir.");
            }
            else llistahabilitats.Remove(habilitat);
        }
        /// <summary>
        /// Metode per modificar habilitats de la llista
        /// </summary>
        /// <param name="habilitat">Parametre per modificar la llista</param>
        public void Modificar(Habilitat habilitatanterior, Habilitat habilitatnova)
        {
            HabilitatsDB habilitatsdb = new HabilitatsDB();
            bool habilitatTrobada = false;

            int index = llistahabilitats.FindIndex(carta => carta.Equals(habilitatanterior));
            if (index != -1)
            {
                foreach (Habilitat habilitat in habilitatsdb.Habilitats.LListahabilitats)
                {
                    if (habilitatnova.Id == habilitat.Id)
                        habilitatTrobada = true;
                }
                if (habilitatTrobada)
                {
                    MessageBox.Show("L'id es el mateix, no es pot afegir.");
                }
                else
                    llistahabilitats[index] = habilitatnova;
            }
        }
        public List<Habilitat> RecuperarHabilitats()
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.RecuperarHabilitats();
            return habilitatsdb.Habilitats.LListahabilitats;
        }
    }
}
