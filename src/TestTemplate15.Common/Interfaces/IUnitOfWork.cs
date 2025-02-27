using System.Threading.Tasks;

namespace TestTemplate15.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}