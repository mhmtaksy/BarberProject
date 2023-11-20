using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;

namespace mvcdapperörnproje.Models
{
    public class DP
    {
        public static string connectionString = @"Server=MEHMETAKSOY\SQLMHMT;Database=Kuaför;Integrated Security=True;";

        public static void ExecuteReturn (string procadi,DynamicParameters param = null)
        {
            using (SqlConnection db = new SqlConnection (connectionString))
            {
                db.Open ();
                db.Execute(procadi, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public static IEnumerable<T>Listeleme<T>(string procadi,DynamicParameters param = null)
        {
            using(SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open ();
                return db.Query<T> (procadi,param,commandType:System.Data.CommandType.StoredProcedure);
            }
        }


    }
}