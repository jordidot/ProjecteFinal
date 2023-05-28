using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Principal.Negoci
{/// <summary>
/// Classe Usuari
/// </summary>
    public class Usuari
    {
        //Atributs i propietats
        /// <summary>
        /// Id usuari
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Alias de l'Usuari
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Contrasenya de l'Usuari
        /// </summary>
        public string Contrasenya { get; set; }
        /// <summary>
        /// Nom de compte Usuari
        /// </summary>
        public string NomUsuari { get; set; }
        /// <summary>
        /// Cartes de l'Usuari
        /// </summary>
        public Mazos Mazos { get; set; }
        /// <summary>
        /// Partides de l'Usuari
        /// </summary>
        public Partides Partides { get; set; }
        /// <summary>
        /// Punts de l'Usuari.
        /// </summary>
        public int Punts { get; set; }
        /// <summary>
        /// Imatge de l'Usuari
        /// </summary>
        public string ImatgePerfil { get; set; }
        /// <summary>
        /// Es administrador de l'Usuari.
        /// </summary>
        public int EsAdministrador { get; set; }
        //Constructors
        /// <summary>
        /// Constructor buit de Usuari.
        /// </summary>
        public Usuari()
        {
            this.Id = 0;
            this.Alias = "";
            this.Contrasenya = "";
            this.NomUsuari = "";
            this.Mazos = new();
            this.Punts = 0;
            this.ImatgePerfil = "";
            this.EsAdministrador = 0;
            Usuaris usuaris = new Usuaris();
            this.Partides = new(usuaris);
        }
        /// <summary>
        /// Constructor Usuari ple.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alias"></param>
        /// <param name="contrasenya"></param>
        /// <param name="nomUsuari"></param>
        /// <param name="mazos"></param>
        /// <param name="partides"></param>
        /// <param name="punts"></param>
        /// <param name="imatgePerfil"></param>
        /// <param name="esAdministrador"></param>
        public Usuari(int id, string alias, string contrasenya, string nomUsuari, Mazos mazos, Partides partides, int punts, string imatgePerfil, int esAdministrador)
        {
            this.Id = id;
            this.Alias = alias;
            this.Contrasenya = contrasenya;
            this.NomUsuari = nomUsuari;
            this.Mazos = mazos;
            this.Partides = partides;
            this.Punts = punts;
            this.ImatgePerfil = imatgePerfil;
            this.EsAdministrador = esAdministrador;
        }
        //Metodes
        /// <summary>
        /// Mètode de la classe Usuari que crida a la classe UsuarisDB per canviar l'imatge del usuari.
        /// </summary>
        /// <param name="usuari">Classe Usuari que conté l'informació d'aquest.</param>
        public void CambiarImatge(Usuari usuari)
        {
            UsuarisDB usuaris = new();
            usuaris.CanviarImatge(usuari);
        }
    }
}
