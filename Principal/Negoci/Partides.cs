using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Partides
    {
        //Atribut
        private List<Partida> llistaPartides;
        public Cartes TotesCartes { get; set; }
        public int Quantitat { get; set; }
        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Partides()
        {
            TotesCartes = new Cartes();
            llistaPartides = new List<Partida>();
        }
        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="llistapartides">LLista partides on es guarden partides</param>
        public Partides(List<Partida> llistapartides)
        {
            llistaPartides = llistapartides;
        }

        //Propietats
        /// <summary>
        /// Propietat del atribut llistapartides
        /// </summary>
        public List<Partida> LlistaPartides
        {
            get { return llistaPartides; }
            set { llistaPartides = value; }
        }
        /// <summary>
        /// Metode per afegir partida
        /// </summary>

        public void AfegirPartida(Cartes cartes, Partida partida)
        {
            PartidesDB partidesdb = new(cartes,partida);
            partidesdb.AfegirPartidaBD(partida);
        }
        /// <summary>
        /// Metode per eliminar partida
        /// </summary>
        public void EliminarPartida(Cartes cartes, Partida partida)
        {
            PartidesDB partidesdb = new(cartes, partida);
            partidesdb.EliminarPartidaBD(partida);
        }
        /// <summary>
        /// Metode per modificar partida
        /// </summary>
        public void ModificarPartida()
        {

        }
        public List<Partida> RecuperarPartides(Usuari usuari, Cartes cartes)
        {
            Bot bot = new(TotesCartes);
            Partida partida = new(0,bot,1500,usuari,1500,"Empat");
            PartidesDB partidesdb = new(TotesCartes,partida);
            partidesdb.RecuperarPartides(usuari,cartes);
            this.Quantitat = partidesdb.Quantitat;
            return partidesdb.RecuperarPartides(usuari, cartes);
        }
    }
}
