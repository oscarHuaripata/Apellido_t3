using APELLIDO_T3.WEB.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APELLIDO_T3.WEB.Web.DB.Mapping;

public class TipoCuentaMapping: IEntityTypeConfiguration<TipoUsuario>
{
    public void Configure(EntityTypeBuilder<TipoUsuario> builder)
    {
        builder.ToTable("TipoUsuario", "dbo");
        builder.HasKey(o => o.Id);
    }
}