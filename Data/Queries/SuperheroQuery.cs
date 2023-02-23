using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Queries
{
    [ExtendObjectType("Query")]
    public class SuperheroQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get a list of superheroes.")]
        public IEnumerable<Superhero> GetSuperheroes([Service] SuperheroService superheroService) => 
            superheroService.Get();

        [GraphQLDescription("Get a single superhero by id.")]
        public Superhero GetSuperhero([Service] SuperheroService superheroService, Guid id) => 
            superheroService.GetSingle(id) ?? new Superhero();
    }
}
