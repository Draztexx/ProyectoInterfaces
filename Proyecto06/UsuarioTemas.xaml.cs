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
    /// Lógica de interacción para UsuarioTemas.xaml
    /// </summary>
    public partial class UsuarioTemas : Window
    {
        UsuarioMenu UsuarioMenuref;
        DataTable result;
        BDConect BD;
        public UsuarioTemas(UsuarioMenu x,DataTable y)
        {
            InitializeComponent();
            UsuarioMenuref = x;
            result = y;
            BD = new BDConect();
            Loaded += MainForm_Load;
            Closing += UsuarioTemas_Cerrar;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dataGrid.LoadingRow += dataGrid_LoadingRow;
        }


        private void CargarDatos()
        {
            try
            {
                string consulta = "SELECT id,nombretema,descripcion,tiempo FROM tema";

                DataTable dt = BD.Select(consulta);
                dt.Columns.Add("realizado", typeof(string));
                BD.Close();




                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    string consulta2 = "SELECT * FROM usuario_tema WHERE idusuario=" +(int.Parse(result.Rows[0]["id"].ToString()))+" AND idtema="+ (int.Parse(dt.Rows[i]["id"].ToString()))+"";
                    DataTable dt2 = BD.Select(consulta2);
                    BD.Close();

                    if (string.IsNullOrWhiteSpace(dt.Rows[i]["nombretema"].ToString()) &&
                        string.IsNullOrWhiteSpace(dt.Rows[i]["descripcion"].ToString()) &&
                        string.IsNullOrWhiteSpace(dt.Rows[i]["tiempo"].ToString()))
                    {
                        dt.Rows.RemoveAt(i);
                    }
                    else
                    {
                        if (dt2.Rows.Count > 0)
                        {
                            
                            dt.Rows[i]["realizado"] = "Realizado";
                        }
                        else
                        {
                            dt.Rows[i]["realizado"] = "Sin Realizar";

                           

                        }
                    }
                }

                dataGrid.ItemsSource = dt.DefaultView;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["realizado"].ToString() == "Realizado")
                    {
                        var cellContent = dataGrid.Columns[dataGrid.Columns.Count - 1].GetCellContent(dataGrid.Items[dt.Rows.IndexOf(row)]);
                        if (cellContent is FrameworkElement element && element is Button)
                        {
                            ((Button)element).IsEnabled = false;
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }

        }




        private void UsuarioTemas_Cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UsuarioMenuref.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
            if (selectedRow != null)
            {
                string nombretema= selectedRow["nombretema"].ToString();
                try
                {
                    string consulta = "SELECT * FROM tema WHERE nombretema LIKE '" + nombretema + "'";
                    DataTable dt = BD.Select(consulta);

                    Tema tema = new Tema(dt, int.Parse(result.Rows[0]["id"].ToString()));
                
                    tema.Show();this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el tema: " + ex.Message);
                }


            }




        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;

            if (rowView != null)
            {
                string realizado = rowView["realizado"].ToString();

                if (realizado == "Realizado")
                {
                    e.Row.IsEnabled = false;
                }
            }
        }




    }
}
