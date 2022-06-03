using APELLIDO_T3.WEB.Web.DB.Mapping;
using APELLIDO_T3.WEB.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace APELLIDO_T3.WEB.Web.DB;

public class DbEntities: DbContext
{
    public virtual DbSet<Usuarios> Usuarios { get; set; }
    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public DbEntities(){}
    public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UsuarioMapping());
        modelBuilder.ApplyConfiguration(new TipoCuentaMapping());
    }
    
    public static List<Transaccion> Transacciones = new();
    
    
    public static List<Usuario> Usuarios = new()
    {
        new Usuario {Id = 1, Username = "admin", Password = "123456"},
        new Usuario {Id = 2, Username = "user1", Password = "123456"},
        new Usuario {Id = 3, Username = "user2", Password = "123456"},
    };
}