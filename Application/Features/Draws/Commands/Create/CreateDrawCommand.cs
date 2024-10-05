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

            var groupResults = await _groupRepository.GetListAsync(size: request.GroupCount);
            var teamsResult = await _teamRepository.GetListAsync(size: 32);
            var teams = teamsResult.Items.ToList();

            var groups = groupResults.Items.ToList();

            Draw draw = _mapper.Map<Draw>(request);

            await _drawRepository.AddAsync(draw);

            Random random = new Random();
            List<int> numbers = Enumerable.Range(0, 33).ToList();

            var groupTeamList = new List<GroupTeam>();
            var isBreak = false;

            for (int j = 0; j < request.GroupCount; j++)
            {
                for (int i = 1; i <= groups.Count; i++)
                {
                    while (numbers.Any())
                    {
                        // Rastgele bir indeks seç
                        int randomIndex = random.Next(numbers.Count);

                        // Seçilen elemaný çýkar ve yazdýr
                        int selectedNumber = numbers[randomIndex];
                        var relatedTeam = teams[selectedNumber];
                        var relatedGroups = groupTeamList.Where(t => t.GroupId == groups[i].Id);
                        var isSameCountry = false;

                        foreach (var relatedGroupTeam in relatedGroups)
                        {
                            var relatedTeamEntity = teams.FirstOrDefault(t => t.Id == relatedGroupTeam.TeamId);
                            if (relatedTeamEntity.CountryId == relatedTeam.CountryId)
                            {
                                isSameCountry = true;
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
                            GroupId = groups[i].Id,
                            DrawId = draw.Id
                        };
                        isBreak = true;

                        // Elemaný listeden çýkar
                        numbers.RemoveAt(randomIndex);
                        groupTeamList.Add(groupTeam);
                    }
                    if (isBreak)
                    {
                        continue;
                    }
                }
            }

            await _groupTeamRepository.AddRangeAsync(groupTeamList);

            CreatedDrawResponse response = _mapper.Map<CreatedDrawResponse>(draw);
            return response;
        }
    }
}