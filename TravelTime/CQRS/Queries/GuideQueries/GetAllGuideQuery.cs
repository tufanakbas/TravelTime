using MediatR;
using System.Collections.Generic;
using TravelTime.CQRS.Results.GuideResults;

namespace TravelTime.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
