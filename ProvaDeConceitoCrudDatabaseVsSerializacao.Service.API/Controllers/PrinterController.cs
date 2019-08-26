using Microsoft.AspNetCore.Mvc;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Application.Interfaces;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Service.API.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class PrinterController : Controller
    {
        private readonly IPrinterAppService _printerAppService;

        public PrinterController(IPrinterAppService printerAppService)
        {
            _printerAppService = printerAppService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Printer>> Get()
        {
            return _printerAppService.GetAll().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Printer> Get(Guid id)
        {
            return _printerAppService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Printer> Post([FromBody] Printer value)
        {
            if (value.Id == Guid.Empty)
                value.Id = Guid.NewGuid();

            _printerAppService.Add(value);

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Printer value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            _printerAppService.Update(value);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(Guid id)
        {
            var printer = _printerAppService.GetById(id);

            if (printer == null)
            {
                return NotFound();
            }

            _printerAppService.Remove(id);

            return NoContent();
        }
    }
}