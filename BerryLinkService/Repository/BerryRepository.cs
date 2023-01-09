using BerryLinkService.Data;
using BerryLinkService.Models;
using Microsoft.EntityFrameworkCore;

namespace BerryLinkService.Repository
{
    public class BerryRepository : IBerryRepository
    {
        private readonly DbContextClass _dbContext;

        public BerryRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BerryDetails> AddStudentAsync(BerryDetails studentDetails)
        {
            var result = _dbContext.Students.Add(studentDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var filteredData = _dbContext.Students.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Students.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<BerryDetails> GetStudentByIdAsync(int Id)
        {
            return await _dbContext.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<BerryDetails>> GetStudentListAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(BerryDetails studentDetails)
        {
            _dbContext.Students.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
