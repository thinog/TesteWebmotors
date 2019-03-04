using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteWebmotors.Domain.Models
{
    public class Anuncio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Necessário informar a marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Necessário informar o modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Necessário informar a versão")]
        [DisplayName("Versão")]
        public string Versao { get; set; }

        [Required(ErrorMessage = "Necessário informar o ano")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Necessário informar a quilometragem")]
        [DisplayName("Quilometragem (Km)")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "Necessário inserir alguma observação")]
        [DisplayName("Observação")]
        public string Observacao { get; set; }
    }
}
