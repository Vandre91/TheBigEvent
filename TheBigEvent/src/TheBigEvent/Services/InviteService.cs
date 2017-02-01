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
        public void addInvite( int _select, string _nom, string _mail, string _code)
        {
            _iLink.AddInvite( _select,  _nom,  _mail, _code);
        }
        public Result<IEnumerable<Invite>> getCodeById(string _code)
        {
            return Result.Success(Status.Ok, _iLink.GetCodeById(_code));
        }
        public Result<IEnumerable<GuestAnswer>> getAllInviteById(int _id)
        {
            return Result.Success(Status.Ok, _iLink.GetAllInviteById(_id));
        }
    }
}
