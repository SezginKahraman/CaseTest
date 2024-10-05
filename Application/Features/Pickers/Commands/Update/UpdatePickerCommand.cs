using Application.Features.Pickers.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Commands.Update
{
    public class UpdatePickerCommand : IRequest<UpdatedPickerResponse>
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public int? GroupId { get; set; }
        public int? DrawId { get; set; }

        public class UpdatePickerCommandHandler : IRequestHandler<UpdatePickerCommand, UpdatedPickerResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPickerRepository _PickerRepository;
            //private readonly PickerBusinessRules _PickerBusinessRules;

            public UpdatePickerCommandHandler(IMapper mapper, IPickerRepository PickerRepository
                //                             PickerBusinessRules PickerBusinessRules
                )
            {
                _mapper = mapper;
                _PickerRepository = PickerRepository;
                // _PickerBusinessRules = PickerBusinessRules;
            }

            public async Task<UpdatedPickerResponse> Handle(UpdatePickerCommand request, CancellationToken cancellationToken)
            {
                Picker? Picker = await _PickerRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
                // await _PickerBusinessRules.PickerShouldExistWhenSelected(Picker);
                Picker = _mapper.Map(request, Picker);

                await _PickerRepository.UpdateAsync(Picker!);

                UpdatedPickerResponse response = _mapper.Map<UpdatedPickerResponse>(Picker);
                return response;
            }
        }
    }
}
