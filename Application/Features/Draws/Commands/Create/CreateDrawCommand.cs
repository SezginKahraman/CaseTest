using Application.Features.Draws.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Draws.Commands.Create;

public class CreateDrawCommand : IRequest<CreatedDrawResponse>
{
    public string Picker { get; set; }
    public int TeamId { get; set; }
    public int GroupId { get; set; }

    public class CreateDrawCommandHandler : IRequestHandler<CreateDrawCommand, CreatedDrawResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDrawRepository _drawRepository;
        private readonly DrawBusinessRules _drawBusinessRules;

        public CreateDrawCommandHandler(IMapper mapper, IDrawRepository drawRepository,
                                         DrawBusinessRules drawBusinessRules)
        {
            _mapper = mapper;
            _drawRepository = drawRepository;
            _drawBusinessRules = drawBusinessRules;
        }

        public async Task<CreatedDrawResponse> Handle(CreateDrawCommand request, CancellationToken cancellationToken)
        {
            Draw draw = _mapper.Map<Draw>(request);

            await _drawRepository.AddAsync(draw);

            CreatedDrawResponse response = _mapper.Map<CreatedDrawResponse>(draw);
            return response;
        }
    }
}