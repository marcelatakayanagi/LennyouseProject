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
    public class StaffTitleController: ControllerBase
    {
        private StaffTitleBusinessObject _bo = new StaffTitleBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] StaffTitleViewModel vm)
        {
            var b = vm.ToStaffTitle();
            var res = _bo.Create(b);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<StaffTitleViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var stvm = StaffTitleViewModel.Parse(res.Result);
                return stvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<StaffTitleViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<StaffTitleViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffTitleViewModel.Parse(item));
            }
            return list;
        }


        [HttpPut]
        public ActionResult Update([FromBody] StaffTitleViewModel stvm)
        {
            var currentResult = _bo.Read(stvm.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.StartDate == stvm.StartDate && current.EndDate == stvm.EndDate && current.TitleId == stvm.TitleId && 
                current.StaffRecordId == stvm.StaffRecordId) 
                return StatusCode((int)HttpStatusCode.NotModified);

            if (current.StartDate != stvm.StartDate) current.StartDate = stvm.StartDate;
            if (current.EndDate != stvm.EndDate) current.EndDate = stvm.EndDate;
            if (current.TitleId != stvm.TitleId) current.TitleId = stvm.TitleId;
            if (current.StaffRecordId != stvm.StaffRecordId) current.StaffRecordId = stvm.StaffRecordId;

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
