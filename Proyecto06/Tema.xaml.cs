using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para Tema.xaml
    /// </summary>
    
    public partial class Tema : Window
    {
        DataTable tema;
        int tiempo;
        BDConect BD;
        int idtema;

        public Tema(DataTable x)
        {
            InitializeComponent();
            tema= x;
            BD = new BDConect();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                if (tema.Rows.Count > 0)
                {
                    idtema = int.Parse(tema.Rows[0]["id"].ToString());
                    TBtitulo.Text = tema.Rows[0]["nombretema"].ToString();
                    Contenido.Text= tema.Rows[0]["descripcion"].ToString();
                    MIN.Text = tema.Rows[0]["tiempo"].ToString() ;
                    tiempo= int.Parse(tema.Rows[0]["tiempo"].ToString());
                    String url = tema.Rows[0]["contenido"].ToString();
                    MiNavegadorWeb.Source= new Uri(url);
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
        }

        private void BTActividades_Click(object sender, RoutedEventArgs e)
        {
            
            string consulta = "SELECT * FROM actividades WHERE tema="+idtema+" AND tipo NOT LIKE 'P'";
            DataTable dt = BD.Select(consulta);
            Actividades actividades = new Actividades(dt);
            actividades.Show(); this.Close();
        }

        private void BTVolver_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    

}
