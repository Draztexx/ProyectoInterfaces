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
    /// Lógica de interacción para AdministrarTemas.xaml
    /// </summary>
    public partial class AdministrarTemas : Window
    {
        AdministrarMenu ADref;
        BDConect BD;

        public AdministrarTemas( AdministrarMenu x)
        {
            InitializeComponent();
            Loaded += MainForm_Load;
            ADref = x;
            BD= new BDConect();

            Closing += AdministrarTemas_Cerrar;
        }

        private void MainForm_Load(object sender, EventArgs e){
            CargarDatos();    
        }

        private void CargarDatos()
        {
            try
            {
                string consulta = "SELECT nombretema,descripcion,tiempo FROM tema";

                DataTable dt = BD.Select(consulta);



                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (string.IsNullOrWhiteSpace(dt.Rows[i]["nombretema"].ToString()) &&
                        string.IsNullOrWhiteSpace(dt.Rows[i]["descripcion"].ToString()) &&
                        string.IsNullOrWhiteSpace(dt.Rows[i]["tiempo"].ToString()))
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }

                dataGrid.ItemsSource = dt.DefaultView;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }

        }




        private void BTNAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarTema ATema = new AgregarTema(this);
            this.Hide();
            ATema.Show();
        }

        private void Button_Click_Eliminar(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;


            if (selectedRow != null)
            {

                string nombre = selectedRow["nombretema"].ToString();

                try
                {

                    string consulta = "DELETE FROM tema WHERE nombretema LIKE '" + nombre + "'";
                    BD.Insert(consulta);

                    var dataView = (DataView)dataGrid.ItemsSource;

                    // Buscar la fila en la DataView
                    DataRowView rowToDelete = dataView.Cast<DataRowView>().FirstOrDefault(r => r.Row == selectedRow.Row);
                    if (rowToDelete != null)
                    {
                        // Eliminar la fila de la DataView
                        dataView.Table.Rows.Remove(rowToDelete.Row);
                    }
                    MessageBox.Show("Se ha eliminado el tema");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el tema: " + ex.Message);
                }
            }
        }

        private void Button_Click_Modificar(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;


            if (selectedRow != null)
            {



                string nombre= selectedRow["nombretema"].ToString();
                string desc = selectedRow["descripcion"].ToString();
                int tiempo = int.Parse(selectedRow["tiempo"].ToString());



                try
                {

                    String consulta2 = "UPDATE tema SET  descripcion='"+desc+"',tiempo ="+tiempo+"  WHERE nombretema='" + nombre + "' ";
                    BD.Insert(consulta2);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el usuario: " + ex.Message);
                }
            }
        }

        private void AdministrarTemas_Cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ADref.Show();
        }
    }
}
