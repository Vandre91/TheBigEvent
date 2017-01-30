using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class InviteService
    {
        readonly InviteLink _iLink;

        public InviteService(string connectionString)
        {
            _iLink = new InviteLink(connectionString);
        }
        public void addInvite(int _id, int _select, string _nom, string _mail)
        {
            _iLink.AddInvite( _id,  _select,  _nom,  _mail);
        }
    }
}
