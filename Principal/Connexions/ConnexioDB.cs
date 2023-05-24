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
        public string NomBD { get; set; }
        public string UsuariBD { get; set; }
        public string ContrasenyaBD { get; set; }
        public string DireccioHost { get; set; }
 
        //Constructors
        //Assigno totes les dades amb el paràmetres que obtinc.
        public ConnexioDB(string contrasenya, string direcciohost, string nom, string usuari)
        {
            this.ContrasenyaBD = contrasenya;
            this.DireccioHost = direcciohost;
            this.NomBD = nom;
            this.UsuariBD = usuari;
        }
        //Mètodes
        /// <summary>
        /// Mètode de la classe ConnexioBD que obre la conexió amb la base de dades.
        /// </summary>
        /// <returns>Retorna un MYsqlConnection amb la connexió oberta.</returns>
        public MySqlConnection Connectar()
        {
            string connectar = "Server=" + this.DireccioHost + ";User ID=" + this.UsuariBD + ";Password=" + this.ContrasenyaBD + ";Database=" + this.NomBD;
            var connexio = new MySqlConnection(connectar);
            connexio.Open();
            return connexio;
        }
    }
}
