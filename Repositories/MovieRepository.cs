using net_graphql.Data;
using net_graphql.Models;

namespace net_graphql.Repositories
{
    public class MovieRepository : AbstractRepository<Movie>
    {
        public MovieRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
