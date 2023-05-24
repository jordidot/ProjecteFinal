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
        public List<Carta> LlistaCartes { get; set; }

        //Constructors
        public Cartes()
        {
            this.LlistaCartes = new List<Carta>();
        }
        public Cartes(List<Carta> llistacartes)
        {
            this.LlistaCartes = llistacartes;
        }
        //Metodes
        /// <summary>
        /// Mètode de la classe Cartes que crida a la classe CartesDb per afegir una carta.
        /// </summary>
        /// <param name="carta">Classe Carta que rep l'informació d'aquesta.</param>
        public void AfegirCarta(Carta carta)
        {
            CartesDB cartesdb = new();
            cartesdb.AfegirCartaBD(carta);
        }
        /// <summary>
        /// Mètode de la classe Cartes que crida a la classe CartesDb per eliminar una carta.
        /// </summary>
        /// <param name="carta">Classe Carta que rep l'informació d'aquesta.</param>
        public void EliminarCarta(Carta carta)
        {
            CartesDB cartesdb = new();
            cartesdb.EliminarCarta(carta);
        }
        /// <summary>
        /// Mètode de la classe Cartes que crida a la classe CartesDb per modificar unes cartes.
        /// </summary>
        /// <param name="cartes">Classe Cartes que rep una llista amb l'informació d'aquestes.</param>
        public void ModificarCartes(Cartes cartes)
        {
            CartesDB cartesdb = new();
            cartesdb.ModificarCartes(cartes);
        }
        /// <summary>
        /// Mètode de la classe Cartes que crida a la classe CartesDb per recuperar totes les cartes.
        /// </summary>
        /// <returns>Retorna una classe Cartes amb una llista de totes les cartes recuperades de la BD.</returns>
        public Cartes RecuperarTotesCartes()
        {
            CartesDB cartesdb = new();
            return cartesdb.RecuperarTotesCartes();
        }
    }
}
