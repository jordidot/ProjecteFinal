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
    /// Lógica de interacción para Administracio.xaml
    /// </summary>
    public partial class Administracio : Window
    {
        public Usuari Administrador { get; set; }
        public Usuaris TotsUsuaris { get; set; }
        public Cartes TotesCartes { get; set; }
        public Partides TotesPartides { get; set; }
        public Habilitats TotesHabilitats { get; set; }
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void windowsAdministracio_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.TotesCartes.ModificarCartes(this.TotesCartes);
            this.TotesHabilitats.ModificarHabilitats(this.TotesHabilitats);
            Home home = new(this.Administrador, this.TotesCartes, this.TotesHabilitats, this.TotesPartides, this.TotsUsuaris);
            home.Show();
        }

        private void dataGridUsuaris_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridUsuaris.ItemsSource = null;
            dataGridUsuaris.ItemsSource = this.TotsUsuaris.Llistausuaris;
        }

        private void dataGridCartes_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridCartes.ItemsSource = null;
            dataGridCartes.ItemsSource = this.TotesCartes.LlistaCartes;
        }

        private void dataGridHabilitats_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridHabilitats.ItemsSource = null;
            dataGridHabilitats.ItemsSource = this.TotesHabilitats.LListahabilitats;
        }

        private void dataGridPartides_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridPartides.ItemsSource = null;
            dataGridPartides.ItemsSource = this.TotesPartides.LlistaPartides;
        }

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


        private void btnAfegirNouUsuariPrincipal_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarUsuaris.Visibility = Visibility.Hidden;
            stckPanelAfegirNouUsuari.Visibility = Visibility.Visible;
        }
        private void btnAfegirNouUsuari_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mazos mazos = new();
                Partides partides = new();
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

        private void btnAfegirNovaCartaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarCartes.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaCarta.Visibility = Visibility.Visible;
        }

        private void comboBoxHabilitat1_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHabilitat1.Items.Clear();
            foreach (Habilitat habilitat in this.TotesHabilitats.LListahabilitats)
            {
                comboBoxHabilitat1.Items.Add(habilitat.Nom);
            }

        }

        private void comboBoxHabilitat2_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHabilitat2.Items.Clear();
            foreach (Habilitat habilitat in this.TotesHabilitats.LListahabilitats)
            {
                comboBoxHabilitat2.Items.Add(habilitat.Nom);
            }
        }

        private void comboBoxHabilitat3_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHabilitat3.Items.Clear();
            foreach (Habilitat habilitat in this.TotesHabilitats.LListahabilitats)
            {
                comboBoxHabilitat3.Items.Add(habilitat.Nom);
            }
        }

        private void comboBoxHabilitat4_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHabilitat4.Items.Clear();
            foreach (Habilitat habilitat in this.TotesHabilitats.LListahabilitats)
            {
                comboBoxHabilitat4.Items.Add(habilitat.Nom);
            }
        }

        private void btnAfegirNovaCarta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Habilitats habilitatsCartaNova = new();
                habilitatsCartaNova.LListahabilitats.Add(this.TotesHabilitats.LListahabilitats[comboBoxHabilitat1.SelectedIndex]);
                habilitatsCartaNova.LListahabilitats.Add(this.TotesHabilitats.LListahabilitats[comboBoxHabilitat2.SelectedIndex]);
                habilitatsCartaNova.LListahabilitats.Add(this.TotesHabilitats.LListahabilitats[comboBoxHabilitat3.SelectedIndex]);
                habilitatsCartaNova.LListahabilitats.Add(this.TotesHabilitats.LListahabilitats[comboBoxHabilitat4.SelectedIndex]);
                Carta carta = new Carta(this.TotesCartes.LlistaCartes.Count + 1, txtBoxNomCarta.Text, txtBoxDescripcioCarta.Text, txtBoxImatgeCarta.Text, habilitatsCartaNova);
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

        private void comboBoxDanyHabilitat_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxDanyHabilitat.Items.Clear();
            comboBoxDanyHabilitat.Items.Add(25);
            comboBoxDanyHabilitat.Items.Add(50);
            comboBoxDanyHabilitat.Items.Add(75);
            comboBoxDanyHabilitat.Items.Add(125);
        }

        private void btnAfegirNovaHabilitatPrincipal_Click(object sender, RoutedEventArgs e)
        {
            stckPanelMostrarHabilitats.Visibility = Visibility.Hidden;
            stckPanelAfegirNovaHabilitat.Visibility = Visibility.Visible;
        }

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
