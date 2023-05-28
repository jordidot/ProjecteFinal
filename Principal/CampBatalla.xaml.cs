using Principal.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Principal
{
    /// <summary>
    /// Finestra Camp de batalla
    /// </summary>
    public partial class CampBatalla : Window
    {
        //Atributs
        private Partida partida;
        /// <summary>
        /// Carta Seleccionada de l'Usuari
        /// </summary>
        public Carta CartaSeleccionadaUsuari { get; set; }
        /// <summary>
        /// Carta Seleccionada del Bot
        /// </summary>
        public Carta CartaSeleccionadaBot { get; set; }
        /// <summary>
        /// Id de la carta seleccionada del Bot
        /// </summary>
        public int IdCartaSelecciondaBot { get; set; }
        /// <summary>
        /// Habilitats seleccionades
        /// </summary>
        public Habilitats HabilitatsSeleccionades { get; set; }
        /// <summary>
        /// Torns de la partida
        /// </summary>
        public int Turnos { get; set; }
        /// <summary>
        /// Boolea si ha clickat en començar partida.
        /// </summary>
        public bool HaComençatPartida { get; set; }
        /// <summary>
        /// Totes les cartes
        /// </summary>
        public Cartes TotesCartes { get; set; }
        /// <summary>
        /// Tots els usuaris
        /// </summary>
        public Usuaris TotsUsuaris { get; set; }
        /// <summary>
        /// Totes les partides
        /// </summary>
        public Partides TotesPartides { get; set; }
        /// <summary>
        /// Totes les habilitats
        /// </summary>
        public Habilitats TotesHabilitats { get; set; }
        /// <summary>
        /// Constructor del camp de batalla
        /// </summary>
        /// <param name="partida"></param>
        /// <param name="cartes"></param>
        /// <param name="usuaris"></param>
        /// <param name="partides"></param>
        /// <param name="habilitats"></param>
        public CampBatalla(Partida partida, Cartes cartes,Usuaris usuaris,Partides partides,Habilitats habilitats)
        {
            InitializeComponent();
            this.TotsUsuaris = usuaris;
            this.TotesPartides = partides;
            this.TotesHabilitats = habilitats;
            this.TotesCartes = cartes;
            HaComençatPartida = false;
            //Inicialitzo els torna a 40
            Turnos = 40;
            HabilitatsSeleccionades = new();
            this.partida = partida;
            btnComençaPartida.Visibility = Visibility.Visible;
            lblMazoBotNom.Content = "Cartes " +partida.Bot.Nom;
            lblMazoUsuariNom.Content = "Cartes " + partida.Usuari.Alias;
            lblVidaBotNom.Content = "Vida " + partida.Bot.Nom;
            lblVidaUsuariNom.Content = "Vida " + partida.Usuari.Alias;
            imgPerfilBot.ImageSource = new BitmapImage(new Uri(partida.Bot.Imatge));
            imgPerfilUsuari.ImageSource = new BitmapImage(new Uri(partida.Usuari.ImatgePerfil));
        }
        //Mètodes
        /// <summary>
        /// Metode de la finestra CampBatalla que guarda la partida a la base de dades i l'assigna a l'usuari un cop tanca la finestra.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void campBatallaWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Partides partides = new(this.TotsUsuaris);
            partides.AfegirPartida(this.TotesCartes, this.partida);
            this.partida.Usuari.Partides.LlistaPartides.Add(this.partida);
            this.TotesPartides.LlistaPartides.Add(this.partida);
            this.partida.Usuari.Partides.Quantitat++;
            Home home = new(this.partida.Usuari, this.TotesCartes,this.TotesHabilitats,this.TotesPartides,this.TotsUsuaris);
            home.Show();
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que Carrega les cartes del bot i de l'usuari.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void gridCampBatalla_Loaded(object sender, RoutedEventArgs e)
        {
            // Miro cuants mazos té l'usuari i depenent dels mazos vaig fent visibles els botons.
            if (partida.Usuari.Mazos.LlistaMazos.Count == 1 && partida.Bot.Cartes.LlistaCartes.Count == 5)
            {
                //Cartes del usuari
                lstBoxCartaUsuari1.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Imatge));
                lstBoxCartaUsuari2.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Imatge));
                lstBoxCartaUsuari3.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Imatge));
                lstBoxCartaUsuari4.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Imatge));
                lstBoxCartaUsuari5.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Imatge));
                //Cartes del bot
                lstBoxCartaBot1.Items.Add(CrearImatgeCarta(partida.Bot.Cartes.LlistaCartes[0].Imatge));
                lstBoxCartaBot2.Items.Add(CrearImatgeCarta(partida.Bot.Cartes.LlistaCartes[1].Imatge));
                lstBoxCartaBot3.Items.Add(CrearImatgeCarta(partida.Bot.Cartes.LlistaCartes[2].Imatge));
                lstBoxCartaBot4.Items.Add(CrearImatgeCarta(partida.Bot.Cartes.LlistaCartes[3].Imatge));
                lstBoxCartaBot5.Items.Add(CrearImatgeCarta(partida.Bot.Cartes.LlistaCartes[4].Imatge));
            }
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que crea un objecte Imatge de la carta.
        /// </summary>
        /// <param name="path">Rep el path de l'imatge com a parametre.</param>
        /// <returns>Retorna la Imatge creada amb el BitMapImage.</returns>
        public Image CrearImatgeCarta(string path)
        {
            Image imageCarta = new();
            imageCarta.Source = new BitmapImage(new Uri(path));
            imageCarta.Width = 150;
            imageCarta.Height = 150;
            return imageCarta;
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que carrega la Carta 1 de l'usuari a la carta principal.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void lstBoxCartaUsuari1_GotFocus(object sender, RoutedEventArgs e)
        {
            lstBoxCartaUsuariSeleccionada.Items.Clear();
            lstBoxCartaUsuariSeleccionada.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Imatge));
            this.CartaSeleccionadaUsuari = partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0];
            this.HabilitatsSeleccionades.LListahabilitats.Clear();
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Habilitats.LListahabilitats[0]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Habilitats.LListahabilitats[1]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Habilitats.LListahabilitats[2]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Habilitats.LListahabilitats[3]);
            if (HaComençatPartida)
                JugarPartida();
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que carrega la Carta 2 de l'usuari a la carta principal.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void lstBoxCartaUsuari2_GotFocus(object sender, RoutedEventArgs e)
        {
            lstBoxCartaUsuariSeleccionada.Items.Clear();
            lstBoxCartaUsuariSeleccionada.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Imatge));
            this.CartaSeleccionadaUsuari = partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1];
            this.HabilitatsSeleccionades.LListahabilitats.Clear();
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Habilitats.LListahabilitats[4]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Habilitats.LListahabilitats[5]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Habilitats.LListahabilitats[6]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Habilitats.LListahabilitats[7]);
            if (HaComençatPartida)
                JugarPartida();
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que carrega la Carta 3 de l'usuari a la carta principal.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void lstBoxCartaUsuari3_GotFocus(object sender, RoutedEventArgs e)
        {
            lstBoxCartaUsuariSeleccionada.Items.Clear();
            lstBoxCartaUsuariSeleccionada.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Imatge));
            this.CartaSeleccionadaUsuari = partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2];
            this.HabilitatsSeleccionades.LListahabilitats.Clear();
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Habilitats.LListahabilitats[8]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Habilitats.LListahabilitats[9]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Habilitats.LListahabilitats[10]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Habilitats.LListahabilitats[11]);
            if (HaComençatPartida)
                JugarPartida();
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que carrega la Carta 4 de l'usuari a la carta principal.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void lstBoxCartaUsuari4_GotFocus(object sender, RoutedEventArgs e)
        {
            lstBoxCartaUsuariSeleccionada.Items.Clear();
            lstBoxCartaUsuariSeleccionada.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Imatge));
            this.CartaSeleccionadaUsuari = partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3];
            this.HabilitatsSeleccionades.LListahabilitats.Clear();
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Habilitats.LListahabilitats[12]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Habilitats.LListahabilitats[13]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Habilitats.LListahabilitats[14]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Habilitats.LListahabilitats[15]);
            if (HaComençatPartida)
                JugarPartida();
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que carrega la Carta 5 de l'usuari a la carta principal.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void lstBoxCartaUsuari5_GotFocus(object sender, RoutedEventArgs e)
        {
            lstBoxCartaUsuariSeleccionada.Items.Clear();
            lstBoxCartaUsuariSeleccionada.Items.Add(CrearImatgeCarta(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Imatge));
            this.CartaSeleccionadaUsuari = partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4];
            this.HabilitatsSeleccionades.LListahabilitats.Clear();
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Habilitats.LListahabilitats[16]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Habilitats.LListahabilitats[17]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Habilitats.LListahabilitats[18]);
            this.HabilitatsSeleccionades.LListahabilitats.Add(partida.Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Habilitats.LListahabilitats[19]);
            if (HaComençatPartida)
                JugarPartida();
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que fa que la partida s'iniciï.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void btnComençaPartida_Click(object sender, RoutedEventArgs e)
        {

            HaComençatPartida = true;
            lstBoxActivitatPartida.Visibility = Visibility.Visible;
            btnComençaPartida.Visibility = Visibility.Hidden;
            btnComençaPartidaSeleccionar.Visibility = Visibility.Hidden;
            lblEstatPartida.Visibility = Visibility.Visible;
            ContinuarPartida();
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que fa calculs de la partida i que inicia les habilitats random del bot un cop ataques.(Va restant els torns també)
        /// </summary>
        private void ContinuarPartida()
        {
            if (this.Turnos != 0)
            {
                if (int.Parse(lblVidaUsuari.Content.ToString()) <= 0)
                {
                    lblVidaUsuari.Content = "0";
                    lblVidaBot.Content = "0";
                    AmagarBotons("Has perdut la partida, sumes 0 punts! Loser!");
                    this.partida.EstatPartida = "Perduda";
                }
                else if (int.Parse(lblVidaBot.Content.ToString()) <= 0)
                {
                    lblVidaBot.Content = "0";
                    lblVidaUsuari.Content = "0";
                    AmagarBotons("Has guanyat la partida, sumes 400 punts! Winner!");
                    this.partida.EstatPartida = "Guanyada";
                    this.partida.Usuari.Punts += 400;
                }
                else
                {
                    if (lstBoxCartaUsuariSeleccionada.Items.Count == 0)
                    {
                        lblEstatPartida.Content = "Selecciona una de le teves cartes";
                        lstBoxActivitatPartida.Visibility = Visibility.Hidden;
                        btnComençaPartidaSeleccionar.Visibility = Visibility.Visible;
                    }
                    else if (lstBoxCartaUsuariSeleccionada.Items.Count == 1)
                    {
                        btnComençaPartidaSeleccionar.Visibility = Visibility.Hidden;
                        lblContadorTemps.Visibility = Visibility.Visible;
                        JugarPartida();
                        //Seleccionar carta del bot
                        lstBoxCartaBotSeleccionada.Items.Clear();
                        Random random = new();
                        IdCartaSelecciondaBot = random.Next(0, partida.Bot.Cartes.LlistaCartes.Count);
                        CartaSeleccionadaBot = partida.Bot.Cartes.LlistaCartes[IdCartaSelecciondaBot];
                        lstBoxCartaBotSeleccionada.Items.Add(CrearImatgeCarta(CartaSeleccionadaBot.Imatge));
                    }
                    Turnos--;
                }
            }
            else
            {
                if (int.Parse(lblVidaUsuari.Content.ToString()) > 0 && int.Parse(lblVidaBot.Content.ToString()) == 0)
                {
                    AmagarBotons("Has guanyat la partida, sumes 400 punts!");
                    this.partida.EstatPartida = "Guanyada";
                    this.partida.Usuari.Punts += 400;
                }
                else if (int.Parse(lblVidaBot.Content.ToString()) > 0 && int.Parse(lblVidaUsuari.Content.ToString()) == 0)
                {
                    AmagarBotons("En "+this.partida.Bot.Nom+" ha guanyat la partida, sumes 0 punts!");
                    this.partida.EstatPartida = "Perduda";
                }
                else if (int.Parse(lblVidaBot.Content.ToString()) == 0 && int.Parse(lblVidaUsuari.Content.ToString()) == 0)
                {
                    AmagarBotons("Has perdut no has pogut vencer a "+this.partida.Bot.Nom +" , sumes 0 punts!");
                    this.partida.EstatPartida = "Perduda";
                }
            }
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que va mostrant les diferents habilitats de les cartes un cop es van seleccionant, també inciia els torns.
        /// </summary>
        private void JugarPartida()
        {
            lblContadorTemps.Content = "Torns totals: " + Turnos.ToString();
            lblEstatPartida.Content = "";
            btnHabilitat1.Visibility = Visibility.Visible;
            lblDanyHabilitat1.Visibility = Visibility.Visible;
            btnHabilitat1.Content = HabilitatsSeleccionades.LListahabilitats[0].Nom;
            btnHabilitat2.Visibility = Visibility.Visible;
            lblDanyHabilitat2.Visibility = Visibility.Visible;
            btnHabilitat2.Content = HabilitatsSeleccionades.LListahabilitats[1].Nom;
            btnHabilitat3.Visibility = Visibility.Visible;
            lblDanyHabilitat3.Visibility = Visibility.Visible;
            btnHabilitat3.Content = HabilitatsSeleccionades.LListahabilitats[2].Nom;
            btnHabilitat4.Visibility = Visibility.Visible;
            lblDanyHabilitat4.Visibility = Visibility.Visible;
            btnHabilitat4.Content = HabilitatsSeleccionades.LListahabilitats[3].Nom;
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que resta la vida al bot de l'habilitat 1 i fa que el bot t'ataqui, va carregant les dades al listbox de el que va succeiint.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void btnHabilitat1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HabilitatsSeleccionades.LListahabilitats[0].Cooldown > 0)
                {
                    Random random = new();
                    int sort = random.Next(1, 3);
                    if (sort == 1)
                    {
                        lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Usuari.Alias);
                        MessageBox.Show(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[0].Nom + " li has tret a " + partida.Bot.Nom + " 25 punts de vida.");
                        lstBoxActivitatPartida.Items.Add(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[0].Nom + " li has tret a " + partida.Bot.Nom + " 25 punts de vida.");
                        lblVidaBot.Content = (int.Parse(lblVidaBot.Content.ToString()) - 25).ToString();
                        HabilitatRandomBot();
                    }
                    else
                    {
                        HabilitatRandomBot();
                        lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Usuari.Alias);
                        MessageBox.Show(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[0].Nom + " li has tret a " + partida.Bot.Nom + " 25 punts de vida.");
                        lstBoxActivitatPartida.Items.Add(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[0].Nom + " li has tret a " + partida.Bot.Nom + " 25 punts de vida.");
                        lblVidaBot.Content = (int.Parse(lblVidaBot.Content.ToString()) - 25).ToString();
                    }
                    HabilitatsSeleccionades.LListahabilitats[0].Cooldown--;
                    ContinuarPartida();
                }
                else
                {
                    MessageBox.Show("No pots utilitzar més aquesta habilitat.");
                }
            }
            catch (Exception ex)
            {
                lstBoxActivitatPartida.Items.Clear();
                lblVidaBot.Content = "1500";
                lstBoxActivitatPartida.Visibility = Visibility.Hidden;
                MessageBox.Show("No has començat la partida! Dona-li click al botó de 'Començar la partida'");
            }
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que resta la vida al bot de l'habilitat 2 i fa que el bot t'ataqui, va carregant les dades al listbox de el que va succeiint.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void btnHabilitat2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HabilitatsSeleccionades.LListahabilitats[1].Cooldown > 0)
                {
                    Random random = new();
                    int sort = random.Next(1, 3);
                    if (sort == 1)
                    {
                        lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Usuari.Alias);
                        MessageBox.Show(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[1].Nom + " li has tret a " + partida.Bot.Nom + " 50 punts de vida.");
                        lstBoxActivitatPartida.Items.Add(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[1].Nom + " li has tret a " + partida.Bot.Nom + " 50 punts de vida.");
                        lblVidaBot.Content = (int.Parse(lblVidaBot.Content.ToString()) - 50).ToString();
                        HabilitatRandomBot();
                    }
                    else
                    {
                        HabilitatRandomBot();
                        lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Usuari.Alias);
                        MessageBox.Show(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[1].Nom + " li has tret a " + partida.Bot.Nom + " 50 punts de vida.");
                        lstBoxActivitatPartida.Items.Add(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[1].Nom + " li has tret a " + partida.Bot.Nom + " 50 punts de vida.");
                        lblVidaBot.Content = (int.Parse(lblVidaBot.Content.ToString()) - 50).ToString();
                    }
                    HabilitatsSeleccionades.LListahabilitats[1].Cooldown--;
                    ContinuarPartida();
                }
                else
                {
                    MessageBox.Show("No pots utilitzar més aquesta habilitat.");
                }

            }
            catch (Exception ex)
            {
                lstBoxActivitatPartida.Items.Clear();
                lblVidaBot.Content = "1500";
                lstBoxActivitatPartida.Visibility = Visibility.Hidden;
                MessageBox.Show("No has començat la partida! Dona-li click al botó de 'Començar la partida'");
            }
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que resta la vida al bot de l'habilitat 3 i fa que el bot t'ataqui, va carregant les dades al listbox de el que va succeiint.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void btnHabilitat3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HabilitatsSeleccionades.LListahabilitats[2].Cooldown > 0)
                {
                    Random random = new();
                    int sort = random.Next(1, 3);
                    if (sort == 1)
                    {
                        lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Usuari.Alias);
                        MessageBox.Show(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[2].Nom + " li has tret a " + partida.Bot.Nom + " 75 punts de vida.");
                        lstBoxActivitatPartida.Items.Add(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[2].Nom + " li has tret a " + partida.Bot.Nom + " 75 punts de vida.");
                        lblVidaBot.Content = (int.Parse(lblVidaBot.Content.ToString()) - 75).ToString();
                        HabilitatRandomBot();
                    }
                    else
                    {
                        HabilitatRandomBot();
                        lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Usuari.Alias);
                        MessageBox.Show(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[2].Nom + " li has tret a " + partida.Bot.Nom + " 75 punts de vida.");
                        lstBoxActivitatPartida.Items.Add(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[2].Nom + " li has tret a " + partida.Bot.Nom + " 75 punts de vida.");
                        lblVidaBot.Content = (int.Parse(lblVidaBot.Content.ToString()) - 75).ToString();
                    }
                    HabilitatsSeleccionades.LListahabilitats[2].Cooldown--;
                    ContinuarPartida();
                }
                else
                {
                    MessageBox.Show("No pots utilitzar més aquesta habilitat.");
                }

            }
            catch (Exception ex)
            {
                lstBoxActivitatPartida.Items.Clear();
                lblVidaBot.Content = "1500";
                lstBoxActivitatPartida.Visibility = Visibility.Hidden;
                MessageBox.Show("No has començat la partida! Dona-li click al botó de 'Començar la partida'");
            }
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que resta la vida al bot de l'habilitat 4 i fa que el bot t'ataqui, va carregant les dades al listbox de el que va succeiint.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void btnHabilitat4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HabilitatsSeleccionades.LListahabilitats[3].Cooldown > 0)
                {
                    Random random = new();
                    int sort = random.Next(1, 3);
                    if (sort == 1)
                    {
                        lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Usuari.Alias);
                        MessageBox.Show(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[3].Nom + " li has tret a " + partida.Bot.Nom + " 125 punts de vida.");
                        lstBoxActivitatPartida.Items.Add(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[3].Nom + " li has tret a " + partida.Bot.Nom + " 125 punts de vida.");
                        lblVidaBot.Content = (int.Parse(lblVidaBot.Content.ToString()) - 125).ToString();
                        HabilitatRandomBot();
                    }
                    else
                    {
                        HabilitatRandomBot();
                        lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Usuari.Alias);
                        MessageBox.Show(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[3].Nom + " li has tret a " + partida.Bot.Nom + " 125 punts de vida.");
                        lstBoxActivitatPartida.Items.Add(partida.Usuari.Alias + " ha utilitzat " + HabilitatsSeleccionades.LListahabilitats[3].Nom + " li has tret a " + partida.Bot.Nom + " 125 punts de vida.");
                        lblVidaBot.Content = (int.Parse(lblVidaBot.Content.ToString()) - 125).ToString();

                    }
                    HabilitatsSeleccionades.LListahabilitats[3].Cooldown--;
                    ContinuarPartida();
                }
                else
                {
                    MessageBox.Show("No pots utilitzar més aquesta habilitat.");
                }
            }
            catch (Exception ex)
            {
                lstBoxActivitatPartida.Items.Clear();
                lblVidaBot.Content = "1500";
                lstBoxActivitatPartida.Visibility = Visibility.Hidden;
                MessageBox.Show("No has començat la partida! Dona-li click al botó de 'Començar la partida'");
            }
        }
        /// <summary>
        /// Metode de la finestra CampBatalla que fa els calculs de la habilitat Random que utilitza el bot de la carta que té seleccionada.
        /// </summary>
        private void HabilitatRandomBot()
        {
            lstBoxActivitatPartida.Items.Add("TORN DE: " + partida.Bot.Nom);
            Random random = new();
            int idHabilitat = random.Next(0, 4);
            if (idHabilitat == 0)
            {
                MessageBox.Show(partida.Bot.Nom + " ha utilitzat " + CartaSeleccionadaBot.Habilitats.LListahabilitats[idHabilitat].Nom + " li ha tret a " + partida.Usuari.Alias + " 25 punts de vida.");
                lstBoxActivitatPartida.Items.Add(partida.Bot.Nom + " ha utilitzat " + CartaSeleccionadaBot.Habilitats.LListahabilitats[idHabilitat].Nom + " li ha tret a " + partida.Usuari.Alias + " 25 punts de vida.");
                lblVidaUsuari.Content = (int.Parse(lblVidaUsuari.Content.ToString()) - 25).ToString();
            }
            else if (idHabilitat == 1)
            {
                MessageBox.Show(partida.Bot.Nom + " ha utilitzat " + CartaSeleccionadaBot.Habilitats.LListahabilitats[idHabilitat].Nom + " li ha tret a " + partida.Usuari.Alias + " 50 punts de vida.");
                lstBoxActivitatPartida.Items.Add(partida.Bot.Nom + " ha utilitzat " + CartaSeleccionadaBot.Habilitats.LListahabilitats[idHabilitat].Nom + " li ha tret a " + partida.Usuari.Alias + " 50 punts de vida.");
                lblVidaUsuari.Content = (int.Parse(lblVidaUsuari.Content.ToString()) - 50).ToString();
            }
            else if (idHabilitat == 2)
            {
                MessageBox.Show(partida.Bot.Nom + " ha utilitzat " + CartaSeleccionadaBot.Habilitats.LListahabilitats[idHabilitat].Nom + " li ha tret a " + partida.Usuari.Alias + " 75 punts de vida.");
                lstBoxActivitatPartida.Items.Add(partida.Bot.Nom + " ha utilitzat " + CartaSeleccionadaBot.Habilitats.LListahabilitats[idHabilitat].Nom + " li ha tret a " + partida.Usuari.Alias + " 75 punts de vida.");
                lblVidaUsuari.Content = (int.Parse(lblVidaUsuari.Content.ToString()) - 75).ToString();
            }
            else if (idHabilitat == 3)
            {
                MessageBox.Show(partida.Bot.Nom + " ha utilitzat " + CartaSeleccionadaBot.Habilitats.LListahabilitats[idHabilitat].Nom + " li ha tret a " + partida.Usuari.Alias + " 125 punts de vida.");
                lstBoxActivitatPartida.Items.Add(partida.Bot.Nom + " ha utilitzat " + CartaSeleccionadaBot.Habilitats.LListahabilitats[idHabilitat].Nom + " li ha tret a " + partida.Usuari.Alias + " 125 punts de vida.");
                lblVidaUsuari.Content = (int.Parse(lblVidaUsuari.Content.ToString()) - 125).ToString();
            }
        }
        /// <summary>
        /// Métode que amaga els botons un cop acabada la partida i mostrá si has guanyat o perdut.
        /// </summary>
        /// <param name="resultat">String amb el resultat de si has guanyat o has perdut.</param>
        private void AmagarBotons(string resultat)
        {
            lblEstatPartida.Content = resultat;
            lblEstatPartida.Foreground = Brushes.Green;
            lblEstatPartida.FontSize = 50;
            lstBoxActivitatPartida.Visibility = Visibility.Hidden;
            btnComençaPartidaSeleccionar.Visibility = Visibility.Hidden;
            btnHabilitat1.Visibility = Visibility.Hidden;
            btnHabilitat2.Visibility = Visibility.Hidden;
            btnHabilitat3.Visibility = Visibility.Hidden;
            btnHabilitat4.Visibility = Visibility.Hidden;
        }
    }
}

