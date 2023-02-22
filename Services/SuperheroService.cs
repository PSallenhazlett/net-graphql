using net_graphql.Data;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using System.Linq;

namespace net_graphql.Services
{
    public class SuperheroService : ServiceBase<Superhero>
    {
        public SuperheroService(ApplicationDbContext context) : base(context)
        {
        }

        public override void PreAddLogic(Superhero newObj, Superhero passedData)
        {
            newObj.Description = passedData.Description;
            newObj.Height = passedData.Height;
            newObj.Movies = passedData.Movies;
            newObj.Name = passedData.Name;
            newObj.Superpowers = passedData.Superpowers;
        }

        public override void UpdateModel(Superhero dbModel, Superhero model)
        {
            dbModel.Height = model.Height;
            dbModel.Name = model.Name;
            dbModel.Description = model.Description;
        }
    }
}
