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
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }





        public Boolean lleno(String x)
        {
            if (!string.IsNullOrEmpty(x))
            {
                return true;
             }else{
                return false;
             }
        }

        public void vaciar()
        {
            TBXNombre.Text = "";
            TBXEmail.Text = "";
            TBXCodigo.Text = "";
            TBXContraseña.Password = "";
            TBXRepetir.Password = "";
        }

        private void BTEnviar_Click(object sender, RoutedEventArgs e)
        {
            String Nombre=TBXNombre.Text;
            String Email=TBXEmail.Text;
            String Codigo=TBXCodigo.Text;
            String Contra1=TBXContraseña.Password;
            String Contra2=TBXRepetir.Password;

            if (lleno(Nombre) && lleno(Email) && lleno(Codigo) && lleno(Contra1) && lleno(Contra2))
            {
                BDConect BD = new BDConect();
                String Consulta = "SELECT * FROM users WHERE email LIKE '" + Email + "'";
                DataTable result = BD.Select(Consulta);
                if (result.Rows.Count <= 0)
                {
                    if (Contra2 == Contra1)
                    {
                        Consulta = "INSERT INTO users (`username`, `password`, `email`, `puntos`, `rol`) VALUES ('" + Nombre + "','" + Contra1 + "','" + Email + "',0,'user')";
                        BD.Insert(Consulta);
                        MessageBox.Show("Se ha Registrado el usuario nuevo, Vuelva a Iniciar Sesion");
                        vaciar();
                        BD.Close();
                    }
                    else{
                        MessageBox.Show("No coinciden las contraseñas");
                    }
                }
                else{
                    MessageBox.Show("Ya existe un usuario registrado con ese correo");
                }
            }else{
                MessageBox.Show("Hay que rellenar todos los campos");
            }





         }
    }

    
}
