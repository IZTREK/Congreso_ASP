using System;
using Oracle.ManagedDataAccess.Client;

namespace Modelo
{
    public static class Conexion
    {
        // Conexión directa a tu Docker local usando los datos de tu docker-compose.yml
        // Service Name: FREEPDB1, User: congreso_user, Pass: congreso_pass
        private static string connectionString = "User Id=congreso_user;Password=congreso_pass;Data Source=localhost:1521/FREEPDB1;";

        public static OracleConnection GetConnection()
        {
            try
            {
                OracleConnection conexion = new OracleConnection(connectionString);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                // Si esto falla, verifica que tu Docker esté corriendo con: docker ps
                throw new Exception("Error conectando a Oracle: " + ex.Message);
            }
        }
    }
}