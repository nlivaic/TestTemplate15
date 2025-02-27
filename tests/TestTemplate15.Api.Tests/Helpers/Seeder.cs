using System.Collections.Generic;
using TestTemplate15.Core.Entities;
using TestTemplate15.Data;

namespace TestTemplate15.Api.Tests.Helpers
{
    public static class Seeder
    {
        public static void Seed(this TestTemplate15DbContext ctx)
        {
            ctx.Foos.AddRange(
                new List<Foo>
                {
                    new ("Text 1"),
                    new ("Text 2"),
                    new ("Text 3")
                });
            ctx.SaveChanges();
        }
    }
}
