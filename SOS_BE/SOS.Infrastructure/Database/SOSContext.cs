using Microsoft.EntityFrameworkCore;
using SOS.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Infrastructure.Database
{
    public class SOSContext : DbContext
    {
        public SOSContext()
        {
        }

        public SOSContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CoordinatesSpanDTO> CoordinatesSpan { get; set; }
        public DbSet<MissionDTO> Mission { get; set; }
        public DbSet<TeamDTO> Team { get; set; }
        public DbSet<TeamMemberDTO> TeamMember { get; set; }
        public DbSet<VehicleDTO> Vehicle { get; set; }

    }
}
