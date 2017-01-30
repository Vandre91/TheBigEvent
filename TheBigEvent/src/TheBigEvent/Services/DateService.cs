using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class DateService
    {
        readonly DateLink _dLink;

        public DateService(string connectionString)
        {
            _dLink = new DateLink(connectionString);
        }
        public void addDate(int _id, DateTime _dates, int _bigselecteId)
        {
            _dLink.AddDate(_id, _dates, _bigselecteId);
        }
    }
}
