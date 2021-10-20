using AutoMapper;
using Domain.DTO.User;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.User;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDTOCreate> Get(Guid id)
        {
            var entity =  await _repository.SelectAsync(id);
            return _mapper.Map<UserDTOCreate>(entity);
        }

        public async Task<IEnumerable<UserDTOCreate>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDTOCreate>>(listEntity);
        }

        public async Task<UserDTOCreateResult> Post(UserDTOCreate user)
        {
            var model = _mapper.Map<UseModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDTOCreateResult>(result);
        }

        public async Task<UserDTOUpdateResult> Put(UserDTOUpdate user)
        {
            var model = _mapper.Map<UseModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var userUpdate = await _repository.Update(entity);
            return _mapper.Map<UserDTOUpdateResult>(userUpdate);
        }
    }
}
