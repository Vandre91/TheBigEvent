using Microsoft.DotNet.Cli.Utils.CommandParsing;
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

        public Result<User> getUser(int id)
        {
            User user = _uLink.getUser(id);
            return Result.Success(Status.Ok, user);
        }


        public User FindUser(string Mail, string Passe)
        {
            User user = _uLink.FindUser(Mail, Passe);
            return user;
        }
        public void DeleteUser(int _id)
        {
            _uLink.Delete(_id);
        }
        public void UpdateUserName(int _UserId, string _firstName, string _lastName, string _City, int _Tel)
        {
            _uLink.UpdateName(_UserId, _firstName, _lastName, _City, _Tel);
        }
        public void UpdateUserMail(int _userId, string _mail, string _passe)
        {
            _uLink.UpdateMail(_userId, _mail, _passe);
        }
    }
}
