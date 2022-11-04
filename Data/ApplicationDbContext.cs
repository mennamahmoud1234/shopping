using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopping.Data
{
    public class ApplicationDbContext : IdentityDbContext<applicationuser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<man> man { get; set; }
        public DbSet<women> women { get; set; }
        public DbSet<childeren> childeren { get; set; }


        public DbSet<Electronics> Electronics { get; set; }
        public DbSet<Grocery> Grocery { get; set; }
        public DbSet<MobilePhone> MobilePhone { get; set; }


        public DbSet<Perfumes> Perfumes { get; set; }

        public DbSet<Shoeses> Shoeses { get; set; }


        public DbSet<Feedback> Feedback { get; set; }


        public DbSet<order> order { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<applicationuser>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        }


    }
}
