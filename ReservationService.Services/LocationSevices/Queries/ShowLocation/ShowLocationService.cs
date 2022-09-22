using ReservationService.Data.DbAccess;
using ReservationService.Entities.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ReservationService.Services.LocationSevices.Queries.ShowLocation
{
    public class ShowLocationService : IShowLocationService
    {
        private readonly SqlDataAccess _context;

        public ShowLocationService(SqlDataAccess context)
        {
            _context = context;
        }


        public async Task<List<Location>> LocationList(int page)
        {
            var procedureName = "spShowLocationList";
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", page, DbType.Int64, ParameterDirection.Input);

            using (var conneciton = _context.CreateConnection())
            {
                var locationList = await conneciton.QueryAsync<Location>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return locationList.ToList();
            };

        }
    }
}
