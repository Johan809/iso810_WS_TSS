using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceProcesarTSS.Model;

namespace WebServiceProcesarTSS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutodeterminacionController : ControllerBase
    {
        private readonly ILogger<AutodeterminacionController> _logger;
        private readonly TSSDbContext _context;

        public AutodeterminacionController(TSSDbContext context, ILogger<AutodeterminacionController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetAutodeterminaciones")]
        public async Task<ActionResult<List<AutodeterminacionTSS>>> Get()
        {
            List<AutodeterminacionTSS> autodeterminaciones = await _context
                .Autodeterminaciones.ToListAsync();
            return Ok(autodeterminaciones);
        }

        [HttpGet("PorRNC/{rnc}", Name = "GetAutodeterminacionPorRNC")]
        public async Task<ActionResult<List<AutodeterminacionTSS>>> GetByRnc(string rnc)
        {
            var autodeterminaciones = await _context.Autodeterminaciones
                .Where(ad => ad.RncEmpresa == rnc)
                .ToListAsync();

            if (autodeterminaciones == null || autodeterminaciones.Count == 0)
                return NotFound();

            return Ok(autodeterminaciones);
        }

        [HttpGet("PorID/{id}", Name = "GetAutodeterminacionPorID")]
        public async Task<ActionResult<AutodeterminacionTSS>> GetAutodeterminacion(int id)
        {
            var autodeterminacion = await _context.Autodeterminaciones.FindAsync(id);
            if (autodeterminacion == null)
                return NotFound();

            return Ok(autodeterminacion);
        }

        [HttpPost(Name = "CreateAutodeterminacion")]
        public async Task<ActionResult<bool>> Create(AutodeterminacionWrapper wrapper)
        {
            if (wrapper == null)
                return BadRequest();

            foreach (AutodeterminacionWrapper.EmpleadoDTO empleado in wrapper.Detalles)
            {
                AutodeterminacionTSS autodeterminacion = new AutodeterminacionTSS()
                {
                    RncEmpresa = wrapper.Encabezado.RncEmpresa,
                    FechaTransmision = wrapper.Encabezado.FechaTransmision,
                    PeriodoCotizable = wrapper.Encabezado.PeriodoCotizable,
                    Nss = empleado.Nss,
                    Cedula = empleado.Cedula,
                    Nombres = empleado.Nombres,
                    Apellidos = empleado.Apellidos,
                    SueldoMensual = empleado.SueldoMensual,
                    MontoCotizable = empleado.MontoCotizable,
                    FechaIngreso = empleado.FechaIngreso,
                    TipoContrato = empleado.TipoContrato,
                    Estado = empleado.Estado,
                };
                _context.Autodeterminaciones.Add(autodeterminacion);
            }
            await _context.SaveChangesAsync();

            return Ok(new { Exitoso = true });
        }

        [HttpDelete("{id}", Name = "DeleteAutodeterminacion")]
        public async Task<IActionResult> Delete(int id)
        {
            var autodeterminacion = await _context.Autodeterminaciones
                .SingleOrDefaultAsync(ad => ad.IdRegistro == id);
            if (autodeterminacion == null)
                return NotFound();

            _context.Autodeterminaciones.Remove(autodeterminacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
