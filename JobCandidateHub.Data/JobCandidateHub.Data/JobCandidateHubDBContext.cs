using JobCandidateHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.Data
{
    public class JobCandidateHubDBContext : DbContext
    {
        public JobCandidateHubDBContext(DbContextOptions<JobCandidateHubDBContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
