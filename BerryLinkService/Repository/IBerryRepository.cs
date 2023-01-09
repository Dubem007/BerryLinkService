using BerryLinkService.Models;

namespace BerryLinkService.Repository
{
    public interface IBerryRepository
    {
        public Task<List<BerryDetails>> GetStudentListAsync();
        public Task<BerryDetails> GetStudentByIdAsync(int Id);
        public Task<BerryDetails> AddStudentAsync(BerryDetails studentDetails);
        public Task<int> UpdateStudentAsync(BerryDetails studentDetails);
        public Task<int> DeleteStudentAsync(int Id);
    }
}
