using System;
using System.Data;
using CongresoModelo;
using Modelo; // Importante para usar ConsultasDAO

namespace AICD_ASP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                lblMensaje.Text = "⚠️ Por favor ingresa un correo.";
                return;
            }

            try
            {
                ConsultasDAO dao = new ConsultasDAO();
                DataTable resultados = dao.ObtenerProgresoAlumno(email);

                if (resultados.Rows.Count > 0)
                {
                    gvAsistencias.DataSource = resultados;
                    gvAsistencias.DataBind();
                }
                else
                {
                    // Limpia la tabla y muestra el mensaje vacío del EmptyDataTemplate
                    gvAsistencias.DataSource = null;
                    gvAsistencias.DataBind();
                    lblMensaje.Text = "No encontramos inscripciones con ese correo.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error de conexión: " + ex.Message;
            }
        }
    }
}