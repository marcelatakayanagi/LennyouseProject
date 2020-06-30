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
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.MenuInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaryRestrictionController : ControllerBase
    {
        private DietaryRestrictionBusinessObject _bo = new DietaryRestrictionBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]DietaryRestrictionViewModel vm)
        {
            var dr = vm.ToDietaryRestriction();
            var res = _bo.Create(dr);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);

            //var dr = new DietaryRestriction(vm.Id, DateTime.Now, DateTime.Now, vm.IsDeleted, vm.Name);
            //HttpStatusCode code = HttpStatusCode.BadRequest;
            //var res = _bo.Create(dr);//, (res) => code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
            //return InternalServerError
            //var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            //return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<DietaryRestrictionViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var drvm = DietaryRestrictionViewModel.Parse(res.Result);
                return drvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }


        [HttpGet]
        public ActionResult<List<DietaryRestrictionViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<DietaryRestrictionViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(DietaryRestrictionViewModel.Parse(item));
            }
            return list;
        }


        [HttpPut]
        public ActionResult Update([FromBody] DietaryRestrictionViewModel dr)
        {
            var currentResult = _bo.Read(dr.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.Name == dr.Name) return new ObjectResult(HttpStatusCode.NotModified);


            if (current.Name != dr.Name) current.Name = dr.Name;
            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _bo.Delete(id);
            if (result.Success) return Ok();
            return new ObjectResult(HttpStatusCode.InternalServerError);
        }
    }
}