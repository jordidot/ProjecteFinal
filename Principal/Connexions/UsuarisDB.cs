using Principal.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;
using System.Security.Cryptography;

namespace Principal.Connexions
{
    public class UsuarisDB
    {
        //Atributs
        public int QuantitatTotal { get; set; }
        public Usuaris Usuaris { get; set; }
        public ConnexioDB ConnexioBD { get; set; }
       
        //Constructors
        public UsuarisDB()
        {
            ConnexioBD = new ConnexioDB("", "127.0.0.1", "cartesdb", "root");
            Usuaris = new Usuaris();
        }
        //Metodes
        /// <summary>
        /// Mètode de la classe UsuarisDB que afegeix un usuari a la base de dades.
        /// </summary>
        /// <param name="usuari">Classe Usuari amb tota l'informació d'aquest.</param>
        public void AfegirUsuariBD(Usuari usuari)
        {
            try
            {
                var comanda = new MySqlCommand("INSERT INTO usuaris VALUES(" + usuari.Id + ",'" + usuari.NomUsuari + "','" + usuari.Contrasenya + "','" + usuari.ImatgePerfil + "','" + usuari.Alias + "'," + usuari.EsAdministrador + "," + usuari.Punts + ");", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir l'usuari." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }
        /// <summary>
        /// Mètode de la classe UsuarisDB que afegeix varis usuaris a la base de dades.
        /// </summary>
        /// <param name="usuaris">Classe Usuaris amb una llista d'Usuari amb tota l'informació d'aquests.</param>
        public void AfegirUsuarisBD(Usuaris usuaris)
        {
            foreach (Usuari usuari in usuaris.Llistausuaris)
            {
                try
                {
                    var comanda = new MySqlCommand("INSERT INTO usuaris VALUES(" + usuari.Id + ",'" + usuari.NomUsuari + "','" + usuari.Contrasenya + "','" + usuari.ImatgePerfil + "','" + usuari.Alias + "'," + usuari.EsAdministrador + "," + usuari.Punts + ");", ConnexioBD.Connectar());
                    comanda.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No s'ha pogut afegir l'usuari." + ex.Message);
                }
                finally
                {
                    ConnexioBD.Connectar().Close();
                }
            }

        }
        /// <summary>
        /// Mètode de la classe UsuarisDB que elimina un usuari de la base de dades.
        /// </summary>
        /// <param name="usuari">Classe Usuari amb tota l'informació d'aquest.</param>
        public void EliminarUsuari(Usuari usuari)
        {
            try
            {
                var comanda = new MySqlCommand("DELETE FROM usuaris WHERE id="+usuari.Id, ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar l'usuari." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }
        /// <summary>
        /// Mètode de la classe UsuarisDB que modifica un usuari de la base de dades.
        /// </summary>
        /// <param name="usuari">Classe Usuari amb tota l'informació d'aquest nou usuari.</param>
        public void ModificarUsuari(Usuari usuari)
        {
            try
            {
                var comanda = new MySqlCommand("UPDATE usuaris SET imatgeperfil ='" + usuari.ImatgePerfil + "', alias='" + usuari.Alias + "',esAdministrador=" + usuari.EsAdministrador + ",punts=" + usuari.Punts + " WHERE id=" + usuari.Id + ";", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut modificar l'usuari." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }
        /// <summary>
        /// Mètode de la classe UsuarisDB que recupera tots els usuaris de la base de dades.
        /// </summary>
        public void RecuperarUsuariBD()
        {
            List<Usuari> usuaris = new List<Usuari>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM usuaris;", ConnexioBD.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Mazos mazos = new();
                    Usuaris usuariss = new();
                    Partides partides = new(usuariss);
                    Usuari usuari = new Usuari(reader.GetInt32(0), reader.GetString(4), reader.GetString(2), reader.GetString(1), mazos, partides, reader.GetInt32(6), reader.GetString(3), reader.GetInt32(5));
                    usuaris.Add(usuari);
                }
                Usuaris.Llistausuaris = usuaris;
                this.QuantitatTotal = Usuaris.Llistausuaris.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
                MySqlConnection.ClearAllPools();
            }
        }
        /// <summary>
        /// Mètode de la classe UsuarisDB que modifica l'imatge d'un usuari de la base de dades.
        /// </summary>
        /// <param name="usuari">Classe Usuari amb tota l'informació d'aquest usuari i l'imatge nova.</param>
        public void CanviarImatge(Usuari usuari)
        {
            try
            {
                var comanda = new MySqlCommand("UPDATE usuaris SET imatgeperfil ='" + usuari.ImatgePerfil + "' WHERE id=" + usuari.Id + ";", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut modificar l'usuari." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }
    }
}
