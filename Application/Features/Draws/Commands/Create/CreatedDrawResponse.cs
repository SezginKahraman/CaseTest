using Core.Application.Responses;

namespace Application.Features.Draws.Commands.Create;

public class CreatedDrawResponse : IResponse
{
    public int Id { get; set; }
    public string Picker { get; set; }
    public int TeamId { get; set; }
    public int GroupId { get; set; }
}