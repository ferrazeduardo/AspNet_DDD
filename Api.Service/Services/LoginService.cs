using Domain.DTO;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services.User;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> FindByLogin(LoginDTO user)
        {
            if(user != null && !string.IsNullOrEmpty(user.Email))
            {
                return  await _userRepository.FindByLogin(user.Email);

            }
            else
            {
                return null;
            }

        }
    }
}
