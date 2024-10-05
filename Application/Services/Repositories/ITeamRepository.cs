using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITeamRepository : IAsyncRepository<Team, int>, IRepository<Team, int>
{
}