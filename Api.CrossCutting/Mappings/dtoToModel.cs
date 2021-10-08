using AutoMapper;
using Domain.DTO.User;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mappings
{
    public class dtoToModel : Profile
    {
        public dtoToModel()
        {
            CreateMap<UseModel, UserDTO>()
                .ReverseMap();
        }
    }
}
