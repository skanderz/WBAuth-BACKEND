using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace WBAuth.DAL.Models
{

    public class ApplicationDbContext : IdentityDbContext<Utilisateur>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Utilisateur>().ToTable("Utilisateurs");

            builder.Entity<Permission>().HasOne(p => p.Fonction).WithMany(f => f.Permissions).HasForeignKey(p => p.IdFonction).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Permission>().HasOne(p => p.Role).WithMany(r => r.Permissions).HasForeignKey(p => p.IdRole).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Utilisateur).WithMany(u => u.UtilisateurApplications).HasForeignKey(ua => ua.GuidUtilisateur).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Application).WithMany(a => a.UtilisateurApplications).HasForeignKey(ua => ua.IdApplication).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UtilisateurApplication>().HasOne(ua => ua.Role).WithMany(r => r.UtilisateurApplications).HasForeignKey(ua => ua.IdRole).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Application>().HasMany(a => a.Fonctions).WithOne(f => f.Application).HasForeignKey(f => f.IdApplication).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Application>().HasMany(a => a.Roles).WithOne(f => f.Application).HasForeignKey(f => f.IdApplication).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Journalisation>().HasOne(u => u.Utilisateur).WithMany(j => j.Journalisations).HasForeignKey(j => j.GuidUtilisateur).OnDelete(DeleteBehavior.Cascade); ;
            builder.Entity<Action>().HasOne(j => j.Journalisation).WithMany(a => a.Actions).HasForeignKey(a => a.IdJournalisation).OnDelete(DeleteBehavior.Cascade); ;
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



