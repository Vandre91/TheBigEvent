using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TheBigEvent.DAL
{
    public class UserLink
    {
        readonly string _connectionString;

        public UserLink(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>("Select * From tbe.tUser");
            }
        }
        public void AddUser(string _Mail, byte[] _Passe, byte _Pro, string _Siret, string _Compagny)
        {
            if (_Pro == 0)
            {
                _Siret = null;
                _Compagny = null;
            }
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pUserAdd",
                    new { Mail = _Mail, Passe = _Passe, Pro = _Pro, Siret = _Siret, Compagny = _Compagny },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public User FindUser(string _Mail, string _Passe)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select UserId,Mail,Passe,Pro from tbe.tUser where Mail = @Mail and Passe = @Passe ;",
                        new { Mail = _Mail, Passe = _Passe })
                    .FirstOrDefault();
            }
        }
        public User FindByEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select UserId,Mail,Passe,Pro from tbe.tUser where Mail = @Mail",
                        new { Mail = email })
                    .FirstOrDefault();
            }
        }

        public User FindUserByID(int Id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select UserId,Mail,Passe,Pro from tbe.tUser where UserId = @UserId;",
                        new { UserId = Id })
                    .FirstOrDefault();
            }
        }

        public User getUser(string _Mail)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select * from tbe.tUser where Mail = @Mail ;",
                        new { Mail = _Mail })
                    .FirstOrDefault();
            }
        }

        public void Delete(int _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query(
                    "DELETE FROM tbe.tUser WHERE UserId = @UserId",
                    new { UserId = _UserId })
                    .FirstOrDefault();
            }
        }
        public void UpdateName(int _UserId, string _firstName, string _lastName, string _City, int _Tel)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query(
                    "update tbe.tUser set FirstName = @FirstName,LastName = @LastName,City = @City,Tel = @Tel where UserId = @UserId",
                    new { UserId = _UserId, FirstName = _firstName, LastName = _lastName, City = _City, Tel = _Tel })
                    .FirstOrDefault();
            }
        }
        public void UpdateMail(int _userId, string _mail, byte[] _passe)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pUserProfilUpdate",
                    new { UserId = _userId, Mail = _mail, Passe = _passe },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
