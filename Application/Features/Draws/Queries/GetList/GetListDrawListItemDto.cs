using Core.Application.Dtos;

namespace Application.Features.Draws.Queries.GetList;

public class GetListDrawListItemDto : IDto
{
    public int Id { get; set; }
    public string Picker { get; set; }
    public int TeamId { get; set; }
    public int GroupId { get; set; }
}