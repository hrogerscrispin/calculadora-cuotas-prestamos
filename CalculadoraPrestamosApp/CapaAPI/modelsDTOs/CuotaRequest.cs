using System.ComponentModel.DataAnnotations;

namespace CapaAPI.modelsDTOs
{
    public class CuotaRequest
    {
        [Required]
        public DateTime FechaNacimiento { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public decimal Monto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe indicar un plazo valido.")]
        public int Meses    { get; set; }
    }
}
