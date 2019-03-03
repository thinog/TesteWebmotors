using System.Data.Entity.ModelConfiguration;
using TesteWebmotors.Domain.Models;

namespace TesteWebmotors.Infrastructure.Mapping
{
    public class AnuncioMapping : EntityTypeConfiguration<Anuncio>
    {
        public AnuncioMapping()
        {
            ToTable("tb_AnuncioWebmotors");

            Property(a => a.Id).IsRequired();
            Property(a => a.Marca).HasMaxLength(45).IsRequired();
            Property(a => a.Modelo).HasMaxLength(45).IsRequired();
            Property(a => a.Versao).HasMaxLength(45).IsRequired();
            Property(a => a.Ano).IsRequired();
            Property(a => a.Quilometragem).IsRequired();
            Property(a => a.Observacao).HasColumnType("text").IsRequired();
        }
    }
}
