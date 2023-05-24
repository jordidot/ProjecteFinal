using Principal.Negoci;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Principal.Connexions
{
    public class HabilitatsDB
    {
        //Atributs
        public Habilitats Habilitats { get; set; }
        public ConnexioDB ConnexioBD { get; set; }
        //Constructors
        public HabilitatsDB()
        {
            Habilitats = new Habilitats();
            ConnexioBD = new ConnexioDB("", "localhost", "cartesdb", "root");
        }
        //Metodes
        /// <summary>
        /// Mètode de la classe HabilitatsDB que afegeix una habilitat a la base de dades.
        /// </summary>
        /// <param name="habilitat">Habilitat que té totes les dades d'aquesta.</param>
        public void AfegirHabilitatBD(Habilitat habilitat)
        {
            try
            {
                var comanda = new MySqlCommand("INSERT INTO habilitats VALUES(" + habilitat.Id + ",'" + habilitat.Nom + "','" + habilitat.Descripcio + "',"+habilitat.Cooldown+ ","+habilitat.Dany+");", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir l'habilitat." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }

        /// <summary>
        /// Mètode de la classe HabilitatsDB que elimina una habilitat a la base de dades.
        /// </summary>
        /// <param name="habilitat">Habilitat que té totes les dades d'aquesta.</param>
        public void EliminarHabilitatBD(Habilitat habilitat)
        {
            try
            {
                var comanda = new MySqlCommand("DELETE FROM habilitats WHERE id=" + habilitat.Id, ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar l'habilitat." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
            }
        }
        /// <summary>
        /// Mètode de la classe HabilitatsDB que modifica moltes habilitats a la base de dades.
        /// </summary>
        /// <param name="habilitat">Classe Habilitats que té una llista amb totes les habilitats.</param>
        public void ModificarHabilitats(Habilitats habilitats)
        {

            foreach (Habilitat habilitat in habilitats.LListahabilitats)
            {
                try
                {
                    var comanda = new MySqlCommand("UPDATE habilitats SET nom='" + habilitat.Nom + "', cooldown=" + habilitat.Cooldown + ", dany=" + habilitat.Dany + " WHERE id=" + habilitat.Id + " ;", ConnexioBD.Connectar());
                    comanda.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No s'ha pogut modificar l'habilitat." + ex.Message);
                }
                finally
                {
                    ConnexioBD.Connectar().Close();
                }
            }
        }
        /// <summary>
        /// Mètode de la classe HabilitatsDB que recupera totes les habilitats de la base de dades.
        /// </summary>
        /// <returns>Retorna una classe Habilitats abm una llista de totes les habilitats.</returns>
        public Habilitats RecuperarHabilitats()
        {
            Habilitats habilitats = new();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM habilitats;", ConnexioBD.Connectar());
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Habilitat habilitat = new Habilitat(reader.GetInt32(0), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(2), reader.GetString(1));
                    habilitats.LListahabilitats.Add(habilitat);
                }
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
            return habilitats;
        }   
    }
}
