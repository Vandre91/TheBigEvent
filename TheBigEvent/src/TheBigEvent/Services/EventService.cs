﻿using System;
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
        public Result<IEnumerable<Event>> getEventById(string id)
        {
            return Result.Success(Status.Ok, _eLink.GetAllEventById(id));
        }
        public Result<IEnumerable<Event>> getEventSalle(int id)
        {
            return Result.Success(Status.Ok, _eLink.GetEventSalle(id));
        }
        public Result<IEnumerable<Event>> getEventDeco(int id)
        {
            return Result.Success(Status.Ok, _eLink.GetEventDeco(id));
        }
        public Result<IEnumerable<Event>> getEventTraiteur(int id)
        {
            return Result.Success(Status.Ok, _eLink.GetEventTraiteur(id));
        }
        public Result<IEnumerable<Event>> getEventProById(string id)
        {
            return Result.Success(Status.Ok, _eLink.GetAllEventProById(id));
        }
        public void addEvent(string _NomEvent, string _Localisation, int _MenuId, int _SalleId, int _TraiteurId, int _DecoId, int _UserId, int NbInvite, int Prix, DateTime Dates)
        {
            _eLink.AddEvent( _NomEvent, _Localisation, _MenuId, _SalleId, _TraiteurId,_DecoId,_UserId, NbInvite, Prix, Dates);
        }
        public Result<IEnumerable<Event>> getEventByIdPT(int id)
        {
            return Result.Success(Status.Ok, _eLink.GetEventByIdT(id));
        }
        public Result<IEnumerable<Event>> getEventByIdPD(int id)
        {
            return Result.Success(Status.Ok, _eLink.GetEventByIdD(id));
        }
        public Result<IEnumerable<Event>> getEventByIdPS(int id)
        {
            return Result.Success(Status.Ok, _eLink.GetEventByIdS(id));
        }
        public Result<IEnumerable<Event>> getEventByIdPM(int id)
        {
            return Result.Success(Status.Ok, _eLink.GetEventByIdM(id));
        }

        public void validT(int id, int value)
        {
            _eLink.validT(id, value);
            return;
        }
        public void validD(int id, int value)
        {
            _eLink.validD(id, value);
            return;
        }
        public void validS(int id, int value)
        {
            _eLink.validS(id, value);
            return;
        }

        public void UpdateTraiteurIdbynull(int id)
        {
            _eLink.UpdateTraiteurIdbynull(id);
            return;
        }

        public void UpdateMenuIdbynull(int id)
        {
            _eLink.UpdateMenuIdbynull(id);
            return;
        }

        public void UpdateSalleIdbynull(int id)
        {
            _eLink.UpdateSalleIdbynull(id);
            return;
        }

        public void UpdateDecoIdbynull(int id)
        {
            _eLink.UpdateDecoIdbynull(id);
            return;
        }



        public void DeleteEvent(int _EventId)
        {
            _eLink.Delete(_EventId);
        }
    }
}
