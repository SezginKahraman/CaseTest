using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TeamRepository : EfRepositoryBase<Team, int, BaseDbContext>, ITeamRepository
{
    public TeamRepository(BaseDbContext context) : base(context)
    {
    }
}