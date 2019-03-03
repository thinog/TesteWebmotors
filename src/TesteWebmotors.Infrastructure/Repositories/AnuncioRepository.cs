using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TesteWebmotors.Domain.Interfaces.Context;
using TesteWebmotors.Domain.Interfaces.Repositories;
using TesteWebmotors.Domain.Models;

namespace TesteWebmotors.Infrastructure.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private ITesteWebmotorsContext _context;
        private IDbSet<Anuncio> _dbSet;

        public AnuncioRepository(ITesteWebmotorsContext context)
        {
            _context = context;
            _dbSet = _context.Set<Anuncio>();
        }

        public int Remover(Anuncio model)
        {
            _dbSet.Remove(model);
            return _context.SaveChanges();
        }

        public IEnumerable<Anuncio> RetornarTodos()
        {
            return _dbSet;
        }

        public IEnumerable<Anuncio> RetornarPorFiltro(Expression<Func<Anuncio, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public Anuncio RetornarPorId(int id)
        {
            return _dbSet.Where(a => a.Id == id).FirstOrDefault();
        }

        public int Inserir(Anuncio model)
        {
            _dbSet.Add(model);
            return _context.SaveChanges();
        }

        public int Atualizar(Anuncio model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
