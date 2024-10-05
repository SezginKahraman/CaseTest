using Core.Application.Responses;

namespace Application.Features.Draws.Commands.Delete;

public class DeletedDrawResponse : IResponse
{
    public int Id { get; set; }
}