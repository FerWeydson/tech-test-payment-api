using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PaymentApi.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class VendasController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> getAll()
        {

        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {

        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id)
        {

        }
    }
}