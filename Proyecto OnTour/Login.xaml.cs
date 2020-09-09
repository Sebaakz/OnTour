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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private void volver_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow inicio = new MainWindow();
            inicio.Show();
        }

        private void Inicio_click (object sender, RoutedEventArgs e)
        {
            if (TXT_user.Text != "")
            {
                if (TXT_contra.Password != "")
                {
                    Class_Empleado emp = new Class_Empleado();
                    var validlogin = emp.Logear(TXT_user.Text, TXT_contra.Password);
                        if (validlogin == true)
                    {
                        Ejecutivo_Ventas MainEjecutivo = new Ejecutivo_Ventas();
                        UserLoginCache.validarlogin = validlogin;
                        MainEjecutivo.Show();
                        MainEjecutivo.Closed += Logout;
                        this.Hide();

                    }
                    else
                    {
                        this.ShowMessageAsync("Error de ingreso", "Usuario o contraseña invalido");
                        TXT_contra.Clear();
                        TXT_user.Focus();
                    }

                }
                else
                {
                    this.ShowMessageAsync("Error de ingreso", "Ingrese la contraseña");
                }

            }
            else
                this.ShowMessageAsync("Error de ingreso", "Ingrese el nombre de usuario");

        }

        public void Logout (object sender, EventArgs e)
        {
            TXT_contra.Clear();
            TXT_user.Clear();
            TXT_user.Focus();
            UserLoginCache.validarlogin = false;
            this.Show();

        }
    } 
}
