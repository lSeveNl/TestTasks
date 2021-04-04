using Desk.Domain.Dictionary.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desk.DAL.Modeling
{
    class RequestTypeConfiguration : IEntityTypeConfiguration<RequestType>
    {
        public void Configure(EntityTypeBuilder<RequestType> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Created).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
