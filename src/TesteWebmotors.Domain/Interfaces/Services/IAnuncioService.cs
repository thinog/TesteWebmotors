using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TesteWebmotors.Domain.Models;

namespace TesteWebmotors.Domain.Interfaces.Services
{
    public interface IAnuncioService
    {
        int Inserir(Anuncio model);
        int Atualizar(Anuncio model);
        int Remover(Anuncio model);
        Anuncio RetornarPorId(int id);
        IEnumerable<Anuncio> RetornarPorFiltro(Expression<Func<Anuncio, bool>> predicate);
        IEnumerable<Anuncio> RetornarTodos();
    }
}
