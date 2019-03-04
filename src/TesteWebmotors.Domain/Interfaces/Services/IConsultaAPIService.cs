using System.Collections.Generic;
using TesteWebmotors.Domain.Models;

namespace TesteWebmotors.Domain.Interfaces.Services
{
    public interface IConsultaAPIService
    {
        IEnumerable<Marca> ConsultarMarcas();
    }
}
