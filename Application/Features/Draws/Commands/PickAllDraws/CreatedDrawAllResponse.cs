using Domain.Entities;

namespace Application.Features.Draws.Commands.PickAllDraws
{
    public class CreatedDrawAllResponse
    {
        public string Picker { get; set; }
        public int TeamId { get; set; }
        public int GroupId { get; set; }

    }
}