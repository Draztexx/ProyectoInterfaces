using System;
using System.Collections;
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
    /// Lógica de interacción para Preguntas.xaml
    /// </summary>
    ///
    public partial class Preguntas : Window
    {
        DataTable todo;
        int idtema;
        int cont = 0;
        int pre = 0;
        Boolean seguir = true;
        string[] lista;
        ArrayList preguntas = new ArrayList();
        int puntos=0;
        public Preguntas(DataTable x)
        {
            todo = x;
            pre= todo.Rows.Count;
            lista = new string[3];
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                if (todo.Rows.Count > 0)
                {

                    Pregunta.Content = todo.Rows[cont]["pregunta"].ToString();
                    lista[0] = todo.Rows[cont]["respuestav"].ToString();
                    lista[1] = todo.Rows[cont]["respuesta2"].ToString();
                    lista[2] = todo.Rows[cont]["respuesta3"].ToString();

                    AleatorioArray(lista);

                    PRE1.Content = lista[0];
                    PRE2.Content = lista[1];
                    PRE3.Content = lista[2];

                    PRE1.IsChecked = false;
                    PRE2.IsChecked = false;
                    PRE3.IsChecked = false;


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

            if (cont == (pre - 1))
            {
                seguir = false;
            }

        }
        static void AleatorioArray<T>(T[] array)
        {
            Random random = new Random();

            // Obtener la longitud del array
            int n = array.Length;

            // Aplicar el algoritmo de Fisher-Yates
            for (int i = n - 1; i > 0; i--)
            {
                // Generar un índice aleatorio entre 0 e i (incluido)
                int indiceAleatorio = random.Next(0, i + 1);

                // Intercambiar los elementos en las posiciones i e indiceAleatorio
                T temp = array[i];
                array[i] = array[indiceAleatorio];
                array[indiceAleatorio] = temp;
            }
        }

        private void Siguiente_Click(object sender, RoutedEventArgs e)
        {
            
            if (seguir && check())
            {
                
                if(respuesta()== todo.Rows[cont]["respuestav"].ToString())
                {
                    puntos++;
                    cont++;
                }
                else
                {
                    cont++;
                    preguntas.Add(respuesta());
                }
                CargarDatos();
            }
            else
            {
                
            }

        }

        private String respuesta()
        {
            String result="";
            if (PRE1.IsChecked.HasValue && PRE1.IsChecked.Value)
            {
                result = PRE1.Content.ToString();
            }
            if (PRE2.IsChecked.HasValue && PRE1.IsChecked.Value)
            {
                result = PRE2.Content.ToString();
            }
            if (PRE3.IsChecked.HasValue && PRE1.IsChecked.Value)
            {
                result = PRE3.Content.ToString();
            }

            return result;

        }

        private Boolean check()
        {
            
            if (PRE1.IsChecked.HasValue && PRE1.IsChecked.Value)
            {
                return true;
            }
            if (PRE2.IsChecked.HasValue && PRE2.IsChecked.Value)
            {
                return true;
            }
            if (PRE3.IsChecked.HasValue && PRE3.IsChecked.Value)
            {
                return true;
            }

            return false; 

        }
    }
}
//<ListBox ItemsSource="{Binding MiArrayList}" />