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
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        //Atributs
        private Usuari usuari;
        public Cartes Cartes { get; set; }
        //Constructors
        /// <summary>
        /// Constructor del Home que rep l'usuari.
        /// </summary>
        /// <param name="usuari">Usuari identificat al login.</param>
        public Home(Usuari usuari, Cartes cartes)
        {
            InitializeComponent();
            Cartes = cartes;
            this.usuari = usuari;
            lblAliasBenvingut.Content = usuari.Alias;
            imageProfile.Source = new BitmapImage(new Uri(usuari.ImatgePerfil));
        }

        //Propietats
        /// <summary>
        /// Propietat de l'usuari del home.
        /// </summary>
        public Usuari Usuari
        {
            get { return usuari; }
            set { this.usuari = value; }
        }
        /// <summary>
        /// Metode que amaga el botó de modificar l'alias de l'usuari i fa visibles els que criden a la classe per modificarlo.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void BtnModificarAliasBefore_Click(object sender, RoutedEventArgs e)
        {
            btnModificarAliasBefore.Visibility = Visibility.Hidden;
            txtBoxAliasNouModificar.Text = Usuari.Alias;
            txtBoxAliasNouModificar.Visibility = Visibility.Visible;
            btnModificarAliasAfter.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Metode que tanca la finestra actual i torna a obrir la del main.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void BtnTancarSessioBenvingut_Click(object sender, RoutedEventArgs e)
        {
            if (this.Usuari.Mazos.LlistaMazos.Count == 1)
            {
                MazosDB afegir = new();
                afegir.EliminarMazoUsuariBD(Usuari);
                afegir.AfegirMazoBD(this.Usuari.Mazos.LlistaMazos[0]);
            }
            this.Close();
        }
        /// <summary>
        /// Metode que carrega els Mazos de l'Usuari loggejat un cop carregada la pestanya.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void tabItemMazos_GotFocus(object sender, RoutedEventArgs e)
        {

            //Inicialitzo un contador.
            int contador = 1;
            //Miro cuants mazos té l'usuari i depenent dels mazos vaig fent visibles els botons.
            if (Usuari.Mazos.LlistaMazos.Count == 1)
            {
                btnAfegirMazoRow1.Visibility = Visibility.Hidden;
                btnEliminarMazoRow1.Visibility = Visibility.Visible;
                btnModificarMazoRow1.Visibility = Visibility.Visible;

                lblNomMazo1.Content = Usuari.Mazos.LlistaMazos[0].Nom;
                //Carta 1 Mazo 1
                listBoxRow1Col1.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Nom));
                listBoxRow1Col1.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Imatge));
                //Carta 2 Mazo 1
                listBoxRow1Col2.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Nom));
                listBoxRow1Col2.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Imatge));
                //Carta 3 Mazo 1
                listBoxRow1Col3.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Nom));
                listBoxRow1Col3.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Imatge));
                //Carta 4 Mazo 1
                listBoxRow1Col4.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Nom));
                listBoxRow1Col4.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Imatge));
                //Carta 5 Mazo 1
                listBoxRow1Col5.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Nom));
                listBoxRow1Col5.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Imatge));
            }

        }
        /// <summary>
        /// Crea un objecte Label per posar el nom de la carta.
        /// </summary>
        /// <param name="nom">Li paso el nom de la carta.</param>
        /// <returns>Retorna el Label amb el nom de la carta.</returns>
        public Label CrearLabelCarta(string nom)
        {
            Label nomCarta = new();
            nomCarta.Content = nom;
            nomCarta.HorizontalContentAlignment = HorizontalAlignment.Center;
            return nomCarta;
        }
        /// <summary>
        /// Creo un objecte Imatge de la carta.
        /// </summary>
        /// <param name="path">Rep el path de l'imatge com a parametre.</param>
        /// <returns>Retorna la Imatge creada amb el BitMapImage.</returns>
        public Image CrearImatgeCarta(string path)
        {
            Image imageCarta = new();
            imageCarta.Source = new BitmapImage(new Uri(path));
            imageCarta.Width = 100;
            imageCarta.Height = 100;
            return imageCarta;
        }
        /// <summary>
        /// Metode que carrega el data grid de la pestanya partides amb les partides de l'usuari.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void tabItemPartides_GotFocus(object sender, RoutedEventArgs e)
        {
            dataGridPartides.ItemsSource = Usuari.Partides.LlistaPartides;
            //Busco el total de punts que té l'usuari per guanyar partides i li afegeixo al label.

        }
        /// <summary>
        /// Metode que obre la finestra de triar el Mazo, per poder jugar la partida.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void BtnPartidaNova_Click(object sender, RoutedEventArgs e)
        {
            TriarMazo triarMazo = new(this.Usuari, Cartes);
            triarMazo.Show();
            this.Close();

        }
        /// <summary>
        /// Metode que obre la finestra de afegir un nou Mazo.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirMazoRow1_Click(object sender, RoutedEventArgs e)
        {
            AfegirUnNouMazo nouMazo = new(Usuari, Cartes);
            nouMazo.Show();
            this.Close();
        }


        private void btnEliminarMazoRow1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuari.Mazos.LlistaMazos.Remove(Usuari.Mazos.LlistaMazos[0]);
                Home home = new(Usuari, Cartes);
                this.Close();
                home.Show();
            }
            catch (Exception ex)
            {
                Home home = new(Usuari, Cartes);
                this.Close();
                home.Show();
            }


        }

        private void windowHome_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (this.Usuari.Mazos.LlistaMazos.Count == 1)
            {
                MazosDB afegir = new();
                afegir.EliminarMazoUsuariBD(Usuari);
                afegir.AfegirMazoBD(this.Usuari.Mazos.LlistaMazos[0]);
            }

        }

        private void btnModificarAliasAfter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuaris usuaris = new Usuaris();
                Usuari.Alias = txtBoxAliasNouModificar.Text;
                usuaris.ModificarUsuari(Usuari);
                Home home = new(Usuari, Cartes);
                this.Close();
                home.Show();
            }catch(Exception ex)
            {
                MessageBox.Show("No s'ha modificat l'usuari.");
                Home home = new(Usuari, Cartes);
                this.Close();
                home.Show();
            }



        }
    }
    //Classe que utilitzo per el Data grid de Partides així hem mostra les següents dades de partides al data grid.
    public class PartidaLLista
    {
        public string Bot { get; set; }
        public string Usuari { get; set; }
        public string Resultat { get; set; }
        public string Punts { get; set; }
    }
}
