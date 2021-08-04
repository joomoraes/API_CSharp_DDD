using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoCreate: UsuarioTestes
    {
         private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create() 
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
        }
    }
}
