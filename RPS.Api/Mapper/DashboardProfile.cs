using System.Collections.Generic;
using AutoMapper;
using RPS.Api.Core;
using RPS.Api.Model;

namespace RPS.Api.Mapper
{
    public class DashboardProfile : Profile
    {
        public DashboardProfile()
        {
            CreateMap<Game, GameModel>(MemberList.None).ReverseMap();
        }
    }
}
