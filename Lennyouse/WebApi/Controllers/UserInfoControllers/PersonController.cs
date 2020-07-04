using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfoBO;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.UserInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.UserInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonBusinessObject _bo = new PersonBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] PersonViewModel vm)
        {
            var p = vm.ToPerson();
            var res = _bo.Create(p);
            return StatusCode(res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var pvm = PersonViewModel.Parse(res.Result);
                return pvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<PersonViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<PersonViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(PersonViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] PersonViewModel p)
        {
            var currentResult = _bo.Read(p.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.FirstName == p.FirstName && current.LastName == p.LastName && current.BirthDate == p.BirthDate && 
                current.PhoneNumber == p.PhoneNumber && current.VatNumber == p.VatNumber) 
                return StatusCode((int)HttpStatusCode.InternalServerError);

            if (current.FirstName != p.FirstName) current.FirstName = p.FirstName;
            if (current.LastName != p.LastName) current.LastName = p.LastName;
            if (current.BirthDate != p.BirthDate) current.BirthDate = p.BirthDate;
            if (current.PhoneNumber != p.PhoneNumber) current.PhoneNumber = p.PhoneNumber;
            if (current.VatNumber != p.PhoneNumber) current.VatNumber = p.VatNumber;

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
