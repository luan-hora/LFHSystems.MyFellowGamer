using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LFHSystems.MyFellowGamer.WebApp.Models;
using LFHSystems.MyFellowGamer.Model;

namespace LFHSystems.MyFellowGamer.WebApp.Mappers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserViewModel, UserModel>().ReverseMap();
        }
    }
}
