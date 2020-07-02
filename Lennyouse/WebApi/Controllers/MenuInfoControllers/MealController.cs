using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.MenuInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private MealBusinessObject _bo = new MealBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] MealViewModel vm)
        {
            var m = new Meal(vm.Name, vm.Starting, vm.Ending);
            var res = _bo.Create(m);
            var code = res.Success ? Ok() : StatusCode((int)HttpStatusCode.InternalServerError);
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<MealViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                var mvm = new MealViewModel();
                if (res.Result == null) return NotFound();
                mvm.Id = res.Result.Id;
                mvm.Name = res.Result.Name;
                mvm.Starting = res.Result.StartingHours;
                mvm.Ending = res.Result.EndingHours;
                return mvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<MealViewModel>> List()
        {
            var res = _bo.List();
            if (res.Success)
            {
                var list = new List<MealViewModel>();
                foreach (var item in res.Result)
                    list.Add(MealViewModel.Parse(item));
                return list;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPut]
        public ActionResult Update([FromBody] MealViewModel vm)
        {
            var res = _bo.Read(vm.Id);
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = res.Result;
            if (current == null) return NotFound();
            if (current.Name == vm.Name && current.StartingHours == vm.Starting && current.EndingHours == vm.Ending) return StatusCode((int)HttpStatusCode.NotModified);
            if (current.Name != vm.Name) current.Name = vm.Name;
            if (current.StartingHours != vm.Starting) current.StartingHours = vm.Starting;
            if (current.EndingHours != vm.Ending) current.EndingHours = vm.Ending;
            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var res = _bo.Delete(id);
            if (res.Success) return Ok();
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
