using Application.Features.Countries.Commands.Create;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.GroupTeams.Commands.Create;
using Application.Features.GroupTeams.Commands.Update;
using Application.Features.GroupTeams.Commands.Delete;

namespace Application.Features.GroupTeams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GroupTeam, CreateGroupTeamCommand>().ReverseMap();
        CreateMap<GroupTeam, CreatedGroupTeamResponse>().ReverseMap();
        CreateMap<GroupTeam, UpdateGroupTeamCommand>().ReverseMap();
        CreateMap<GroupTeam, UpdatedGroupTeamResponse>().ReverseMap();
        CreateMap<GroupTeam, DeleteGroupTeamCommand>().ReverseMap();
        CreateMap<GroupTeam, DeletedGroupTeamResponse>().ReverseMap();
        //CreateMap<GroupTeam, GetByIdGroupTeamResponse>().ReverseMap();
        //CreateMap<GroupTeam, GetListGroupTeamListItemDto>().ReverseMap();
        //CreateMap<IPaginate<GroupTeam>, GetListResponse<GetListGroupTeamListItemDto>>().ReverseMap();
    }
}