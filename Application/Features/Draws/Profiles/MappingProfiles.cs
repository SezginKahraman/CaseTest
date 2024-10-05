using Application.Features.Draws.Commands.Create;
using Application.Features.Draws.Commands.Delete;
using Application.Features.Draws.Commands.Update;
using Application.Features.Draws.Queries.GetById;
using Application.Features.Draws.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Draws.Commands.PickAllDraws;

namespace Application.Features.Draws.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Draw, CreateDrawCommand>().ReverseMap();
        CreateMap<Draw, CreatedDrawResponse>().ReverseMap();

        CreateMap<Draw, PickAllDrawsCommand>().ReverseMap();
        CreateMap<IPaginate<Draw>, GetListResponse<CreatedDrawAllResponse>>().ReverseMap();
        CreateMap<Draw, CreatedDrawAllResponse>().ReverseMap();

        CreateMap<Draw, UpdateDrawCommand>().ReverseMap();
        CreateMap<Draw, UpdatedDrawResponse>().ReverseMap();
        CreateMap<Draw, DeleteDrawCommand>().ReverseMap();
        CreateMap<Draw, DeletedDrawResponse>().ReverseMap();
        CreateMap<Draw, GetByIdDrawResponse>().ReverseMap();
        CreateMap<Draw, GetListDrawListItemDto>().ReverseMap();
        CreateMap<IPaginate<Draw>, GetListResponse<GetListDrawListItemDto>>().ReverseMap();
       
    }
}