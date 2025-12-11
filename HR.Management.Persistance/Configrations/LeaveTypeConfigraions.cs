using HR.Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Persistance.Configrations
{
    internal class LeaveTypeConfigraions : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Name)
                .HasColumnType("nvarchar(70)")
                .HasMaxLength(70)
                .IsRequired();

            builder.HasIndex(q => q.Name)
                .IsUnique();

            builder.Property(q => q.DefaultDays)
                .HasColumnType("int")
                .IsRequired();
            builder.HasData(
       new LeaveType
       {
           Id = 1,
           Name = "Vacation",
           DefaultDays = 10,
           DateCreated = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
           DateModified = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
       }
   );
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_LeaveTypes_DefaultDays", "[DefaultDays] >= 1 AND [DefaultDays] <= 100");
            });

        }

    }
}
