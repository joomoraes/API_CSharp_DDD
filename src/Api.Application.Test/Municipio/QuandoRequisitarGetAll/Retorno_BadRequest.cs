using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Municipios;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetAll
{
    public class Retorno_BadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É Possível Realizar o GetAll")]
        public async Task E_Possivell_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IMunicipioService>();  
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<MunicipioDto>
                {
                    new MunicipioDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = "São Paulo",
                    },
                    new MunicipioDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Limeira",
                    }
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
