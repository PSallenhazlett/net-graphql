using net_graphql.Data.Mutations;
using net_graphql.Models;

namespace net_graphql.Data.Subscriptions
{
    [ExtendObjectType("Subscription")]
    public class SuperheroSubscription
    {
        [Subscribe]
        [Topic(nameof(SuperheroMutation.AddSuperhero))]
        public Superhero SuperheroAdded([EventMessage] Superhero superhero) => superhero;

        [Subscribe]
        [Topic(nameof(SuperheroMutation.UpdateSuperhero))]
        public Superhero SuperheroUpdated([EventMessage] Superhero superhero) => superhero;

        [Subscribe]
        [Topic(nameof(SuperheroMutation.DeleteSuperhero))]
        public DeleteResult SuperheroDeleted([EventMessage] DeleteResult deleteResult) => deleteResult;
    }
}
