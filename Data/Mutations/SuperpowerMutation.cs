using net_graphql.Models.Mutations;
using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Mutations
{
    [ExtendObjectType("Mutation")]
    public class SuperpowerMutation
    {
        [GraphQLDescription("Add a superpower by passing the fields needed to create one.")]
        public async Task<Superpower> AddSuperpower([Service] SuperpowerService superpowerService, CreateSuperpower superpower)
        {
            return await superpowerService.Add(superpower);
        }

        [GraphQLDescription("Update a superpower by passing all the fields of one.")]
        public async Task<Superpower> UpdateSuperpower([Service] SuperpowerService superpowerService, Superpower superpower)
        {
            return await superpowerService.Update(superpower);
        }

        [GraphQLDescription("Delete a superpower by id.")]
        public async Task<DeleteResult> DeleteSuperpower([Service] SuperpowerService superpowerService, Guid id)
        {
            var result = new DeleteResult();

            try
            {
                await superpowerService.Delete(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }

            return result;
        }
    }
}
