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

        //Constructors
        /// <summary>
        /// Constructor del Home que rep l'usuari.
        /// </summary>
        /// <param name="usuari">Usuari identificat al login.</param>
        public Home(Usuari usuari)
        {
            InitializeComponent();
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
            txtBoxAliasNouModificar.Text = Usuari.NomUsuari;
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
            MainWindow main = new();
            main.Show();
            this.Close();
        }
        /// <summary>
        /// Metode que carrega els Mazos de l'Usuari loggejat un cop carregada la pestanya.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void TabItemMazos_Loaded(object sender, RoutedEventArgs e)
        {
            //Instancio la classe mazos
            Mazos mazos = new();
            mazos.LlistaMazos = mazos.RecuperarMazos();
            //Inicialitzo un contador.
            int contador = 1;
            //Els filtro amb un Find All per l'id del usuari.
            mazos.LlistaMazos = mazos.LlistaMazos.FindAll(x => x.Usuari.Id == this.Usuari.Id);
            //Miro cuants mazos té l'usuari i depenent dels mazos vaig fent visibles els botons.
            if (mazos.LlistaMazos.Count == 1)
            {
                btnAfegirMazoRow1.Visibility = Visibility.Hidden;
                btnEliminarMazoRow1.Visibility = Visibility.Visible;
                btnModificarMazoRow1.Visibility = Visibility.Visible;

                btnAfegirMazoRow2.Visibility = Visibility.Visible;
                btnEliminarMazoRow2.Visibility = Visibility.Hidden;
                btnModificarMazoRow2.Visibility = Visibility.Hidden;

                btnAfegirMazoRow3.Visibility = Visibility.Hidden;
                btnEliminarMazoRow3.Visibility = Visibility.Hidden;
                btnModificarMazoRow3.Visibility = Visibility.Hidden;
            }
            else if (mazos.LlistaMazos.Count == 2)
            {
                btnAfegirMazoRow1.Visibility = Visibility.Hidden;
                btnEliminarMazoRow1.Visibility = Visibility.Visible;
                btnModificarMazoRow1.Visibility = Visibility.Visible;

                btnAfegirMazoRow2.Visibility = Visibility.Hidden;
                btnEliminarMazoRow2.Visibility = Visibility.Visible;
                btnModificarMazoRow2.Visibility = Visibility.Visible;

                btnAfegirMazoRow3.Visibility = Visibility.Visible;
                btnEliminarMazoRow3.Visibility = Visibility.Hidden;
                btnModificarMazoRow3.Visibility = Visibility.Hidden;
            }
            else if (mazos.LlistaMazos.Count == 1)
            {
                btnAfegirMazoRow1.Visibility = Visibility.Hidden;
                btnEliminarMazoRow1.Visibility = Visibility.Visible;
                btnModificarMazoRow1.Visibility = Visibility.Visible;

                btnAfegirMazoRow2.Visibility = Visibility.Hidden;
                btnEliminarMazoRow2.Visibility = Visibility.Visible;
                btnModificarMazoRow2.Visibility = Visibility.Visible;

                btnAfegirMazoRow3.Visibility = Visibility.Hidden;
                btnEliminarMazoRow3.Visibility = Visibility.Visible;
                btnModificarMazoRow3.Visibility = Visibility.Visible;
            }
            else
            {
                btnAfegirMazoRow1.Visibility = Visibility.Visible;
                btnEliminarMazoRow1.Visibility = Visibility.Hidden;
                btnModificarMazoRow1.Visibility = Visibility.Hidden;

                btnAfegirMazoRow2.Visibility = Visibility.Hidden;
                btnEliminarMazoRow2.Visibility = Visibility.Hidden;
                btnModificarMazoRow2.Visibility = Visibility.Hidden;

                btnAfegirMazoRow3.Visibility = Visibility.Hidden;
                btnEliminarMazoRow3.Visibility = Visibility.Hidden;
                btnModificarMazoRow3.Visibility = Visibility.Hidden;
            }
            //Recorro tots el mazos buscant els del Usuari loggejat.
            foreach (Mazo mazo in mazos.LlistaMazos)
            {
                //Afegeixo el primer mazo trobat i incremento la i per buscar el seguent mazo.
                //Tamb´´e afegeixo el mazo a la primer fila de list box.
                if (contador == 1)
                {
                    lblNomMazo1.Content = mazo.Nom;
                    //Carta 1 Mazo 1
                    listBoxRow1Col1.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[0].Nom));
                    listBoxRow1Col1.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[0].Imatge));
                    //Carta 2 Mazo 1
                    listBoxRow1Col2.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[1].Nom));
                    listBoxRow1Col2.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[1].Imatge));
                    //Carta 3 Mazo 1
                    listBoxRow1Col3.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[2].Nom));
                    listBoxRow1Col3.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[2].Imatge));
                    //Carta 4 Mazo 1
                    listBoxRow1Col4.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[3].Nom));
                    listBoxRow1Col4.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[3].Imatge));
                    //Carta 5 Mazo 1
                    listBoxRow1Col5.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[4].Nom));
                    listBoxRow1Col5.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[4].Imatge));
                    contador++;
                }
                //Si el troba l'afegeixo a els list box de la segona fila.
                //Incremento el contador en un per buscar el tercer.
                else if (contador == 2)
                {
                    lblNomMazo2.Content = mazo.Nom;
                    //Carta 1 Mazo 2
                    listBoxRow2Col1.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[0].Nom));
                    listBoxRow2Col1.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[0].Imatge));
                    //Carta 2 Mazo 2
                    listBoxRow2Col2.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[1].Nom));
                    listBoxRow2Col2.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[1].Imatge));
                    //Carta 3 Mazo 2
                    listBoxRow2Col3.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[2].Nom));
                    listBoxRow2Col3.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[2].Imatge));
                    //Carta 4 Mazo 2
                    listBoxRow2Col4.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[3].Nom));
                    listBoxRow2Col4.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[3].Imatge));
                    //Carta 5 Mazo 2
                    listBoxRow2Col5.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[4].Nom));
                    listBoxRow2Col5.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[4].Imatge));
                    contador++;
                }
                //Si troba el tercer l'afegeixo a el list box de la tercera fila.
                //Reinicio el contador a 1 per si haig de tornar a carregarlos.
                else if (contador == 3)
                {
                    lblNomMazo3.Content = mazo.Nom;
                    //Carta 1 Mazo 3
                    listBoxRow3Col1.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[0].Nom));
                    listBoxRow3Col1.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[0].Imatge));
                    //Carta 2 Mazo 3
                    listBoxRow3Col2.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[0].Nom));
                    listBoxRow3Col2.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[0].Imatge));
                    //Carta 3 Mazo 3
                    listBoxRow3Col3.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[0].Nom));
                    listBoxRow3Col3.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[0].Imatge));
                    //Carta 4 Mazo 3
                    listBoxRow3Col4.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[0].Nom));
                    listBoxRow3Col4.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[0].Imatge));
                    //Carta 5 Mazo 3
                    listBoxRow3Col5.Items.Add(CrearLabelCarta(mazo.Cartes.LlistaCartes[0].Nom));
                    listBoxRow3Col5.Items.Add(CrearImatgeCarta(mazo.Cartes.LlistaCartes[0].Imatge));
                    contador = 1;
                }

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
        private void DataGridPartides_Loaded(object sender, RoutedEventArgs e)
        {
            Partides partides = new();
            partides.LlistaPartides = partides.RecuperarPartides();
            List<PartidaLLista> llistat = new List<PartidaLLista>();
            //Els filtro amb un Find All per l'id del usuari.
            partides.LlistaPartides = partides.LlistaPartides.FindAll(x => x.Usuari.Id == this.Usuari.Id);
            foreach (Partida partida in partides.LlistaPartides)
            {
                PartidaLLista llistatPartida = new();
                llistatPartida.Bot = partida.Bot.Nom.ToString();
                llistatPartida.Usuari = Usuari.Alias.ToString();
                llistatPartida.Resultat = partida.EstatPartida.ToString();
                if (partida.EstatPartida == "Guanyada")
                    llistatPartida.Punts = "400 punts";
                else
                    llistatPartida.Punts = "0 punts";
                llistat.Add(llistatPartida);
            }
            dataGridPartides.ItemsSource = llistat;
            //Busco el total de punts que té l'usuari per guanyar partides i li afegeixo al label.
            lblPuntuacioUsuari.Content = Usuari.Punts + " punts.";
        }
        /// <summary>
        /// Metode que obre la finestra de triar el Mazo, per poder jugar la partida.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void BtnPartidaNova_Click(object sender, RoutedEventArgs e)
        {
            TriarMazo triarMazo = new(this.Usuari);
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
            AfegirMazo nouMazo = new(Usuari);
            nouMazo.Show();
            this.Close();
        }
        /// <summary>
        /// Metode que obre la finestra de afegir un nou Mazo.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirMazoRow2_Click(object sender, RoutedEventArgs e)
        {
            AfegirMazo nouMazo = new(Usuari);
            nouMazo.Show();
            this.Close();
        }
        /// <summary>
        /// Metode que obre la finestra de afegir un nou Mazo.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirMazoRow3_Click(object sender, RoutedEventArgs e)
        {
            AfegirMazo nouMazo = new(Usuari);
            nouMazo.Show();
            this.Close();
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
