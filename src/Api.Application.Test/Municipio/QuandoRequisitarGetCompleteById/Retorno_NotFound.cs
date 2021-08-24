using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Municipios;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetCompleteById
{
    public class Retorno_NotFound
    {
        private MunicipiosController _controller;
        
        [Fact(DisplayName = "É Possível Realizar o Get")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>()))
            .Returns(Task.FromResult((MunicipioDtoCompleto)null));

            _controller = new MunicipiosController(serviceMock.Object);
            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}
