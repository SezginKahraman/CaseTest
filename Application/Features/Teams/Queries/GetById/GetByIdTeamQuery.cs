using Application.Features.Teams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teams.Queries.GetById;

public class GetByIdTeamQuery : IRequest<GetByIdTeamResponse>
{
    public int Id { get; set; }

    public class GetByIdTeamQueryHandler : IRequestHandler<GetByIdTeamQuery, GetByIdTeamResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly TeamBusinessRules _teamBusinessRules;

        public GetByIdTeamQueryHandler(IMapper mapper, ITeamRepository teamRepository, TeamBusinessRules teamBusinessRules)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
            _teamBusinessRules = teamBusinessRules;
        }

        public async Task<GetByIdTeamResponse> Handle(GetByIdTeamQuery request, CancellationToken cancellationToken)
        {
            Team? team = await _teamRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _teamBusinessRules.TeamShouldExistWhenSelected(team);

            GetByIdTeamResponse response = _mapper.Map<GetByIdTeamResponse>(team);
            return response;
        }
    }
}