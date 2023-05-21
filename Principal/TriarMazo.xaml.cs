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
    /// Lógica de interacción para TriarMazo.xaml
    /// </summary>
    public partial class TriarMazo : Window
    {
        //Atributs
        private Usuari usuari;
        private Bot bot;
        public Cartes TotesCartes { get; set; }

        //Constructors
        /// <summary>
        /// Constructor que rep l'usuari, inicialitza el bot per competir en la partida.
        /// </summary>
        /// <param name="usuari">Rep un usuari per parámetre.</param>
        public TriarMazo(Usuari usuari, Cartes totesCartes)
        {
            InitializeComponent();
            TotesCartes = totesCartes;
            this.usuari = usuari;
            this.bot = new(totesCartes);
        }
        //Propietats
        /// <summary>
        /// Propietat de l'usuari de la finestra Tirar Mazo.
        /// </summary>
        public Usuari Usuari
        {
            get { return this.usuari; }
            set { this.usuari = value; }
        }
        /// <summary>
        /// Propietat del bot de la finestra Triar Mazo.
        /// </summary>
        public Bot Bot
        {
            get { return this.bot; }
            set { this.bot = value; }
        }
        //Métodes
        /// <summary>
        /// Métode que crea la partida a través del index del mazo dle usuari.
        /// </summary>
        /// <param name="mazo">Un número enter que es el index del mazo de la llista.</param>
        /// <returns>Retorna la partida ja creada.</returns>
        public void /* Aqui va Partida no void*/ CrearPartida(int mazo)
        {
            //Crear una partida nova
            Partides partides = new();
            partides.RecuperarPartides(this.Usuari);
            partides.LlistaPartides = partides.RecuperarPartides(this.Usuari).LlistaPartides;
            //Partida partidaNova = new();
            ////Partida partidaNova = new(partides.LlistaPartides.Count + 1, this.Bot, 1500, this.Bot.Cartes, this.Usuari.Mazos.LlistaMazos[mazo], this.Usuari, 1500, "Perduda");
            //return partidaNova;
        }
        /// <summary>
        /// Métode que obre el camp de batalla amb el primer mazo si ha sigut escollit.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Evenet intern.</param>
        private void BtnMazo1_Click(object sender, RoutedEventArgs e)
        {
            //CampBatalla camp = new(this.Usuari, CrearPartida(0),TotesCartes);
            //camp.Show();
            //this.Close();
        }
        
        /// <summary>
        /// Métode que busca els mazos el usuari, i afegeix el nom d'aquests al 
        /// </summary>
        /// <param name="sender">Objecte que rep</param>
        /// <param name="e">Event intern.</param>
        private void WindowTriar_Loaded(object sender, RoutedEventArgs e)
        {
       
            
            if (Usuari.Mazos.LlistaMazos.Count >= 1)
            {
                btnMazo1.Content = Usuari.Mazos.LlistaMazos[0].Nom;
                btnMazo1.Visibility = Visibility.Visible;
            }
            
        }
    }
}
