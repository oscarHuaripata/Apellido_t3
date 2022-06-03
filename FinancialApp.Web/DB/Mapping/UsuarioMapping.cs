using APELLIDO_T3.WEB.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APELLIDO_T3.WEB.Web.DB.Mapping;

public class CuentaMapping: IEntityTypeConfiguration<Usuarios>
{
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
        builder.ToTable("Usuarios", "dbo");
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.TipoUsuario)
            .WithMany()
            .HasForeignKey(o => o.TipoUsuarioId);

        //builder.Property(o => o.Nombre).HasField("Name"); // opcional
    }
}