using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class EventService
    {
        readonly EventLink _eLink;
        public EventService(string connectionString)
        {
            _eLink = new EventLink(connectionString);
        }
        public Result<IEnumerable<Event>> getEvent()
        {
            return Result.Success(Status.Ok, _eLink.GetAllEvent());
        }
        public Result<Event> addEvent(string _NomEvent, string _Localisation, int _MenuId, int _SalleId, int _TraiteurId, int _DecoId, int _UserId)
        {
            _eLink.AddEvent( _NomEvent, _Localisation, _MenuId, _SalleId, _TraiteurId,_DecoId,_UserId);
        }
        public void DeleteEvent(int _EventId)
        {
            _eLink.Delete(_EventId);
        }
    }
}
