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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Principal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        //Métodes
        /// <summary>
        /// Metode que obre la finestra de Registre i tanca la actual.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void BtnRegistrarmeLogin_Click(object sender, RoutedEventArgs e)
        {
            Registre registre = new Registre();
            registre.Show();
            this.Close();
        }
        /// <summary>
        /// Métode que comprova si l'usuari existeix a la base de dades. Si existeix obre la finestra Home i tanca aquesta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIniciarSessio_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxNomUsuari.Text == "" || pwdBoxContrasenyaUsuari.Password == "")
                MessageBox.Show("No has introduït dades.");
            else
            {
                Usuaris usuaris = new();
                usuaris.Llistausuaris = usuaris.RecuperarUsuaris().FindAll(x => x.NomUsuari == txtBoxNomUsuari.Text && x.Contrasenya == pwdBoxContrasenyaUsuari.Password);
                Cartes cartes = new();
                cartes = cartes.RecuperarTotesCartes();
                //Miro si hi han usuaris amb les seguents dades.
                if (usuaris.Llistausuaris.Count == 0)
                    MessageBox.Show("Usuari o contrasenya incorrecte.");
                else
                {
                    //Li passo l'usuari al constructor de la finestra del home per tenir les seves dades.
                    Home home = new(usuaris.Llistausuaris[0],cartes);
                    this.Close();
                    home.Show();
                    
                }
            }
        }
    }
}

