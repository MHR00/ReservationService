using ReservationService.Data.DbAccess;
using ReservationService.Entities.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ReservationService.Services.LocationSevices.Queries.SearchLocation
{
    public class SearchLocationService : ISearchLocationService
    {
        private readonly SqlDataAccess _context;

        public SearchLocationService(SqlDataAccess context)
        {
            _context = context;
        }


        public async Task<List<Location>> SearchLocation(string name, string type, int page , int size)
        {
            var procedureName = "spSearchLocation";
            var parameters = new DynamicParameters();
            parameters.Add("Name", name, DbType.String, ParameterDirection.Input );
            parameters.Add("LocationType", type, DbType.String, ParameterDirection.Input);
            parameters.Add("PageNumber", page, DbType.Int64, ParameterDirection.Input);
            parameters.Add("RowsOfPage", size, DbType.Int64, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var results = await connection.QueryAsync<Location>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }
    }
}
