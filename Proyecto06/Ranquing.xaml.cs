using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Ranquing.xaml
    /// </summary>
    public partial class Ranquing : Window
    {
       
        BDConect BD;
        public Ranquing()
        {
            BD = new BDConect();
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try 
            {
                string consulta = "SELECT username,puntos FROM users WHERE rol LIKE 'user' ORDER BY puntos DESC";
                DataTable dt = BD.Select(consulta);
                BD.Close();
                lvRanking.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void Accion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
