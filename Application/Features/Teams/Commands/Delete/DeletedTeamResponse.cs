using Core.Application.Responses;

namespace Application.Features.Teams.Commands.Delete;

public class DeletedTeamResponse : IResponse
{
    public int Id { get; set; }
}