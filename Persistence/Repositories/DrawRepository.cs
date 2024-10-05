using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DrawRepository : EfRepositoryBase<Draw, int, BaseDbContext>, IDrawRepository
{
    public DrawRepository(BaseDbContext context) : base(context)
    {
    }
}