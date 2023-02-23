using Microsoft.EntityFrameworkCore;
using net_graphql.Data;
using net_graphql.Models;

namespace net_graphql.Repositories
{
    public class MovieRepository : AbstractRepository<Movie>
    {
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        protected override IEnumerable<Movie> GetIncludes(IQueryable<Movie> set)
        {
            return set.Include(m => m.Superhero);
        }
    }
}
