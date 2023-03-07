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
    }
}
