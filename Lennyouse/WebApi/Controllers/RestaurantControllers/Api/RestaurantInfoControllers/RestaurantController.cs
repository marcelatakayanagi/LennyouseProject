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
    public class RestaurantController:ControllerBase
    {
        private RestaurantBusinessObject _bo = new RestaurantBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] RestaurantViewModel vm)
        {
            var r = vm.ToRestaurant();
            var res = _bo.Create(r);
            return StatusCode(res.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var rvm = RestaurantViewModel.Parse(res.Result);
                return rvm;
            }
            else return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<RestaurantViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return StatusCode((int)HttpStatusCode.InternalServerError);
            var list = new List<RestaurantViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(RestaurantViewModel.Parse(item));
            }
            return list;
        }


        [HttpPut]
        public ActionResult Update([FromBody] RestaurantViewModel restaurantView)
        {
            var currentResult = _bo.Read(restaurantView.Id);
            if (!currentResult.Success) return StatusCode((int)HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == restaurantView.Name && current.Address == restaurantView.Address && 
                current.OpeningHours ==restaurantView.OpeningHours && current.ClosingHours == restaurantView.ClosingHours && 
                current.ClosedDays == restaurantView.ClosedDays && current.TableCount == restaurantView.TableCount) 
                return StatusCode((int)HttpStatusCode.NotModified);

            if (current.Name != restaurantView.Name) current.Name = restaurantView.Name;
            if (current.Address != restaurantView.Address) current.Address = restaurantView.Address;
            if (current.OpeningHours!= restaurantView.OpeningHours) current.OpeningHours = restaurantView.OpeningHours;
            if (current.ClosingHours != restaurantView.ClosingHours) current.ClosingHours = restaurantView.ClosingHours;
            if (current.ClosedDays != restaurantView.ClosedDays) current.ClosedDays = restaurantView.ClosedDays;
            if (current.TableCount != restaurantView.TableCount) current.TableCount = restaurantView.TableCount;

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
