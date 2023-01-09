using BerryLinkService.Command;
using BerryLinkService.Repository;
using MediatR;

namespace BerryLinkService.Handlers
{
    public class DeleteBerryHandler : IRequestHandler<DeleteBerryCommand, int>
    {
        private readonly IBerryRepository _studentRepository;

        public DeleteBerryHandler(IBerryRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteBerryCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (studentDetails == null)
                return default;

            return await _studentRepository.DeleteStudentAsync(studentDetails.Id);
        }
    }
}
