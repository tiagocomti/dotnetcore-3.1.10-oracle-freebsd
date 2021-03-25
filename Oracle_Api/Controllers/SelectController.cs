using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oracle_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectController : Controller
    {
        // POST api/values  
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }
    }
}
