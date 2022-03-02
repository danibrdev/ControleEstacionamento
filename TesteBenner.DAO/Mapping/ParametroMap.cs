using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBenner.DAO.Entities;

namespace TesteBenner.DAO.Mapping
{
    public class ParametroMap : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("parametros");
            builder.HasKey(d => d.ID);

            builder.Property(d => d.VigenciaFim)
                   .HasColumnName("vigenciafim")
                   .HasColumnType("date")
                   .IsRequired();
            builder.Property(d => d.VigenciaInicio)
                   .HasColumnName("vigenciainicio")
                   .HasColumnType("date")
                   .IsRequired();
            builder.Property(d => d.ValorHoraInicial)
                   .HasColumnName("valorhorainicial")
                   .HasColumnType("money")
                   .IsRequired();
            builder.Property(d => d.ValorHoraFinal)
                   .HasColumnName("valorhorafinal")
                   .HasColumnType("money")
                   .IsRequired();
        }
    }
}
