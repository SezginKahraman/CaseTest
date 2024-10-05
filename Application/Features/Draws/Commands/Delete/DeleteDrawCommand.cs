using Application.Features.Draws.Constants;
using Application.Features.Draws.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Draws.Commands.Delete;

public class DeleteDrawCommand : IRequest<DeletedDrawResponse>
{
    public int Id { get; set; }

    public class DeleteDrawCommandHandler : IRequestHandler<DeleteDrawCommand, DeletedDrawResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDrawRepository _drawRepository;
        private readonly DrawBusinessRules _drawBusinessRules;

        public DeleteDrawCommandHandler(IMapper mapper, IDrawRepository drawRepository,
                                         DrawBusinessRules drawBusinessRules)
        {
            _mapper = mapper;
            _drawRepository = drawRepository;
            _drawBusinessRules = drawBusinessRules;
        }

        public async Task<DeletedDrawResponse> Handle(DeleteDrawCommand request, CancellationToken cancellationToken)
        {
            Draw? draw = await _drawRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _drawBusinessRules.DrawShouldExistWhenSelected(draw);

            await _drawRepository.DeleteAsync(draw!);

            DeletedDrawResponse response = _mapper.Map<DeletedDrawResponse>(draw);
            return response;
        }
    }
}