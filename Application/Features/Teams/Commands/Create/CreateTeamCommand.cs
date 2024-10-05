using Application.Features.Teams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teams.Commands.Create;

public class CreateTeamCommand : IRequest<CreatedTeamResponse>
{
    public string Name { get; set; }
    public int CountryId { get; set; }
    public int? GroupId { get; set; }

    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, CreatedTeamResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly TeamBusinessRules _teamBusinessRules;

        public CreateTeamCommandHandler(IMapper mapper, ITeamRepository teamRepository,
                                         TeamBusinessRules teamBusinessRules)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
            _teamBusinessRules = teamBusinessRules;
        }

        public async Task<CreatedTeamResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            Team team = _mapper.Map<Team>(request);

            await _teamRepository.AddAsync(team);

            CreatedTeamResponse response = _mapper.Map<CreatedTeamResponse>(team);
            return response;
        }
    }
}