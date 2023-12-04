using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Lógica de interacción para UsuarioMenu.xaml
    /// </summary>
    public partial class UsuarioMenu : Window
    {   
        MainWindow mainWindowref;
        DataTable result;
        public UsuarioMenu(MainWindow x,DataTable y)
        {
            InitializeComponent();
            mainWindowref = x;
            result = y;
            Nombre.Text = result.Rows[0]["username"].ToString();
            Puntuacion.Text ="Puntos: "+result.Rows[0]["puntos"].ToString();

            Closing += UsuarioMenu_Cerrar;
            
        }

        private void BTTemas_Click(object sender, RoutedEventArgs e)
        {
            UsuarioTemas UT= new UsuarioTemas(this,result);
            this.Hide();
            UT.Show();
        }

        private void BTCContraseña_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UsuarioMenu_Cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindowref.Show();
        }
    }
}
