using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaryRestrictionController : ControllerBase
    {
        private DietaryRestrictionInheritedBusinessObject _bo = new DietaryRestrictionInheritedBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]DietaryRestrictionViewModel vm)
        {
            var dr = new DietaryRestriction(vm.Id, DateTime.Now, DateTime.Now, vm.IsDeleted, vm.Name);
            //HttpStatusCode code = HttpStatusCode.BadRequest;
            var res = _bo.Create(dr);//, (res) => code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<DietaryRestrictionViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var drvm = new DietaryRestrictionViewModel();
                drvm.Id = res.Result.Id;
                drvm.Name = res.Result.Name;
                drvm.IsDeleted = res.Result.IsDeleted;
                return drvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }
    }
}