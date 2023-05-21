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
    /// Lógica de interacción para Administracio.xaml
    /// </summary>
    public partial class Administracio : Window
    {
        public Usuari Administrador { get; set; }
        public Usuaris TotsUsuaris { get; set; }
        public Cartes TotesCartes { get; set; }
        public Partides TotesPartides { get; set; }
        public Habilitats TotesHabilitats { get; set; }
        public Mazos TotsMazos { get; set; }
        public Administracio( Usuari usuari,Cartes cartes, Partides partides, Habilitats habilitats,Usuaris usuaris)
        {
            InitializeComponent();
            this.Administrador = usuari;
            this.TotsUsuaris = usuaris;
            this.TotesCartes = cartes;
            this.TotesPartides = partides;
            this.TotesHabilitats = habilitats;
            this.TotsMazos = new();
            foreach(Usuari u in TotsUsuaris.Llistausuaris)
            {
                if (u.Mazos.LlistaMazos.Count == 1)
                    TotsMazos.LlistaMazos.Add(u.Mazos.LlistaMazos[0]);
            }
        }

        private void windowsAdministracio_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MazosDB mazos = new();
            foreach(Mazo mazo in this.TotsMazos.LlistaMazos)
            {
                mazos.EliminarMazoBD(mazo);
            }
            foreach (Mazo mazo in this.TotsMazos.LlistaMazos)
            {
                mazos.AfegirMazoBD(mazo);
            }
            this.TotsUsuaris.EliminarUsuaris();
            this.TotsUsuaris.AfegirUsuaris(this.TotsUsuaris);
            Home home = new(this.Administrador,this.TotesCartes);
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
            dataGridHabilitats.ItemsSource = null;
            dataGridPartides.ItemsSource = this.TotesPartides.LlistaPartides;
        }
    }
}
