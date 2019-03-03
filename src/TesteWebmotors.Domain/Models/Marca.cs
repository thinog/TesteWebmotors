using System.Collections.Generic;

namespace TesteWebmotors.Domain.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Modelo> CarModels { get; set; }
    }
}
