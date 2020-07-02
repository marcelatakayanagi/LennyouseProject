using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.MenuInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private MenuBusinessObject _bo = new MenuBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] MenuViewModel vm)
        {
            var m = vm.ToMenu();
            var res = _bo.Create(m);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<MenuViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var mvm = MenuViewModel.Parse(res.Result);
                return mvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<MenuViewModel>> List()
        {
            var res = _bo.List();
            if (res.Success)
            {
                var list = new List<MenuViewModel>();
                foreach (var item in res.Result)
                    list.Add(MenuViewModel.Parse(item));
                return list;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpPut]
        public ActionResult Update([FromBody] MenuViewModel vm)
        {
            var res = _bo.Read(vm.Id);
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = res.Result;
            if (current == null) return NotFound();
            if (vm.Equals(current)) return new ObjectResult(HttpStatusCode.NotModified);
            if (current.MealId != vm.MealId) current.MealId = vm.MealId;
            if (current.RestaurantId != vm.RestaurantId) current.RestaurantId = vm.RestaurantId;
            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var res = _bo.Delete(id);
            if (res.Success) return Ok();
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }
    }
}
