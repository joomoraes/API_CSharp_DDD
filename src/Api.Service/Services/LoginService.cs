using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Api.Domain.Repository;

namespace Api.Service.Services
{
    public class LoginService: ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository) 
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(UserEntity user)
        {
            var BaseUser = new UserEntity();
            if(user != null && !string.IsNullOrWhiteSpace(user.Email)) 
            {
                BaseUser = await _repository.FindByLogin(user.Email);
                if(BaseUser == null) 
                {
                    return null;
                } else {
                    return BaseUser;
                }
            } else {
                return null;
            }
        }
    }
}
