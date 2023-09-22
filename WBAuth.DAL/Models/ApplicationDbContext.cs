using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WBAuth.DAL.Models
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Permission>().HasOne(p => p.Fonction).WithOne(f => f.Permission).HasForeignKey<Permission>(p => p.IdFonction).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Permission>().HasOne(p => p.Role).WithMany(r => r.Permissions).HasForeignKey(p => p.IdRole).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Utilisateur).WithOne(u => u.UtilisateurApplication).HasForeignKey<UtilisateurApplication>(ua => ua.IdUtilisateur).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Application).WithMany(a => a.UtilisateurApplications).HasForeignKey(ua => ua.IdApplication).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Role).WithOne(r => r.UtilisateurApplication).HasForeignKey<UtilisateurApplication>(ua => ua.IdRole).OnDelete(DeleteBehavior.NoAction);
        }


        public DbSet<Action>? Action { get; set; }
        public DbSet<Application>? Application { get; set; }
        public DbSet<Fonction>? Fonction { get; set; }
        public DbSet<Journalisation>? Journalisation { get; set; }
        public DbSet<Permission>? Permission { get; set; }
        public DbSet<Role>? Role { get; set; }
        public DbSet<Utilisateur>? Utilisateur { get; set; }
        public DbSet<UtilisateurApplication>? UtilisateurApplication { get; set; }


    }

}



