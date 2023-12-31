﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int IDUsuario;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTENTRAR_Click(object sender, RoutedEventArgs e)
        {
            string correo=TBXCorreo.Text;
            string contraseña = TBXContraseña.Password;

            if(lleno(correo) && lleno(contraseña))
            {
                BDConect BD= new BDConect();
                String Consulta = "SELECT * FROM users WHERE password LIKE '"+contraseña+"' AND email LIKE '"+correo+"'";
                DataTable result=BD.Select(Consulta);
                if(result.Rows.Count > 0 )
                {
                    if (result.Rows[0]["rol"].ToString() == "admin")
                    {
                    
                        AdministrarMenu ad = new AdministrarMenu(this);
                       this.Hide();
                        ad.Show();
                    }
                    else
                    {

                        
                        UsuarioMenu UM= new UsuarioMenu(this,result);
                        this.Hide();
                        UM.Show();
                    }
                }
                else
                {
                    MessageBox.Show("El correo y la contraseña no coinciden, si no esta registrado hagalo", "Información");
                }
                
            }
            else
            {
                MessageBox.Show("Hay que rellenar todos los campos");

            }





        }

        

        public Boolean lleno(String x)
        {
            if (!string.IsNullOrEmpty(x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BTRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
        }

       
    }
}


