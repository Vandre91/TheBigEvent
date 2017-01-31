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
        public BigSelecte AddBigSelecte(int _id,string _nom,string _ville,string _description)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {


                return con.Query<BigSelecte>("INSERT INTO tbe.tBigSelecte (Nom, UserId, Ville, Description) OUTPUT Inserted.BigSelecteId VALUES (@nom, @id,@ville, @description)",
                    new { id = _id, nom = _nom, ville = _ville, description = _description }).FirstOrDefault(); 
            }
        }
        public IEnumerable<BigSelecte> GetBigSelectById(int _id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<BigSelecte>("select BigSelecteId,UserId,Nom,Ville,Description from tbe.tBigSelecte where BigSelecteId = @id",
                        new { id = _id });
            }
        }
    }
}
