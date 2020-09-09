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
    /// Lógica de interacción para buscarContrato.xaml
    /// </summary>
    public partial class buscarContrato : MetroWindow
    {
        public buscarContrato()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//volver
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
    }
}
