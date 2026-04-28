using CapaNegocio.Interfaces;
using CapaPresentacion.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class CuotaController : Controller
    {
        private readonly ICuota_Service service;
        public CuotaController(ICuota_Service _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            return View(new Cuota_ViewModel());
        }

        [HttpPost]
        public IActionResult Calcular(Cuota_ViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "desconocida";

                    var resultado = service.CalcularCuota(model.FechaNacimiento!.Value, model.Monto!.Value, model.Meses!.Value, ip);

                    model.ValorCuota = resultado.esExitoso ? resultado.ValorCuota : null;
                    model.Mensaje = resultado.Mensaje;
                }
            }
            catch (Exception ex)
            {
                model.Mensaje=$"Ocurrió un error al calcular la cuota: {ex.Message}";
            }

            return View("Index", model);
        }
    }
}
