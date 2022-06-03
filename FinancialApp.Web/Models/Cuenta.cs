namespace APELLIDO_T3.WEB.Web.Models;

public class Cuenta
{
    public int Id { get; set; } 
    public string Nombre { get; set; }
    public decimal Fecha_registro { get; set; }
    public decimal Fecha_Nacimiento { get; set; }
    public int UsuarioId { get; set; }
    public int TipoUsuarioId { get; set; }
    public TipoUsuario? TipoUsuario {get; set; }

    public string Sexo { get; set; }

    public string Especie { get; set; }

    public string Raza { get; set; }

    public decimal Tama�o { get; set; }
    public string Datos_particulares { get; set; }

    public string Nombre_due�o { get; set; }
    public string Direccion_due�o { get; set; }

    public decimal Telefeno { get; set; }
    public string email { get; set; }
}