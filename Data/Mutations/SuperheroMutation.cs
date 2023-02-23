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
        public async Task<Superhero> AddSuperhero([Service] SuperheroService superheroService, CreateSuperhero superhero)
        {
            return await superheroService.Add(superhero);
        }

        [GraphQLDescription("Update a superhero by passing all the fields of one.")]
        public async Task<Superhero> UpdateSuperhero([Service] SuperheroService superheroService, Superhero superhero)
        {
            return await superheroService.Update(superhero);
        }

        [GraphQLDescription("Delete a superhero by id.")]
        public async Task<Superhero> DeleteSuperhero([Service] SuperheroService superheroService, Guid id)
        {
            await superheroService.Delete(id);
            return new Superhero()
            {
                Id = Guid.Empty,
                Description = "",
                Height = 0,
                Name = "",
            };
        }
    }
}
