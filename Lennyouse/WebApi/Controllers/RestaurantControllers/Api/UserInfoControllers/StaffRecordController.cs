using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfoBO;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.UserInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.RestaurantControllers.Api.UserInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffRecordController : ControllerBase
    {
        private StaffRecordBusinessObject _bo = new StaffRecordBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] StaffRecordViewModel vm)
        {
            var p = vm.ToStaffRecord();
            var res = _bo.Create(p);
            return StatusCode(res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<StaffRecordViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var srvm = StaffRecordViewModel.Parse(res.Result);
                return srvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }
        [HttpGet]
        public ActionResult<List<StaffRecordViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<StaffRecordViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffRecordViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] StaffRecordViewModel sr)
        {
            var currentResult = _bo.Read(sr.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.BeginDate == sr.BeginDate && current.EndDate == sr.EndDate) return StatusCode((int)HttpStatusCode.InternalServerError);

            if (current.BeginDate != sr.BeginDate) current.BeginDate = sr.BeginDate;
            if (current.EndDate != sr.EndDate) current.EndDate = sr.EndDate;

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
