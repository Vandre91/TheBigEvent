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
        public Result<BigSelecte> addBigSelecte(int _id, string _nom, string _ville, string _description)
        {
            return Result.Success(Status.Ok, _bLink.AddBigSelecte( _id, _nom, _ville, _description));
        }
        public Result<IEnumerable<BigSelecte>> getBigSelectById(int _id)
        {
            return Result.Success(Status.Ok, _bLink.GetBigSelectById(_id));
        }
    }
}
