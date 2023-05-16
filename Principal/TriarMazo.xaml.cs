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

        //Constructors
        /// <summary>
        /// Constructor que rep l'usuari, inicialitza el bot per competir en la partida.
        /// </summary>
        /// <param name="usuari">Rep un usuari per parámetre.</param>
        public TriarMazo(Usuari usuari)
        {
            InitializeComponent();
            this.usuari = usuari;
            this.bot = new();
            this.bot.GenerarNom();
            this.bot.GenerarImatge();
            this.bot.GenerarCartes();
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
        public Partida CrearPartida(int mazo)
        {
            //Crear una partida nova
            Partides partides = new();
            PartidesDB partidesdb = new();
            partidesdb.RecuperarPartides();
            partides.LlistaPartides = partidesdb.Partides.LlistaPartides;
            Partida partidaNova = new(partides.LlistaPartides.Count + 1, this.Bot, 1500, this.Bot.Cartes, this.Usuari.Mazos.LlistaMazos[mazo], this.Usuari, 1500, "Perduda");
            return partidaNova;
        }
        /// <summary>
        /// Métode que obre el camp de batalla amb el primer mazo si ha sigut escollit.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Evenet intern.</param>
        private void BtnMazo1_Click(object sender, RoutedEventArgs e)
        {
            CampBatalla camp = new(this.Usuari, CrearPartida(0));
            camp.Show();
            this.Close();
        }
        /// <summary>
        /// Métode que obre el camp de batalla amb el segon mazo si ha sigut escollit.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Evenet intern.</param>
        private void BtnMazo2_Click(object sender, RoutedEventArgs e)
        {
            CampBatalla camp = new(this.Usuari, CrearPartida(1));
            camp.Show();
            this.Close();
        }
        /// <summary>
        /// Métode que obre el camp de batalla amb el tercer mazo si ha sigut escollit.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void BtnMazo3_Click(object sender, RoutedEventArgs e)
        {
            CampBatalla camp = new(this.Usuari, CrearPartida(2));
            camp.Show();
            this.Close();
        }
        /// <summary>
        /// Métode que busca els mazos el usuari, i afegeix el nom d'aquests al 
        /// </summary>
        /// <param name="sender">Objecte que rep</param>
        /// <param name="e">Event intern.</param>
        private void WindowTriar_Loaded(object sender, RoutedEventArgs e)
        {
            //Creo la classe mazos y recupero  les dades de la BD.
            Mazos mazos = new();
            mazos.LlistaMazos = mazos.RecuperarMazos();
            //Creo una llista on posare els mazos del usuari.
            Mazos mazosUsuario = new();
            //Els filtro amb un Find All per l'id del usuari.
            mazosUsuario.LlistaMazos = mazos.LlistaMazos.FindAll(x => x.Usuari.Id == this.Usuari.Id);
            //IMPORTANT 
            //Assigno aquesta mazos als mazos del usuari, ara l'usuari ja te asignats aquest mazos de cartes.
            Usuari.Mazos = mazosUsuario;
            //Segons els mazos vaig posant els noms dels botons amb els dels mazos i faig visible el botó.
            //Aixo fará que amb les funcion del mazo segons el que clicki es un o un altre.
            if (mazosUsuario.LlistaMazos.Count >= 1)
            {
                btnMazo1.Content = mazosUsuario.LlistaMazos[0].Nom;
                btnMazo1.Visibility = Visibility.Visible;
            }
            if (mazosUsuario.LlistaMazos.Count >= 2)
            {
                btnMazo2.Content = mazosUsuario.LlistaMazos[1].Nom;
                btnMazo2.Visibility = Visibility.Visible;

            }
            if (mazosUsuario.LlistaMazos.Count >= 3)
            {
                btnMazo3.Content = mazosUsuario.LlistaMazos[2].Nom;
                btnMazo3.Visibility = Visibility.Visible;

            }
        }
    }
}
