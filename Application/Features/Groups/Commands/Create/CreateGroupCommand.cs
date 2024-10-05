using Application.Features.Groups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Groups.Commands.Create;

public class CreateGroupCommand : IRequest<CreatedGroupResponse>
{
    public string Name { get; set; }

    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, CreatedGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly GroupBusinessRules _groupBusinessRules;

        public CreateGroupCommandHandler(IMapper mapper, IGroupRepository groupRepository,
                                         GroupBusinessRules groupBusinessRules)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            _groupBusinessRules = groupBusinessRules;
        }

        public async Task<CreatedGroupResponse> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            Group group = _mapper.Map<Group>(request);

            await _groupRepository.AddAsync(group);

            CreatedGroupResponse response = _mapper.Map<CreatedGroupResponse>(group);
            return response;
        }
    }
}