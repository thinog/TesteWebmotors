using System.ComponentModel;

namespace TesteWebmotors.Domain.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [DisplayName("Versão")]
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        [DisplayName("Observação")]
        public string Observacao { get; set; }
    }
}
