﻿using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO;
using Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers.RestaurantControllers.Api.MenuInfoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private MenuBusinessObject _bo = new MenuBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] MenuViewModel vm)
        {
            var m = vm.ToMenu();
            var res = _bo.Create(m);
            if (res.Success) return Ok();
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<MenuViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var mvm = MenuViewModel.Parse(res.Result);
                return mvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<MenuViewModel>> List()
        {
            var res = _bo.List();
            if (res.Success)
            {
                var list = new List<MenuViewModel>();
                foreach (var item in res.Result)
                    list.Add(MenuViewModel.Parse(item));
                return list;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPut]
        public ActionResult Update([FromBody] MenuViewModel vm)
        {
            var res = _bo.Read(vm.Id);
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var current = res.Result;
            if (current == null) return NotFound();
            if (vm.Equals(current)) return StatusCode((int)HttpStatusCode.NotModified);
            if (current.Date != vm.Date) current.Date = vm.Date;
            if (current.MealId != vm.MealId) current.MealId = vm.MealId;
            if (current.RestaurantId != vm.RestaurantId) current.RestaurantId = vm.RestaurantId;
            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var res = _bo.Delete(id);
            if (res.Success) return Ok();
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
