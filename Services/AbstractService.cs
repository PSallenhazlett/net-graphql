using net_graphql.Data;
using net_graphql.Models.Mutations;
using net_graphql.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using net_graphql.Repositories;

namespace net_graphql.Services
{
    public abstract class AbstractService<TModel, TCreateModel> where TModel : EntityBase, new() where TCreateModel : class
    {
        protected abstract TModel MapCreate(TCreateModel createModel);
        protected abstract void UpdateModel(TModel dbModel, TModel model);

        protected abstract AbstractRepository<TModel> LoadRepository();

        public IEnumerable<TModel> Get(Func<TModel, bool>? filter = null)
        {
            return this.LoadRepository().Get(filter);
        }

        public TModel? GetSingle(Guid id)
        {
            return this.LoadRepository().GetSingle(id);
        }

        public async Task<TModel> Add(TCreateModel createModel)
        {
            var model = this.MapCreate(createModel);
            return await LoadRepository().Add(model);
        }

        public async Task<TModel> Update(TModel model)
        {
            var dbModel = this.GetSingle(model.Id);
            this.UpdateModel(dbModel, model);

            return await this.LoadRepository().Update(dbModel);
        }

        public async Task<DeleteResult> Delete(Guid id)
        {
            var success = false;
            var dbModel = this.GetSingle(id);

            try 
            {
                if (dbModel == null)
                {
                    throw new Exception("Could not find Model based on Id");
                }

                await this.LoadRepository().Delete(dbModel);
                success = true;
            }
            catch (Exception ex)
            {
                return new DeleteResult()
                {
                    Success = success,
                    Exception = ex
                };
            }

            return new DeleteResult()
            {
                Success = success,
            };
        }
    }
}
