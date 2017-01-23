using Dapper;
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

        public IEnumerable<Event> GetEventById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Event>("Select * From tbe.tEvent where SalleId = @Id or TraiteurId = @Id or DecoId = @Id",
                        new { Id = id });
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
