using Application.Features.Draws.Rules;
using Application.Features.Groups.Commands.Create;
using Application.Features.Groups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.Draws.Commands.Create;

public class CreateDrawCommand : IRequest<CreatedDrawResponse>
{
    public string DrawName { get; set; }
    public int PickerId { get; set; }
    public int GroupCount { get; set; }

    public class CreateDrawCommandHandler : IRequestHandler<CreateDrawCommand, CreatedDrawResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDrawRepository _drawRepository;
        private readonly DrawBusinessRules _drawBusinessRules;
        private readonly GroupBusinessRules _groupBusinessRules;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupTeamRepository _groupTeamRepository;
        private readonly ITeamRepository _teamRepository;

        public CreateDrawCommandHandler(IMapper mapper, IDrawRepository drawRepository,
                                         GroupBusinessRules groupBusinessRules,
                                         IGroupRepository groupRepository,
                                         IGroupTeamRepository groupTeamRepository,
                                         ITeamRepository teamRepository,
                                         DrawBusinessRules drawBusinessRules)
        {
            _mapper = mapper;
            _drawRepository = drawRepository;
            _drawBusinessRules = drawBusinessRules;
            _groupBusinessRules = groupBusinessRules;
            _groupRepository = groupRepository;
            _groupTeamRepository = groupTeamRepository;
            _teamRepository = teamRepository;
        }

        public async Task<CreatedDrawResponse> Handle(CreateDrawCommand request, CancellationToken cancellationToken)
        {
            await _groupBusinessRules.NumberOfGroupsMustFourOrEight(request.GroupCount);

            var groupResults = await _groupRepository.GetListAsync(size:request.GroupCount);
            Random random = new Random();

            var teamsResult = await _teamRepository.GetListAsync(size:32);
            var teams = teamsResult.Items.OrderBy(t => random.Next()).ToList();

            var groups = groupResults.Items.ToList();

            Draw draw = _mapper.Map<Draw>(request);

            await _drawRepository.AddAsync(draw);

            var groupTeamList = new List<GroupTeam>();
            var index = 0;

            foreach (var group in groups)
            {
                while (teams.Any())
                {
                    var relatedTeam = teams[index];
                    var relatedGroups = groupTeamList.Where(t => t.GroupId == group.Id);
                    var isSameCountry = false;

                    foreach (var relatedGroupTeam in relatedGroups)
                    {
                        var relatedTeamEntity = teams.FirstOrDefault(t => t.Id == relatedGroupTeam.TeamId);
                        if (relatedTeamEntity != null)
                        {
                            if (relatedTeamEntity.CountryId == relatedTeam.CountryId)
                            {
                                isSameCountry = true;
                            }
                        }
                    }
                    if (isSameCountry)
                    {
                        continue;
                    }

                    isSameCountry = false;

                    GroupTeam groupTeam = new GroupTeam()
                    {
                        TeamId = relatedTeam.Id,
                        GroupId = group.Id,
                        DrawId = draw.Id
                    };

                    // Elemaný listeden çýkar
                    teams.RemoveAt(index);
                    groupTeamList.Add(groupTeam);
                    if(groupTeamList.Count != request.GroupCount)
                    {
                        continue;
                    }
                    index++;
                }
            }

            await _groupTeamRepository.AddRangeAsync(groupTeamList);

            CreatedDrawResponse response = _mapper.Map<CreatedDrawResponse>(draw);
            return response;
        }
    }
}