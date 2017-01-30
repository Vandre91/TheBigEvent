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
    }
}
