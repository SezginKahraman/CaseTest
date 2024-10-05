using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Draws.Commands.Create;

public class CreatedDrawResponse : IResponse
{
    public int Id { get; set; }
    public Picker Picker { get; set; }
    public int TeamId { get; set; }
    public int GroupId { get; set; }
}