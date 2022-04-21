using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.Core.Logging;
using InvoiceManagement.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class InvoiceManagementDbContext : DbContext 
    {
        public InvoiceManagementDbContext(DbContextOptions<InvoiceManagementDbContext> options) : base(options){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<FlatType> FlatTypes { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<InvoicePayment> InvoicePayment { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Resident>(ConfigureResident);
            modelBuilder.Entity<House>(ConfigureHouse);
            modelBuilder.Entity<Apartment>(ConfigureApartment);
            modelBuilder.Entity<FlatType>(ConfigureFlatType);
            modelBuilder.Entity<InvoiceType>(ConfigureInvoiceType);
            modelBuilder.Entity<Invoice>(ConfigureInvoice);
            modelBuilder.Entity<Log>(ConfigureLog);
            modelBuilder.Entity<InvoicePayment>(ConfigureInvoicePayment);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
           
        }

        private void ConfigureResident(EntityTypeBuilder<Resident> builder)
        {
            builder.HasKey(x=>x.UserId);
            builder.HasOne<User>().WithOne().HasForeignKey<Resident>(x=>x.UserId);
            builder.HasOne<House>().WithMany().HasForeignKey(x=>x.HouseId);

        }

        private void ConfigureHouse(EntityTypeBuilder<House> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne<Apartment>().WithMany().HasForeignKey(x=>x.ApartmentId);
            builder.HasOne<FlatType>().WithMany().HasForeignKey(x=>x.FlatTypeId);   
        }

        private void ConfigureApartment(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(x => x.Id);
        }
        private void ConfigureFlatType(EntityTypeBuilder<FlatType> builder)
        {
            builder.HasKey(x => x.Id);
        }
        private void ConfigureInvoiceType(EntityTypeBuilder<InvoiceType> builder)
        {
            builder.HasKey(x => x.Id);
        }

        private void ConfigureInvoice(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne<InvoiceType>().WithMany().HasForeignKey(x=>x.InvoiceTypeId);
            builder.HasOne<House>().WithMany().HasForeignKey(x=>x.HouseId);
        }

        private void ConfigureLog(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(x => x.Id);
        }
        private void ConfigureInvoicePayment(EntityTypeBuilder<InvoicePayment> builder)
        {
            builder.HasKey(ow => new { ow.InvoiceId, ow.UserId });
            builder.HasOne<Invoice>().WithMany().HasForeignKey(x => x.InvoiceId);
            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        }

    }
}
