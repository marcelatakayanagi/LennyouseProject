using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfoBO;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.RestaurantInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.RestaurantControllers.Api.RestaurantInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController: ControllerBase
    {
        private BookingBusinessObject _bo = new BookingBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] BookingViewModel vm)
        {
            var b = vm.ToBooking();
            var res = _bo.Create(b);
            return StatusCode(res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var bvm = BookingViewModel.Parse(res.Result);
                return bvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<BookingViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<BookingViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(BookingViewModel.Parse(item));
            }
            return list;
        }


        [HttpPut]
        public ActionResult Update([FromBody] BookingViewModel b)
        {
            var currentResult = _bo.Read(b.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Date == b.Date && current.ClientRecordId == b.ClientRecordId) return StatusCode((int)HttpStatusCode.NotModified);
            if (current.Date != b.Date) current.Date = b.Date;
            if (current.ClientRecordId != b.ClientRecordId) current.ClientRecordId = b.ClientRecordId;
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
