using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TesteWebmotors.Domain.Interfaces.Context
{
    public interface ITesteWebmotorsContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}
