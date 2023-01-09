using BerryLinkService.Command;
using BerryLinkService.Models;
using BerryLinkService.Repository;
using MediatR;

namespace BerryLinkService.Handlers
{
    public class CreateBerryHandler : IRequestHandler<CreateBerryCommand, BerryDetails>
    {
        private readonly IBerryRepository _studentRepository;

        public CreateBerryHandler(IBerryRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<BerryDetails> Handle(CreateBerryCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = new BerryDetails()
            {
                StudentName = command.StudentName,
                StudentEmail = command.StudentEmail,
                StudentAddress = command.StudentAddress,
                StudentAge = command.StudentAge
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}
