using Domain.DTO.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDTOCreate> Get(Guid id);
        Task<IEnumerable<UserDTOCreate>> GetAll();
        Task<UserDTOCreateResult> Post(UserDTOCreate user);
        Task<UserDTOUpdateResult> Put(UserDTOUpdate user);
        Task<bool> Delete(Guid id);
    }
}
