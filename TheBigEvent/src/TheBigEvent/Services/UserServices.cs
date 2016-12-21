using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class UserServices
    {
        readonly UserLink _uLink;

        public UserServices(string connectionString)
        {
            _uLink = new UserLink(connectionString);
        }

        public void addUser(string Mail, string Passe, byte Pro, string Siret, string Compagny)
        {
            _uLink.AddUser(Mail, Passe, Pro, Siret, Compagny);
        }
        public User FindUser(string Mail, string Passe)
        {
            User user = _uLink.FindUser(Mail, Passe);
            return user;
        }
    }
}
