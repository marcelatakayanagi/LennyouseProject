using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.RestaurantControllers.Api.MenuInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseBusinessObject _bo = new CourseBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]CourseViewModel vm)
        {
            var c = vm.ToCourse();
            var res = _bo.Create(c);
            return StatusCode(res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<CourseViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var cvm = CourseViewModel.Parse(res.Result);
                return cvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<CourseViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<CourseViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(CourseViewModel.Parse(item));
            }
            return list;
        }


        [HttpPut]
        public ActionResult Update([FromBody] CourseViewModel c)
        {
            var currentResult = _bo.Read(c.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.Name == c.Name) return StatusCode((int)HttpStatusCode.NotModified);


            if (current.Name != c.Name) current.Name = c.Name;
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