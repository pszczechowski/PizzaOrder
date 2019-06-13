using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPortal.Contract.PizzaTemplatesDto;
using PizzaPortal.Core.Services;
using PizzaPortal.Infrastructure;
using PizzaPortal.Infrastructure.Context;

namespace PizzaPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaTemplatesController : ControllerBase
    {
        private readonly IPizzaTemplatesService _pizzaTemplatesService;
        
        public PizzaTemplatesController(IPizzaTemplatesService pizzaTemplatesService)
        {
            _pizzaTemplatesService = pizzaTemplatesService;
        }

        [HttpGet("GetPizzaTemplate/{Id}")]
        public async Task<IActionResult> GetPizzaTemplateById(long id)
        {
            try
            {
                var pizzaTemplate = await _pizzaTemplatesService.GetById(id);
                return Ok(pizzaTemplate);

            }
            catch (NullReferenceException )
            {
                return NotFound($"Can't found pizzaTemplate with id = {id}");
            }
        }

        [HttpGet("GetAllPizzaTemplates")]
        public async Task<IActionResult> GetAllPizzaTemplates()
        {
            var pizzaTemplates = await _pizzaTemplatesService.GetAll();
            return Ok(pizzaTemplates);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePizzaTemplates([FromBody] PizzaTemplatesDto pizzaTemplates)
        {
            if (pizzaTemplates == null)
            {
                return BadRequest();
            }

            await _pizzaTemplatesService.Add(pizzaTemplates);
            return Created("Created new Pizza", pizzaTemplates);
        }

        [HttpPut("UpdatePizzaTemplate")]
        public async Task<IActionResult> UpdatePizzaTemplate([FromBody] PizzaTemplatesDto pizzaTemplates)
        {
            if (pizzaTemplates == null)
            {
                return BadRequest();
            }

            await _pizzaTemplatesService.Update(pizzaTemplates);
            return Ok($"Update pizza with id = {pizzaTemplates.Id}");
        }
    }
}