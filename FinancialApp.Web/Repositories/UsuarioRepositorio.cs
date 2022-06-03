using APELLIDO_T3.WEB.Web.DB;
using APELLIDO_T3.WEB.Web.Models;

namespace APELLIDO_T3.WEB.Web.Repositories;

public interface ICuentaRepositorio
{
    List<Usuarios> ObtenerTodos();
}

public class UsuarioRepositorio: ICuentaRepositorio
{
    private DbEntities _dbEntities;
    public UsuarioRepositorio(DbEntities dbEntities)
    {
        this._dbEntities = dbEntities;
    }
    public List<Usuarios> ObtenerTodos()
    {
        return _dbEntities.Usuarios.ToList();
    }
}