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
    /// Lógica de interacción para ModificarContrato.xaml
    /// </summary>
    public partial class ModificarContrato : MetroWindow

    {

        private List<Class_Contrato> Lista_Contratos = null;
        public ModificarContrato()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Ejecutivo_Ventas MainEjecutivo = new Ejecutivo_Ventas();
            Login Log = new Login();
            MainEjecutivo.Show();
            MainEjecutivo.Closed += Log.Logout;
            this.Hide();
        }
        private void Grid_SeleccionarC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dg = (DataGrid)sender;
            Class_Contrato Selected_Contr = dg.SelectedItem as Class_Contrato;
            MainWindow Login = new MainWindow();
            GRID_BUSCAR_ACT.Visibility = System.Windows.Visibility.Hidden;
            GRID_ACTUALIZAR.Visibility = System.Windows.Visibility.Visible;

            TXT_IDcontrato_ACTUALIZAR.Text = Selected_Contr.ID_Contrato;
            TXT_Destino_ACTUALIZAR.Text = Selected_Contr.Destino;
            TXT_Escuela_ACTUALIZAR.Text = Selected_Contr.Escuela;
            DATETIME_FECHA_IDA_ACTUALIZAR.SelectedDate = Selected_Contr.Fecha_Salida;
            DATETIME_FECHA_VUELTA_ACTUALIZAR.SelectedDate = Selected_Contr.Fecha_llegada;
            TXT_VALOR_CONTRATO_ACTUALIZAR.Text = Selected_Contr.Valor_Contrato;
            TXT_NUM_ALUMNOS_ACTUALIZAR.Text = Selected_Contr.N_alumnos.ToString();
            TXT_RUNEMP_ACTUALIZAR.Text = Selected_Contr.Run_Emp;
            TXT_IDseguro_ACTUALIZAR.Text = Selected_Contr.ID_seguro;
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TXT_IDcontrato_BUSCAR_ACT.Text == "")
            {
                this.ShowMessageAsync("ERROR: ", "Por favor, ingrese un numero de contrato");

            }
            else
            {
                Class_Contrato Contr = new Class_Contrato();

                Lista_Contratos = Contr.Listar_contratos();
                var Resultado_Busqueda = from ListContratos in this.Lista_Contratos
                                         where ListContratos.ID_Contrato == TXT_IDcontrato_BUSCAR_ACT.Text
                                         select ListContratos;
                if (TXT_IDcontrato_BUSCAR_ACT.Text != "")
                {
                    Grid_seleccionarContrato.ItemsSource = Resultado_Busqueda;

                }
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Class_Contrato Contr = new Class_Contrato();

            Contr.Destino = TXT_Destino_ACTUALIZAR.Text;
            Contr.Escuela = TXT_Escuela_ACTUALIZAR.Text;
            Contr.ID_Contrato = TXT_IDcontrato_ACTUALIZAR.Text;
            Contr.Run_Emp = TXT_RUNEMP_ACTUALIZAR.Text;
            Contr.Valor_Contrato = TXT_VALOR_CONTRATO_ACTUALIZAR.Text;
            Contr.Fecha_Salida = DATETIME_FECHA_IDA_ACTUALIZAR.SelectedDate;
            Contr.Fecha_llegada = DATETIME_FECHA_VUELTA_ACTUALIZAR.SelectedDate;
            Contr.N_alumnos = int.Parse(TXT_NUM_ALUMNOS_ACTUALIZAR.Text);
            if (TXT_IDseguro_ACTUALIZAR.Text == "")
            {
                Contr.ID_seguro = null;
            }else
                Contr.ID_seguro = TXT_IDseguro_ACTUALIZAR.Text;

            if (Contr.Actualizar())
            {
                this.ShowMessageAsync("PROCESO COMPLETADO", "Datos Actualizados de manera exitosa");
                GRID_BUSCAR_ACT.Visibility = System.Windows.Visibility.Visible;
                GRID_ACTUALIZAR.Visibility = System.Windows.Visibility.Hidden;
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
