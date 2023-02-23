using net_graphql.Data;
using net_graphql.Models;

namespace net_graphql.Repositories
{
    public class SuperpowerRepository : AbstractRepository<Superpower>
    {
        public SuperpowerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
