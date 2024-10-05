using Application.Features.Teams.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Teams.Rules;

public class TeamBusinessRules : BaseBusinessRules
{
    private readonly ITeamRepository _teamRepository;

    public TeamBusinessRules(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public Task TeamShouldExistWhenSelected(Team? team)
    {
        if (team == null)
            throw new BusinessException(TeamsBusinessMessages.TeamNotExists);
        return Task.CompletedTask;
    }

    public async Task TeamIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Team? team = await _teamRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TeamShouldExistWhenSelected(team);
    }
}