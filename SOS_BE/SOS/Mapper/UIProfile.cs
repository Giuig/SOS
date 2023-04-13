using AutoMapper;
using SOS.Core.Domain;
using SOS.Model;

namespace SOS.Mapper
{
    public class UIProfile : Profile
    {
        public UIProfile()
        {
            CreateMap <CoordinatesSpanModel, CoordinatesSpan>().ReverseMap();
            CreateMap<MissionModel, Mission>().ReverseMap();
            CreateMap<TeamMemberModel, TeamMember>().ReverseMap();
            CreateMap<TeamModel, Team>().ReverseMap();
            CreateMap<VehicleModel, Vehicle>().ReverseMap();
        }
    }
}
