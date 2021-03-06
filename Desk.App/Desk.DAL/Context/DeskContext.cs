using Desk.DAL.Modeling;
using Desk.Domain.Auth;
using Desk.Domain.Dictionary.RequestModels;
using Desk.Domain.Registration;
using Microsoft.EntityFrameworkCore;

namespace Desk.DAL.Context
{
    public class DeskContext : DbContext
    {
        public DeskContext(DbContextOptions<DeskContext> options)
            :base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<RequestType> RequestTypes { get; set; }

        public DbSet<LogTable> LogTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RequestType>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Request>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);

            const string schema = "dbo";

            modelBuilder.HasSequence<int>(nameof(User) + "Code", schema)
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.HasSequence<int>(nameof(Request) + "Code", schema)
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.HasSequence<int>(nameof(RequestType) + "Code", schema)
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new RequestTypeConfiguration());
        }
    }
}
