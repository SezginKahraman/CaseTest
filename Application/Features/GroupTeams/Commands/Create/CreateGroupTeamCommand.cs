using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GroupTeams.Commands.Create
{
    public class CreateGroupTeamCommand : IRequest<CreatedGroupTeamResponse>
    {
        public int TeamId { get; set; }
        public int GroupId { get; set; }
        public int DrawId { get; set; }

        public class CreateGroupTeamCommandHandler : IRequestHandler<CreateGroupTeamCommand, CreatedGroupTeamResponse>
        {
            private readonly IMapper _mapper;
            private readonly IGroupTeamRepository _GroupTeamRepository;
            //private readonly GroupTeamBusinessRules _GroupTeamBusinessRules;

            public CreateGroupTeamCommandHandler(IMapper mapper, IGroupTeamRepository GroupTeamRepository
                                            // GroupTeamBusinessRules GroupTeamBusinessRules
                )
            {
                _mapper = mapper;
                _GroupTeamRepository = GroupTeamRepository;
                //_GroupTeamBusinessRules = GroupTeamBusinessRules;
            }

            public async Task<CreatedGroupTeamResponse> Handle(CreateGroupTeamCommand request, CancellationToken cancellationToken)
            {
                GroupTeam GroupTeam = _mapper.Map<GroupTeam>(request);

                await _GroupTeamRepository.AddAsync(GroupTeam);

                CreatedGroupTeamResponse response = _mapper.Map<CreatedGroupTeamResponse>(GroupTeam);
                return response;
            }
        }
    }
}
