using Application.Features.Teams.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Teams;

public class TeamsManager : ITeamsService
{
    private readonly ITeamRepository _teamRepository;
    private readonly TeamBusinessRules _teamBusinessRules;

    public TeamsManager(ITeamRepository teamRepository, TeamBusinessRules teamBusinessRules)
    {
        _teamRepository = teamRepository;
        _teamBusinessRules = teamBusinessRules;
    }

    public async Task<Team?> GetAsync(
        Expression<Func<Team, bool>> predicate,
        Func<IQueryable<Team>, IIncludableQueryable<Team, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Team? team = await _teamRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return team;
    }

    public async Task<IPaginate<Team>?> GetListAsync(
        Expression<Func<Team, bool>>? predicate = null,
        Func<IQueryable<Team>, IOrderedQueryable<Team>>? orderBy = null,
        Func<IQueryable<Team>, IIncludableQueryable<Team, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Team> teamList = await _teamRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return teamList;
    }

    public async Task<Team> AddAsync(Team team)
    {
        Team addedTeam = await _teamRepository.AddAsync(team);

        return addedTeam;
    }

    public async Task<Team> UpdateAsync(Team team)
    {
        Team updatedTeam = await _teamRepository.UpdateAsync(team);

        return updatedTeam;
    }

    public async Task<Team> DeleteAsync(Team team, bool permanent = false)
    {
        Team deletedTeam = await _teamRepository.DeleteAsync(team);

        return deletedTeam;
    }
}
