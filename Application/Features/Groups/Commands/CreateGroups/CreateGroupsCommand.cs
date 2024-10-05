using Application.Features.Groups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Groups.Commands.CreateGroups;

public class CreateGroupsCommand : IRequest<GetListResponse<CreatedGroupsResponse>>
{
    public string MatchName { get; set; }
    public int NumberOfGroups { get; set; }

    public class CreateGroupsCommandHandler : IRequestHandler<CreateGroupsCommand, GetListResponse<CreatedGroupsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly GroupBusinessRules _groupBusinessRules;

        public CreateGroupsCommandHandler(IMapper mapper, IGroupRepository groupRepository,
                                         GroupBusinessRules groupBusinessRules)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            _groupBusinessRules = groupBusinessRules;
        }

        public async Task<GetListResponse<CreatedGroupsResponse>> Handle(CreateGroupsCommand request, CancellationToken cancellationToken)
        {

           
        }
    }
}