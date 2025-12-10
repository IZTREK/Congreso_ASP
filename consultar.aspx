<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AICD_ASP.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de Asistencias</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body { background-color: #f4f7f6; }
        .card-custom { margin-top: 50px; border: none; box-shadow: 0 4px 6px rgba(0,0,0,0.1); }
        .header-bg { background: linear-gradient(135deg, #0d6efd 0%, #0a58ca 100%); color: white; padding: 20px; border-radius: 5px 5px 0 0; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    
                    <div class="card card-custom">
                        <div class="header-bg text-center">
                            <h3>📊 Kiosco de Asistencias</h3>
                            <p class="mb-0">Consulta tu progreso en el Congreso</p>
                        </div>
                        <div class="card-body p-4">
                            
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" placeholder="Ingresa tu correo institucional"></asp:TextBox>
                                <asp:Button ID="btnConsultar" runat="server" Text="Ver mis Asistencias" CssClass="btn btn-primary btn-lg" OnClick="btnConsultar_Click" />
                            </div>

                            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold"></asp:Label>

                            <hr class="my-4" />

                            <div class="table-responsive">
                                <asp:GridView ID="gvAsistencias" runat="server" CssClass="table table-hover table-striped align-middle" AutoGenerateColumns="False" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="Evento" HeaderText="Evento" HeaderStyle-CssClass="bg-light text-primary" />
                                        <asp:BoundField DataField="Lugar" HeaderText="Lugar" HeaderStyle-CssClass="bg-light text-primary" />
                                        
                                        <asp:TemplateField HeaderText="Asistencias Registradas" HeaderStyle-CssClass="bg-light text-primary">
                                            <ItemTemplate>
                                                <span class="badge rounded-pill bg-success fs-6">
                                                    <%# Eval("TotalAsistencias") %> Registros
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="bg-light text-primary">
                                            <ItemTemplate>
                                                <%# Convert.ToInt32(Eval("TotalAsistencias")) > 0 ? "🟢 Asistiendo" : "🔴 Pendiente" %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div class="alert alert-warning text-center">
                                            No se encontraron inscripciones para este correo.
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>