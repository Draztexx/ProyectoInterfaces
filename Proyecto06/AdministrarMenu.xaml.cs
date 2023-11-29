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

namespace Proyecto05
{
    /// <summary>
    /// Lógica de interacción para AdministrarMenu.xaml
    /// </summary>
    public partial class AdministrarMenu : Window
    {
        MainWindow mainWindowRef;
        public AdministrarMenu(MainWindow x)
        {
            InitializeComponent();
            mainWindowRef = x;
            Closing += AdministrarMenu_Cerrar;
        }

        private void Alumno_Click(object sender, RoutedEventArgs e)
        {
            Administrar ad = new Administrar(this);
            ad.Show();
            this.Hide();
        }

        private void Temas_Click(object sender, RoutedEventArgs e)
        {
            AdministrarTemas ad = new AdministrarTemas(this);
            this.Hide();
            ad.Show();

        }

        private void AdministrarMenu_Cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindowRef.Show();
        }



    }
}
