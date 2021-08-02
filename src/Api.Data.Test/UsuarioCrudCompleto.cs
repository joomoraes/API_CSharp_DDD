using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using System;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.serviceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario() 
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity()
                {
                    Email = "teste@email.com",
                    Name = "teste"
                };

                var _registroCrido = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCrido);
                Assert.Equal("teste@email.com", _registroCrido.Email);
                Assert.Equal("teste", _registroCrido.Name);
                Assert.True(_registroCrido.Id == Guid.Empty);
            }
        }
    }
}
