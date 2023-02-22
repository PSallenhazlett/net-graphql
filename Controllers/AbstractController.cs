using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_graphql.Data;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Services;

namespace net_graphql.Controllers
{
    public abstract class AbstractController<TModel, TCreateModel> : ControllerBase where TModel : EntityBase, new() where TCreateModel : class
    {
        protected abstract ServiceBase<TModel> LoadService();
        protected abstract TModel MapCreate(TCreateModel createModel);

        [HttpGet]
        public IActionResult Get()
        {
            var models = this.LoadService().Get();
            return Ok(models);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetSingle(Guid id)
        {
            var model = this.LoadService().GetSingle(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCreateModel createModel)
        {
            var newModel = this.MapCreate(createModel);
            var modelToReturn = await LoadService().Add(newModel);

            return Ok(modelToReturn);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TModel model)
        {
            var updatedModel = await this.LoadService().Update(model);
            return Ok(updatedModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await this.LoadService().Delete(id);
            return Ok(result);
        }
    }


}
