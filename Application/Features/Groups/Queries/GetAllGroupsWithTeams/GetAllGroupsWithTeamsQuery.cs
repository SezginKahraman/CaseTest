using Application.Features.Groups.Queries.GetList;
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
using System.Xml.Linq;

namespace Application.Features.Groups.Queries.GetAllGroupsWithTeams
{
    public class GetAllGroupsWithTeamsQuery : IRequest<List<GetAllGroupsWithTeamsDto>>
    {
        public string MatchName { get; set; }
        public class GetAllGroupsWithTeamsQueryHandler : IRequestHandler<GetAllGroupsWithTeamsQuery, List<GetAllGroupsWithTeamsDto>>
        {
            private readonly IGroupRepository _groupRepository;
            private readonly IMapper _mapper;

            public GetAllGroupsWithTeamsQueryHandler(IGroupRepository groupRepository, IMapper mapper)
            {
                _groupRepository = groupRepository;
                _mapper = mapper;
            }

            public async Task<List<GetAllGroupsWithTeamsDto>> Handle(GetAllGroupsWithTeamsQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Group> groups = await _groupRepository.GetListAsync(
                    predicate: p => p.MatchName == request.MatchName,
                    include: m => m.Include(m => m.Teams),
                    index: 0,
                    size: 8,
                    cancellationToken: cancellationToken
                );
                List<GetAllGroupsWithTeamsDto> response = new();

                foreach (var group in groups.Items)
                {
                    var groupName = group.Name;
                    List<string> teams = new();
                    foreach (var team in group.Teams)
                    {
                        teams.Add(team.Name);
                    }
                    GetAllGroupsWithTeamsDto resultGroup = new()
                    {
                        Name = groupName,
                        Teams = teams
                    };
                    response.Add(resultGroup);
                }

                return response;
            }

            }
        }
    }

