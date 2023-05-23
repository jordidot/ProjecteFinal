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
    /// Lógica de interacción para CampBatalla.xaml
    /// </summary>
    public partial class CampBatalla : Window
    {
        //Atributs
        private Partida partida;
        public Carta CartaSeleccionadaUsuari { get; set; }
        public Carta CartaSeleccionadaBot { get; set; }
        public int IdCartaSelecciondaBot { get; set; }
        public Habilitats HabilitatsSeleccionades { get; set; }
        public int Turnos { get; set; }
        public bool HaComençatPartida { get; set; }
        public Cartes TotesCartes { get; set; }
        public Usuaris TotsUsuaris { get; set; }
        public Partides TotesPartides { get; set; }
        public Habilitats TotesHabilitats { get; set; }
        /// <summary>
        /// Constructor del camp de batalla que rep l'usuari i la partida.
        /// </summary>
        /// <param name="usuari">Usuari que juga.</param>
        /// <param name="partida">Dades de la partida, cartes, etc..</param>
        public CampBatalla(Partida partida, Cartes cartes,Usuaris usuaris,Partides partides,Habilitats habilitats)
        {
            InitializeComponent();
            this.TotsUsuaris = usuaris;
            this.TotesPartides = partides;
            this.TotesHabilitats = habilitats;
            this.TotesCartes = cartes;
            HaComençatPartida = false;
            Turnos = 40;
            HabilitatsSeleccionades = new();
            this.partida = partida;
            btnComençaPartida.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// Metode que s'executa quan es tanca la finestra.
        /// </summary>
        /// <param name="sender">Objecte que rep per parametre</param>
        /// <param name="e">Event intern que relitza per tancar la finestra.</param>
        private void campBatallaWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Partides partides = new();
            partides.AfegirPartida(this.TotesCartes, this.partida);
            this.partida.Usuari.Partides.LlistaPartides.Add(this.partida);
            this.TotesPartides.LlistaPartides.Add(this.partida);
            this.partida.Usuari.Partides.Quantitat++;
            Home home = new(this.partida.Usuari, this.TotesCartes,this.TotesHabilitats,this.TotesPartides,this.TotsUsuaris);
            home.Show();
        }

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
        /// Creo un objecte Imatge de la carta.
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

        //CARTES DEL USUARI AL SELCCIONAR

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

        private void btnComençaPartida_Click(object sender, RoutedEventArgs e)
        {

            HaComençatPartida = true;
            lstBoxActivitatPartida.Visibility = Visibility.Visible;
            btnComençaPartida.Visibility = Visibility.Hidden;
            btnComençaPartidaSeleccionar.Visibility = Visibility.Hidden;
            lblEstatPartida.Visibility = Visibility.Visible;
            ContinuarPartida();
        }
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

