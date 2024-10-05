//using Application.Features.Picker.Queries.GetById;
//using Application.Features.Picker.Queries.GetList;
using Application.Features.Pickers.Commands.Create;
using Application.Features.Pickers.Commands.Delete;
using Application.Features.Pickers.Commands.Update;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Picker, CreatePickerCommand>().ReverseMap();
            CreateMap<Picker, CreatedPickerResponse>().ReverseMap();
            CreateMap<Picker, UpdatePickerCommand>().ReverseMap();
            CreateMap<Picker, UpdatedPickerResponse>().ReverseMap();
            CreateMap<Picker, DeletePickerCommand>().ReverseMap();
            CreateMap<Picker, DeletedPickerResponse>().ReverseMap();
            //CreateMap<Picker, GetByIdPickerResponse>().ReverseMap();
            //CreateMap<Picker, GetListPickerListItemDto>().ReverseMap();
            //CreateMap<IPaginate<Picker>, GetListResponse<GetListPickerListItemDto>>().ReverseMap();
        }
    }
}
