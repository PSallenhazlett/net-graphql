using net_graphql.Data;
using net_graphql.Models.Mutations;
using net_graphql.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace net_graphql.Services
{
    public abstract class ServiceBase<TModel> where TModel : EntityBase, new()
    {
        ApplicationDbContext _context;

        public ServiceBase(ApplicationDbContext context)
        {   
            this._context = context;
        }

        ~ServiceBase()
        {
            this._context.Dispose();
        }

        public abstract void PreAddLogic(TModel newObj, TModel passedData);
        public abstract void UpdateModel(TModel dbModel, TModel model);

        public IEnumerable<TModel> Get(Func<TModel, bool>? filter = null)
        {
            if (filter != null)
            {
                return this._context.Set<TModel>().Where(filter);
            }
            else
            {
                return this._context.Set<TModel>();
            }
        }

        public TModel? GetSingle(Guid id)
        {
            return this._context.Set<TModel>().FirstOrDefault(o => o.Id == id);
        }

        public async Task<TModel> Add(TModel model)
        {
            var newObj = new TModel();
            PreAddLogic(newObj, model);

            await this._context.Set<TModel>().AddAsync(newObj);
            await this._context.SaveChangesAsync();

            return model;
        }

        public async Task<TModel> Update(TModel model)
        {
            var dbModel = this.GetSingle(model.Id);
            this.UpdateModel(dbModel, model);

            this._context.Set<TModel>().Update(dbModel);
            await _context.SaveChangesAsync();

            return dbModel;
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

                this._context.Remove(dbModel);

                await this._context.SaveChangesAsync();
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
