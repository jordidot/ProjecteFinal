﻿using Principal.Negoci;
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
    /// <summary>
    /// Lógica de interacción para AfegirMazo.xaml
    /// </summary>
    public partial class AfegirMazo : Window
    {
        //Atributs
        private Usuari usuari;
        private Cartes cartesMazoNou;
        private Cartes totesCartes;
        private int contador;
        //Constructors
        /// <summary>
        /// Constructor d'afegir mazo que rep un usuari.
        /// </summary>
        /// <param name="usuari">Usuari logejat a l'aplicació.</param>
        public AfegirMazo(Usuari usuari)
        {
            InitializeComponent();
            Usuari = usuari;
            CartesMazoNou = new();
            contador = 1;
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
        public Cartes CartesMazoNou
        {
            get { return this.cartesMazoNou; }
            set { this.cartesMazoNou = value; }
        }
        /// <summary>
        /// Métode que carrega totes les cartes al stackpanel.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>

        private void stckPanelCartes_Loaded(object sender, RoutedEventArgs e)
        {
            //Accedeixo a Cartes per recuperar les cartes de la BD.
            totesCartes = new();
            totesCartes.LlistaCartes = totesCartes.RecuperarCartes();
            foreach (Carta carta in totesCartes.LlistaCartes)
            {
                ListBox cartaList = new();
                cartaList.HorizontalContentAlignment = HorizontalAlignment.Center;
                cartaList.Width = 250;
                cartaList.Height = 450;
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
                habilitatsCarta.HorizontalContentAlignment = HorizontalAlignment.Center;
                habilitatsCarta.Width = 200;
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[0].Nom);
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[1].Nom);
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[2].Nom);
                habilitatsCarta.Items.Add(carta.Habilitats.LListahabilitats[3].Nom);
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

        //Métodes
        private void AfegirCarta(object sender, RoutedEventArgs e, int id)
        {
            try
            {
                if (contador != 5)
                {
                    CartesMazoNou.LlistaCartes.Add(totesCartes.LlistaCartes[id - 1]);
                    contador++;
                    lblCartesAfegides.Content += " " + totesCartes.LlistaCartes[id - 1].Nom + ",";
                }
                else if(contador == 5)
                {
                    lblCartesAfegides.Content = lblCartesAfegides.Content.ToString().Substring(0, lblCartesAfegides.Content.ToString().Length - 1);
                    lblCartesAfegidesSucces.Visibility = Visibility.Visible;
                    Mazos mazos = new();
                    mazos.LlistaMazos = mazos.RecuperarMazos();
                    AfegirMazoExtend extend = new(CartesMazoNou, Usuari, mazos.LlistaMazos.Count);
                    extend.Show();
                    this.Close();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir la carta selccionada.");
            }


        }
    }
}
