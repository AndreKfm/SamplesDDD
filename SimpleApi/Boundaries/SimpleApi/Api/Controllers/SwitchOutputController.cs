using Microsoft.AspNetCore.Mvc;
using SimpleApi.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class SwitchOutputController : ControllerBase
    {

        public SwitchOutputController()
        {

        }

        [HttpGet] public string Get()
        {
            return "SwitchOutputController";
        }

        [HttpPut]
        public ActionResult SetOutput(string whichOutput, [FromServices] IOutputServices outputServices)
        {
            return Ok();
        }
    }
}
