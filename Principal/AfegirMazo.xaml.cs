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
    /// Lógica de interacción para AfegirMazo.xaml
    /// </summary>
    public partial class AfegirMazo : Window
    {
        //Atributs
        private Usuari usuari;
        //Constructors
        /// <summary>
        /// Constructor d'afegir mazo que rep un usuari.
        /// </summary>
        /// <param name="usuari">Usuari logejat a l'aplicació.</param>
        public AfegirMazo(Usuari usuari)
        {
            InitializeComponent();
        }
        //Propietats
        /// <summary>
        /// Propietat de l'usuari.
        /// </summary>
        public Usuari Usuari
        {
            get { return this.usuari; }
            set { this.usuari = value; }
        }
        /// <summary>
        /// Métode que carrega totes les cartes al stackpanel.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>

        private void stckPanelCartes_Loaded(object sender, RoutedEventArgs e)
        {
            //Accedeixo a Cartes per recuperar les cartes de la BD.
            Cartes cartes = new();
            cartes.LlistaCartes = cartes.RecuperarCartes();
            foreach (Carta carta in cartes.LlistaCartes)
            {
                ListBox cartaList = new();
                cartaList.Width = 250;
                //Afegeixo el nom de la carta.
                Label nomCarta = new();
                nomCarta.Content = carta.Nom;
                //Creo l'imatge de la carta.
                Image imatgeCarta = new();
                imatgeCarta.Source = new BitmapImage(new Uri(carta.Imatge));
                imatgeCarta.Width = 200;
                imatgeCarta.Height = 200;
                //Afegeixo descripcio de la carta.
                Label descripcioCarta = new();
                descripcioCarta.Content = carta.Descripcio;
                //Afegeixo un listbox amb les habilitats.
                ListBox habilitatsCarta = new();
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[0].Nom);
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[1].Nom);
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[2].Nom);
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[3].Nom);
                //Botó que fará que s'afegeixi la carta.
                Button botoMazo = new();
                botoMazo.Content = "Afegir " + carta.Nom;
                //Guardo l'id de la carta per afegirla.
                Label idCarta = new();
                idCarta.Content = carta.Id;
                idCarta.Visibility = Visibility.Hidden;
                //Afegir els elements anteriors al listbox.
                cartaList.Items.Add(nomCarta);
                cartaList.Items.Add(imatgeCarta);
                cartaList.Items.Add(descripcioCarta);
                cartaList.Items.Add(habilitatsCarta);
                cartaList.Items.Add(botoMazo);
                cartaList.Items.Add(idCarta);

                //Afegeixo el listbox amb totes les dades al listbox contenidor.
                stckPanelCartes.Children.Add(cartaList);
            }

        }

        //Métodes

    }
}
