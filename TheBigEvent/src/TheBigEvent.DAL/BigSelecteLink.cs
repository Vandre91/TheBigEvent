using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class BigSelecteLink
    {
        readonly string _connectionString;

        public BigSelecteLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<BigSelecte> AddBigSelecte(int _id,string _nom,string _ville,string _description)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<BigSelecte>("insert into tbe.tBigSelecte (UserId,Nom,Ville,Description) values (@id,@nom,@ville,@description)",
                    new { id = _id, nom = _nom, ville = _ville, description = _description });
            }
        }
    }
}
