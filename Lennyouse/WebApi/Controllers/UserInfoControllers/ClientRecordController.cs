using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfoBO;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.UserInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.UserInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientRecordController : ControllerBase
    {
        private ClientRecordBusinessObject _bo = new ClientRecordBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] ClientRecordViewModel vm)
        {
            var p = vm.ToClientRecord();
            var res = _bo.Create(p);
            return StatusCode(res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<ClientRecordViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var crvm = ClientRecordViewModel.Parse(res.Result);
                return crvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<ClientRecordViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<ClientRecordViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(ClientRecordViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] ClientRecordViewModel cr)
        {
            var currentResult = _bo.Read(cr.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.RegisterDate ==  cr.RegisterDate) return StatusCode((int)HttpStatusCode.InternalServerError);

            if (current.RegisterDate != cr.RegisterDate) current.RegisterDate = cr.RegisterDate;

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
