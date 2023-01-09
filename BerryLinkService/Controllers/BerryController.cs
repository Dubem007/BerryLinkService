using BerryLinkService.Command;
using BerryLinkService.Models;
using BerryLinkService.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerryLinkService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BerryController : ControllerBase
    {
        private readonly IMediator mediator;

        public BerryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<BerryDetails>> GetBerryListAsync()
        {
            var studentDetails = await mediator.Send(new GetBerryListQuery());

            return studentDetails;
        }

        [HttpGet("berryId")]
        public async Task<BerryDetails> GetStudentByIdAsync(int studentId)
        {
            var studentDetails = await mediator.Send(new GetBerryByIdQuery() { Id = studentId });

            return studentDetails;
        }

        [HttpPost]
        public async Task<BerryDetails> AddStudentAsync(BerryDetails studentDetails)
        {
            var studentDetail = await mediator.Send(new CreateBerryCommand(
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge));
            return studentDetail;
        }

        [HttpPut]
        public async Task<int> UpdateStudentAsync(BerryDetails studentDetails)
        {
            var isStudentDetailUpdated = await mediator.Send(new UpdateBerryCommand(
               studentDetails.Id,
               studentDetails.StudentName,
               studentDetails.StudentEmail,
               studentDetails.StudentAddress,
               studentDetails.StudentAge));
            return isStudentDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int Id)
        {
            return await mediator.Send(new DeleteBerryCommand() { Id = Id });
        }
    }
}
