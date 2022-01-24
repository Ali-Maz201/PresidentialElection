using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PresidentialElection.Models;

namespace PresidentialElection.Data
{
    public class ApplicationContext : IdentityDbContext<StoreUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
