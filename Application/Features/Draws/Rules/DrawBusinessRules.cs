using Application.Features.Draws.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Draws.Rules;

public class DrawBusinessRules : BaseBusinessRules
{
    private readonly IDrawRepository _drawRepository;

    public DrawBusinessRules(IDrawRepository drawRepository)
    {
        _drawRepository = drawRepository;
    }

    public Task DrawShouldExistWhenSelected(Draw? draw)
    {
        if (draw == null)
            throw new BusinessException(DrawsBusinessMessages.DrawNotExists);
        return Task.CompletedTask;
    }

    public async Task DrawIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Draw? draw = await _drawRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DrawShouldExistWhenSelected(draw);
    }
}