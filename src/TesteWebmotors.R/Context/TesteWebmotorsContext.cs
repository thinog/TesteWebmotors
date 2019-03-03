using System.Data.Entity;
using System.Configuration;
using TesteWebmotors.Infrastructure.Mapping;
using TesteWebmotors.Domain.Interfaces.Context;

namespace TesteWebmotors.Infrastructure.Context
{
    public class TesteWebmotorsContext : DbContext, ITesteWebmotorsContext
    {
        public TesteWebmotorsContext()
            : base(ConfigurationManager.ConnectionStrings["TesteWebmotors"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<int>().Where(p => p.Name.Equals("Id")).Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new AnuncioMapping());
        }
    }
}
