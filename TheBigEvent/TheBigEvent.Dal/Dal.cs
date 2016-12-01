using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBigEvent.Dal
{
    public class Dal : IDal
    {
        BdContext bdd = new BdContext(@"Server = VIVI\SQLEXPRESS; Database = TheBigEvent.BDD; Trusted_Connection = True");
        public void Dispose()
        {
            bdd.Dispose();
        }
        public List<User> AllUser()
        {
            return bdd.Users.ToList();
        }

        public void CreatUser(string FirstName, string LastName, string City, int Tel, string Mail)
        {
            bdd.Users.Add(new User { FirstName = FirstName, LastName = LastName, City = City, Tel = Tel, Mail = Mail });
            bdd.SaveChanges();
        }

    }
}
