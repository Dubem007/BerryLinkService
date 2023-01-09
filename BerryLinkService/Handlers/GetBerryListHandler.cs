using BerryLinkService.Models;
using BerryLinkService.Queries;
using BerryLinkService.Repository;
using MediatR;

namespace BerryLinkService.Handlers
{
    public class GetBerryListHandler : IRequestHandler<GetBerryListQuery, List<BerryDetails>>
    {
        private readonly IBerryRepository _studentRepository;

        public GetBerryListHandler(IBerryRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<BerryDetails>> Handle(GetBerryListQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentListAsync();
        }
    }
}
