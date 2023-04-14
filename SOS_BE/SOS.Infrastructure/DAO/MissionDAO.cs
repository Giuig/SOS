using Microsoft.EntityFrameworkCore;
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
    public class MissionDAO : IMissionDAO
    {
        private readonly SOSContext _ctx;

        public MissionDAO(SOSContext ctx)
        {
            _ctx = ctx;
        }
        public async Task Create(MissionDTO dto)
        {
            _ctx.Mission.Add(dto);
            await _ctx.SaveChangesAsync();
        }
        public async Task Delete(MissionDTO dto)
        {
            _ctx.Mission.Remove(dto);
            await _ctx.SaveChangesAsync();
        }
        public async Task<IEnumerable<MissionDTO>> GetAll()
        {
            return await _ctx.Mission.ToListAsync();
        }
        public async Task<MissionDTO> GetById(int id)
        {
            return await _ctx.Mission.FirstOrDefaultAsync(i => i.Id == id) ?? throw new ArgumentException($"Mission with ID {id} not found.");
        }
        public async Task Update(int id, MissionDTO dto)
        {
            var mission = _ctx.Mission.FirstOrDefault(i => i.Id == id);
            if (mission == null) return; // Handle the case where the mission with given id does not exist
            if (dto.Name != null) mission.Name = dto.Name;
            if (dto.StartDate != DateTime.MinValue) mission.StartDate = dto.StartDate;
            if (dto.EndDate != DateTime.MinValue) mission.EndDate = dto.EndDate;
            if (dto.Team != null) mission.Team = dto.Team;

            await _ctx.SaveChangesAsync();
        }
    }
}
