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
        public async Task Create(TeamDTO dto)
        {
            _ctx.Team.Add(dto);
            await _ctx.SaveChangesAsync();
        }

        public Task<IEnumerable<TeamDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TeamDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, TeamDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
