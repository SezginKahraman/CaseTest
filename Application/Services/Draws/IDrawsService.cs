using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Draws;

public interface IDrawsService
{
    Task<Draw?> GetAsync(
        Expression<Func<Draw, bool>> predicate,
        Func<IQueryable<Draw>, IIncludableQueryable<Draw, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Draw>?> GetListAsync(
        Expression<Func<Draw, bool>>? predicate = null,
        Func<IQueryable<Draw>, IOrderedQueryable<Draw>>? orderBy = null,
        Func<IQueryable<Draw>, IIncludableQueryable<Draw, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Draw> AddAsync(Draw draw);
    Task<Draw> UpdateAsync(Draw draw);
    Task<Draw> DeleteAsync(Draw draw, bool permanent = false);
}
