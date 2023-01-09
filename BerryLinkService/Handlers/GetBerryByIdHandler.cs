using BerryLinkService.Models;
using BerryLinkService.Queries;
using BerryLinkService.Repository;
using MediatR;

namespace BerryLinkService.Handlers
{
    public class GetBerryByIdHandler : IRequestHandler<GetBerryByIdQuery, BerryDetails>
    {
        private readonly IBerryRepository _studentRepository;

        public GetBerryByIdHandler(IBerryRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<BerryDetails> Handle(GetBerryByIdQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentByIdAsync(query.Id);
        }
    }
}
