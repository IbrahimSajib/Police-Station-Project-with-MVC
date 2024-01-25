using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Police_Station.Models;
using System.Reflection.Emit;

namespace Police_Station.Models.DbContext
{
    public class PoliceStationDbContext : IdentityDbContext
    {
        public PoliceStationDbContext(DbContextOptions<PoliceStationDbContext> options) : base(options)
        {
        }


        public DbSet<CaseApplication> CaseApplications { get; set; }
        public DbSet<PoliceOfficer> PoliceOfficers { get; set; }
        public DbSet<InvestigationInfo> InvestigationInfos { get; set; }
        public DbSet<ReportAnalysis> ReportAnalysis { get; set; }
        public DbSet<Criminal> Criminals { get; set; }
        public DbSet<Prison> Prisons { get; set; }
        public DbSet<PrisonRecord> PrisonRecords { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SeedRole();
            builder.SeedUser();
            builder.SeedUserRole();
            builder.SeedPoliceOfficer();
            builder.SeedPrison();
          
        }
        
    }
}
