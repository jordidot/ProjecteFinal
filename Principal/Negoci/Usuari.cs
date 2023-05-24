using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Usuari
    {
        //Atributs i propietats
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Contrasenya { get; set; }
        public string NomUsuari { get; set; }
        public Mazos Mazos { get; set; }
        public Partides Partides { get; set; }
        public int Punts { get; set; }
        public string ImatgePerfil { get; set; }
        public int EsAdministrador { get; set; }
        //Constructors
        public Usuari(){}
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
