using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Principal.Negoci
{
    public class Mazos
    {
        //Atributs i propietats
        public List<Mazo> LlistaMazos { get; set; }
        public Cartes TotesCartes { get; set; }
        //Constructors
        public Mazos()
        {
            this.LlistaMazos = new List<Mazo>();
        }
        public Mazos(List<Mazo> llistaMazos)
        {
            this.LlistaMazos = llistaMazos;
        }
        //Metodes
        /// <summary>
        /// Mètode de la classe Mazos que comprova si l'usuari té el mateix mazo i si el nom del mazo es correcte si es així crida a la classe MazosDB per afegir el mazo a la base de dades.
        /// </summary>
        /// <param name="usuari">Classe Usuari amb l'informació d'aquest.</param>
        /// <param name="m">Classe Mazo amb l'informació d'aquest.</param>
        public void AfegirMazoBD(Usuari usuari, Mazo m)
        {
            string nomvalidar = m.Nom;
            bool mazoTrobada = false;
            bool nomvalid = true;

            //Aquest foreach recorre la llista de mazos de la base de dades, per buscar si el mazo existeix.
            if (usuari.Mazos.LlistaMazos.Contains(m)) mazoTrobada = true;
            if (mazoTrobada) MessageBox.Show("No es pot afegir aquest mazo.");
            else
            {
                for (int i = 0; i < nomvalidar.Length; i++)
                    if (i > 16) nomvalid = false;
                if (nomvalid)
                {
                    MazosDB mazosdb = new(this.TotesCartes);
                    mazosdb.AfegirMazoBD(m);
                }

            }
        }
        /// <summary>
        /// Mètode de la classe Mazos que crida a la classe MazosDb per eliminar un mazo.
        /// </summary>
        /// <param name="mazo">Classe Mazo amb l'informació d'aquest.</param>
        public void EliminarMazo(Mazo mazo)
        {
            try
            {
                MazosDB mazosdb = new(this.TotesCartes);
                mazosdb.EliminarMazoBD(mazo);
            }catch(Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar el mazo.");
            }


        }
        /// <summary>
        /// Mètode de la classe Mazos que crida a la classe MazosDB per saber la quantitat que hi ha a la base de dades.        
        /// </summary>
        /// <returns>Retorna un integer amb la quantitat de mazos.</returns>
        public int RecuperaQuantitat()
        {
            MazosDB mazos = new(this.TotesCartes);
            return mazos.Quantitat;
        }
        /// <summary>
        /// Mètode de la classe Mazos que crida a la classe MazosDB per recuperar tots els mazos.
        /// </summary>
        /// <param name="usuari">Classe Usuariq que conté ifnromació d'aquest.</param>
        /// <param name="cartes">Classe Cartes que conté una llista amb totes les cartes.</param>
        /// <returns>Retorna una classe Mazos amb el Mazo de l'usuari.</returns>
        public Mazos RecuperarMazos(Usuari usuari,Cartes cartes)
        {
            MazosDB mazosdb = new(cartes);
            return mazosdb.RecuperarMazos(usuari);
        }
    }
}
