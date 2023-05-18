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
    /// Lógica de interacción para CampBatalla.xaml
    /// </summary>
    public partial class CampBatalla : Window
    {
        //Atributs
        private Usuari usuari;
        private Partida partida;
        public Cartes TotesCartes { get; set; }
        /// <summary>
        /// Constructor del camp de batalla que rep l'usuari i la partida.
        /// </summary>
        /// <param name="usuari">Usuari que juga.</param>
        /// <param name="partida">Dades de la partida, cartes, etc..</param>
        public CampBatalla(Usuari usuari, Partida partida, Cartes totesCartes)
        {
            InitializeComponent();
            TotesCartes = totesCartes;
            this.usuari = usuari;
            this.partida = partida;
        }
        /// <summary>
        /// Propietat de l'usuari del camp de batalla.
        /// </summary>
        public Usuari Usuari
        {
            get { return this.usuari; }
            set { this.usuari = value; }
        }
        /// <summary>
        /// Metode que s'executa quan es tanca la finestra.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void campBatallaWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //HACER ACTUALIZACION BASE DE DATOS
            
            Home home = new(Usuari,TotesCartes);
            home.Show();
        }
    }
}
