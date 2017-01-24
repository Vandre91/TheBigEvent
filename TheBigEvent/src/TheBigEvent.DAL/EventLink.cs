﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class EventLink
    {
        readonly string _connectionString;

        public EventLink(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Event> GetAllEvent()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>("Select * From tbe.tEvent");
            }
        }
        public IEnumerable<Event> GetAllEventById(string id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>("Select * From tbe.tEvent where UserId = @Id",
                        new { Id = id }); 
            }
        }
        public IEnumerable<Event> GetAllEventProById(string id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>("Select NomEvent,tbe.tEvent.SalleId,tbe.tEvent.TraiteurId,tbe.tEvent.DecoId,tbe.tEvent.UserId,tbe.tUser.LastName From tbe.tEvent INNER JOIN tbe.tUser ON tbe.tEvent.UserId = tbe.tUser.UserId where MenuId = @Id or SalleId = @Id or DecoId = @Id",
                        new { Id = id });
            }
        }

        public IEnumerable<Event> GetEventByIdS(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>("Select* from tbe.Salle, tbe.tEvent where tbe.Salle.SalleId = tbe.tEvent.SalleId and tbe.Salle.UserId = @Id",
                        new { Id = id });
            }
        }

        public IEnumerable<Event> GetEventByIdD(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>("Select* from tbe.tDeco, tbe.tEvent where tbe.tDeco.DecoId = tbe.tEvent.DecoId and tbe.tDeco.UserId = @Id",
                        new { Id = id });
            }
        }

        public IEnumerable<Event> GetEventByIdT(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>("Select* from tbe.tTraiteur, tbe.tEvent where tbe.tTraiteur.TraiteurId = tbe.tEvent.TraiteurId and tbe.tTraiteur.TraiteurId = @Id",
                        new { Id = id });
            }
        }

        public void validT(int _Id, int _value)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query(
                    "update tbe.tevent set validationT = @validationT where EventId = @EventId",
                    new { validationT = _value, EventId = _Id })
                    .FirstOrDefault();
            }
        }

        public void validD(int _Id, int _value)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query(
                    "update tbe.tevent set validationD = @validationD where EventId = @EventId",
                    new { validationD = _value, EventId = _Id })
                    .FirstOrDefault();
            }
        }

        public void validS(int _Id, int _value)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query(
                    "update tbe.tevent set validationS = @validationS where EventId = @EventId",
                    new { validationS = _value, EventId = _Id })
                    .FirstOrDefault();
            }
        }



        public void UpdateName(int _UserId, string _firstName, string _lastName, string _City, int _Tel)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Query(
                    "update tbe.tUser set FirstName = @FirstName,LastName = @LastName,City = @City,Tel = @Tel where UserId = @UserId",
                    new { UserId = _UserId, FirstName = _firstName, LastName = _lastName, City = _City, Tel = _Tel })
                    .FirstOrDefault();
            }
        }





        public void AddEvent(string _NomEvent, string _Localisation, int _MenuId,int _SalleId, int _TraiteurId, int _DecoId, int _UserId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pCreatEvent",
                    new { NomEvent = _NomEvent, Localisation = _Localisation, MenuId = _MenuId, SalleId = _SalleId, TraiteurId = _TraiteurId, DecoId= _DecoId, UserId= _UserId },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Delete(int _EventId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pDeleteEvent",
                    new { EventId = _EventId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
