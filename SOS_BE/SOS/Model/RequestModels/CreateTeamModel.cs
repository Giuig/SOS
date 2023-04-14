using SOS.Core.Domain;

namespace SOS.Model.RequestModels
{
    public class CreateTeamModel
    {
        public string Name { get; set; }
        public CreateVehicle Vehicle { get; set; }
        public CreateCoordinatesSpan TeamArea { get; set; }
    }
}
