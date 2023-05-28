using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    /// <summary>
    /// Classe Partides
    /// </summary>
    public class Partides
    {
        //Atributs i propietats
        /// <summary>
        /// Quantitat de partides
        /// </summary>
        public int Quantitat { get; set; }
        /// <summary>
        /// Llista de partides
        /// </summary>
        public List<Partida> LlistaPartides { get; set; }
        /// <summary>
        /// Totes les cartes de Partides
        /// </summary>
        public Cartes TotesCartes { get; set; }
        /// <summary>
        /// Tots els usuaris de Partides
        /// </summary>
        public Usuaris TotsUsuaris { get; set; }
        //Constructors  
        /// <summary>
        /// Constructor Partides
        /// </summary>
        /// <param name="usuaris"></param>
        public Partides(Usuaris usuaris)
        {
            this.TotsUsuaris = usuaris;
            this.TotesCartes = new Cartes();
            this.LlistaPartides = new List<Partida>();
        }
        /// <summary>
        /// Mètode de la classe Partides que crida a la classe PartidesDB per afegir una partida a la base de dades.
        /// </summary>
        /// <param name="cartes">Classe Cartes que conté una llista de Carta amb tota l'informació d'aquestes.</param>
        /// <param name="partida">Classe Partida que conté tota l'informació d'aquesta.</param>
        public void AfegirPartida(Cartes cartes, Partida partida)
        {
            PartidesDB partidesdb = new(cartes,partida,this.TotsUsuaris);
            partidesdb.AfegirPartidaBD(partida);
        }
        /// <summary>
        /// Mètode de la classe Partides que crida a la classe PartidesDB per eliminar una partida a la base de dades.
        /// </summary>
        /// <param name="cartes">Classe Cartes que conté una llista de Carta amb tota l'informació d'aquestes.</param>
        /// <param name="partida">Classe Partida que conté tota l'informació d'aquesta.</param>
        public void EliminarPartida(Cartes cartes, Partida partida)
        {
            PartidesDB partidesdb = new(cartes, partida, this.TotsUsuaris);
            partidesdb.EliminarPartidaBD(partida);
        }
        /// <summary>
        /// Mètode de la classe Partides que crida a la classe PartidesDB per recuperar les partides.
        /// </summary>
        /// <param name="usuari">Classe Usuari que conté tota l'informació d'aquest.</param>
        /// <param name="cartes">Classe Cartes que conté una llista de Carta amb tota l'informació d'aquestes.</param>
        /// <returns></returns>
        public List<Partida> RecuperarPartides(Usuari usuari, Cartes cartes)
        {
            Bot bot = new(TotesCartes);
            Partida partida = new(0,bot,1500,usuari,1500,"Empat");
            PartidesDB partidesdb = new(TotesCartes,partida, this.TotsUsuaris);
            partidesdb.RecuperarPartides(usuari,cartes);
            this.Quantitat = partidesdb.Quantitat;
            return partidesdb.RecuperarPartides(usuari,cartes);
        }
    }
}
