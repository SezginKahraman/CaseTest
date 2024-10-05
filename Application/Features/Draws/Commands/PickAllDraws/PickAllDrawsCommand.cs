using Application.Features.Draws.Commands.Create;
using Application.Features.Draws.Rules;
using Application.Services.Groups;
using Application.Services.Repositories;
using Application.Services.Teams;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Draws.Commands.PickAllDraws
{
    public class PickAllDrawsCommand : IRequest<GetListResponse<CreatedDrawAllResponse>>
    {
        public Picker Picker { get; set; }
        public string MatchName { get; set; }
        

        public class PickAllDrawsCommandHandler : IRequestHandler<PickAllDrawsCommand, GetListResponse<CreatedDrawAllResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IDrawRepository _drawRepository;
            private readonly ITeamsService _teamsService;
            private readonly IGroupsService _groupsService;
            private readonly DrawBusinessRules _drawBusinessRules;

            public PickAllDrawsCommandHandler(IMapper mapper, IDrawRepository drawRepository, ITeamsService teamsService, IGroupsService groupsService, DrawBusinessRules drawBusinessRules)
            {
                _mapper = mapper;
                _drawRepository = drawRepository;
                _teamsService = teamsService;
                _groupsService = groupsService;
                _drawBusinessRules = drawBusinessRules;
            }

            public async Task<GetListResponse<CreatedDrawAllResponse>> Handle(PickAllDrawsCommand request, CancellationToken cancellationToken)
            {
                IPaginate<Group> groups = await _groupsService.GetListAsync(index:0, size:10);
                IPaginate<Team> teams = await _teamsService.GetListAsync(index:0, size:32);

                bool isTeamSelected;
                Random random = new();
                for (int i = 0; i < (teams.Count/groups.Count); i++)
                {
                    foreach (var group in groups.Items)
                    {
                        isTeamSelected = false;
                        var counter = 0;
                        while (!isTeamSelected)
                        {
                            var randomNumber = random.Next(teams.Items.Count);
                            var teamToSelect = teams.Items[randomNumber];

                            var isSelectedTeamUniqueInSelectedGroup = await _teamsService.GetAsync(predicate: p => p.GroupId == group.Id && p.CountryId == teamToSelect.CountryId);
                            if (isSelectedTeamUniqueInSelectedGroup == null)
                            {
                                Draw draw = new()
                                {
                                    Picker = request.Picker,
                                    GroupId = group.Id,
                                    TeamId = teamToSelect.Id
                                };

                                teamToSelect.GroupId = group.Id;
                                isTeamSelected = true;
                                await _teamsService.UpdateAsync(teamToSelect);

                                await _drawRepository.AddAsync(draw);

                                teams.Items.Remove(teamToSelect);
                            }

                            counter++;
                            if (counter == 33) { break; }
                        }
                    }
                }

                

                IPaginate<Draw> draws = await _drawRepository.GetListAsync(predicate:p=> p.Picker == request.Picker , index:0, size:32);

                GetListResponse<CreatedDrawAllResponse> response = _mapper.Map<GetListResponse<CreatedDrawAllResponse>>(draws);
                return response;
            }
        }
    }
}
