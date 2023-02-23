using net_graphql.Data;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Repositories;
using System.Linq;

namespace net_graphql.Services
{
    public class SuperheroService : AbstractService<Superhero, CreateSuperhero>
    {
        SuperheroRepository _superheroRepository;

        public SuperheroService(SuperheroRepository superheroRepository)
        {
            this._superheroRepository = superheroRepository;
        }

        protected override AbstractRepository<Superhero> LoadRepository()
        {
            return this._superheroRepository;
        }

        protected override Superhero MapCreate(CreateSuperhero createModel)
        {
            return new Superhero()
            {
                Description = createModel.Description,
                Height = createModel.Height,
                Name = createModel.Name,
                Movies = createModel.Movies,
                Superpowers = createModel.Superpowers
            };
        }

        protected override void UpdateModel(Superhero dbModel, Superhero model)
        {
            dbModel.Height = model.Height;
            dbModel.Name = model.Name;
            dbModel.Description = model.Description;
        }
    }
}
