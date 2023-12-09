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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto05
{
    /// <summary>
    /// Lógica de interacción para Actividades.xaml
    /// </summary>
    public partial class Actividades : Window
    {
        DataTable todo;
        int cont = 0;
        int act = 0;
        Boolean seguir = true;
        int idUsuario;
        public Actividades( DataTable x,int y)
        {
            idUsuario = y;
            InitializeComponent();
            todo = x;
            act = todo.Rows.Count;
            CargarDatos();
        }

        private void CargarDatos() { 
            try
            {
                if (todo.Rows.Count > 0)
                {
                    String contenido=todo.Rows[cont]["pregunta"].ToString();
                    Contenido.Text = "Actividad :"+ (cont + 1) +" "+contenido;
                    link.NavigateUri = new Uri(todo.Rows[cont]["respuestav"].ToString());
                    link.Inlines.Clear();
                    link.Inlines.Add(new Run("VISITA ESTE ENLACE ANTES DE REALIZAR LA ACTIVIDAD"));

                }
                else
                {
                    //error

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }

            if (cont == (act-1))
            {
                seguir = false;
            }
            
        }

        private void BTSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (seguir)
            {
                cont++;
                CargarDatos();
            }
            else
            {
                Felicidades felicidades = new Felicidades(act,todo,idUsuario);
                felicidades.Show(); this.Close();
            }
            
        }

        private void BTEnviar_Click(object sender, RoutedEventArgs e)
        {
            string enlace = "https://www.salesianospizarrales.com/"; 
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(enlace) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el enlace: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {e.Uri.AbsoluteUri}") { CreateNoWindow = true }); e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el enlace: " + ex.Message);
            }
        }
    }
}
