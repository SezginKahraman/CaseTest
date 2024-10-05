using Application.Features.Draws.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Draws;

public class DrawsManager : IDrawsService
{
    private readonly IDrawRepository _drawRepository;
    private readonly DrawBusinessRules _drawBusinessRules;

    public DrawsManager(IDrawRepository drawRepository, DrawBusinessRules drawBusinessRules)
    {
        _drawRepository = drawRepository;
        _drawBusinessRules = drawBusinessRules;
    }

    public async Task<Draw?> GetAsync(
        Expression<Func<Draw, bool>> predicate,
        Func<IQueryable<Draw>, IIncludableQueryable<Draw, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Draw? draw = await _drawRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return draw;
    }

    public async Task<IPaginate<Draw>?> GetListAsync(
        Expression<Func<Draw, bool>>? predicate = null,
        Func<IQueryable<Draw>, IOrderedQueryable<Draw>>? orderBy = null,
        Func<IQueryable<Draw>, IIncludableQueryable<Draw, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Draw> drawList = await _drawRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return drawList;
    }

    public async Task<Draw> AddAsync(Draw draw)
    {
        Draw addedDraw = await _drawRepository.AddAsync(draw);

        return addedDraw;
    }

    public async Task<Draw> UpdateAsync(Draw draw)
    {
        Draw updatedDraw = await _drawRepository.UpdateAsync(draw);

        return updatedDraw;
    }

    public async Task<Draw> DeleteAsync(Draw draw, bool permanent = false)
    {
        Draw deletedDraw = await _drawRepository.DeleteAsync(draw);

        return deletedDraw;
    }
}
