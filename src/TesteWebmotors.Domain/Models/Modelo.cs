using System.Collections.Generic;

namespace TesteWebmotors.Domain.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MakeId { get; set; }
        public IEnumerable<Versao> CarVersions { get; set; }
    }
}
