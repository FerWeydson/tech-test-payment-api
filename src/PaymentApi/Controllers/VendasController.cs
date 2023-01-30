using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Requests;
using PaymentApi.Services;
using PaymentApi.Utils;

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
        [HttpGet("{id:long}", Name = "GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var response = await _service.GetById(id);
                return Ok(response);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetAll();
                return Ok(response);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(VendaRequest request)
        {
             try
            {
                var response = await _service.Create(request);
                return CreatedAtAction("GetById", new {id = response.Id}, response);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] StatusVenda status)
        {
             try
            {
                await _service.Update(id, status);
                return Ok("Atualizado");
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}