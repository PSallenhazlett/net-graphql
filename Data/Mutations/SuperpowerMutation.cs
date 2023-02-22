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
            return await superpowerService.Add(new Superpower()
            {
                Description = superpower.Description,
                SuperPower = superpower.SuperPower,
                SuperheroId = superpower.SuperheroId
            });
        }

        public async Task<Superpower> UpdateSuperpower([Service] SuperpowerService superpowerService, Guid id, string superPower, string description, Guid superheroId)
        {
            return await superpowerService.Update(new Superpower()
            {
                Id = id,
                SuperPower = superPower,
                Description = description,
                SuperheroId = superheroId,
            });
        }

        public async Task<Superpower> DeleteSuperpower([Service] SuperpowerService superpowerService, Guid id)
        {
            await superpowerService.Delete(id);

            return new Superpower();
        }
    }
}
