using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class User
    {
        
        public int UserId { get; set; }
        public byte[] Passe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int Tel { get; set; }
        public string Mail { get; set; }
        public bool Pro { get; set; }
        public String Siret { get; set; }
        public string Compagny { get; set; }
    
    }
}
