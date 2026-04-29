using System.ComponentModel.DataAnnotations;

namespace CapaPresentacion.ViewModel
{
    public class Cuota_ViewModel
    {
        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El monto es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal? Monto { get; set; }

        [Required(ErrorMessage = "El plazo es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un plazo.")]
        public int? Meses { get; set; }

        public decimal? ValorCuota { get; set; }
        public string? Mensaje { get; set; }
    }
}
