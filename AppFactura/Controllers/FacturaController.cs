using AppFactura.Models;
using AppFactura.Repos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly  FacturaRepo _facturaRepo;

        public FacturaController(FacturaRepo facturaRepo) => _facturaRepo = facturaRepo;

        // GET: api/<FacturaController>
        [HttpGet]
        public IEnumerable<Factura> Get()
        {
            return _facturaRepo.facturas();
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public ActionResult<Factura> Get(int id)
        {
            var fact = _facturaRepo.finFacturaById(id);
            if (fact == null)
            {
                NotFound();
            }
            return Ok(fact);  
        }

        // POST api/<FacturaController>
        [HttpPost]
        public async Task<ActionResult<Factura>> Post(Factura fact)
        {
            await _facturaRepo.createFacturaAsync(fact);
            return Ok(fact);
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Factura>> Put(int id,  Factura fact)
        {
            if (id != fact.Id)
            {
                BadRequest();
            }
            await _facturaRepo.updateFacturaAsync(fact);   
            return Ok(fact);

        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var find = _facturaRepo.finFacturaById(id);
            if(find == null)
            {
                NotFound();
            }
            await _facturaRepo.deleteFacturaAsync(find);
            return Ok();

        }
    }
}
