using APELLIDO_T3.WEB.Web.DB;
using APELLIDO_T3.WEB.Web.Models;

namespace APELLIDO_T3.WEB.Web.Controllers;

public class UsuarioController : Controller
{
    [HttpGet]
    public IActionResult Index(int cuentaId)
    {
        var items = DbEntities.Transacciones.Where(o => o.CuentaId == cuentaId).ToList();
        ViewBag.CuentaId = cuentaId;
        ViewBag.Total = items.Any() ? items.Sum(x => x.Monto) : 0;

        return View(items);
    }
    
    [HttpGet]
    public IActionResult Create(int cuentaId)
    {
        ViewBag.CuentaId = cuentaId;
        return View(new Transaccion());
    }
    
    [HttpPost]
    public IActionResult Create(int cuentaId, Transaccion transaccion)
    {
        transaccion.Id = GetNextId();
        transaccion.UsuarioId = cuentaId;
        if (transaccion.Tipo == "GASTO")
            transaccion.Monto *= -1;
        
        DbEntities.Transacciones.Add(transaccion);

        return RedirectToAction("Index", new { cuentaId = cuentaId});
    }
    
    public int GetNextId()  {
        if (DbEntities.Transacciones.Count == 0)
            return 1;
        return DbEntities.Transacciones.Max(o => o.Id) + 1;
    }
}