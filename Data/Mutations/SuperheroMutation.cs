using HotChocolate.Subscriptions;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Services;
using System.ComponentModel.DataAnnotations;

namespace net_graphql.Data.Mutations
{
    [ExtendObjectType("Mutation")]
    public class SuperheroMutation
    {
        [GraphQLDescription("Add a superhero by passing the fields needed to create one.")]
        public async Task<Superhero> AddSuperhero([Service] SuperheroService superheroService, [Service] ITopicEventSender sender, CreateSuperhero superhero, CancellationToken cancellationToken)
        {
            var newSuperhero = await superheroService.Add(superhero);
            await sender.SendAsync(nameof(AddSuperhero), newSuperhero, cancellationToken);

            return newSuperhero;
        }

        [GraphQLDescription("Update a superhero by passing all the fields of one.")]
        public async Task<Superhero> UpdateSuperhero([Service] SuperheroService superheroService, [Service] ITopicEventSender sender, Superhero superhero, CancellationToken cancellationToken)
        {
            var updatedMovie = await superheroService.Update(superhero);
            await sender.SendAsync(nameof(UpdateSuperhero), updatedMovie, cancellationToken);

            return updatedMovie;
        }

        [GraphQLDescription("Delete a superhero by id.")]
        public async Task<DeleteResult> DeleteSuperhero([Service] SuperheroService superheroService, [Service] ITopicEventSender sender, Guid id, CancellationToken cancellationToken)
        {
            var result = new DeleteResult();

            try
            {
                await superheroService.Delete(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }

            await sender.SendAsync(nameof(DeleteSuperhero), result, cancellationToken);

            return result;
        }
    }
}
