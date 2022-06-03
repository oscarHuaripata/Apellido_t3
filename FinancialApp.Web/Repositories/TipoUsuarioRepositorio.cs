using APELLIDO_T3.WEB.Web.DB;
using APELLIDO_T3.WEB.Web.Models;

namespace APELLIDO_T3.WEB.Web.Repositories;

public interface ITipoUsuarioRepositorio
{
    void Guardar(TipoUsuario tipoCuenta);
    List<TipoUsuario> ObtenerTodos();
    List<TipoUsuario> ObtenerPoNombre(string nombre);
}

public class TipoUsuarioRepositorio: ITipoUsuarioRepositorio
{
    private DbEntities _dbEntities;
    
    public TipoUsuarioRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }

    public void Guardar(TipoUsuario tipoCuenta)
    {
        _dbEntities.TipoUsuarios.Add(tipoCuenta);
        _dbEntities.SaveChanges();
    }

    public List<TipoUsuario> ObtenerTodos()
    {
        return _dbEntities.TipoUsuarios.ToList();
    }

    public List<TipoUsuario> ObtenerPoNombre(string nombre)
    {
        return _dbEntities
            .TipoUsuarios.Where(o => o.Nombre.Contains(nombre))
            .ToList();
    }
}