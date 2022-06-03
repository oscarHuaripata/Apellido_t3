using System.Security.Claims;
using APELLIDO_T3.WEB.Web.DB;
using APELLIDO_T3.WEB.Web.Models;
using APELLIDO_T3.WEB.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APELLIDO_T3.WEB.Web.Controllers;

[Authorize]
public class UsuarioController : Controller
{
    private readonly ITipoUsuarioRepositorio _tipoUsuarioRepositorio;
    private DbEntities _dbEntities;
    public UsuarioController(ITipoUsuarioRepositorio tipoUsuarioRepositorio, DbEntities dbEntities)
    {
        _tipoUsuarioRepositorio = tipoUsuarioRepositorio;
        _dbEntities = dbEntities;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var user = GetLoggedUser();
        var usuarios = _dbEntities.Usuarios
            .Include(o => o.TipoCuenta)
            .Where(o => o.UsuarioId == user.Id).ToList();
        ViewBag.Total = usuarios.Any() ? usuarios.Sum(o => o.Monto) : 0; 
        return View(usuarios);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.TipoDeUsuarios = _tipoUsuarioRepositorio.ObtenerTodos();
        return View(new Usuario());
    }

    [HttpPost]
    public IActionResult Create(Usuario cuenta)
    {
        cuenta.UsuarioId = GetLoggedUser().Id;
        
        if (cuenta.TipoCuentaId > 6 || cuenta.TipoCuentaId < 1)
        {
            ModelState.AddModelError("TipoUsuarioId", "Tipo de usuario no exite");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.TipoDeCuentas = _dbEntities.TipoUsuarios.ToList();
            return View("Create", cuenta);
        }

        
        _dbEntities.Usuarios.Add(cuenta);
        _dbEntities.SaveChanges();
        return RedirectToAction("Index");

    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var cuenta = _dbEntities.Usuarios.First(o => o.Id == id); // lambdas / LINQ
        ViewBag.TipoDeCuentas = _dbEntities.TipoUsuarios.ToList();
        return View(cuenta);
    }
    
    [HttpPost]
    public IActionResult Edit(int id, Usuario usuario)
    {
        if (!ModelState.IsValid) {
            ViewBag.TipoDeCuentas = _dbEntities.TipoUsuarios.ToList();
            return View("Edit", usuario);
        }
        
        var usuarioDb = _dbEntities.Usuarios.First(o => o.Id == id);
        usuarioDb.Nombre = usuario.Nombre;
        _dbEntities.SaveChanges();
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var usuarioDb = _dbEntities.Usuarios.First(o => o.Id == id);
        _dbEntities.Usuarios.Remove(usuarioDb);
        _dbEntities.SaveChanges();

        return RedirectToAction("Index");
    }

    private Usuario GetLoggedUser()
    {
        var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
        var username = claim.Value;
        return DbEntities.Usuarios.First(o => o.Username == username);
    }
}