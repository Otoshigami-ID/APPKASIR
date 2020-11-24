using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace AppKasir
{
    class Koneksi
    {
        
        public OleDbConnection GetConn()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:/XI/KK3/Code/Kasir/db_appkasir.accdb";
            return conn;
        }
    }
}
