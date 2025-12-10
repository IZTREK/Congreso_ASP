using Modelo;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace CongresoModelo
{
    public class ConsultasDAO
    {
        public DataTable ObtenerProgresoAlumno(string email)
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = Conexion.GetConnection())
            {

                string query = @"
                    SELECT 
                        e.nombre_evento AS Evento, 
                        e.lugar AS Lugar,
                        (SELECT COUNT(*) FROM asistencias a 
                         WHERE a.id_usuario = u.id_usuario 
                         AND a.id_evento = e.id_evento) AS TotalAsistencias,
                        e.cupo_actual
                    FROM inscripciones i
                    INNER JOIN usuarios u ON i.id_usuario = u.id_usuario
                    INNER JOIN eventos e ON i.id_evento = e.id_evento
                    WHERE u.email = :email";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Oracle es sensible a mayúsculas en los parámetros, usamos Varchar2
                    OracleParameter paramEmail = new OracleParameter("email", OracleDbType.Varchar2);
                    paramEmail.Value = email;
                    cmd.Parameters.Add(paramEmail);

                    try
                    {
                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (OracleException ex)
                    {
                        // Si falla, lanzamos un error más claro para saber qué tabla falta
                        if (ex.Number == 942) // Error ORA-00942
                        {
                            throw new Exception("Error: " + ex.Message);
                        }
                        throw ex;
                    }
                }
            }
            return dt;
        }
    }
}