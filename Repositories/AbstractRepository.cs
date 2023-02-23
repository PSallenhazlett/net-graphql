using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using net_graphql.Data;
using net_graphql.Models;

namespace net_graphql.Repositories
{
    public abstract class AbstractRepository<TModel> where TModel : EntityBase, new()
    {
        ApplicationDbContext _context;

        protected abstract IEnumerable<TModel> GetIncludes(IQueryable<TModel> set);

        public AbstractRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<TModel> Get(Func<TModel, bool>? filter = null)
        {
            if (filter != null)
            {
                return this.GetIncludes(this._context.Set<TModel>()).Where(filter);
            }
            else
            {
                return this.GetIncludes(this._context.Set<TModel>());
            }
        }

        public TModel? GetSingle(Guid id)
        {
            return this.GetIncludes(this._context.Set<TModel>()).FirstOrDefault(o => o.Id == id);
        }

        public async Task<TModel> Add(TModel model)
        {
            await this._context.Set<TModel>().AddAsync(model);
            await this._context.SaveChangesAsync();

            return model;
        }

        public async Task<TModel> Update(TModel model)
        {
            this._context.Set<TModel>().Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(TModel model)
        {
            this._context.Remove(model);
            await this._context.SaveChangesAsync();
        }
    }
}
