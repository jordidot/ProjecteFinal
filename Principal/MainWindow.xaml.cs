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
        //Atributs
        private Usuaris usuaris;
        private Cartes cartes;
        private Mazos mazos;
        private Partides totesPartides;
        private Usuaris totsUsuaris;
        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            usuaris = new();
            cartes = new();
            mazos = new();
            totesPartides = new();
            totsUsuaris = new();
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
                totsUsuaris.Llistausuaris = usuaris.RecuperarUsuaris();
                usuaris.Llistausuaris = totsUsuaris.Llistausuaris.FindAll(x => x.NomUsuari == txtBoxNomUsuari.Text && x.Contrasenya == pwdBoxContrasenyaUsuari.Password);
                //Miro si hi han usuaris amb les seguents dades.
                if (usuaris.Llistausuaris.Count == 0)
                    MessageBox.Show("Usuari o contrasenya incorrecte.");
                else
                {
                    cartes = cartes.RecuperarTotesCartes();
                    HabilitatsDB habilitats = new();
                    usuaris.Llistausuaris[0].Partides.TotesCartes = cartes;
                    this.totesPartides.LlistaPartides = usuaris.Llistausuaris[0].Partides.RecuperarPartides(usuaris.Llistausuaris[0], cartes);
                    usuaris.Llistausuaris[0].Partides.LlistaPartides = usuaris.Llistausuaris[0].Partides.RecuperarPartides(usuaris.Llistausuaris[0], cartes).FindAll(x => x.Usuari.Id == usuaris.Llistausuaris[0].Id);
                    usuaris.Llistausuaris[0].Mazos = mazos.RecuperarMazos(usuaris.Llistausuaris[0], cartes);
                    //Li passo l'usuari al constructor de la finestra del home per tenir les seves dades.
                    Home home = new(usuaris.Llistausuaris[0], cartes, habilitats.RecuperarHabilitats(cartes.LlistaCartes[0]),this.totesPartides,this.totsUsuaris);
                    this.Close();
                    home.Show();

                }
            }



        }
    }
}

