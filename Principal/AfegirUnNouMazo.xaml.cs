using MySqlConnector;
using Principal.Connexions;
using Principal.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Principal
{
    public partial class AfegirUnNouMazo : Window
    {
        //Atributs i propietats
        public int Contador { get; set; }
        public Usuari Usuari { get; set; }
        public Cartes CartesMazoNou { get; set; }
        public Cartes TotesCartes { get; set; }
        public Usuaris TotsUsuaris { get; set; }
        public Partides TotesPartides { get; set; }
        public Habilitats TotesHabilitats { get; set; }
        //Constructors
        public AfegirUnNouMazo(Usuari usuari,Cartes totesCartes, Habilitats habilitats, Partides partides, Usuaris usuaris)
        {
            InitializeComponent();
            this.TotesHabilitats = habilitats;
            this.TotesPartides = partides;
            this.TotsUsuaris = usuaris;
            this.TotesCartes = totesCartes;
            Usuari = usuari;
            CartesMazoNou = new();
            Contador = 0;
        }
        //Mètodes
        /// <summary>
        /// Métode de la finestra AfegirUnNouMazo que carrega totes les cartes al stackpanel quan es carrega. (Va creant les cartes i les va afegint)
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void stckPanelCartes_Loaded(object sender, RoutedEventArgs e)
        {
            int contadorHabilitats = 0;
            foreach (Carta carta in TotesCartes.LlistaCartes)
            {
                ListBox cartaList = new();
                cartaList.HorizontalContentAlignment = HorizontalAlignment.Center;
                cartaList.Width = 550;
                cartaList.Height = 550;
                //Afegeixo el nom de la carta.
                Label nomCarta = new();
                nomCarta.Content = carta.Nom;
                //Creo l'imatge de la carta.
                Image imatgeCarta = new();
                imatgeCarta.Source = new BitmapImage(new Uri(carta.Imatge));
                imatgeCarta.Width = 500;
                imatgeCarta.Height = 150;
                //Afegeixo descripcio de la carta.
                Label descripcioCarta = new();
                descripcioCarta.Content = carta.Descripcio;
                descripcioCarta.Padding = new Thickness(10);
                //Afegeixo un listbox amb les habilitats.
                ListBox habilitatsCarta = new();
                
                habilitatsCarta.HorizontalContentAlignment = HorizontalAlignment.Center;
                habilitatsCarta.Width = 200;
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[contadorHabilitats].Nom);
                contadorHabilitats++;
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[contadorHabilitats].Nom);
                contadorHabilitats++;
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[contadorHabilitats].Nom);
                contadorHabilitats++;
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[contadorHabilitats].Nom);
                contadorHabilitats++;
                //Botó que fará que s'afegeixi la carta.
                Button botoMazo = new();
                botoMazo.Content = "Afegir " + carta.Nom;
                //Afegir els elements anteriors al listbox.
                cartaList.Items.Add(nomCarta);
                cartaList.Items.Add(imatgeCarta);
                cartaList.Items.Add(descripcioCarta);
                cartaList.Items.Add(habilitatsCarta);
                cartaList.Items.Add(botoMazo);
                //Afegeixo el listbox amb totes les dades al listbox contenidor.
                stckPanelCartes.Children.Add(cartaList);
                //Afegeixo un event al boto
                botoMazo.Click += (sendr, EventArgs) => { AfegirCarta(sendr, EventArgs, carta.Id); };

            }
        }
        /// <summary>
        /// Mètode de la finestra AfegirUnNouMazo que afegeix les cartes a l'usuari i puja el mazo a la base de dades un cop té les 5 cartes escollides.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        /// <param name="id">Li passo l'id de la carta seleccionada.</param>
        private void AfegirCarta(object sender, RoutedEventArgs e, int id)
        {
            try
            {
                //Va afegint a la llista de el mazo nou les cartes fins que no arriba a 5 cartes, un cop arriba a 5 cartes les assigna a l'usuari i les afegeix a la base de dades.
                if (Contador < 4)
                {
                    CartesMazoNou.LlistaCartes.Add(TotesCartes.LlistaCartes[id - 1]);
                    lblCartesAfegides.Content += " " + TotesCartes.LlistaCartes[id - 1].Nom + ",";
                    Contador++;
                }
                else if (Contador == 4)
                {
                    CartesMazoNou.LlistaCartes.Add(TotesCartes.LlistaCartes[id - 1]);
                    lblCartesAfegides.Content += " " + TotesCartes.LlistaCartes[id - 1].Nom;
                    try
                    {
                        Mazo mazo = new(Usuari.Mazos.RecuperaQuantitat(), CartesMazoNou,"Mazo" + this.Usuari.Alias, this.Usuari);
                        this.Usuari.Mazos.LlistaMazos.Clear();
                        this.Usuari.Mazos.LlistaMazos.Add(mazo);
                        MessageBox.Show("Mazo afegit correctament.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No s'ha pogut afegir el mazo.");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir la carta selccionada.");
            }
        }

        private void windowAfegirNouMazo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Home home = new(this.Usuari, this.TotesCartes, this.TotesHabilitats, this.TotesPartides, this.TotsUsuaris);
            home.Show();
        }
    }
}
