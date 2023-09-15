using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WBAuth.DAL.Models;

namespace WBAuth.DAL.Models
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder) { 
            base.OnModelCreating(builder);

            builder.Entity<Permission>().HasOne(ua => ua.Fonction).WithMany().HasForeignKey(ua => ua.IdRole);
            builder.Entity<Permission>().HasOne(ua => ua.Role).WithMany().HasForeignKey(ua => ua.IdRole);

            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Utilisateur).WithMany(u => u.UtilisateurApplication).HasForeignKey(ua => ua.IdUtilisateur);
            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Application).WithMany(a => a.UtilisateurApplication).HasForeignKey(ua => ua.IdApplication);
            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Role).WithMany().HasForeignKey(ua => ua.IdRole);
        }

        public DbSet<Action>? Action { get; set; }
        public DbSet<Application>? Application { get; set; }
        public DbSet<Fonction>? Fonction { get; set; }
        public DbSet<Journalisation>? Journalisation { get; set; }
        public DbSet<Permission>? Permission { get; set; }
        public DbSet<Role>? Role { get; set; }
        public DbSet<Utilisateur>? Utilisateur { get; set; }


    }

}



