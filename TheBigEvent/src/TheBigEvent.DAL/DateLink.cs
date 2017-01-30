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
        public void AddDate(int _id, DateTime _dates, int _bigselecteId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query<Date>("insert into tbe.tDate (DateId,Dates,BigSelectedId) values (@id,@Dates,@BigSelectedId)",
                   new { id = _id, date = _dates, BigSelecteId = _bigselecteId});
            }
        }
    }
}
