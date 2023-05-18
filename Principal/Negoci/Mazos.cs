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
        //Atributs
        private List<Mazo> llistaMazos;

        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Mazos()
        {
            llistaMazos = new List<Mazo>();
        }
        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="llistaMazos">LLista per emplenar els mazos guardats</param>
        public Mazos(List<Mazo> llistaMazos)
        {
            this.llistaMazos = llistaMazos;
        }
        //Propietat
        /// <summary>
        /// Propietat de mazos
        /// </summary>
        public List<Mazo> LlistaMazos
        {
            get { return llistaMazos; }
            set { llistaMazos = value; }
        }
        //Metodes
        /// <summary>
        ///Metode per afegir mazos
        /// </summary>
        public void AfegirMazoBD(Usuari usuari, Mazo m)
        {
            string nomvalidar = m.Nom;
            bool mazoTrobada = false;
            bool nomvalid = true;

            //Aquest foreach recorre la llista de mazos de la base de dades, per buscar si el
            if (usuari.Mazos.LlistaMazos.Contains(m)) mazoTrobada = true;
            if (mazoTrobada) MessageBox.Show("No es pot afegir aquest mazo.");
            else
            {
                for (int i = 0; i < nomvalidar.Length; i++)
                    if (i > 16) nomvalid = false;

                if (nomvalid)
                {
                    MazosDB mazosdb = new();
                    mazosdb.AfegirMazoBD(m);
                }

            }
        }
        /// <summary>
        /// Metode per eliminar mazo
        /// </summary>
        public void EliminarMazo(Mazo mazo)
        {
            try
            {
                MazosDB mazosdb = new();
                mazosdb.EliminarMazoBD(mazo);
            }catch(Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar el mazo.");
            }


        }
        /// <summary>
        /// Metode per Modificar mazo
        /// </summary>
        public void ModificarMazo()
        {


        }
        public int RecuperarId()
        {
            MazosDB mazos = new();
            return mazos.Quantitat;
        }
        public Mazos RecuperarMazos(Usuari usuari)
        {
            MazosDB mazosdb = new();
            return mazosdb.RecuperarMazos(usuari);
        }
    }
}
