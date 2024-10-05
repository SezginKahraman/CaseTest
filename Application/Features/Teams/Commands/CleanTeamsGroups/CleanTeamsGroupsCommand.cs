using Application.Features.Teams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Teams.Commands.CleanTeamsGroups
{
    public class CleanTeamsGroupsCommand : IRequest<CleanTeamsGroupsResponse>
    {

        public class CleanTeamsGroupsCommandHandler : IRequestHandler<CleanTeamsGroupsCommand, CleanTeamsGroupsResponse>
        {
            private readonly ITeamRepository _teamRepository;
            private readonly TeamBusinessRules _teamBusinessRules;

            public CleanTeamsGroupsCommandHandler(ITeamRepository teamRepository, TeamBusinessRules teamBusinessRules)
            {
                _teamRepository = teamRepository;
                _teamBusinessRules = teamBusinessRules;
            }

            public async Task<CleanTeamsGroupsResponse> Handle(CleanTeamsGroupsCommand request, CancellationToken cancellationToken)
            {
                IPaginate<Team> teams = await _teamRepository.GetListAsync(
                index: 0,
                size: 32,
                cancellationToken: cancellationToken
            );
                
                foreach (var team in teams.Items)
                {
                    team.GroupId = null;
                    
                }

                await _teamRepository.UpdateRangeAsync(teams.Items);

                CleanTeamsGroupsResponse res = new() { Response = "Teams are ungroup now." };

                return res;

            }
        }
    }
}
