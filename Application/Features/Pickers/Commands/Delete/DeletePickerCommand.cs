using Application.Features.Pickers.Commands.Delete;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pickers.Commands.Delete
{
    public class DeletePickerCommand : IRequest<DeletedPickerResponse>
    {
        public int Id { get; set; }

        public class DeletePickerCommandHandler : IRequestHandler<DeletePickerCommand, DeletedPickerResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPickerRepository _PickerRepository;
            //private readonly PickerBusinessRules _PickerBusinessRules;

            public DeletePickerCommandHandler(IMapper mapper, IPickerRepository PickerRepository
                                             //PickerBusinessRules PickerBusinessRules
                                             )
            {
                _mapper = mapper;
                _PickerRepository = PickerRepository;
                //_PickerBusinessRules = PickerBusinessRules;
            }

            public async Task<DeletedPickerResponse> Handle(DeletePickerCommand request, CancellationToken cancellationToken)
            {
                Picker? Picker = await _PickerRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
                //await _PickerBusinessRules.PickerShouldExistWhenSelected(Picker);

                await _PickerRepository.DeleteAsync(Picker!);

                DeletedPickerResponse response = _mapper.Map<DeletedPickerResponse>(Picker);
                return response;
            }
        }
    }
}
