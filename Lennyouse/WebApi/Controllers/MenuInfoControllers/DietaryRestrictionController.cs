using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            var statusCodeNum = res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;
            var statusCode = StatusCode(statusCodeNum);
            return statusCode;

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
                //if(res.Result.UpdatedAt != DateTime.Now) return StatusCode((int)HttpStatusCode.InternalServerError);
                var drvm = DietaryRestrictionViewModel.Parse(res.Result);
                return drvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        //[Authorize]
        [HttpGet]
        public ActionResult<List<DietaryRestrictionViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
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
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.Name == dr.Name) return StatusCode((int)HttpStatusCode.NotModified);


            if (current.Name != dr.Name) current.Name = dr.Name;
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