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
        public AfegirMazoExtend(Cartes cartes,Usuari usuari, int id)
        {
            InitializeComponent();
            this.cartes = cartes;
            this.usuari = usuari;
            this.id = id;
        }

        private void btnAfegirNouMazoExtend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mazo mazo = new(this.cartes, txtBoxNomMazo.Text, this.usuari, this.id);
                this.usuari.Mazos.LlistaMazos.Add(mazo);
                MessageBox.Show("Mazo afegit correctament.");
                Home home = new(this.usuari);
                home.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir el mazo.");
            }
            
        }
    }
}
