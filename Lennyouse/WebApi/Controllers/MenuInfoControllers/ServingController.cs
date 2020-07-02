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
    public class ServingController : ControllerBase
    {
        private ServingBusinessObject _bo = new ServingBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]ServingViewModel vm)
        {
            var s = vm.ToServing();
            var res = _bo.Create(s);
            return StatusCode(res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<ServingViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var svm = ServingViewModel.Parse(res.Result);
                return svm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<ServingViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<ServingViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(ServingViewModel.Parse(item));
            }
            return list;
        }


        [HttpPut]
        public ActionResult Update([FromBody] ServingViewModel s)
        {
            var currentResult = _bo.Read(s.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.MenuId == s.MenuId && current.CourseId == s.CourseId && current.DishId == s.DishId) return StatusCode((int)HttpStatusCode.NotModified);


            if (current.MenuId != s.MenuId) current.MenuId = s.MenuId;
            if (current.CourseId != s.CourseId) current.CourseId = s.CourseId;
            if (current.DishId != s.DishId) current.DishId = s.DishId;

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