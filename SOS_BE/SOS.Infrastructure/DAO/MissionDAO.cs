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
        public void Create(MissionDTO dto)
        {
            _ctx.Mission.Add(dto);
            _ctx.SaveChanges();
        }
    }
}
