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
        
        public void AddEvent(string _NomEvent, string _NbInvite, string _Prix,DateTime _Horaire,int _MenuId,int _SalleId, int _TraiteurId, int _DecoId, string _Localisation, int _UserId,string _Validation)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Execute(
                    "tbe.pCreatEvent",
                    new { NomEvent = _NomEvent, NbInvite = _NbInvite, Prix = _Prix, Horaire = _Horaire, MenuId = _MenuId, SalleId = _SalleId, TraiteurId = _TraiteurId, DecoId= _DecoId, Localisation = _Localisation, UserId= _UserId,Validation = _Validation },
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
