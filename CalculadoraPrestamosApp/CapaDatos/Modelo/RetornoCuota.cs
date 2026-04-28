using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDatos.Modelo
{
    public class RetornoCuota
    {
        public decimal ValorCuota { get; set; }
        public bool esExitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;

    }
}
