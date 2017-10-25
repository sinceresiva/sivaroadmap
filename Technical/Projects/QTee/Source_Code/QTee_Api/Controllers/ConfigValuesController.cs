using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QTee_Api.Controllers
{
    [Route("api/[controller]")]
    public class ConfigValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Siva", "Siddhi" };
        }
    }
}
