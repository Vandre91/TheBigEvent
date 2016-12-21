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
<<<<<<< HEAD
        public void AddUser(string _Mail, string _Passe, string _FirstName, string _LastName, string _City, string _Tel, string _Pro, string _Siret, string _Compagny)
        {
=======
        public void AddUser(string _Mail, string _Passe, byte _Pro, string _Siret, string _Compagny)
        {
            if (_Pro == 0)
            {
                _Siret = null;
                _Compagny = null;
            }
>>>>>>> master
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pUserAdd",
<<<<<<< HEAD
                    new { Passe = _Passe, FirstName = _FirstName, LastName = _LastName, City = _City, Tel = Int32.Parse(_Tel), Mail = _Mail, Pro = Boolean.Parse(_Pro), Siret = Int32.Parse(_Siret), Compagny = _Compagny },
=======
                    new { Mail = _Mail, Passe = _Passe, Pro = _Pro, Siret = _Siret, Compagny = _Compagny },
>>>>>>> master
                    commandType: CommandType.StoredProcedure);
            }
        }
        public User FindUser(string _Mail, string _Passe)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<User>(
                        "select UserId,Mail,Passe from tbe.tUser where Mail = @Mail and Passe = @Passe ;",
                        new { Mail = _Mail, Passe = _Passe })
                    .FirstOrDefault();
            }
        }
    }
}
