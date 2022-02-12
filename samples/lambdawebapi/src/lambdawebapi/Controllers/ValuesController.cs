﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lambdawebapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("ip")]
        public IActionResult GetIp()
        {
            var ip = HttpContext.Connection.RemoteIpAddress;
            var v4 = ip.MapToIPv4().ToString();
            return Ok($"{ip.ToString()} - {v4}");
        }

        [HttpGet("test-generic")]
        public IActionResult Test([FromServices] IList<int> list)
        {
            list?.Add(1);
            return Ok( list?.Count);

        }
    }
}
