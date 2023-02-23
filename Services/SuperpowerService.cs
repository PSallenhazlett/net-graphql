using net_graphql.Data;
using net_graphql.Models;
using net_graphql.Models.Mutations;

namespace net_graphql.Services
{
    public class SuperpowerService : ServiceBase<Superpower, CreateSuperpower>
    {
        public SuperpowerService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        protected override Superpower MapCreate(CreateSuperpower createModel)
        {
            return new Superpower()
            {
                Description = createModel.Description,
                SuperheroId = createModel.SuperheroId,
                SuperPower = createModel.SuperPower
            };
        }

        protected override void UpdateModel(Superpower dbModel, Superpower model)
        {
            dbModel.SuperheroId = model.SuperheroId;
            dbModel.SuperPower = model.SuperPower;
            dbModel.Description = model.Description;
        }

    }
}
