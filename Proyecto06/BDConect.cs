using Microsoft.VisualBasic;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto05
{
    class BDConect
    {
        private MySqlConnection coneccion;
        private string Server;
        private string database;
        private string uid;
        private string password;

        public BDConect()
        {
            Initialize();
        }


        private void Initialize()
        {
            Server = "localhost";
            database = "proyectointerfaces";
            uid = "root";
            password = "";
            string CadenaConexion;
            CadenaConexion = "SERVER=" + Server + ";DATABASE=" + database +
            ";UID=" + uid + ";PASSWORD=" + password + ";";

            coneccion= new MySqlConnection(CadenaConexion);

        }

        public bool Open()
        {
            try
            {
                coneccion.Open();
                return true;
            }catch (MySqlException ex) {
                switch (ex.Number) { 
                case 0:
                        MessageBox.Show("Cannot conect to server");
                        break;
                case 1:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show("Please try again");
                        break;
                }
                return false;
            }
        }


        public bool Close()
        {
            try
            {
                coneccion.Close();
                return true;
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public void Insert(String x)
        {
            MySqlCommand cmd = new MySqlCommand(x, coneccion);
            cmd.ExecuteNonQuery();



        }

        public DataTable Select(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (Open())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, coneccion))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
                
            

            return dataTable;
        }














    }
}
