using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class BigSelecteService
    {
        readonly BigSelecteLink _bLink;

        public BigSelecteService(string connectionString)
        {
            _bLink = new BigSelecteLink(connectionString);
        }
        public void addBigSelecte(int _id, string _nom, string _ville, string _description)
        {
            _bLink.AddBigSelecte( _id, _nom, _ville, _description);
        }
    }
}
