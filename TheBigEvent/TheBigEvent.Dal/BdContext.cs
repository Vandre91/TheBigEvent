using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TheBigEvent.Dal
{
    public class BdContext : DbContext
    {
        public BdContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbSet<User> Users { get; set; }
    }
}
