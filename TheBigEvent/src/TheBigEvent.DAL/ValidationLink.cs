using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class ValidationLink
    {
        readonly string _connectionString;

        public ValidationLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddValidation(int _id, int _inviteid)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query<Validation>("insert into tbe.tValidation (PropositionId, InviteId) values (@id,@inviteid)",
                   new { id = _id, InviteId = _inviteid});
            }
        }
    }
}
