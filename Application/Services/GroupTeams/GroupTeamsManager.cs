using Application.Services.GroupTeams;
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

namespace Application.Services.GroupTeams
{
    public class GroupTeamsManager : IGroupTeamsService
    {
        private readonly IGroupTeamRepository _groupTeamRepository;
        //private readonly GroupTeamBusinessRules _GroupTeamBusinessRules;

        public GroupTeamsManager(IGroupTeamRepository groupTeamRepository
            //, GroupTeamBusinessRules GroupTeamBusinessRules
            )
        {
            _groupTeamRepository = groupTeamRepository;
            //_groupTeamBusinessRules = groupTeamBusinessRules;
        }

        public async Task<GroupTeam?> GetAsync(
            Expression<Func<GroupTeam, bool>> predicate,
            Func<IQueryable<GroupTeam>, IIncludableQueryable<GroupTeam, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            GroupTeam? GroupTeam = await _groupTeamRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
            return GroupTeam;
        }

        public async Task<IPaginate<GroupTeam>?> GetListAsync(
            Expression<Func<GroupTeam, bool>>? predicate = null,
            Func<IQueryable<GroupTeam>, IOrderedQueryable<GroupTeam>>? orderBy = null,
            Func<IQueryable<GroupTeam>, IIncludableQueryable<GroupTeam, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IPaginate<GroupTeam> GroupTeamList = await _groupTeamRepository.GetListAsync(
                predicate,
                orderBy,
                include,
                index,
                size,
                withDeleted,
                enableTracking,
                cancellationToken
            );
            return GroupTeamList;
        }

        public async Task<GroupTeam> AddAsync(GroupTeam GroupTeam)
        {
            GroupTeam addedGroupTeam = await _groupTeamRepository.AddAsync(GroupTeam);

            return addedGroupTeam;
        }

        public async Task<GroupTeam> UpdateAsync(GroupTeam GroupTeam)
        {
            GroupTeam updatedGroupTeam = await _groupTeamRepository.UpdateAsync(GroupTeam);

            return updatedGroupTeam;
        }

        public async Task<GroupTeam> DeleteAsync(GroupTeam GroupTeam, bool permanent = false)
        {
            GroupTeam deletedGroupTeam = await _groupTeamRepository.DeleteAsync(GroupTeam);

            return deletedGroupTeam;
        }
    }

}
