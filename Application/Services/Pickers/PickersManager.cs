using Application.Services.Pickers;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Pickers
{
    public class PickersManager : IPickersService
    {
        private readonly IPickerRepository _pickerRepository;
        //private readonly PickerBusinessRules _PickerBusinessRules;

        public PickersManager(IPickerRepository PickerRepository
            //PickerBusinessRules PickerBusinessRules
            )
        {
            _pickerRepository = PickerRepository;
            //_PickerBusinessRules = PickerBusinessRules;
        }

        public async Task<Picker?> GetAsync(
            Expression<Func<Picker, bool>> predicate,
            Func<IQueryable<Picker>, IIncludableQueryable<Picker, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            Picker? Picker = await _pickerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
            return Picker;
        }

        public async Task<IPaginate<Picker>?> GetListAsync(
            Expression<Func<Picker, bool>>? predicate = null,
            Func<IQueryable<Picker>, IOrderedQueryable<Picker>>? orderBy = null,
            Func<IQueryable<Picker>, IIncludableQueryable<Picker, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IPaginate<Picker> PickerList = await _pickerRepository.GetListAsync(
                predicate,
                orderBy,
                include,
                index,
                size,
                withDeleted,
                enableTracking,
                cancellationToken
            );
            return PickerList;
        }

        public async Task<Picker> AddAsync(Picker Picker)
        {
            Picker addedPicker = await _pickerRepository.AddAsync(Picker);

            return addedPicker;
        }

        public async Task<Picker> UpdateAsync(Picker Picker)
        {
            Picker updatedPicker = await _pickerRepository.UpdateAsync(Picker);

            return updatedPicker;
        }

        public async Task<Picker> DeleteAsync(Picker Picker, bool permanent = false)
        {
            Picker deletedPicker = await _pickerRepository.DeleteAsync(Picker);

            return deletedPicker;
        }
    }

}
