using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Queries
{
    [ExtendObjectType("Query")]
    public class SuperpowerQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get a list of superheroes.")]
        public IEnumerable<Superpower> GetSuperpowers([Service] ApplicationDbContext context) => context.Superpowers;

        [GraphQLDescription("Get a single superpower by id.")]
        public Superpower GetSuperpower([Service] SuperpowerService superpowerService, Guid id) =>
            superpowerService.GetSingle(id) ?? new Superpower()
            {
                Id = Guid.Empty,
                Description = "",
                SuperheroId = Guid.Empty,
                SuperPower = ""
            };
    }
}
