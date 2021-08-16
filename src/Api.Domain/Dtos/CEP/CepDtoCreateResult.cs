using System;

namespace Api.Domain.Dtos.CEP
{
    public class CepDtoCreateResult
    {
        public Guid id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public Guid MunicipioId { get; set; }
        

    }
}
