namespace APELLIDO_T3.WEB.Web.Models;

public class Transaccion
{
    public int Id { get; set; }
    public int UsuarioId { get; set; } // siempre enviar
    public DateTime Fecha { get; set; }
    public string Tipo { get; set; }
   
}