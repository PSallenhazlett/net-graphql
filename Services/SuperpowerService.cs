using net_graphql.Data;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Repositories;

namespace net_graphql.Services
{
    public class SuperpowerService : AbstractService<Superpower, CreateSuperpower>
    {
        SuperpowerRepository _superpowerRepository;

        public SuperpowerService(SuperpowerRepository superpowerRepository)
        {
            this._superpowerRepository = superpowerRepository;
        }

        protected override AbstractRepository<Superpower> LoadRepository()
        {
            return this._superpowerRepository;
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
