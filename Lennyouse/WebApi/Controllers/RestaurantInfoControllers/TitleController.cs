using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfoBO;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.RestaurantInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.RestaurantInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController: ControllerBase
    {
        private TitleBusinessObject _bo = new TitleBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] TitleViewModel vm)
        {
            var t = vm.ToTitle();
            var res = _bo.Create(t);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<TitleViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var tvm = TitleViewModel.Parse(res.Result);
                return tvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<TitleViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<TitleViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(TitleViewModel.Parse(item));
            }
            return list;
        }


        [HttpPut]
        public ActionResult Update([FromBody] TitleViewModel tvm)
        {
            var currentResult = _bo.Read(tvm.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == tvm.Name && current.OpeningHours == tvm.OpeningHours && 
                current.ClosingHours  == tvm.ClosingHours) return StatusCode((int)HttpStatusCode.NotModified);
            if (current.Name != tvm.Name) current.Name = tvm.Name;
            if (current.OpeningHours != tvm.OpeningHours) current.OpeningHours = tvm.OpeningHours;
            if (current.ClosingHours != tvm.ClosingHours) current.ClosingHours = tvm.ClosingHours;
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
