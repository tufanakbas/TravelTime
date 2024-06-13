using DataAccessLayer.Concrete;
using TravelTime.CQRS.Queries.DestinationQueries;
using TravelTime.CQRS.Results.DestinationResults;

namespace TravelTime.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                DayNight=values.DayNight,
                Price=values.Price
            };
        }
    }
}
