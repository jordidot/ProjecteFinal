using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Principal.Negoci
{
    public class Cartes
    {
        //Atributs
        private List<Carta> llistacartes;

        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Cartes()
        {
            this.llistacartes = new List<Carta>();
        }

        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="llistacartes">LLista del atribut per emplenar les cartes</param>
        public Cartes(List<Carta> llistacartes)
        {
            this.llistacartes = llistacartes;

        }
        //Propietat
        /// <summary>
        /// Propietat de la Cartes
        /// </summary>
        public List<Carta> LlistaCartes
        {
            get { return llistacartes; }
            set { llistacartes = value; }
        }
        //Metodes

        /// <summary>
        /// Metode per afegir cartes
        /// </summary>
        public void AfegirCarta(Carta c)
        {
            CartesDB cartesbd = new CartesDB();
            bool cartaTrobada = false;
            cartesbd.RecuperarCartes();
            foreach (Carta carta in cartesbd.Cartes.LlistaCartes)
            {
                if (c.Id == carta.Id)
                    cartaTrobada = true;
            }

            if (cartaTrobada)
            {
                MessageBox.Show("L'id es el mateix, no es pot afegir.");
            }
            else
                llistacartes.Add(c);

        }
        /// <summary>
        /// Metode per eliminar cartes
        /// </summary>

        public void EliminarCarta(Carta c)
        {

            CartesDB cartesbd = new CartesDB();
            bool cartaTrobada = false;
            cartesbd.RecuperarCartes();
            foreach (Carta carta in cartesbd.Cartes.LlistaCartes)
            {
                if (c.Id != carta.Id)
                    cartaTrobada = true;
            }

            if (cartaTrobada)
            {
                MessageBox.Show("No s'ha trobat l'id, no es pot afegir.");
            }
            else llistacartes.Remove(c);

        }
        /// <summary>
        /// Metode per modificar cartes
        /// </summary>
        public void ModificarCarta(Carta cartaanterior, Carta cartanova)
        {
            CartesDB cartesDB = new CartesDB();
            bool cartesbd = false;
            int index = llistacartes.FindIndex(carta => carta.Equals(cartaanterior));
            if (index != -1)
            {
                foreach (Carta carta in cartesDB.Cartes.LlistaCartes)
                {
                    if (cartanova.Id == carta.Id)
                        cartesbd = true;
                }
                if (cartesbd)
                {
                    MessageBox.Show("L'id es el mateix, no es pot afegir.");
                }
                else
                    llistacartes[index] = cartanova;
            }

        }

        public List<Carta> RecuperarCartes()
        {
            CartesDB cartesdb = new();
            cartesdb.RecuperarCartes();
            return cartesdb.Cartes.LlistaCartes;
        }
    }
}
