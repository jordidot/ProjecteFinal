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
        public Usuari UsuariAdministrador { get; set; }
        public Cartes TotesCartes { get; set; }
        public Partides TotesPartides { get; set; }
        public Administracio( Usuari usuari,Cartes cartes, Partides partides)
        {
            InitializeComponent();
            this.UsuariAdministrador = usuari;
            this.TotesCartes = cartes;
            this.TotesPartides = partides;
        }

        private void windowsAdministracio_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Home home = new(this.UsuariAdministrador,this.TotesCartes);
            home.Show();
          
            
        }
    }
}
