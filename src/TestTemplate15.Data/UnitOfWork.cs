using System.Threading.Tasks;
using TestTemplate15.Common.Interfaces;

namespace TestTemplate15.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestTemplate15DbContext _dbContext;

        public UnitOfWork(TestTemplate15DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}