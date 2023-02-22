using net_graphql.Data;
using net_graphql.Models;

namespace net_graphql.Services
{
    public class SuperpowerService : ServiceBase<Superpower>
    {
        public SuperpowerService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override void PreAddLogic(Superpower newObj, Superpower passedData)
        {
            newObj.Description = passedData.Description;
            newObj.SuperheroId = passedData.SuperheroId;
            newObj.SuperPower = passedData.SuperPower;
        }

        public override void UpdateModel(Superpower dbModel, Superpower model)
        {
            dbModel.SuperheroId = model.SuperheroId;
            dbModel.SuperPower = model.SuperPower;
            dbModel.Description = model.Description;
        }
    }
}
