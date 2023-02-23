using Microsoft.EntityFrameworkCore;
using net_graphql.Data;
using net_graphql.Models;

namespace net_graphql.Repositories
{
    public class SuperheroRepository : AbstractRepository<Superhero>
    {
        public SuperheroRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        protected override IEnumerable<Superhero> GetIncludes(IQueryable<Superhero> set)
        {
            return set.Include(s => s.Superpowers).Include(s => s.Movies);
        }
    }
}
