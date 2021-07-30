using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService: ILoginService
    {
        private IUserRepository _repository;

        private SigningConfigurations _signingConfigurations;

        private TokenConfiguration _tokenConfiguration;

        private IConfiguration _configurations;

        public LoginService(IUserRepository repository,
        SigningConfigurations signingConfigurations,
        TokenConfiguration tokenConfiguration,
        IConfiguration configurations) 
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
            _configurations = configurations;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var BaseUser = new UserEntity();
            if(user != null && !string.IsNullOrWhiteSpace(user.Email)) 
            {
                BaseUser = await _repository.FindByLogin(user.Email);
                if(BaseUser == null) 
                {
                    return new {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                } else {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(BaseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                    );

                    DateTime createDate = DateTime.Now;
                    DateTime experationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, experationDate, handler);
                    return SuccessObject(createDate, experationDate, token, BaseUser);

                }
            } else {
                return new 
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createdDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createdDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createdDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new 
            {
                authenticated = true,
                created = createdDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                name = user.Name,
                message = "Usuário logado com sucesso"
            };
        }
    }
}
