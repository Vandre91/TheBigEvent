using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class Salle
    {
        public int SalleId { get; set; }
        public int NbPlace { get; set; }
        public int UserId { get; set; }
        public string Descriptions { get; set; }
        public float Prix { get; set; }
        public string Nom { get; set; }
        public string NomEvent { get; set; }
        public int Userid { get; set; }
        public string Compagny { get; set; }
    }
}
