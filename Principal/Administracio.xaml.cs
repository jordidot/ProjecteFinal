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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Principal
{
    /// <summary>
    /// Finestra Administració
    /// </summary>
    public partial class Administracio : Window
    {
        /// <summary>
        /// Usuari Administrador
        /// </summary>
        public Usuari Administrador { get; set; }
        /// <summary>
        /// Tots els usuaris
        /// </summary>
        public Usuaris TotsUsuaris { get; set; }
        /// <summary>
        /// Totes les cartes
        /// </summary>
        public Cartes TotesCartes { get; set; }
        /// <summary>
        /// Totes les partides
        /// </summary>
        public Partides TotesPartides { get; set; }
        /// <summary>
        /// Totes les habilitats
        /// </summary>
        public Habilitats TotesHabilitats { get; set; }
        /// <summary>
        /// Constrcutor Administració
        /// </summary>
        /// <param name="usuari"></param>
        /// <param name="cartes"></param>
        /// <param name="partides"></param>
        /// <param name="habilitats"></param>
        /// <param name="usuaris"></param>
        public Administracio(Usuari usuari, Cartes cartes, Partides partides, Habilitats habilitats, Usuaris usuaris)
        {
            InitializeComponent();
            this.Administrador = usuari;
            this.TotsUsuaris = usuaris;
            this.TotesCartes = cartes;
            this.TotesPartides = partides;
            this.TotesHabilitats = habilitats;
        }
        /// <summary>
        /// Métode de la finestra Administració que guarda les dades a la base de dades quan es tanca la finestra.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void windowsAdministracio_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try{this.TotesCartes.ModificarCartes(this.TotesCartes);} catch (Exception ex) { }
            try{this.TotesHabilitats.ModificarHabilitats(this.TotesHabilitats);}catch (Exception ex) { }
            Home home = new(this.Administrador, this.TotesCartes, this.TotesHabilitats, this.TotesPartides, this.TotsUsuaris);
            home.Show();
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega els usuaris al datagrid un cop oberta la finestra.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void dataGridUsuaris_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridUsuaris.ItemsSource = null;
            dataGridUsuaris.ItemsSource = this.TotsUsuaris.Llistausuaris;
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega les cartes al datagrid un cop oberta la finestra.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void dataGridCartes_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridCartes.ItemsSource = null;
            dataGridCartes.ItemsSource = this.TotesCartes.LlistaCartes;
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega les habilitats al datagrid un cop oberta la finestra.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void dataGridHabilitats_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridHabilitats.ItemsSource = null;
            dataGridHabilitats.ItemsSource = this.TotesHabilitats.LListahabilitats;
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega les partides al datagrid un cop oberta la finestra.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void dataGridPartides_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridPartides.ItemsSource = null;
            dataGridPartides.ItemsSource = this.TotesPartides.LlistaPartides;
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega la vista dels usuaris.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnUsuarisMenu_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarUsuaris.Visibility = Visibility.Visible;
            stckPanelMostrarCartes.Visibility = Visibility.Hidden;
            stckPanelMostrarHabilitats.Visibility = Visibility.Hidden;
            stckPanelMostrarPartides.Visibility = Visibility.Hidden;

            stckPanelAfegirNouUsuari.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaCarta.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaHabilitat.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega la vista de les cartes.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnCartesMenu_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarUsuaris.Visibility = Visibility.Hidden;
            stckPanelMostrarCartes.Visibility = Visibility.Visible;
            stckPanelMostrarHabilitats.Visibility = Visibility.Hidden;
            stckPanelMostrarPartides.Visibility = Visibility.Hidden;

            stckPanelAfegirNouUsuari.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaCarta.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaHabilitat.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega la vista de les habilitats.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnHabilitatsMenu_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarUsuaris.Visibility = Visibility.Hidden;
            stckPanelMostrarCartes.Visibility = Visibility.Hidden;
            stckPanelMostrarHabilitats.Visibility = Visibility.Visible;
            stckPanelMostrarPartides.Visibility = Visibility.Hidden;

            stckPanelAfegirNouUsuari.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaCarta.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaHabilitat.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega la vista de les partides.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnPartidesMenu_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarUsuaris.Visibility = Visibility.Hidden;
            stckPanelMostrarCartes.Visibility = Visibility.Hidden;
            stckPanelMostrarHabilitats.Visibility = Visibility.Hidden;
            stckPanelMostrarPartides.Visibility = Visibility.Visible;

            stckPanelAfegirNouUsuari.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaCarta.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaHabilitat.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Métode de la finestra Administració que carrega la vista de creació d'usuaris.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirNouUsuariPrincipal_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarUsuaris.Visibility = Visibility.Hidden;
            stckPanelAfegirNouUsuari.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Métode de la finestra Administració afegeix l'usuari creat a la base de dades.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirNouUsuari_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mazos mazos = new();
                Partides partides = new(this.TotsUsuaris);
                Usuari usuari = new(this.TotsUsuaris.Llistausuaris.Count + 1, txtBoxAliasUsuari.Text, pwdBoxContrasenyaUsuari.Password, txtBoxNomUsuari.Text, mazos, partides, 0, txtBoxImatgeUsuari.Text, 0);
                this.TotsUsuaris.AfegirUsuari(usuari);
                this.TotsUsuaris.Llistausuaris.Add(usuari);
                dataGridUsuaris.ItemsSource = null;
                dataGridUsuaris.ItemsSource = this.TotsUsuaris.Llistausuaris;
                stckPanelMostrarUsuaris.Visibility = Visibility.Visible;
                stckPanelAfegirNouUsuari.Visibility = Visibility.Hidden;
                MessageBox.Show("Usuari afegit correctament.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir l'usuari.");
            }
        }
        /// <summary>
        /// Métode de la finestra Administració elimina l'usuari de la base de dades.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnEliminarUsuari_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.TotsUsuaris.EliminarUsuari(this.TotsUsuaris.Llistausuaris[dataGridUsuaris.SelectedIndex]);
                this.TotsUsuaris.Llistausuaris.Remove(this.TotsUsuaris.Llistausuaris[dataGridUsuaris.SelectedIndex]);
                dataGridUsuaris.ItemsSource = null;
                dataGridUsuaris.ItemsSource = this.TotsUsuaris.Llistausuaris;
                MessageBox.Show("Usuari eliminat correctament.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar l'usuari.");
            }
        }
        /// <summary>
        /// Métode de la finestra Administració que crida a la vista de la creació de una carta nova.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirNovaCartaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarCartes.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaCarta.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Métode de la finestra Administració carrega totes les habilitats al ComboBox 1.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void comboBoxHabilitat1_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHabilitat1.Items.Clear();
            foreach (Habilitat habilitat in this.TotesHabilitats.LListahabilitats)
            {
                comboBoxHabilitat1.Items.Add(habilitat.Nom);
            }
        }
        /// <summary>
        /// Métode de la finestra Administració carrega totes les habilitats al ComboBox 2.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void comboBoxHabilitat2_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHabilitat2.Items.Clear();
            foreach (Habilitat habilitat in this.TotesHabilitats.LListahabilitats)
            {
                comboBoxHabilitat2.Items.Add(habilitat.Nom);
            }
        }
        /// <summary>
        /// Métode de la finestra Administració carrega totes les habilitats al ComboBox 3.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void comboBoxHabilitat3_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHabilitat3.Items.Clear();
            foreach (Habilitat habilitat in this.TotesHabilitats.LListahabilitats)
            {
                comboBoxHabilitat3.Items.Add(habilitat.Nom);
            }
        }
        /// <summary>
        /// Métode de la finestra Administració carrega totes les habilitats al ComboBox 4.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void comboBoxHabilitat4_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHabilitat4.Items.Clear();
            foreach (Habilitat habilitat in this.TotesHabilitats.LListahabilitats)
            {
                comboBoxHabilitat4.Items.Add(habilitat.Nom);
            }
        }
        /// <summary>
        /// Métode de la finestra Administració que afegeix noves cartes a la base de dades.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirNovaCarta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Habilitats habilitatsCartaNova = new();
                habilitatsCartaNova.LListahabilitats.Add(this.TotesHabilitats.LListahabilitats[comboBoxHabilitat1.SelectedIndex]);
                habilitatsCartaNova.LListahabilitats.Add(this.TotesHabilitats.LListahabilitats[comboBoxHabilitat2.SelectedIndex]);
                habilitatsCartaNova.LListahabilitats.Add(this.TotesHabilitats.LListahabilitats[comboBoxHabilitat3.SelectedIndex]);
                habilitatsCartaNova.LListahabilitats.Add(this.TotesHabilitats.LListahabilitats[comboBoxHabilitat4.SelectedIndex]);
                Carta carta = new(this.TotesCartes.LlistaCartes.Count + 1, txtBoxNomCarta.Text, txtBoxDescripcioCarta.Text, txtBoxImatgeCarta.Text, habilitatsCartaNova);
                this.TotesCartes.AfegirCarta(carta);
                this.TotesCartes.LlistaCartes.Add(carta);
                dataGridCartes.ItemsSource = null;
                dataGridCartes.ItemsSource = this.TotesCartes.LlistaCartes;
                stckPanelAfegirNovaCarta.Visibility = Visibility.Hidden;
                stckPanelMostrarCartes.Visibility = Visibility.Visible;
                MessageBox.Show("Carta afegida correctament.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir la carta.");
            }
        }
        /// <summary>
        /// Métode de la finestra Administració elimina la carta seleccionada del data grid.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnEliminarCarta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Administrador.Mazos.LlistaMazos[0].Cartes.LlistaCartes.Contains(this.TotesCartes.LlistaCartes[dataGridCartes.SelectedIndex]))
                {
                    this.Administrador.Mazos.EliminarMazo(this.Administrador.Mazos.LlistaMazos[0]);
                    this.Administrador.Mazos.LlistaMazos.Remove(this.Administrador.Mazos.LlistaMazos[0]);
                }
                this.TotesCartes.EliminarCarta(this.TotesCartes.LlistaCartes[dataGridCartes.SelectedIndex]);
                this.TotesCartes.LlistaCartes.Remove(this.TotesCartes.LlistaCartes[dataGridCartes.SelectedIndex]);
                dataGridCartes.ItemsSource = null;
                dataGridCartes.ItemsSource = this.TotesCartes.LlistaCartes;
                MessageBox.Show("Carta eliminada correctament.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar la carta.");
            }
        }
        /// <summary>
        /// Métode de la finestra Administració carrega els dany de les habilitats al ComboBox.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void comboBoxDanyHabilitat_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxDanyHabilitat.Items.Clear();
            comboBoxDanyHabilitat.Items.Add(25);
            comboBoxDanyHabilitat.Items.Add(50);
            comboBoxDanyHabilitat.Items.Add(75);
            comboBoxDanyHabilitat.Items.Add(125);
        }
        /// <summary>
        /// Métode de la finestra Administració que crida al StackPanel que mostra la creació d'habilitats.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirNovaHabilitatPrincipal_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarHabilitats.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaHabilitat.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Métode de la finestra Administració que afegeix una nova habilitat a la base de dades.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirNovaHabilitat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int dany = 0;
                if (comboBoxDanyHabilitat.SelectedIndex == 1) dany = 25;
                else if (comboBoxDanyHabilitat.SelectedIndex == 2) dany = 50;
                else if (comboBoxDanyHabilitat.SelectedIndex == 3) dany = 75;
                else if (comboBoxDanyHabilitat.SelectedIndex == 4) dany = 125;
                Habilitat habilitat = new(this.TotesHabilitats.LListahabilitats.Count + 1, int.Parse(txtBoxCooldownHabilitat.Text), dany, txtBoxDescripcioHabilitat.Text, txtBoxNomHabilitat.Text);
                this.TotesHabilitats.AfegirHabilitat(habilitat);
                this.TotesHabilitats.LListahabilitats.Add(habilitat);
                dataGridHabilitats.ItemsSource = null;
                dataGridHabilitats.ItemsSource = this.TotesHabilitats.LListahabilitats;
                stckPanelMostrarHabilitats.Visibility = Visibility.Visible;
                stckPanelAfegirNovaHabilitat.Visibility = Visibility.Hidden;
                MessageBox.Show("Habilitat afegida correctament.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir l'habilitat.");
            }
        }
        /// <summary>
        /// Métode de la finestra Administració que elimina una habilitat de la base de dades.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnEliminarHabilitat_Click(object sender, RoutedEventArgs e)
        {
            foreach (Carta carta in this.TotesCartes.LlistaCartes)
            {
                if (carta.Habilitats.LListahabilitats.Contains(this.TotesHabilitats.LListahabilitats[dataGridHabilitats.SelectedIndex]))
                {
                    if (this.Administrador.Mazos.LlistaMazos[0].Cartes.LlistaCartes.Contains(this.TotesCartes.LlistaCartes[dataGridCartes.SelectedIndex]))
                    {
                        this.Administrador.Mazos.EliminarMazo(this.Administrador.Mazos.LlistaMazos[0]);
                        this.Administrador.Mazos.LlistaMazos.Remove(this.Administrador.Mazos.LlistaMazos[0]);
                    }
                    this.TotesCartes.EliminarCarta(carta);
                    this.TotesCartes.LlistaCartes.Remove(carta);
                    dataGridCartes.ItemsSource = null;
                    dataGridCartes.ItemsSource = this.TotesCartes.LlistaCartes;
                }
            }
            try
            {
                this.TotesHabilitats.EliminarHabilitat(this.TotesHabilitats.LListahabilitats[dataGridHabilitats.SelectedIndex]);
                this.TotesHabilitats.LListahabilitats.Remove(this.TotesHabilitats.LListahabilitats[dataGridHabilitats.SelectedIndex]);
                dataGridHabilitats.ItemsSource = null;
                dataGridHabilitats.ItemsSource = this.TotesHabilitats.LListahabilitats;
                MessageBox.Show("Habilitat eliminada correctament.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar l'habilitat.");
            }
        }
        /// <summary>
        /// Métode de la finestra Administració que elimina una partida de la base de dades.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void btnEliminarPartida_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Administrador.Partides.LlistaPartides.Contains(this.TotesPartides.LlistaPartides[dataGridPartides.SelectedIndex]))
                    this.Administrador.Partides.LlistaPartides.Remove(this.TotesPartides.LlistaPartides[dataGridPartides.SelectedIndex]);
                this.TotesPartides.EliminarPartida(this.TotesCartes, this.TotesPartides.LlistaPartides[dataGridPartides.SelectedIndex]);
                this.TotesPartides.LlistaPartides.Remove(this.TotesPartides.LlistaPartides[dataGridPartides.SelectedIndex]);
                dataGridPartides.ItemsSource = null;
                dataGridPartides.ItemsSource = this.TotesPartides.LlistaPartides;
                MessageBox.Show("Partida eliminada correctament.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar la partida.");
            }
        }


    }
}
