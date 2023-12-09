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
using System.Windows.Threading;

namespace Proyecto05
{
    /// <summary>
    /// Lógica de interacción para Tema.xaml
    /// </summary>
    
    public partial class Tema : Window
    {
        DataTable tema;
        int tiempo;
        int seg = 60;
        BDConect BD;
        int idtema;
        int idUsuario;
        DispatcherTimer timer;

        public Tema(DataTable x,int y)
            
        {   
            idUsuario=y;
            InitializeComponent();
            tema= x;
            BD = new BDConect();
            CargarDatos();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Intervalo de actualización (1 segundo en este caso)
            timer.Tick += Timer_Tick;
            timer.Start();

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
            timer.Stop();
            string consulta = "SELECT * FROM actividades WHERE tema=" + idtema + " AND tipo NOT LIKE 'P'";
            DataTable dt = BD.Select(consulta);
            BD.Close();
            if (dt.Rows.Count > 0)
            {
                Actividades actividades = new Actividades(dt, idUsuario);
                actividades.Show(); this.Close();
            }
            else
            {
                consulta = "SELECT * FROM actividades WHERE tema=" + idtema + " AND tipo LIKE 'P'";
                dt = BD.Select(consulta);
                Preguntas preguntas = new Preguntas(dt, idUsuario);
                preguntas.Show(); this.Close();
            }
        }

        private void BTVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Verificar si aún queda tiempo
            if (tiempo > 0 || seg>0)
            {
                if (seg>0)
                {
                    seg--;
                }
                else
                {
                    tiempo--;
                    seg = 60;
                }
                
                MostrarTiempoRestante();
            }
            else
            {
                timer.Stop();
                string consulta = "SELECT * FROM actividades WHERE tema=" + idtema + " AND tipo NOT LIKE 'P'";
                DataTable dt = BD.Select(consulta);
                BD.Close();
                if (dt.Rows.Count > 0) { 
                Actividades actividades = new Actividades(dt, idUsuario);
                actividades.Show(); this.Close();
                }
                else
                {
                    consulta = "SELECT * FROM actividades WHERE tema=" + idtema + " AND tipo LIKE 'P'";
                    dt = BD.Select(consulta);
                    Preguntas preguntas = new Preguntas(dt, idUsuario);
                    preguntas.Show(); this.Close();
                }
            }
        }
        private void MostrarTiempoRestante()
        {
            
            MIN.Text= tiempo+"";
            SEC.Text = seg + "";
            
        }
    }

    

}
