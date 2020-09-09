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
using Common.Cache;


namespace Proyecto_OnTour
{
    /// <summary>
    /// Lógica de interacción para EmergenteContrato.xaml
    /// </summary>
    public partial class EmergenteContrato : MetroWindow

    {
        private List<Class_Contrato> Lista_Contratos = null;


        public EmergenteContrato()
        {
            InitializeComponent();
            BuscadorUsuario();

        }

        private void Grid_seleccionarContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dg = (DataGrid)sender;
            Class_Contrato Selected_Contr = dg.SelectedItem as Class_Contrato;
            buscarContrato BuscarCon = new buscarContrato();
            MainWindow Login = new MainWindow();            

                BuscarCon.Show();
                this.Hide();
                BuscarCon.TXT_IdContrato.Text = Selected_Contr.ID_Contrato;
                BuscarCon.TXT_NombreSeguro.Text = Selected_Contr.ID_seguro;
                BuscarCon.TXT_Destino.Text = Selected_Contr.Destino;
                BuscarCon.TXT_Escuela.Text = Selected_Contr.Escuela;
                BuscarCon.TXT_Run_Emp.Text = Selected_Contr.Run_Emp;
                BuscarCon.DATETIME_FECHA_IDA.SelectedDate = Selected_Contr.Fecha_Salida;
                BuscarCon.DATETIME_FECHA_VUELTA.SelectedDate = Selected_Contr.Fecha_llegada;
                BuscarCon.TXT_VALORTOTAL.Text = Selected_Contr.Valor_Contrato;
            BuscarCon.TXT_NUM_alumnos.Text = Selected_Contr.N_alumnos.ToString();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserLoginCache.validarlogin == true)
            {
                this.Hide();
                Ejecutivo_Ventas MainEjecutivo = new Ejecutivo_Ventas();
                Login Log = new Login();
                MainEjecutivo.Show();
                MainEjecutivo.Closed += Log.Logout;
                this.Hide();

            }
            else
            {
                this.Hide();
                MainWindow Login = new MainWindow();
                Login.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Class_Contrato Contr = new Class_Contrato();
            buscarContrato BuscarCon = new buscarContrato();
            EmergenteContrato EmergenteCon = new EmergenteContrato();

            Lista_Contratos = Contr.Listar_contratos();
            var Resultado_Busqueda = from ListContratos in this.Lista_Contratos
                                     where ListContratos.ID_Contrato == TXT_NumCOn_BUSCAR.Text
                                     select ListContratos;

            if (TXT_NumCOn_BUSCAR.Text != null)
            {
                if (TXT_NumCOn_BUSCAR.Text == "")
                {
                    Grid_seleccionarContrato.ItemsSource = Contr.Listar_contratos();
                }
                else
                {
                    Grid_seleccionarContrato.ItemsSource = Resultado_Busqueda;

                }
            }
            else {
                this.ShowMessageAsync("ERROR:  ", "Error de busqueda, vuelva al login e intente nuevamente");
            }
        }

        private void BuscadorUsuario()
        {
            if (UserLoginCache.validarlogin == true)
            {
                Grid_BuscadorUsuario.Visibility = System.Windows.Visibility.Visible;
            }
            else {
                Grid_BuscadorUsuario.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

    }
}
