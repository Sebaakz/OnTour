using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common.Cache;
namespace DATOS_OnTour

{
    public class acceso_empleados : conexionsql
    {
        public bool login(string usuario, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = connection;
                    Command.CommandText = " Select *from empleados where Usuario_Emp= @usuario and Contraseña_Emp=@pass";
                    Command.Parameters.AddWithValue("@usuario", usuario);
                    Command.Parameters.AddWithValue("@pass", pass);
                    Command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = Command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.Run_Emp = reader.GetString(0);
                            UserLoginCache.Nombre_Emp = reader.GetString(1);
                            UserLoginCache.Apellido_Emp = reader.GetString(2);
                            UserLoginCache.ID_Cargo_Emp = reader.GetInt32(3);

                        }
                        return true;
                    }
                    else
                        return false;
                }
            }

        }
    }
}
