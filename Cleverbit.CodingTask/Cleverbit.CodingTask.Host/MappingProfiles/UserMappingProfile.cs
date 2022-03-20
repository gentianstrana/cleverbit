using AutoMapper;
using Cleverbit.CodingTask.Data.Models;
using Cleverbit.CodingTask.Host.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserListDto>();
        }
    }
}
