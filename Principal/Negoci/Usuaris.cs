using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    /// <summary>
    /// Classe Usuaris
    /// </summary>
    public class Usuaris
    {
        //Atributs
        /// <summary>
        /// LLista Usuaris
        /// </summary>
        public List<Usuari> Llistausuaris { get; set; }
        /// <summary>
        /// Quantitat Usuaris
        /// </summary>
        public int QuantitatUsuaris { get; set; }
        //Constructors
        /// <summary>
        /// Constructor Usuaris buit.
        /// </summary>
        public Usuaris()
        {
            Llistausuaris = new List<Usuari>();
        }
        /// <summary>
        /// Constructor Usuaris ple.
        /// </summary>
        /// <param name="llistaUsuaris"></param>
        public Usuaris(List<Usuari> llistaUsuaris)
        {
            Llistausuaris = llistaUsuaris;
        }
        //Metodes
        /// <summary>
        /// Mètode de la classe Usuaris que crida a la classe UsuarisDB per poder afegir un usuari.
        /// </summary>
        /// <param name="usuari">Classe Usuari que conté l'informació d'aquest.</param>
        public void AfegirUsuari(Usuari usuari)
        {
            UsuarisDB usuarisdb = new();
            usuarisdb.AfegirUsuariBD(usuari);
        }
        /// <summary>
        /// Mètode de la classe Usuaris que crida a la classe UsuarisDB per poder afegir molts usuaris.
        /// </summary>
        /// <param name="usuaris">Classe Usuaris que conté una llista d'Usuari amb l'informació d'aquests.</param>
        public void AfegirUsuaris(Usuaris usuaris)
        {
            UsuarisDB usuarisdb = new();
            usuarisdb.AfegirUsuarisBD(usuaris);
        }
        /// <summary>
        /// Mètode de la classe Usuaris que crida a la classe UsuarisDB per poder eliminar un usuari.
        /// </summary>
        /// <param name="usuari">Classe Usuari que conté l'informació d'aquest.</param>
        public void EliminarUsuari(Usuari usuari)
        {
            UsuarisDB usuarisdb = new();
            usuarisdb.EliminarUsuari(usuari);
        }
        /// <summary>
        /// Mètode de la classe Usuaris que crida a la classe UsuarisDB per poder modificar un usuari.
        /// </summary>
        /// <param name="usuari">Classe Usuari que conté l'informació d'aquest.</param>
        public void ModificarUsuari(Usuari usuari)
        {
            UsuarisDB usuarisdb = new();
            usuarisdb.ModificarUsuari(usuari);
        }
        /// <summary>
        /// Mètode de la classe Usuaris que crida a la classe UsuarisDB per poder recuperar usuaris de la base de dades.
        /// </summary>
        /// <returns>Retorna una llista d'Usuari amb tots l'informació d'aquests.</returns>
        public List<Usuari> RecuperarUsuaris()
        {
            UsuarisDB usuarisdb = new();
            usuarisdb.RecuperarUsuariBD();
            QuantitatUsuaris = usuarisdb.QuantitatTotal;
            return usuarisdb.Usuaris.Llistausuaris;
        }
    }
}
