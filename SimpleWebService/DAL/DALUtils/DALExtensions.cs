using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;

namespace SimpleWebService.DAL.DALUtils
{
    public static class DALExtensions
    {

        //public IEnumerable<TResult> ExecSql<TResult>(this DatabaseFacade db, string query)
        //{
        //    using (var conn = db.GetDbConnection())
        //    using (var cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText = query;
        //        //using (var reader = cmd.ExecuteReader())
        //        //{
        //        //    while (reader.Read())
        //        //        Console.WriteLine(reader.GetString(0));
        //        //}
               
        //        var dataTable = new DataTable();
        //        var da = new SqlDataAdapter(cmd);
        //        da.Fill(dataTable);
        //    }
        //}
    }
}
