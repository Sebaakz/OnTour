using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DATOS_OnTour
{
    public abstract class conexionsql
    {
        private readonly string ConnectionString;
        public conexionsql()
        {
            ConnectionString = "server=SEBA-PC;DataBase=OnTour; integrated security = True";
        }
            protected SqlConnection GetConnection()
            {
                return new SqlConnection(ConnectionString);
            }

    }
}
