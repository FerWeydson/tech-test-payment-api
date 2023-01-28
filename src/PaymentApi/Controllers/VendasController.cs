using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Services;

namespace PaymentApi.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _service;
        public VendasController(IVendaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

            }catch
            {

            }
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