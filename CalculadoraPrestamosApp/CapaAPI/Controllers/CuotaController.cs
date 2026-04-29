using CapaAPI.modelsDTOs;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CapaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuotaController : ControllerBase   
    {
        private readonly ICuota_Service service;
        public CuotaController(ICuota_Service _service)
        {
            service = _service;
        }

        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] CuotaRequest request)
        {

            try
            {
                if (request == null)
                    return BadRequest(new { message = "Request invalido" });

                string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Descononida";

                var resultado = service.CalcularCuota(request.FechaNacimiento, request.Monto, request.Meses, ip);
                if (!resultado.esExitoso)
                    return BadRequest(new { message = resultado.Mensaje });

                return Ok(new { valorCuota = resultado.ValorCuota });
            }
            catch (Exception ex) {

                return StatusCode(500, new
                {
                    message="Error interno del servidor",
                    details=ex.Message
                });
            }
        }
       
    }
}
