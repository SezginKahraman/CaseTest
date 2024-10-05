using Application.Features.Countries.Commands.Update;
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

namespace Application.Features.GroupTeams.Commands.Update
{
    public class UpdateGroupTeamCommand : IRequest<UpdatedGroupTeamResponse>
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public int? GroupId { get; set; }
        public int? DrawId { get; set; }

        public class UpdateGroupTeamCommandHandler : IRequestHandler<UpdateGroupTeamCommand, UpdatedGroupTeamResponse>
        {
            private readonly IMapper _mapper;
            private readonly IGroupTeamRepository _GroupTeamRepository;
            //private readonly GroupTeamBusinessRules _GroupTeamBusinessRules;

            public UpdateGroupTeamCommandHandler(IMapper mapper, IGroupTeamRepository GroupTeamRepository
                //                             GroupTeamBusinessRules GroupTeamBusinessRules
                )
            {
                _mapper = mapper;
                _GroupTeamRepository = GroupTeamRepository;
               // _GroupTeamBusinessRules = GroupTeamBusinessRules;
            }

            public async Task<UpdatedGroupTeamResponse> Handle(UpdateGroupTeamCommand request, CancellationToken cancellationToken)
            {
                GroupTeam? GroupTeam = await _GroupTeamRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
                // await _GroupTeamBusinessRules.GroupTeamShouldExistWhenSelected(GroupTeam);
                GroupTeam = _mapper.Map(request, GroupTeam);

                await _GroupTeamRepository.UpdateAsync(GroupTeam!);

                UpdatedGroupTeamResponse response = _mapper.Map<UpdatedGroupTeamResponse>(GroupTeam);
                return response;
            }
        }
    }
}