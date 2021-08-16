using System;

namespace Api.Domain.Dtos.CEP
{
    public class CepDtoUpdateResult
    {
        public Guid id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid Municipio { get; set; }
        public DateTime creatAt { get; set; }
    }
}
