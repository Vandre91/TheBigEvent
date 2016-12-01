using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.Entity;
using TheBigEvent.Dal;

namespace TheBigEvent.Test
{
    [TestFixture]
    public class TestUser
    {
        [Test]
        public void CreatTest()
        {
            using (BdContext context = new BdContext(@"Server = VIVI\SQLEXPRESS; Database = TheBigEvent.BDD; Trusted_Connection = True"))
            {
                User user = new User
                {
                    FirstName = "Tes1",
                    LastName = "Tes1",
                    City = "test1",
                    Passe = "gggkkk",
                    Tel = 0144556677,
                    Mail = "ggg",
                    Compagny = "audi"

                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        [Test]
        public void Checktest()
        {
            using (BdContext context = new BdContext(@"Server = VIVI\SQLEXPRESS; Database =TheBigEvent.BDD ; Trusted_Connection = True"))
            {

                foreach (User user in context.Users)
                {
                    Console.WriteLine("First Name: {0} - LastName:{1}- Mail: {2}", user.FirstName, user.LastName, user.Mail);
                }

            }
        }
    }
}
