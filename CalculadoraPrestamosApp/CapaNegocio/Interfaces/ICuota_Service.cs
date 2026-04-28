using CapaDatos.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio.Interfaces
{
    public interface ICuota_Service
    {
        public RetornoCuota CalcularCuota(DateTime fechaNacimiento, decimal monto, int meses, string ip);
        public int CalcularEdad(DateTime fechaNacimiento);
    }
}
