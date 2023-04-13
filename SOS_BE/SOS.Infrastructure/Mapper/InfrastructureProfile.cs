using AutoMapper;
using SOS.Core.Domain;
using SOS.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Infrastructure.Mapper
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<CoordinatesSpanDTO, CoordinatesSpan>().ReverseMap();
            CreateMap<MissionDTO, Mission>().ReverseMap();
            CreateMap<TeamMemberDTO, TeamMember>().ReverseMap();
            CreateMap<TeamDTO, Team>().ReverseMap();
            CreateMap<VehicleDTO, Vehicle>().ReverseMap();
        }
    }
}
