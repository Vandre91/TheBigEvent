using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBigEvent.Dal
{
    public interface IDal : IDisposable
    {
        void CreatUser(string FirstName, string LastName, string City, int Tel, string Mail);
        List<User> AllUser();
    }
}
