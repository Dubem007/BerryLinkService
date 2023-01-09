using BerryLinkService.Models;
using MediatR;

namespace BerryLinkService.Queries
{
    public class GetBerryListQuery : IRequest<List<BerryDetails>>
    {
    }
}
