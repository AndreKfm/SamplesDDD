using Microsoft.AspNetCore.Mvc;
using SampleComplete.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleComplete.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class SwitchOutputController : ControllerBase
    {

        public SwitchOutputController()
        {

        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<string> GetValidOutputs([FromServices] Domain.Ports.IOutputService outputService)
        {
            return outputService.AvailableOutputs();
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult SetOutput(string whichOutput, [FromServices] IChangeOutput outputServices)
        {
            outputServices.SetActiveOutput(whichOutput);
            return Ok();
        }
    }
}
