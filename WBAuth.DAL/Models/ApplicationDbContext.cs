using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WBAuth.Models;

namespace WBAuth.Data
{



    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        

    }




    








}         



