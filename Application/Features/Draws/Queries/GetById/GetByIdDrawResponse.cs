using Core.Application.Responses;

namespace Application.Features.Draws.Queries.GetById;

public class GetByIdDrawResponse : IResponse
{
    public int Id { get; set; }
    public string Picker { get; set; }
    public int TeamId { get; set; }
    public int GroupId { get; set; }
}