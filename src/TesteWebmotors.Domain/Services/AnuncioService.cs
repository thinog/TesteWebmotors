using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TesteWebmotors.Domain.Interfaces.Repositories;
using TesteWebmotors.Domain.Interfaces.Services;
using TesteWebmotors.Domain.Models;

namespace TesteWebmotors.Domain.Services
{
    public class AnuncioService : IAnuncioService
    {
        private IAnuncioRepository _repository;

        public AnuncioService(IAnuncioRepository repository)
        {
            _repository = repository;
        }


        public int Remover(Anuncio model)
        {
            return _repository.Remover(model);
        }

        public IEnumerable<Anuncio> RetornarTodos()
        {
            return _repository.RetornarTodos();
        }

        public IEnumerable<Anuncio> RetornarPorFiltro(Expression<Func<Anuncio, bool>> predicate)
        {
            return _repository.RetornarPorFiltro(predicate);
        }

        public Anuncio RetornarPorId(int id)
        {
            return _repository.RetornarPorId(id);
        }

        public int Inserir(Anuncio model)
        {
            return _repository.Inserir(model);
        }

        public int Atualizar(Anuncio model)
        {
            return _repository.Atualizar(model);
        }
    }
}
