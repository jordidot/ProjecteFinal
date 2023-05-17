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
    /// Lógica de interacción para AfegirMazoExtend.xaml
    /// </summary>
    public partial class AfegirMazoExtend : Window
    {
        private Cartes cartes;
        private Usuari usuari;
        private int id;
        private AfegirUnNouMazo finestra;
        public AfegirMazoExtend(Cartes cartes,Usuari usuari, int id, AfegirUnNouMazo finestra)
        {
            InitializeComponent();
            this.cartes = cartes;
            this.usuari = usuari;
            this.id = id;
            this.finestra = finestra;
        }
        public Usuari Usuari
        {
            get { return this.usuari; }
            set { this.usuari = value; }
        }
        public Cartes Cartes
        {
            get { return this.cartes; }
            set { this.cartes = value; }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        private void btnAfegirNouMazoExtend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mazo mazo = new(this.Id, this.Cartes, txtBoxNomMazo.Text, this.Usuari);
                this.Usuari.Mazos.AfegirMazoBD(mazo);
                this.Usuari.Mazos.LlistaMazos.Add(mazo);
                MessageBox.Show("Mazo afegit correctament.");
                this.finestra.Close();
                Home home = new(this.usuari);
                home.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir el mazo.");
                this.finestra.Close();
                AfegirUnNouMazo finestraNova = new(this.usuari);
                finestraNova.Show();
                this.Close();
            }
            
        }
    }
}
