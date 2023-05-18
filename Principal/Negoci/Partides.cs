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

        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Partides()
        {
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

        public void AfegirPartida()
        {

        }
        /// <summary>
        /// Metode per eliminar partida
        /// </summary>
        public void EliminarPartida()
        {

        }
        /// <summary>
        /// Metode per modificar partida
        /// </summary>
        public void ModificarPartida()
        {

        }
        public Partides RecuperarPartides(Usuari usuari)
        {
            PartidesDB partidesdb = new();
            partidesdb.RecuperarPartides(usuari);
            return partidesdb.RecuperarPartides(usuari);
        }
    }
}
