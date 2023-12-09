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
    /// Lógica de interacción para Felicidades.xaml
    /// </summary>
    public partial class Felicidades : Window
    {
        int cont;
        DataTable todo;
        BDConect BD;
        int idUsuario;

        public Felicidades(int x,DataTable y,int z)
        {
            idUsuario = z;
            BD = new BDConect();
            cont = x;
            todo= y;
            InitializeComponent();
            LB01.Content = "Has realizado " + cont + " Actividades. ¡Gracias por participar!";
        }

        private void Preguntas_Click(object sender, RoutedEventArgs e)
        {
            int num=0;
            try {num = int.Parse(todo.Rows[0]["tema"].ToString()); }catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }

            string consulta = "SELECT * FROM actividades WHERE tema=" +num+ " AND tipo LIKE 'P'";
            DataTable dt = BD.Select(consulta);
            Preguntas preguntas = new Preguntas(dt,idUsuario);
            preguntas.Show(); this.Close();
        }
    }
}
