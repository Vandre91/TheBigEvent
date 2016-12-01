using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBigEvent.Dal
{
    public class User
    {
        public int UserId { get; set; }
        public string Passe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int Tel { get; set; }
        public string Mail { get; set; }
        public byte Pro { get; set; }
        public int Siret { get; set; }
        public string Compagny { get; set; }
    }
}
