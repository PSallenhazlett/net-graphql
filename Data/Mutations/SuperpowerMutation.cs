using net_graphql.Models.Mutations;
using net_graphql.Models;
using net_graphql.Services;
using HotChocolate.Subscriptions;

namespace net_graphql.Data.Mutations
{
    [ExtendObjectType("Mutation")]
    public class SuperpowerMutation
    {
        [GraphQLDescription("Add a superpower by passing the fields needed to create one.")]
        public async Task<Superpower> AddSuperpower([Service] SuperpowerService superpowerService, [Service] ITopicEventSender sender, CreateSuperpower superpower, CancellationToken cancellationToken)
        {
            var power = await superpowerService.Add(superpower);
            await sender.SendAsync(nameof(AddSuperpower), power, cancellationToken);

            return power;
        }

        [GraphQLDescription("Update a superpower by passing all the fields of one.")]
        public async Task<Superpower> UpdateSuperpower([Service] SuperpowerService superpowerService, [Service] ITopicEventSender sender, Superpower superpower, CancellationToken cancellationToken)
        {
            var power = await superpowerService.Update(superpower);
            await sender.SendAsync(nameof(UpdateSuperpower), power, cancellationToken);
            
            return power;
        }

        [GraphQLDescription("Delete a superpower by id.")]
        public async Task<DeleteResult> DeleteSuperpower([Service] SuperpowerService superpowerService, [Service] ITopicEventSender sender, Guid id, CancellationToken cancellationToken)
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

            await sender.SendAsync(nameof(DeleteSuperpower), result, cancellationToken);

            return result;
        }
    }
}
