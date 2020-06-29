using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private MealBusinessObject _bo = new MealBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]MealViewModel vm)
        {
            var m = new Meal(vm.Name, vm.Starting, vm.Ending);
            var res = _bo.Create(m);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
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
                mvm.Name = res.Result.Name;
                mvm.Starting = res.Result.StartingHours;
                mvm.Ending = res.Result.EndingHours;
                return mvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }
    }
}
