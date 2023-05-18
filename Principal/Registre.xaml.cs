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
    /// Lógica de interacción para Registre.xaml
    /// </summary>
    public partial class Registre : Window
    {
        //Constructors
        public Registre()
        {
            InitializeComponent();
        }
        //Métodes 
        /// <summary>
        /// Métode que tanca la finestra actual i obre la finestra del login.
        /// </summary>
        /// <param name="sender">Objecte que rep.</param>
        /// <param name="e">Event intern.</param>
        private void BtntornarLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.Show();
            
        }
    }
}
