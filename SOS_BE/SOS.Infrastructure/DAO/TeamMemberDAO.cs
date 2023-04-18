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
        public async Task Create(TeamMemberDTO dto)
        {
            try
            {
                _ctx.TeamMember.Add(dto);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Exception occurred while creating Team Member: {ex.Message}");
                throw; // rethrow the exception
            }
        }


        public Task<IEnumerable<TeamMemberDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TeamMemberDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, TeamMemberDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
