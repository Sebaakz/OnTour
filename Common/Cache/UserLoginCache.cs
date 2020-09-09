using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public static class UserLoginCache
    {
        public static string Run_Emp { get; set; }
        public static string Nombre_Emp { get; set; }
        public static string Apellido_Emp { get; set; }
        public static int ID_Cargo_Emp { get; set; }
        public static bool validarlogin { get; set; }
        public static string ID_seguro { get; set; }

    }
}
