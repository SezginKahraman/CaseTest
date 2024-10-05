using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Draws.Queries.GetList;

public class GetListDrawQuery : IRequest<GetListResponse<GetListDrawListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDrawQueryHandler : IRequestHandler<GetListDrawQuery, GetListResponse<GetListDrawListItemDto>>
    {
        private readonly IDrawRepository _drawRepository;
        private readonly IMapper _mapper;

        public GetListDrawQueryHandler(IDrawRepository drawRepository, IMapper mapper)
        {
            _drawRepository = drawRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDrawListItemDto>> Handle(GetListDrawQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Draw> draws = await _drawRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDrawListItemDto> response = _mapper.Map<GetListResponse<GetListDrawListItemDto>>(draws);
            return response;
        }
    }
}