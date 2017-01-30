using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class ValidationService
    {
        readonly ValidationLink _vLink;

        public ValidationService(string connectionString)
        {
            _vLink = new ValidationLink(connectionString);
        }
        public void addValidation(int _id, int _inviteid)
        {
            _vLink.AddValidation(_id, _inviteid);
        }
    }
}
