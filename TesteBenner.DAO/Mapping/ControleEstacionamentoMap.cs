using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBenner.DAO.Entities;

namespace TesteBenner.DAO.Mapping
{
    internal class ControleEstacionamentoMap : IEntityTypeConfiguration<ControleEstacionamento>
    {
        public void Configure(EntityTypeBuilder<ControleEstacionamento> builder)
        {
            builder.ToTable("controle_estacionamento");
            builder.HasKey(d => d.ID);

            builder.Property(d => d.Entrada)
                   .HasColumnName("dataentrada")
                   .HasColumnType("timestamp")
                   .IsRequired();
            builder.Property(d => d.Saida)
                   .HasColumnName("datasaida")
                   .HasColumnType("timestamp");
            builder.Property(d => d.PlacaVeiculo)
                   .HasColumnName("placaveiculo")
                   .HasColumnType("varchar")
                   .HasMaxLength(8)
                   .IsRequired();
            builder.Property(d => d.Valor)
                   .HasColumnName("valor")
                   .HasColumnType("money");
        }
    }
}
