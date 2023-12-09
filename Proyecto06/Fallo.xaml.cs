using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
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
    /// Lógica de interacción para Fallo.xaml
    /// </summary>
    public partial class Fallo : Window
    {
        List<string> preguntas;
        int cont = 0;
        DataTable todo;
        Boolean pasa = false;
        int idUsuario;
        
        public Fallo(int x, List<string> y, DataTable z,int a)

        {
            idUsuario = a;
            todo = z;
            preguntas = y;
            cont = x;
            if (cont >2)
            {
                pasa = true;
            }
            InitializeComponent();
            CargarDatos();
            
        }
            
        private void CargarDatos()
        {
            if (!pasa) { 
            Ltitulo.Content = "El numero de preguntas acertadas: "+cont;
                Accion.Content = "Repetir Cuestionario";
            }else{
            Ltitulo.Content = "El numero de preguntas acertadas: " + cont+" Tema Superado";
                Accion.Content = "Ver Ranquing";
            }
            Listafallos.ItemsSource =preguntas;
            

        }

        private void Accion_Click(object sender, RoutedEventArgs e)
        {
            if (!pasa)
            {
                Preguntas preguntas = new Preguntas(todo,idUsuario);
                preguntas.Show(); this.Close();
            }
            else
            {
                BDConect BD = new BDConect();
                BD.Open();
                String Consulta = "INSERT INTO usuario_tema VALUES (" +idUsuario+ "," + int.Parse(todo.Rows[0]["tema"].ToString()) + "," +(cont*2) + ",'SI')";
                BD.Insert(Consulta);
                BD.Close();
                Consulta = "SELECT * FROM users WHERE id = "+idUsuario +"";
                DataTable result = BD.Select(Consulta);
                int puntos = int.Parse(result.Rows[0]["puntos"].ToString());
                puntos += (cont * 2);
                Consulta = "UPDATE `users` SET `puntos` = "+puntos+" WHERE `id`= "+idUsuario+"; ";
                BD.Insert(Consulta);
                BD.Close();


                Ranquing ranquing = new Ranquing();
                ranquing.Show(); this.Close();
            }
        }
    }
}
