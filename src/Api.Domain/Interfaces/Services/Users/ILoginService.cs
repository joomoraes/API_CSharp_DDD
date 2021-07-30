using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<Object> FindByLogin(UserEntity user);
    }
}
