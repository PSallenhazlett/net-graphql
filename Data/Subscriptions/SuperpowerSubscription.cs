using net_graphql.Data.Mutations;
using net_graphql.Models;

namespace net_graphql.Data.Subscriptions
{
    [ExtendObjectType("Subscription")]
    public class SuperpowerSubscription
    {
        [Subscribe]
        [Topic(nameof(SuperpowerMutation.AddSuperpower))]
        public Superpower SuperpowerAdded([EventMessage] Superpower superpower) => superpower;

        [Subscribe]
        [Topic(nameof(SuperpowerMutation.UpdateSuperpower))]
        public Superpower SuperpowerUpdated([EventMessage] Superpower superpower) => superpower;

        [Subscribe]
        [Topic(nameof(SuperpowerMutation.DeleteSuperpower))]
        public DeleteResult SuperpowerDeleted([EventMessage] DeleteResult deleteResult) => deleteResult;
    }
}
