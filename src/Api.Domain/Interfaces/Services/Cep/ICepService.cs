using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.CEP;

namespace Api.Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);
        Task<CepDto> Get(string cep);
        Task<CepDtoCreateResult> Post(CepDtoCreateResult cep);
        Task<CepDtoCreateResult> Put(CepDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}
