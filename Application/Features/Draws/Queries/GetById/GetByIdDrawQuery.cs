using Application.Features.Draws.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.Draws.Queries.GetById;

public class GetByIdDrawQuery : IRequest<GetByIdDrawResponse>
{
    public int Id { get; set; }
    public int PickerId { get; set; }
    public string DrawName { get; set; }

    public class GetByIdDrawQueryHandler : IRequestHandler<GetByIdDrawQuery, GetByIdDrawResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDrawRepository _drawRepository;
        private readonly DrawBusinessRules _drawBusinessRules;

        public GetByIdDrawQueryHandler(IMapper mapper, IDrawRepository drawRepository, DrawBusinessRules drawBusinessRules)
        {
            _mapper = mapper;
            _drawRepository = drawRepository;
            _drawBusinessRules = drawBusinessRules;
        }

        public async Task<GetByIdDrawResponse> Handle(GetByIdDrawQuery request, CancellationToken cancellationToken)
        {
            Draw? draw = await _drawRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _drawBusinessRules.DrawShouldExistWhenSelected(draw);

            GetByIdDrawResponse response = _mapper.Map<GetByIdDrawResponse>(draw);
            return response;
        }
    }
}