using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace E_Dnevnik
{
    class Connection
    {
        static public SqlConnection Connect()
        {
            string CS;
            CS = @"Data Source=DESKTOP;Initial Catalog=ednevnik;Integrated Security=True;MultipleActiveResultSets=True";
            SqlConnection veza = new SqlConnection(CS);
            return veza;
        }
    }
}
