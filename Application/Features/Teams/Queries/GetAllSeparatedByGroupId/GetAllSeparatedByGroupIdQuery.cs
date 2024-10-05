using Application.Features.Teams.Queries.GetList;
using Application.Services.Groups;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Teams.Queries.GetAllSeparatedByGroupId
{
    public class GetDistinctGrouppedQuery : IRequest<GetListResponse<GetAllSeparatedByGroupIdDto>>
    {
        public string MatchName { get; set; }
        public class GetAllSeparatedByGroupIdQueryHandler : IRequestHandler<GetDistinctGrouppedQuery, GetListResponse<GetAllSeparatedByGroupIdDto>>
        {
            private readonly ITeamRepository _teamRepository;
            private readonly IMapper _mapper;
            private readonly IGroupsService _groupsService;

            public GetAllSeparatedByGroupIdQueryHandler(ITeamRepository teamRepository, IMapper mapper, IGroupsService groupsService)
            {
                _teamRepository = teamRepository;
                _mapper = mapper;
                _groupsService = groupsService;
            }

            public async Task<GetListResponse<GetAllSeparatedByGroupIdDto>> Handle(GetDistinctGrouppedQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Team> teams = await _teamRepository.GetListAsync(
                    include: t => t.Include(t => t.Group).Include(t => t.Country),
                    index: 0,
                    size: 32,
                    cancellationToken: cancellationToken
                );

                IPaginate<Group> groups = await _groupsService.GetListAsync(predicate => predicate.MatchName == request.MatchName,
                    include: m => m.Include(m => m.Teams)
                    ,index: 0, size: 10);

                GetListResponse<GetAllSeparatedByGroupIdDto> response = _mapper.Map<GetListResponse<GetAllSeparatedByGroupIdDto>>(teams);
                return response;
            }
        }
    }
}
