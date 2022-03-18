using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tugas3_PV_Kasir_Sally_Livia_Kosasih_201401025
{
    class koneksi
    {
        public SqlConnection GetConn() 
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source= DESKTOP-ELDPJU4\\SQLEXPRESS; Initial Catalog = Kasir; Integrated Security=true";
            return Conn;
        }
        
    }
}
