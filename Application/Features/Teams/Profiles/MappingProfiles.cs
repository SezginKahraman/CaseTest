using Application.Features.Teams.Commands.Create;
using Application.Features.Teams.Commands.Delete;
using Application.Features.Teams.Commands.Update;
using Application.Features.Teams.Queries.GetById;
using Application.Features.Teams.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Teams.Queries.GetAllSeparatedByGroupId;

namespace Application.Features.Teams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Team, CreateTeamCommand>().ReverseMap();
        CreateMap<Team, CreatedTeamResponse>().ReverseMap();
        CreateMap<Team, UpdateTeamCommand>().ReverseMap();
        CreateMap<Team, UpdatedTeamResponse>().ReverseMap();
        CreateMap<Team, DeleteTeamCommand>().ReverseMap();
        CreateMap<Team, DeletedTeamResponse>().ReverseMap();
        CreateMap<Team, GetByIdTeamResponse>().ReverseMap();
        CreateMap<Team, GetListTeamListItemDto>().ReverseMap();
        CreateMap<IPaginate<Team>, GetListResponse<GetListTeamListItemDto>>().ReverseMap();



        CreateMap<Team, GetAllSeparatedByGroupIdDto>().ReverseMap();
        CreateMap<IPaginate<Team>, GetListResponse<GetAllSeparatedByGroupIdDto>>().ReverseMap();


    }
}