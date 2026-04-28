using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace CapaDatos.Repositorio
{
    public class Cuota_Repository
    {
        private readonly string connectionString;
        public Cuota_Repository(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public decimal? ObtenerTasaPorEdad(int edad)
        {
            using var conexion = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("sp_ObtenerTasaPorEdad",conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Edad", edad);

            conexion.Open();
            var res = cmd.ExecuteScalar();


            return res == null || res == DBNull.Value ? 0 : Convert.ToDecimal(res);
        }

        public void InsertarRegistroConsulta(int edad, decimal monto, int meses, decimal valorCuota, string ip)
        {
            using var conexion = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("sp_InsertarRegistroConsulta", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Edad", edad);
            cmd.Parameters.AddWithValue("@Monto", monto);
            cmd.Parameters.AddWithValue("@Meses", meses);
            cmd.Parameters.AddWithValue("@ValorCuota", valorCuota);
            cmd.Parameters.AddWithValue("@IP", ip);

            conexion.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
