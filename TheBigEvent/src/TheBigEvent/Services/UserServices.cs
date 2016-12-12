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

        public List<string> returnAllNameUser()
        {
            List<string> tmpVar = new List<string>();

            foreach (User i in _uLink.GetAll())
            {
                tmpVar.Add(i.FirstName);
            }

            return tmpVar;
        }
        public void addUser(string Mail, string Passe, string FirstName, string LastName, string City, string Tel, string Pro, string Siret, string Compagny)
        {
            _uLink.AddUser(Mail, Passe, FirstName, LastName, City, Tel, Pro, Siret, Compagny);
        }
        public User FindUser(string Mail, string Passe)
        {
            User user = _uLink.FindUser(Mail, Passe);
            return user;
        }
    }
}
