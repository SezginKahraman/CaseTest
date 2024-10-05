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
            Random random = new Random();

            var teamsResult = await _teamRepository.GetListAsync(size: 32);
            var shuffledTeams = teamsResult.Items.OrderBy(t => random.Next()).ToList();

            //var groups = groupResults.Items.ToList();

            Draw draw = _mapper.Map<Draw>(request);

            await _drawRepository.AddAsync(draw);

            var groupTeamList = new List<GroupTeam>();
            var index = 0;

            //var random = new Random();

            // Tak�mlar� shuffle ediyoruz
            //var shuffledTeams = teams.OrderBy(x => random.Next()).ToList();

            // Gruplar� olu�turaca��m�z liste
            var groups = new List<List<Team>>(request.GroupCount);

            // Her grup i�in bo� bir liste olu�turuyoruz
            for (int i = 0; i < request.GroupCount; i++)
            {
                groups.Add(new List<Team>());
            }

            // Gruplara e�it say�da tak�m eklemek i�in gruplar�n maksimum boyutunu hesapl�yoruz
            int teamsPerGroup = shuffledTeams.Count / request.GroupCount;
            int remainingTeams = shuffledTeams.Count % request.GroupCount;

            // Tak�mlar� gruplara s�rayla ve countryId'lere dikkat ederek ekliyoruz
            foreach (var team in shuffledTeams)
            {
                bool teamAdded = false;

                // En k���k dolulu�a sahip uygun bir grup bulmaya �al���yoruz
                foreach (var group in groups.OrderBy(g => g.Count))
                {
                    if (!group.Any(t => t.CountryId == team.CountryId) && group.Count < teamsPerGroup + (remainingTeams > 0 ? 1 : 0))
                    {
                        group.Add(team);
                        teamAdded = true;

                        // E�er fazladan bir tak�m� bu gruba eklediysek, remainingTeams'i azalt�yoruz
                        if (group.Count == teamsPerGroup + 1)
                        {
                            remainingTeams--;
                        }
                        break;
                    }
                }

                // E�er uygun grup bulamad�ysak (ayn� �lkeye sahip tak�mlardan dolay�), en k���k gruba zorla ekliyoruz
                if (!teamAdded)
                {
                    var fallbackGroup = groups.OrderBy(g => g.Count).First();
                    fallbackGroup.Add(team);

                    if (fallbackGroup.Count == teamsPerGroup + 1)
                    {
                        remainingTeams--;
                    }
                }
            }

            // Sonu� olarak gruplara da��t�lm�� tak�mlar
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine($"Group {i + 1}:");
                foreach (var team in groups[i])
                {
                    Console.WriteLine($"Team {team.Name} - CountryId {team.CountryId}");
                    groupTeamList.Add(new GroupTeam()
                    {
                        TeamId = team.Id,
                        GroupId = i + 1,
                        DrawId = draw.Id
                    });
                }
            }

            await _groupTeamRepository.AddRangeAsync(groupTeamList);

            var response = groupTeamList
             .GroupBy(t => t.GroupId)
             .Select(g => new GroupResponse()
             {
                 GroupName = groupResults.Items.FirstOrDefault(t => t.Id == g.Key)?.Name,
                 Teams = g.Select(t => new TeamResponse
                 {
                     Name = teamsResult.Items.FirstOrDefault(s => s.Id == t.Id)?.Name
                 }).ToList()
             }).ToList();

            return new CreatedDrawResponse() { Group = response };
        }
    }
}