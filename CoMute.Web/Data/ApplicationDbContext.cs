using CoMute.Web.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoMute.Web.Models;

namespace CoMute.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        }

        public DbSet<CoMute.Web.Models.CarPoolModel>? CarPoolModel { get; set; }
    }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // throw new NotImplementedException();
        builder.Property(u => u.Name).HasMaxLength(255);
        builder.Property(u => u.Surname).HasMaxLength(255);
        builder.Property(u => u.PhoneNumber).HasMaxLength(255);
    }
}