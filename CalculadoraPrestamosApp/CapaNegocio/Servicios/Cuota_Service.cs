using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CapaDatos.Modelo;
using CapaDatos.Repositorio;
using CapaNegocio.Interfaces;
using Microsoft.Data.SqlClient;

namespace CapaNegocio.Servicios
{
    public class Cuota_Service:ICuota_Service
    {
        private readonly Cuota_Repository repository;
        public Cuota_Service(Cuota_Repository _repository)
        {
            repository = _repository;
        }

        public RetornoCuota CalcularCuota(DateTime fechaNacimiento, decimal monto, int meses, string ip)
        {
            try
            {
                int edad = CalcularEdad(fechaNacimiento);

                if (edad < 18)
                    return new RetornoCuota
                    {
                        esExitoso = false,
                        Mensaje = "Lo sentimos, aun no cuenta con la edad para solicitar este producto."
                    };

                if (edad > 25)
                    return new RetornoCuota
                    {
                        esExitoso = false,
                        Mensaje = "Favor pasar por una de nuestras sucursales para evaluar su caso."

                    };


                decimal? tasa = repository.ObtenerTasaPorEdad(edad);

                decimal valorCuota = (monto * tasa!.Value) / meses;

                repository.InsertarRegistroConsulta(edad, monto, meses, valorCuota, ip);



                return new RetornoCuota
                {
                    esExitoso = true,
                    ValorCuota = valorCuota
                };
            }
            catch (SqlException ex)
            {
                return new RetornoCuota
                {
                    esExitoso = false,
                    Mensaje = $"Error de base de datos:{ex.Message}"
                };

            }
            catch (Exception ex)
            {
                return new RetornoCuota
                {
                    esExitoso = false,
                    Mensaje = $"Error inesperado: {ex.Message}"
                };
            }
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > fechaActual.AddYears(-edad)) edad--;
            return edad;
        }
    }
}
