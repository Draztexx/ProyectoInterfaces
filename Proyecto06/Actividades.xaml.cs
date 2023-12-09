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
    /// Lógica de interacción para Actividades.xaml
    /// </summary>
    public partial class Actividades : Window
    {
        DataTable todo;
        int cont = 0;
        int act = 0;
        Boolean seguir = true;
        public Actividades( DataTable x)
        {
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
                Felicidades felicidades = new Felicidades(act,todo);
                felicidades.Show(); this.Close();
            }
            
        }

        private void BTEnviar_Click(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
