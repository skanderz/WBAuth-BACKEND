using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.Models;

namespace WBAuth.DAL.Models
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder) { base.OnModelCreating(builder); }

        public DbSet<Action>? Action { get; set; }
        public DbSet<Application>? Application { get; set; }
        public DbSet<Fonction>? Fonction { get; set; }
        public DbSet<Journalisation>? Journalisation { get; set; }
        public DbSet<Permission>? Permission { get; set; }
        public DbSet<Role>? Role { get; set; }
        public DbSet<Utilisateur>? Utilisateur { get; set; }


    }

}



