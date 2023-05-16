using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Usuaris
    {
        //Atributs
        private List<Usuari> llistausuaris;
        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Usuaris()
        {
            llistausuaris = new List<Usuari>();
        }
        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="llistaUsuaris">LLista dels usuaris</param>
        public Usuaris(List<Usuari> llistaUsuaris)
        {
            llistausuaris = llistaUsuaris;
        }
        /// <summary>
        /// Propietat de l'atribut llista Usuaris
        /// </summary>
        public List<Usuari> Llistausuaris
        {
            get { return llistausuaris; }
            set { llistausuaris = value; }
        }
        //Metodes
        /// <summary>
        /// Metode per afegir usuari
        /// </summary>
        /// <param name="usuari">usuari a afegir</param>
        public void AfegirUsuari(Usuari usuari)
        {

        }
        /// <summary>
        /// Metode per comprovar el nom
        /// </summary>
        /// <param name="usuari">usuari a comprovar</param>
        /// <returns></returns>
        public bool ComprovarNomUsuari(Usuari usuari)
        {
            bool holajordi = true;

            return holajordi;
        }
        /// <summary>
        /// Metode per eliminar usuari
        /// </summary>
        /// <param name="usuari">usuari a eliminar</param>
        public void EliminarUsuari(Usuari usuari)
        {

        }
        /// <summary>
        /// Metode per modificar usuari
        /// </summary>
        /// <param name="usuari">Usuari modificat</param>
        public void ModificarUsuari(Usuari usuari)
        {

        }
        public List<Usuari> RecuperarUsuaris()
        {
            UsuarisDB usuarisdb = new();
            usuarisdb.RecuperarUsuariBD();
            return usuarisdb.Usuaris.Llistausuaris;
        }
    }
}
