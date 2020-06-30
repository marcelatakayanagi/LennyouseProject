using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string HelloWorld()
        {
            return "HelloWorld";
        }

        [HttpGet("{name}")]
        public string Hello(string name)
        {
            return $"Hello {name}";
        }

        [HttpGet("person")]
        public string HelloPerson(string name)
        {
            return $"Hello {name}";
        }

        [HttpPost]
        public string HelloIndividual([FromBody]string name)
        {
            return $"Hello {name}";
        }
    }
}