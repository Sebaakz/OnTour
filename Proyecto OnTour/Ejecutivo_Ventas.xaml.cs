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
using Common.Cache;

namespace Proyecto_OnTour
{
    /// <summary>
    /// Lógica de interacción para Ejecutivo_Ventas.xaml
    /// </summary>
    public partial class Ejecutivo_Ventas : Window
    {
        public Ejecutivo_Ventas()
        {
            InitializeComponent();
            cargarDatosUsuario();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("confirme cierre de sesion", "Precaucion",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                this.Close();
        }
        private void cargarDatosUsuario()
        {
            TXT_mostarNombre.Text = UserLoginCache.Nombre_Emp + " " + UserLoginCache.Apellido_Emp;
            TXT_mostarRut.Text = UserLoginCache.Run_Emp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Crear_Contratos crearC = new Crear_Contratos();
            crearC.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ObtenerInformes Informes = new ObtenerInformes();
            Informes.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ModificarContrato modificarCon = new ModificarContrato();
            modificarCon.Show();
            modificarCon.GRID_BUSCAR_ACT.Visibility = System.Windows.Visibility.Visible;
            modificarCon.GRID_ACTUALIZAR.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            RegistroSeguros Seg = new RegistroSeguros();
            Seg.GRID_BuscarSeguro.Visibility = System.Windows.Visibility.Visible;
            Seg.GRID_registrarSeguro.Visibility = System.Windows.Visibility.Collapsed;
            Seg.GRID_MostrarSeguro.Visibility = System.Windows.Visibility.Collapsed;
            this.Hide();
            RegistroSeguros RegistroS = new RegistroSeguros();
            RegistroS.Show();
        }
    }
}
