using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS_OnTour;

namespace OnTour_Negocio
{
    public class Class_Contrato
    {
        private DATOS_OnTour.OnTourEntities Conn = new OnTourEntities();

        public string ID_Contrato { get; set; }
        public string Destino { get; set; }
        public string Valor_Contrato { get; set; }
        public Nullable<System.DateTime> Fecha_Salida { get; set; }
        public Nullable<System.DateTime> Fecha_llegada { get; set; }
        public string Escuela { get; set; }
        public int N_alumnos { get; set; }
        public string ID_seguro { get; set; }
        public string Run_Emp { get; set; }
        //=======================================================================================================
        // Listar Contratos
        //=======================================================================================================
        public List<Class_Contrato> Listar_contratos()
        {
            try
            {
                List<Class_Contrato> ListaContratos = new List<Class_Contrato>();
                List<Contrato> ListDatos = Conn.Contrato.ToList<Contrato>();
                foreach (Contrato dat in ListDatos)
                {
                    Class_Contrato Contr = new Class_Contrato();

                    Contr.ID_Contrato = dat.ID_Contrato;
                    Contr.Destino = dat.Destino;
                    Contr.Valor_Contrato = dat.Valor_Contrato;
                    Contr.Fecha_Salida = dat.Fecha_Salida;
                    Contr.Fecha_llegada = dat.Fecha_llegada;
                    Contr.Escuela = dat.Escuela;
                    Contr.N_alumnos = dat.N_alumnos;
                    Contr.ID_seguro = dat.ID_seguro;
                    Contr.Run_Emp = dat.Run_Emp;

                    ListaContratos.Add(Contr);
                }
                return ListaContratos;
            }
            catch (Exception e)
            {
                return new List<Class_Contrato>();
            }


        }
        //=======================================================================================================
        //Agregar Contratos
        //=======================================================================================================
        public bool Agregar()
        {
            try
            {
                Contrato dat = new Contrato();
                dat.ID_Contrato = this.ID_Contrato;
                dat.Destino = this.Destino;
                dat.Valor_Contrato = this.Valor_Contrato;
                dat.Fecha_Salida = this.Fecha_Salida;
                dat.Fecha_llegada = this.Fecha_llegada;
                dat.Escuela = this.Escuela;
                dat.N_alumnos = this.N_alumnos;
                dat.ID_seguro = this.ID_seguro;
                dat.Run_Emp = this.Run_Emp;

                Conn.Contrato.Add(dat);
                Conn.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }
        //=======================================================================================================
        //Actualizar Contratos
        //=======================================================================================================
        public bool Actualizar()
        {
            try
            {
                Contrato datCon = Conn.Contrato.First(C => C.ID_Contrato == this.ID_Contrato);
                datCon.ID_Contrato = this.ID_Contrato;
                datCon.Destino = this.Destino;
                datCon.Valor_Contrato = this.Valor_Contrato;
                datCon.Fecha_Salida = this.Fecha_Salida;
                datCon.Fecha_llegada = this.Fecha_llegada;
                datCon.Escuela = this.Escuela;
                datCon.N_alumnos = this.N_alumnos;
                datCon.ID_seguro = this.ID_seguro;
                datCon.Run_Emp = this.Run_Emp;

                Conn.SaveChanges();

                return true;
            }
            catch( Exception e)
            {
                return false;
            }

        }
        //=======================================================================================================
    }
}
