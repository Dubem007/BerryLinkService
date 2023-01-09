using BerryLinkService.Models;
using MediatR;

namespace BerryLinkService.Queries
{
    public class GetBerryByIdQuery : IRequest<BerryDetails>
    {
        public int Id { get; set; }
    }
}
