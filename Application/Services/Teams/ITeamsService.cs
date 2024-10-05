using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Teams;

public interface ITeamsService
{
    Task<Team?> GetAsync(
        Expression<Func<Team, bool>> predicate,
        Func<IQueryable<Team>, IIncludableQueryable<Team, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Team>?> GetListAsync(
        Expression<Func<Team, bool>>? predicate = null,
        Func<IQueryable<Team>, IOrderedQueryable<Team>>? orderBy = null,
        Func<IQueryable<Team>, IIncludableQueryable<Team, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Team> AddAsync(Team team);
    Task<Team> UpdateAsync(Team team);
    Task<Team> DeleteAsync(Team team, bool permanent = false);
}
