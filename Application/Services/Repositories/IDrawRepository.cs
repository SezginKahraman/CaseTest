using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDrawRepository : IAsyncRepository<Draw, int>, IRepository<Draw, int>
{
}