using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Services;
using System.ComponentModel.DataAnnotations;

namespace net_graphql.Data.Mutations
{
    [ExtendObjectType("Mutation")]
    public class SuperheroMutation
    {
        public async Task<Superhero> AddSuperhero([Service] SuperheroService superheroService, CreateSuperhero superhero)
        {
            return await superheroService.Add(new Superhero()
            {
                Description = superhero.Description,
                Height = superhero.Height,
                Movies = superhero.Movies,
                Name = superhero.Name,
                Superpowers = superhero.Superpowers
            });
        }

        public async Task<Superhero> UpdateSuperhero([Service] SuperheroService superheroService, Guid id, string name, string description, double height)
        {
            return await superheroService.Update(new Superhero()
            {
                Id = id,
                Name = name,
                Description = description,
                Height = height,
            });
        }

        public async Task<Superhero> DeleteSuperhero([Service] SuperheroService superheroService, Guid id)
        {
            await superheroService.Delete(id);
            return new Superhero();
        }
    }
}
