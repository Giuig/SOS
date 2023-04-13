using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vehicle Vehicle { get; set; }
        public IEnumerable<TeamMember> Members { get; set; }
        public CoordinatesSpan TeamArea { get; set; }
    }
}
