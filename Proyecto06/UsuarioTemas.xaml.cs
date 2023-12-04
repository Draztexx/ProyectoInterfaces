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
                    string consulta2 = "SELECT* FROM usuario_tema WHERE idusuario= " +(result.Rows[0].Field<int>("id"))+" AND idtema="+ (dt.Rows[i].Field<int>("id"))+"";
                    DataTable dt2 = BD.Select(consulta);
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

                    Tema tema = new Tema( result);
                
                    tema.Show();this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el tema: " + ex.Message);
                }


            }




        }

        
    }
}
