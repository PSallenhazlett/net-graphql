using net_graphql.Data.Mutations;
using net_graphql.Models;

namespace net_graphql.Data.Subscriptions
{
    [ExtendObjectType("Subscription")]
    public class MovieSubscription
    {
        [Subscribe]
        [Topic(nameof(MovieMutation.AddMovie))]
        public Movie MovieAdded([EventMessage] Movie movie) => movie;

        [Subscribe]
        [Topic(nameof(MovieMutation.UpdateMovie))]
        public Movie MovieUpdated([EventMessage] Movie movie) => movie;

        [Subscribe]
        [Topic(nameof(MovieMutation.DeleteMovie))]
        public DeleteResult MovieDeleted([EventMessage] DeleteResult deleteResult) => deleteResult;
    }
}
