using BerryLinkService.Command;
using BerryLinkService.Models;
using BerryLinkService.Repository;
using MediatR;

namespace BerryLinkService.Handlers
{
    public class UpdateBerryHandler : IRequestHandler<UpdateBerryCommand, int>
    {
        private readonly IBerryRepository _studentRepository;

        public UpdateBerryHandler(IBerryRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<int> Handle(UpdateBerryCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (studentDetails == null)
                return default;

            studentDetails.StudentName = command.StudentName;
            studentDetails.StudentEmail = command.StudentEmail;
            studentDetails.StudentAddress = command.StudentAddress;
            studentDetails.StudentAge = command.StudentAge;

            return await _studentRepository.UpdateStudentAsync(studentDetails);

        }
    }
}
