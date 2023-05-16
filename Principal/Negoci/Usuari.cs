using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Usuari
    {
        //Atributs
        private int id;
        private string alias;
        private string contrasenya;
        private string nomUsuari;
        private Mazos mazos;
        private Partides partides;
        private int punts;
        private string imatgePerfil;
        private int esAdministrador;

        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Usuari()
        {

        }
        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="alias">Atribut alias, dona un alies el teu usuari</param>
        /// <param name="contrasenya">Atribut contrasenya, dona una contrasenya al teu usuari</param>
        /// <param name="nomUsuari"> Atribut nomusuari, dona el teu nom</param>
        /// <param name="mazos"> Atribut mazos, prove de la classe mazos</param>
        /// <param name="partides">Atribut partides, prove de la classe partides</param>
        /// <param name="punts">Atribut punts, senyala els punts que tens</param>
        /// <param name="imatgePerfil">Atribut imatgeperfil, enllaç de la imatge de perfil</param>
        /// <param name="esAdministrador">Atribut esadministrador, indica si ets admin</param>
        public Usuari(int id, string alias, string contrasenya, string nomUsuari, Mazos mazos, Partides partides, int punts, string imatgePerfil, int esAdministrador)
        {
            this.id = id;
            this.alias = alias;
            this.contrasenya = contrasenya;
            this.nomUsuari = nomUsuari;
            this.mazos = mazos;
            this.partides = partides;
            this.punts = punts;
            this.imatgePerfil = imatgePerfil;
            this.esAdministrador = esAdministrador;
        }
        //Propietat
        /// <summary>
        /// Propietat de l'atribut id
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        /// <summary>
        /// Propietat de l'atribut alies
        /// </summary>
        public string Alias
        {
            get { return alias; }
            set { alias = value; }
        }
        /// <summary>
        /// Propietat de l'atribut Contrasenya
        /// </summary>
        public string Contrasenya
        {
            get { return contrasenya; }
            set { contrasenya = value; }
        }
        /// <summary>
        /// Propietat de l'atribut nomusuari
        /// </summary>
        public string NomUsuari
        {
            get { return nomUsuari; }
            set { nomUsuari = value; }
        }
        /// <summary>
        /// Propietat de l'atribut mazos
        /// </summary>
        public Mazos Mazos
        {
            get { return mazos; }
            set { mazos = value; }
        }
        /// <summary>
        /// Propietat de l'atribut partides
        /// </summary>
        public Partides Partides
        {
            get { return partides; }
            set { partides = value; }
        }
        /// <summary>
        /// Propietat de l'atribut punts
        /// </summary>
        public int Punts
        {
            get { return punts; }
            set { punts = value; }
        }
        /// <summary>
        /// Propietat de l'imatge de perfil
        /// </summary>
        public string ImatgePerfil
        {
            get { return imatgePerfil; }
            set { imatgePerfil = value; }
        }
        /// <summary>
        /// Propietat de l'atribut esadministrador
        /// </summary>
        public int EsAdministrador
        {
            get { return esAdministrador; }
            set { esAdministrador = value; }
        }
        //Metodes
        /// <summary>
        /// Metode canviar alies
        /// </summary>
        /// <param name="nouAlias"></param>
        public void CambiarAlias(string nouAlias)
        {
        }
        /// <summary>
        /// Metode per canviar contrasenya
        /// </summary>
        /// <param name="novaContrasenya"></param>
        public void CambiarContrasenya(string novaContrasenya)
        {

        }
        /// <summary>
        /// Metode per canviar la Imatge
        /// </summary>
        /// <param name="pathNovaImatge"></param>
        public void CambiarImatge(string pathNovaImatge)
        {

        }
    }
}
