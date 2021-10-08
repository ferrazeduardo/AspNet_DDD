using AutoMapper;
using Domain.DTO.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mappings
{
    public class EntityToDTOProfile : Profile
    {

        public EntityToDTOProfile()
        {
            CreateMap<UserDTO, UserEntity>()
                .ReverseMap();

            CreateMap<UserDTOCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDTOUpdateResult, UserEntity>()
                .ReverseMap();  
        }
    }
}
