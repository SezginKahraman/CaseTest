using Core.Application.Responses;

namespace Application.Features.Teams.Commands.Create;

public class CreatedTeamResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public int GroupId { get; set; }
}