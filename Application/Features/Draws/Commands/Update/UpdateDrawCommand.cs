using Application.Features.Draws.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Draws.Commands.Update;

public class UpdateDrawCommand : IRequest<UpdatedDrawResponse>
{
    public int Id { get; set; }
    public string Picker { get; set; }
    public int TeamId { get; set; }
    public int GroupId { get; set; }

    public class UpdateDrawCommandHandler : IRequestHandler<UpdateDrawCommand, UpdatedDrawResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDrawRepository _drawRepository;
        private readonly DrawBusinessRules _drawBusinessRules;

        public UpdateDrawCommandHandler(IMapper mapper, IDrawRepository drawRepository,
                                         DrawBusinessRules drawBusinessRules)
        {
            _mapper = mapper;
            _drawRepository = drawRepository;
            _drawBusinessRules = drawBusinessRules;
        }

        public async Task<UpdatedDrawResponse> Handle(UpdateDrawCommand request, CancellationToken cancellationToken)
        {
            Draw? draw = await _drawRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _drawBusinessRules.DrawShouldExistWhenSelected(draw);
            draw = _mapper.Map(request, draw);

            await _drawRepository.UpdateAsync(draw!);

            UpdatedDrawResponse response = _mapper.Map<UpdatedDrawResponse>(draw);
            return response;
        }
    }
}