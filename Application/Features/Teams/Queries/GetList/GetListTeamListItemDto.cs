using Core.Application.Dtos;

namespace Application.Features.Teams.Queries.GetList;

public class GetListTeamListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public int GroupId { get; set; }
}