using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarDelete
{
    public class Retorno_BadRequest
    {
        private MunicipiosController _controller;
        
        [Fact(DisplayName = "É Possível Realizar o Deleted")]
        public async Task E_Possivel_a_Controller_Deleted()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
            .ReturnsAsync(true);

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
