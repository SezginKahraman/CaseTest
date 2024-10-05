using Application.Features.Countries.Commands.Delete;
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

namespace Application.Features.GroupTeams.Commands.Delete
{
    public class DeleteGroupTeamCommand : IRequest<DeletedGroupTeamResponse>
    {
        public int Id { get; set; }

        public class DeleteGroupTeamCommandHandler : IRequestHandler<DeleteGroupTeamCommand, DeletedGroupTeamResponse>
        {
            private readonly IMapper _mapper;
            private readonly IGroupTeamRepository _GroupTeamRepository;
            //private readonly GroupTeamBusinessRules _GroupTeamBusinessRules;

            public DeleteGroupTeamCommandHandler(IMapper mapper, IGroupTeamRepository GroupTeamRepository
                                             //GroupTeamBusinessRules GroupTeamBusinessRules
                                             )
            {
                _mapper = mapper;
                _GroupTeamRepository = GroupTeamRepository;
                //_GroupTeamBusinessRules = GroupTeamBusinessRules;
            }

            public async Task<DeletedGroupTeamResponse> Handle(DeleteGroupTeamCommand request, CancellationToken cancellationToken)
            {
                GroupTeam? GroupTeam = await _GroupTeamRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
                //await _GroupTeamBusinessRules.GroupTeamShouldExistWhenSelected(GroupTeam);

                await _GroupTeamRepository.DeleteAsync(GroupTeam!);

                DeletedGroupTeamResponse response = _mapper.Map<DeletedGroupTeamResponse>(GroupTeam);
                return response;
            }
        }
    }
}
