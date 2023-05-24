using Principal.Connexions;
using Principal.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Principal
{
    public partial class Registre : Window
    {
        //Constructors
        public Registre()
        {
            InitializeComponent();
        }
        //Métodes 
        /// <summary>
        /// Métode de la finestra Registre que tanca la finestra actual i obre la finestra del login.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void BtntornarLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.Show();
        }
        /// <summary>
        /// Métode de la finestra Registre que si totes les dades estan correctes inserta l'usuari nou registrat a la base de dades.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnRegistre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuaris usuaris = new();
                usuaris.RecuperarUsuaris();
                Mazos mazos = new();
                Partides partides = new(usuaris);
                Usuari usuari = new(usuaris.QuantitatUsuaris + 1, txtBoxAliasUsuari.Text, pwdBoxContrasenyaUsuari.Password, txtBoxNomUsuari.Text, mazos, partides, 0, txtBoxImatgeUsuari.Text, 0);
                usuaris.AfegirUsuari(usuari);
                MessageBox.Show("Usuari afegit correctament, ja pots iniciar sessió.");
                MainWindow login = new MainWindow();
                this.Close();
                login.Show();
            }catch(Exception ex)
            {
                MessageBox.Show("L'usuari no s'ha registrat.");
            }
        }
    }
}
