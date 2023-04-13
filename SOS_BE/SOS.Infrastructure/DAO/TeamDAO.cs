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
    public class TeamDAO : ITeamDAO
    {
        private readonly SOSContext _ctx;

        public TeamDAO(SOSContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(TeamDTO dto)
        {
            _ctx.Team.Add(dto);
            _ctx.SaveChanges();
        }
    }
}
