using AuthApp.api.Models;
using AuthApp.core.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterModel, UserRegisterDto>();
        }
    }
}
