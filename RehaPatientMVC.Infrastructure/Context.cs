using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace RehaPatientMVC.Infrastructure
{
    public class Context :IdentityDbContext<AppUser>
    {
        public DbSet<Address> addresses { get; set; }
        public DbSet<ContactDetails> contactDetails { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Medic> medics { get; set; }
        public DbSet<Referral> referrals { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
