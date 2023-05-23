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
        public void AfegirCarta(Carta carta)
        {
            CartesDB cartesdb = new();
            cartesdb.AfegirCartaBD(carta);
        }
        /// <summary>
        /// Metode per eliminar cartes
        /// </summary>

        public void EliminarCarta(Carta carta)
        {
            CartesDB cartesdb = new();
            cartesdb.EliminarCarta(carta);
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
        public void ModificarCartes(Cartes cartes)
        {
            CartesDB cartesdb = new();
            cartesdb.ModificarCartes(cartes);
        }
        public Cartes RecuperarCartes(Mazo mazo)
        {
            CartesDB cartesdb = new();
            return cartesdb.RecuperarCartes(mazo);
        }
        public Cartes RecuperarTotesCartes()
        {
            CartesDB cartesdb = new();
            return cartesdb.RecuperarTotesCartes();
        }
    }
}
