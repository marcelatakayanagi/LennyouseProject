using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.MenuInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private DishBusinessObject _bo = new DishBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]DishViewModel vm)
        {
            var d = vm.ToDish();
            var res = _bo.Create(d);
            return StatusCode(res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<DishViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var dvm = DishViewModel.Parse(res.Result);
                return dvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<DishViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<DishViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(DishViewModel.Parse(item));
            }
            return list;
        }


        [HttpPut]
        public ActionResult Update([FromBody] DishViewModel d)
        {
            var currentResult = _bo.Read(d.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.Name == d.Name && current.DietaryRestrictionId == d.DietaryRestrictionId) return StatusCode((int)HttpStatusCode.NotModified);


            if (current.Name != d.Name) current.Name = d.Name;
            if (current.DietaryRestrictionId != d.DietaryRestrictionId) current.DietaryRestrictionId = d.DietaryRestrictionId;
            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _bo.Delete(id);
            if (result.Success) return Ok();
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}