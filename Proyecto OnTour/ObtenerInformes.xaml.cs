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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OnTour_Negocio;

namespace Proyecto_OnTour
{
    /// <summary>
    /// Lógica de interacción para ObtenerInformes.xaml
    /// </summary>
    public partial class ObtenerInformes : MetroWindow
    {
        public ObtenerInformes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Buscar Contratos
        {
            this.Hide();
            EmergenteContrato ListaCOntratos = new EmergenteContrato();
            Class_Contrato Con = new Class_Contrato();

            ListaCOntratos.Grid_seleccionarContrato.ItemsSource = Con.Listar_contratos();
            ListaCOntratos.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Ejecutivo_Ventas MainEjecutivo = new Ejecutivo_Ventas();
            Login Log = new Login();
            MainEjecutivo.Show();
            MainEjecutivo.Closed += Log.Logout;
            this.Hide();
        }
    }
}
