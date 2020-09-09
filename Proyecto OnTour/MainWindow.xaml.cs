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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OnTour_Negocio;


namespace Proyecto_OnTour
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private List<Class_Contrato> Lista_Contratos = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)//Buscar Contrato
        {

            if (TXT_numContrato.Text == "")
            {
                this.ShowMessageAsync("ERROR: ", "Por favor, ingrese un numero de contrato");

            }
            else
            {
                Class_Contrato Contr = new Class_Contrato();
                buscarContrato BuscarCon = new buscarContrato();
                EmergenteContrato EmergenteCon = new EmergenteContrato();

                Lista_Contratos = Contr.Listar_contratos();
                var Resultado_Busqueda = from ListContratos in this.Lista_Contratos
                                         where ListContratos.ID_Contrato == TXT_numContrato.Text
                                         select ListContratos;

                if (TXT_numContrato.Text != null)
                {

                    EmergenteCon.Show();
                    EmergenteCon.Grid_seleccionarContrato.ItemsSource = Resultado_Busqueda;
                    this.Hide();
                }
            }
    
        }

        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            TXT_numContrato.Text = "";
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login Login = new Login();
            Login.Show();

        }
    }
}
