using ITI.PrimarySchool.WebApp;
using Microsoft.DotNet.Cli.Utils.CommandParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;
using TheBigEvent.Models;

namespace TheBigEvent.Services
{
    public class UserServices
    {
        readonly UserLink _uLink;
        readonly PasswordHasher _passwordHasher;

        public UserServices(string connectionString)
        {
            _uLink = new UserLink(connectionString);
            _passwordHasher = new PasswordHasher();
        }

        public void addUser(string Mail, string Passe, byte Pro, string Siret, string Compagny)
        {
            if (Mail != null)
            {
                _uLink.AddUser(Mail, _passwordHasher.HashPassword(Passe), Pro, Siret, Compagny);
            }
            
        }


        public Result<User> getUser(string email)
        {
            User user = _uLink.getUser(email);
            return Result.Success(Status.Ok, user);
        }


        public User FindUser(string Mail, string _Passe)
        {
            User user = _uLink.FindByEmail(Mail);
            if (user != null && _passwordHasher.VerifyHashedPassword(user.Passe, _Passe) == PasswordVerificationResult.Success)
            {
                return user;
            }

            return null;
        }
        public User FindUsermail(string email)
        {
            return _uLink.FindByEmail(email);
        }
        public void DeleteUser(int _id)
        {
            _uLink.Delete(_id);
        }
        public Result<User> UpdateUserName(int _UserId, string _firstName, string _lastName, string _City, int _Tel)
        {
           _uLink.UpdateName(_UserId, _firstName, _lastName, _City, _Tel);
            User user = _uLink.FindUserByID(_UserId);
            return Result.Success(Status.Ok, user);
        }
        public Result<User> UpdateUserMail(int _UserId, string _mail, string _passe)
        {
            UserViewModel test = new UserViewModel();
            test._pass = _passwordHasher.HashPassword(_passe);
            _uLink.UpdateMail(_UserId, _mail, test._pass);
            User user = _uLink.FindUserByID(_UserId);
            return Result.Success(Status.Ok, user);
        }
    }
}
