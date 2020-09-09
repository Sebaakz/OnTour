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
    /// Lógica de interacción para Crear_Contratos.xaml
    /// </summary>
    public partial class Crear_Contratos : MetroWindow
    {
        public Crear_Contratos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class_Contrato Con = new Class_Contrato();
            if (TXT_NumCon.Text == "")
            {
                this.ShowMessageAsync("ERROR: ", "Ingrese el Numero de contrato");
            }
            else
            {
                if (TXT_NumCon.Text == Con.ID_Contrato)
                {
                    this.ShowMessageAsync("ERROR:", "El contrato ingresado ya existe");
                }
                else
                {
                    Con.ID_Contrato = TXT_NumCon.Text;
                    Con.ID_seguro = null;
                    Con.Destino = TXT_Destino.Text;
                    Con.Escuela = TXT_Escuela.Text;
                    Con.Run_Emp = UserLoginCache.Run_Emp;
                    Con.Fecha_Salida = DATETIME_FECHA_IDA.SelectedDate;
                    Con.Fecha_llegada = DATETIME_FECHA_VUELTA.SelectedDate;
                    Con.Valor_Contrato = TXT_VALOR_CONTRATO.Text;
                    if (TXT_NUM_ALUMNOS.Text=="" || TXT_Destino.Text=="" ||
                        TXT_NumCon.Text=="" || TXT_VALOR_CONTRATO.Text == "" || DATETIME_FECHA_IDA.SelectedDate == null || DATETIME_FECHA_VUELTA.SelectedDate==null)
                    {
                        this.ShowMessageAsync("ERROR:", "Por favor, ingrese todos los campos");

                    }
                    else
                    {
                        Con.N_alumnos = int.Parse(TXT_NUM_ALUMNOS.Text);
                        if (Con.Agregar())
                        {
                            this.ShowMessageAsync("PROCESO COMPLETADO", "Contrato grabado con exito");
                            TXT_Destino.Clear();
                            TXT_Escuela.Clear();
                            TXT_NumCon.Clear();
                            TXT_NUM_ALUMNOS.Clear();
                            TXT_VALOR_CONTRATO.Clear();

                        }
                        else
                        {
                            this.ShowMessageAsync("ERROR AL INGRESAR DATOS ", "Error al registrar datos, asegurese de que todos los campos estan completados de manera correcta e intente nuevamente");
                        }

                    }
                    
                }
            }

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

        private void numerosTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
