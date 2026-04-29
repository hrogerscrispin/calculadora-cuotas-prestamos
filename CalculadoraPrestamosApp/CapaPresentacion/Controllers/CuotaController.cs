using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class CuotaController : Controller
    {
   
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
