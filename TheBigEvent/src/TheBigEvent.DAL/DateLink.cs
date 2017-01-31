using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class DateLink
    {
        readonly string _connectionString;

        public DateLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddDate( DateTime _dates, int _bigselecteId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query("insert into tbe.tProposition (Date,BigSelecteId) values (@date,@BigSelecteId)",
                   new {  date = _dates, BigSelecteId = _bigselecteId});
            }
        }
        public IEnumerable<Date> GetDateById(int _id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Date>("select [Date] from tbe.tProposition where BigSelecteId = @id",
                        new { id = _id });
            }
        }
    }
}
