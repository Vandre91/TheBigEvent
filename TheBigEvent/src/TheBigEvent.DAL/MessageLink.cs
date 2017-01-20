using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class MessageLink
    {
        readonly string _connectionString;

        public MessageLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Message> GetAllMessage(int id1,int id2)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Message>("select UserId1,UserId2,Text from tbe.tMessage where UserId1 = @Id and UserId2 = @Id2 or UserId1 = @Id2 and UserId2 = @Id",
                        new { Id = id1,Id2 =id2  });
            }
        }
    }
}
