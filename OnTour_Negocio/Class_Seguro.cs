using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS_OnTour;

namespace OnTour_Negocio
{
    public class Class_Seguro
    {
        private DATOS_OnTour.OnTourEntities Conn = new OnTourEntities();

        public string ID_seguro { get; set; }
        public string Empresa { get; set; }
        public string Info_seguro { get; set; }




        public List<Class_Seguro> Listar_seguros()
        {
            try
            {
                List<Class_Seguro> ListaSeguros = new List<Class_Seguro>();
                List<Seguro> ListDatos = Conn.Seguro.ToList<Seguro>();
                foreach (Seguro dat in ListDatos)
                {
                    Class_Seguro seg = new Class_Seguro();
                    seg.ID_seguro = dat.ID_seguro;
                    seg.Empresa = dat.Empresa;
                    seg.Info_seguro = dat.Info_seguro;

                    ListaSeguros.Add(seg);

                }
                return ListaSeguros;
            }

            catch (Exception e)
            {
                return new List<Class_Seguro>();
            }
        }
    }

}
