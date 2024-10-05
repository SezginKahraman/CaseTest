using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Draws;

public interface IDrawsService : IServiceRepositoryBase<Draw>
{
}
