using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleComplete.Domain.Entities;
using SampleComplete.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleComplete.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public UsersController()
        {

        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult NewUser(string userName, [FromServices] IEventBus bus)
        {
            var user = new User(bus, userName);
            return Ok();
        }
    }
}
