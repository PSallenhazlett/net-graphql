using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Queries
{
    [ExtendObjectType("Query")]
    public class SuperheroQuery
    {
        public IEnumerable<Superhero> GetSuperheroes([Service] SuperheroService superheroService) => 
            superheroService.Get();

        public Superhero GetSuperhero([Service] SuperheroService superheroService, Guid id) => 
            superheroService.GetSingle(id) ?? new Superhero();
    }
}
