using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Service.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoCreate: MunicipioTestes
    {
        private IMunicipioService _service;
        
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método Create")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Post(municipioDtoCreate)).ReturnsAsync(municipioDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(municipioDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
            Assert.Equal(IdUf, result.UfId);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Put(municipioDtoUpdate)).ReturnsAsync(municipioDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(municipioDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeMunicipioAlterado, resultUpdate.Nome);
            Assert.Equal(COdigoIBGEMunicipioAlterado, resultUpdate.CodIBGE);
            Assert.Equal(IdUf, result.UfId);

        }
    }
}
