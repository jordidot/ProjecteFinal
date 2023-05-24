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
    public partial class MainWindow : Window
    {
        //Atributs i propietats
        public Usuaris Usuaris { get; set; }
        public Cartes Cartes { get; set; }
        public Mazos Mazos { get; set; }
        public Partides TotesPartides { get; set; }
        public Usuaris TotsUsuaris { get; set; }
        //Constructors
        public MainWindow()
        {
            InitializeComponent();
            Usuaris = new();
            Cartes = new();
            Mazos = new();
            TotsUsuaris = new();
            TotesPartides = new(this.TotsUsuaris);
            
        }

        //Métodes
        /// <summary>
        /// Mètode de la finestra MainWindow(Login) que obre la finestra de Registre i tanca la actual.
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
        /// Mètode de la finestra MainWindow(Login) que comprova si l'usuari existeix a la base de dades. Si existeix obre la finestra Home i tanca aquesta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIniciarSessio_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxNomUsuari.Text == "" || pwdBoxContrasenyaUsuari.Password == "")
                MessageBox.Show("No has introduït dades.");
            else
            {
                TotsUsuaris.Llistausuaris = Usuaris.RecuperarUsuaris();
                Usuaris.Llistausuaris = TotsUsuaris.Llistausuaris.FindAll(x => x.NomUsuari == txtBoxNomUsuari.Text && x.Contrasenya == pwdBoxContrasenyaUsuari.Password);
                //Miro si hi han usuaris amb les seguents dades.
                if (Usuaris.Llistausuaris.Count == 0)
                    MessageBox.Show("Usuari o contrasenya incorrecte.");
                else
                {
                    this.Cartes = this.Cartes.RecuperarTotesCartes();
                    HabilitatsDB habilitats = new();
                    this.Usuaris.Llistausuaris[0].Partides.TotesCartes = this.Cartes;
                    this.TotesPartides.LlistaPartides = this.Usuaris.Llistausuaris[0].Partides.RecuperarPartides(this.Usuaris.Llistausuaris[0], this.Cartes);
                    this.Usuaris.Llistausuaris[0].Partides.LlistaPartides = this.Usuaris.Llistausuaris[0].Partides.RecuperarPartides(this.Usuaris.Llistausuaris[0], this.Cartes).FindAll(x => x.Usuari.Id == this.Usuaris.Llistausuaris[0].Id);
                    this.Usuaris.Llistausuaris[0].Mazos = this.Mazos.RecuperarMazos(this.Usuaris.Llistausuaris[0], this.Cartes);
                    //Li passo l'usuari al constructor de la finestra del home per tenir les seves dades.
                    Home home = new(this.Usuaris.Llistausuaris[0], this.Cartes, habilitats.RecuperarHabilitats(),this.TotesPartides,this.TotsUsuaris);
                    this.Close();
                    home.Show();
                }
            }
        }
    }
}

