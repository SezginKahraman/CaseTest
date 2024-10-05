using Core.Application.Responses;

namespace Application.Features.Teams.Queries.GetById;

public class GetByIdTeamResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public int GroupId { get; set; }
}