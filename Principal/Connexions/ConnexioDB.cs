using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Principal.Connexions
{
    public class ConnexioDB
    {
        //Atributs
        private string contrasenyaBD;
        private string direccioHost;
        private string nomBD;
        private string usuariBD;
        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public ConnexioDB() { }
        /// <summary>
        /// Constructor per emplenar les dades de la ConnexioBD
        /// </summary>
        /// <param name="contrasenya">Contrasenya per entrar a la BD</param>
        /// <param name="direcciohost">Direcció per entrar a la BD</param>
        /// <param name="nom">Nom de la BD</param>
        /// <param name="usuari">Usuari de la BD</param>
        public ConnexioDB(string contrasenya, string direcciohost, string nom, string usuari)
        {
            this.contrasenyaBD = contrasenya;
            this.direccioHost = direcciohost;
            this.nomBD = nom;
            this.usuariBD = usuari;
        }

        //Propietats
        /// <summary>
        /// Propietat de l'atribut contrasenya
        /// </summary>
        public string ContrasenyaBD
        {
            get { return contrasenyaBD; }
            set { contrasenyaBD = value; }

        }
        /// <summary>
        /// Propietat de l'atribut direcciohost
        /// </summary>
        public string DireccioHost
        {
            get { return direccioHost; }
            set { direccioHost = value; }

        }
        /// <summary>
        /// Propietat de l'atribut nom
        /// </summary>
        public string NomBD
        {
            get { return nomBD; }
            set { nomBD = value; }

        }
        /// <summary>
        /// Propietat de l'atribut Usuari
        /// </summary>
        public string UsuariBD
        {
            get { return usuariBD; }
            set { usuariBD = value; }

        }

        //Mètodes
        /// <summary>
        /// Retorna la conexiom a la base de dades.
        /// </summary>
        /// <returns></returns>
        public MySqlConnection Connectar()
        {
            string connectar = "Server=" + this.DireccioHost + ";User ID=" + this.UsuariBD + ";Password=" + this.ContrasenyaBD + ";Database=" + this.NomBD;
            var connexio = new MySqlConnection(connectar);
            connexio.Open();
            return connexio;
        }
        public MySqlConnection ConnectarAsync()
        {
            string connectar = "Server=" + this.DireccioHost + ";User ID=" + this.UsuariBD + ";Password=" + this.ContrasenyaBD + ";Database=" + this.NomBD;
            var connexio = new MySqlConnection(connectar);
            connexio.OpenAsync();
            return connexio;
        }
    }
}
