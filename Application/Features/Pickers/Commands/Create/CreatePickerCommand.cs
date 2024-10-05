using Application.Features.Pickers.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Commands.Create
{
    public class CreatePickerCommand : IRequest<CreatedPickerResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public class CreatePickerCommandHandler : IRequestHandler<CreatePickerCommand, CreatedPickerResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPickerRepository _PickerRepository;
            //private readonly PickerBusinessRules _PickerBusinessRules;

            public CreatePickerCommandHandler(IMapper mapper, IPickerRepository PickerRepository
                // PickerBusinessRules PickerBusinessRules
                )
            {
                _mapper = mapper;
                _PickerRepository = PickerRepository;
                //_PickerBusinessRules = PickerBusinessRules;
            }

            public async Task<CreatedPickerResponse> Handle(CreatePickerCommand request, CancellationToken cancellationToken)
            {
                Picker Picker = _mapper.Map<Picker>(request);

                await _PickerRepository.AddAsync(Picker);

                CreatedPickerResponse response = _mapper.Map<CreatedPickerResponse>(Picker);
                return response;
            }
        }
    }
}
