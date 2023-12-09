using MySqlConnector;
using System;
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
using System.Windows.Threading;


namespace Proyecto05
{
    /// <summary>
    /// Lógica de interacción para Administrar.xaml
    /// </summary>
    public partial class Administrar : Window
    {
        AdministrarMenu ADref;
        
        BDConect BD;
        int id;
        

        public Administrar(AdministrarMenu x)
        {
            InitializeComponent();
            BD = new BDConect();
            Loaded += MainForm_Load;
            ADref = x;
            Closing += Administrar_Cerrar;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }





        private void CargarDatos()
        {
            try
            {
                string consulta = "SELECT * FROM users WHERE rol LIKE 'user'";

                DataTable dt = BD.Select(consulta);

            

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (string.IsNullOrWhiteSpace(dt.Rows[i]["username"].ToString()) &&
                        string.IsNullOrWhiteSpace(dt.Rows[i]["email"].ToString()) &&
                        string.IsNullOrWhiteSpace(dt.Rows[i]["puntos"].ToString()))
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }

                dataGrid1.ItemsSource = dt.DefaultView;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dataGrid1.SelectedItem;


            if (selectedRow != null)
            {
                

                
                string username= selectedRow["username"].ToString();
                string email = selectedRow["email"].ToString();
                int puntos = int.Parse(selectedRow["puntos"].ToString());

              

                try
                {

                    String consulta2 = "UPDATE users SET  username='"+username+"',puntos ="+puntos+"  WHERE email='"+email+"' ";
                    BD.Insert(consulta2);

                            
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el usuario: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dataGrid1.SelectedItem;


            if (selectedRow != null)
            {

                string email = selectedRow["email"].ToString();

                try
                {

                    string consulta = "DELETE FROM users WHERE email LIKE '" + email + "'";
                    BD.Insert(consulta);

                    var dataView = (DataView)dataGrid1.ItemsSource;

                    // Buscar la fila en la DataView
                    DataRowView rowToDelete = dataView.Cast<DataRowView>().FirstOrDefault(r => r.Row == selectedRow.Row);
                    if (rowToDelete != null)
                    {
                        // Eliminar la fila de la DataView
                        dataView.Table.Rows.Remove(rowToDelete.Row);
                    }
                    MessageBox.Show("Se ha eliminado el usuario");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                }
            }
        }

        private void Administrar_Cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ADref.Show();
        }

    }
}