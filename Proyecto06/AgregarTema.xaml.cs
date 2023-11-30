using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    /// Lógica de interacción para AgregarTema.xaml
    /// </summary>
    public partial class AgregarTema : Window
    {
        AdministrarTemas AT;
        int idtema;


        public AgregarTema(AdministrarTemas x)
        {
            InitializeComponent();
            AT = x;


            Closing += AgregarTema_Cerrar;
        }

        private void AgregarTema_Cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AT.Show();
        }

        public int SqlTema(String Nombre,String Descripcion,String Documento,String Duracion)
        {
            BDConect BD = new BDConect();BD.Open();
            BD.Insert("INSERT INTO `tema`(`nombretema`, `descripcion`, `contenido`, `tiempo`) VALUES ('" + Nombre + "','" + Descripcion + "','" + Documento + "','" + Duracion + "')");
            BD.Close();
            DataTable result = BD.Select("SELECT * FROM TEMA WHERE nombretema LIKE '"+Nombre+"'");
            
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["id"]);
            }

            return 0;
               
        }

        public void Sqlpreguntas(int id, String pregunta, String ResC, String ResI1, String ResI2)
        {
            BDConect BD = new BDConect();BD.Open();
            BD.Insert("INSERT INTO `actividades`( `pregunta`, `respuestav`, `respuesta2`, `respuesta3`, `puntos`, `tipo`, `tema`) VALUES('"+pregunta+"', '"+ResC+"', '"+ResI1+"', '"+ResI2+"', "+1+", 'P', "+id+")");
            BD.Close();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            idtema = SqlTema(titulo.Text, descripcion.Text, documento.Text, duracion.Text);
            if (idtema!=0)
            {
                
                Sqlpreguntas(idtema, P1.Text, RC1.Text, RI11.Text, RI12.Text);
                Sqlpreguntas(idtema, P2.Text, RC2.Text, RI21.Text, RI22.Text);
                Sqlpreguntas(idtema, P3.Text, RC3.Text, RI31.Text, RI32.Text);
                Sqlpreguntas(idtema, P4.Text, RC4.Text, RI41.Text, RI42.Text);
                MessageBox.Show("Se ha agregado el tema correctamente junto con sus respectivas preguntas", "Información");

            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al insertar todo en la base de datos", "Información");

            }

        }
    }

    


}
