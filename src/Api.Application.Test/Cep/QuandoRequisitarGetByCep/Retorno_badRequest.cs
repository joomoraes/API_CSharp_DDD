using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.CEP;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarGetByCep
{
    public class Retorno_badRequest
    {
        private CepsController _controller;
        [Fact(DisplayName = "É Possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<ICepService>();   

            serviceMock.Setup(m => m.Get(It.IsAny<string>()))
            .ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de Rua"   
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get("134800000");
            Assert.True(result is BadRequestObjectResult);
        }
        
    }
}
