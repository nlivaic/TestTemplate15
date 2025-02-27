using TestTemplate15.Core.Entities;
using TestTemplate15.Core.Interfaces;

namespace TestTemplate15.Data.Repositories
{
    public class FooRepository : Repository<Foo>, IFooRepository
    {
        public FooRepository(TestTemplate15DbContext context)
            : base(context)
        {
        }
    }
}
