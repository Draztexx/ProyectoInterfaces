using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para AgregarTema.xaml
    /// </summary>
    public partial class AgregarTema : Window
    {
        AdministrarTemas AT;
        public List<GrupoPreguntasRespuesta> preguntas { get; set; }


        public AgregarTema(AdministrarTemas x)
        {
            InitializeComponent();
            AT = x;

            preguntas = new List<GrupoPreguntasRespuesta>();





            Closing += AgregarTema_Cerrar;
        }

        private void AgregarTema_Cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AT.Show();
        }

    }

    public class GrupoPreguntasRespuesta
    {
        public string Pregunta { get; set; }
        public string PreguntaValor { get; set; }
        public string RCorrecta { get; set; }
        public string RCorrectaValor { get; set; }
        public string RIncorrecta1 { get; set; }
        public string RIncorrecta1Valor { get; set; }
        public string RIncorrecta2 { get; set; }
        public string RIncorrecta2Valor { get; set; }
    }


}
