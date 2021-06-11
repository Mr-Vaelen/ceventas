using System;
using Microsoft.AspNetCore.Mvc;

namespace Ceventas.Controllers
{
    [Route("api/UrlEncode")]
    [ApiController]
    public class UrlEncode : ControllerBase
    {
        [HttpPost]
        public string encode([FromHeader] string longUrl)
        {
            return Encoder.encode(longUrl);
        }

        [HttpGet]
        public string decode([FromHeader] string shortUrl)
        {
            return Encoder.decode(shortUrl);
        }

        
    }
}
