using net_graphql.Models.Mutations;
using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Mutations
{
    [ExtendObjectType("Mutation")]
    public class SuperpowerMutation
    {
        public async Task<Superpower> AddSuperpower([Service] SuperpowerService superpowerService, CreateSuperpower superpower)
        {
            return await superpowerService.Add(superpower);
        }

        public async Task<Superpower> UpdateSuperpower([Service] SuperpowerService superpowerService, Superpower superpower)
        {
            return await superpowerService.Update(superpower);
        }

        public async Task<Superpower> DeleteSuperpower([Service] SuperpowerService superpowerService, Guid id)
        {
            await superpowerService.Delete(id);
            return new Superpower();
        }
    }
}
