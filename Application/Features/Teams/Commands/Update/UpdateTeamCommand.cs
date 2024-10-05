using Application.Features.Teams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teams.Commands.Update;

public class UpdateTeamCommand : IRequest<UpdatedTeamResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public int GroupId { get; set; }

    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, UpdatedTeamResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly TeamBusinessRules _teamBusinessRules;

        public UpdateTeamCommandHandler(IMapper mapper, ITeamRepository teamRepository,
                                         TeamBusinessRules teamBusinessRules)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
            _teamBusinessRules = teamBusinessRules;
        }

        public async Task<UpdatedTeamResponse> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            Team? team = await _teamRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _teamBusinessRules.TeamShouldExistWhenSelected(team);
            team = _mapper.Map(request, team);

            await _teamRepository.UpdateAsync(team!);

            UpdatedTeamResponse response = _mapper.Map<UpdatedTeamResponse>(team);
            return response;
        }
    }
}