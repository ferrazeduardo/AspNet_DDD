using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services.User;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;
        private IConfiguration _configuration;

        public LoginService(IUserRepository userRepository,SigningConfiguration signingConfiguration,TokenConfiguration tokenConfiguration
                            ,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDTO user)
        {
            var baseUser = new UserEntity();

            if(user != null && !string.IsNullOrEmpty(user.Email))
            {
                baseUser =  await _userRepository.FindByLogin(user.Email);

                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                   new GenericIdentity(baseUser.Email),
                   new[]{
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),//jti o id do token
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.Email),
                   });

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity,createDate, expirationDate,handler);

                    return SuccessObject(createDate, expirationDate, token, user);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }

        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDTO user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "Usuario logado com sucesso"
            };

        }

        public String CreateToken(ClaimsIdentity claimsIdentity,DateTime createDate,DateTime expirationDate,JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = claimsIdentity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }
    }
}
