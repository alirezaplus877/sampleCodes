using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Data.Contexts
{
    public class Context : IdentityDbContext<Users, Roles, Guid, UserClaim, UsersInRoles, UserLogin, RoleClaim, UserToken>
    {


        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PGWUserClaimMap());
            //modelBuilder.ApplyConfiguration(new PersonMap());
            //modelBuilder.ApplyConfiguration(new CusomerMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<PGWUserClaim> PGWUserClaim { get; set; }
        //public DbSet<Post> Posts { get; set; }
        //public DbSet<Person> Persons { get; set; }
        //public DbSet<Customer> Customers{ get; set; }
    }
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    //{
    //    public Context CreateDbContext(string[] args)
    //    {
    //        var builder = new DbContextOptionsBuilder<Context>();
    //        builder.UseSqlServer(Context.connectionString);
    //        return new Context(builder.Options);
    //    }
    //}

}
