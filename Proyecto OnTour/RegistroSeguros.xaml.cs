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
    /// Lógica de interacción para RegistroSeguros.xaml
    /// </summary>
    public partial class RegistroSeguros : MetroWindow
    {
        public RegistroSeguros()
        {
            InitializeComponent();
            LLenarGrid();
        }

        private void LLenarGrid()
        {
            Class_Seguro seg = new Class_Seguro();
            Grid_listaSeguros.ItemsSource = seg.Listar_seguros();
            Class_Contrato Con = new Class_Contrato();
            Grid_listaContratos.ItemsSource = Con.Listar_contratos();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GRID_BuscarSeguro.Visibility = System.Windows.Visibility.Visible;
            GRID_registrarSeguro.Visibility = System.Windows.Visibility.Collapsed;
            GRID_MostrarSeguro.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            Class_Seguro selected_Seg = dg.SelectedItem as Class_Seguro;
            TXT_ID_seguro.Text = selected_Seg.ID_seguro;
            GRID_BuscarSeguro.Visibility = System.Windows.Visibility.Collapsed;
            GRID_registrarSeguro.Visibility = System.Windows.Visibility.Visible;
            GRID_MostrarSeguro.Visibility = System.Windows.Visibility.Collapsed;


        }


        private void Grid_listaContratos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            Class_Contrato Select_Contr = dg.SelectedItem as Class_Contrato;
            TXT_Destino.Text = Select_Contr.Destino;
            TXT_Escuela.Text = Select_Contr.Escuela;
            TXT_IdContrato.Text = Select_Contr.ID_Contrato;
            TXT_VALORTOTAL.Text = Select_Contr.Valor_Contrato;
            TXT_NUmAlumnos.Text = Select_Contr.N_alumnos.ToString();
            TXT_RunEmpleado.Text = Select_Contr.Run_Emp;
            DATETIME_FECHA_IDA.SelectedDate = Select_Contr.Fecha_Salida;
            DATETIME_FECHA_VUELTA.SelectedDate = Select_Contr.Fecha_llegada;
            GRID_BuscarSeguro.Visibility = System.Windows.Visibility.Collapsed;
            GRID_registrarSeguro.Visibility = System.Windows.Visibility.Collapsed;
            GRID_MostrarSeguro.Visibility = System.Windows.Visibility.Visible;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GRID_BuscarSeguro.Visibility = System.Windows.Visibility.Collapsed;
            GRID_registrarSeguro.Visibility = System.Windows.Visibility.Visible;
            GRID_MostrarSeguro.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Ejecutivo_Ventas MainEjecutivo = new Ejecutivo_Ventas();
            Login Log = new Login();
            MainEjecutivo.Show();
            MainEjecutivo.Closed += Log.Logout;
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Class_Contrato Contr = new Class_Contrato();

            Contr.Destino = TXT_Destino.Text;
            Contr.Escuela =TXT_Escuela.Text;
            Contr.ID_Contrato = TXT_IdContrato.Text;
            Contr.Run_Emp = TXT_RunEmpleado.Text;
            Contr.Valor_Contrato = TXT_VALORTOTAL.Text;
            Contr.Fecha_Salida = DATETIME_FECHA_IDA.SelectedDate;
            Contr.Fecha_llegada = DATETIME_FECHA_VUELTA.SelectedDate;
            Contr.N_alumnos = int.Parse(TXT_NUmAlumnos.Text);
            Contr.ID_seguro = TXT_ID_seguro.Text;

            if (Contr.Actualizar())
            {
                if (MessageBox.Show("Proceso completado", "seguro incorporado de manera exitosa",
                MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                    this.Hide();
                Ejecutivo_Ventas MainEjecutivo = new Ejecutivo_Ventas();
                Login Log = new Login();
                MainEjecutivo.Show();
                MainEjecutivo.Closed += Log.Logout;
                this.Hide();
            }
            else
            {
                this.ShowMessageAsync("ERROR AL INGRESAR DATOS", "Los datos no han sido actualizados, Intente nuevamente");

            }
        }

    }
}
