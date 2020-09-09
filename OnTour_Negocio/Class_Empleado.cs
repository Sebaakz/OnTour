using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS_OnTour;
using System.Data.SqlClient;

namespace OnTour_Negocio
{
    public class Class_Empleado
    {
        acceso_empleados emp_dat = new acceso_empleados();
        private DATOS_OnTour.OnTourEntities Conn = new OnTourEntities();

        public string Run_Emp { get; set; }
        public string Nombre_Emp { get; set; }
        public string Apellido_Emp { get; set; }
        public int ID_Cargo_Emp { get; set; }
        public string Usuario_Emp { get; set; }
        public string Contraseña_Emp { get; set; }

        public List<Class_Empleado> Listar_empleados()
        {
            try
            {
                List<Class_Empleado> ListEmp = new List<Class_Empleado>();
                List<Empleados> ListDatos = Conn.Empleados.ToList<Empleados>();
                foreach (Empleados dat in ListDatos)
                {
                    Class_Empleado emp = new Class_Empleado();
                    emp.Run_Emp = dat.Run_Emp;
                    emp.Nombre_Emp = dat.Nombre_Emp;
                    emp.Apellido_Emp = dat.Apellido_Emp;
                    emp.ID_Cargo_Emp = dat.ID_Cargo_Emp;
                    emp.Usuario_Emp = dat.Usuario_Emp;
                    emp.Contraseña_Emp = dat.Contraseña_Emp;

                    ListEmp.Add(emp);

                }
                return ListEmp;
            }
            catch (Exception e)
            {
                return new List<Class_Empleado>();
            }
        }

        public bool Logear(string user, string pass)
        {
            return emp_dat.login(user, pass);




        }
 }







    
}
