using SOS.Core.Domain;

namespace SOS.Model.RequestModels
{
    public class CreateTeamModel
    {
        public string Name { get; set; }
        public Vehicle Vehicle { get; set; }
        public CoordinatesSpan TeamArea { get; set; }
    }
}
