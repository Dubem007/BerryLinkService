using MediatR;

namespace BerryLinkService.Command
{
    public class DeleteBerryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
