using CapaNegocio.Interfaces;
using CapaPresentacion.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CapaPresentacion.Controllers
{
    public class CuotaController : Controller
    {
        private readonly IHttpClientFactory httpClient;
        public CuotaController(IHttpClientFactory _httpClient)
        {
            httpClient = _httpClient;
        }
        public IActionResult Index()
        {
            return View(new Cuota_ViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Calcular(Cuota_ViewModel model)
        {
            try
            {
                if (ModelState.IsValid) {
                    var client = httpClient.CreateClient("CuotaAPI");

                    var request = new
                    {
                        fechaNacimiento = model.FechaNacimiento,
                        monto = model.Monto,
                        meses = model.Meses
                    };

                    var respuesta = await client.PostAsJsonAsync("api/Api/calcular", request);
                    var resultadojson = await respuesta.Content.ReadAsStringAsync();
                    var resultado = JsonDocument.Parse(resultadojson).RootElement;

                    if (respuesta.IsSuccessStatusCode)
                        model.ValorCuota = resultado.GetProperty("valorCuota").GetDecimal();
                    else
                        model.Mensaje = $"Error al calcular la cuota: {resultado.GetProperty("message").GetString()}";

                }
               

            } catch (Exception ex) { 
            
                model.Mensaje = $"Error al conectar con  la API: {ex.Message}";
            }

            return View("Index", model);
        }      
    }
}
