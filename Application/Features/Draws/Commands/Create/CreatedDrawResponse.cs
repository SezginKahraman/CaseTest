using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Draws.Commands.Create;

public class CreatedDrawResponse : IResponse
{
    public List<GroupResponse> Group { get; set; }
}

public class GroupResponse
{
    public string GroupName { get; set; }
    public List<TeamResponse> Teams { get; set; }
}
public class TeamResponse
{
    public string Name { get; set; }
}