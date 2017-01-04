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
        public void addEvent(string _NomEvent, string _NbInvite, string _Prix, DateTime _Horaire, int _MenuId, int _SalleId, int _TraiteurId, int _DecoId, string _Localisation, int _UserId, string _Validation)
        {
            _eLink.AddEvent( _NomEvent,_NbInvite,_Prix, _Horaire, _MenuId, _SalleId, _TraiteurId,_DecoId,_Localisation,_UserId,_Validation);
        }
        public void DeleteEvent(int _EventId)
        {
            _eLink.Delete(_EventId);
        }
    }
}
