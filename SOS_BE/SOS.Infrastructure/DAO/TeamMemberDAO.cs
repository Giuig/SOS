using SOS.Infrastructure.Database;
using SOS.Infrastructure.DTO;
using SOS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Infrastructure.DAO
{
    public class TeamMemberDAO : ITeamMemberDAO
    {
        private readonly SOSContext _ctx;

        public TeamMemberDAO(SOSContext ctx) 
        { 
            _ctx = ctx;
        }
        public void Create(TeamMemberDTO dto)
        {
            _ctx.TeamMember.Add(dto);
            _ctx.SaveChanges();
        }
    }
}
