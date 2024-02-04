using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.webapp.Models;

namespace TMS.webapp.ModelConfiguration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
           builder.ToTable(nameof(Teacher));
            builder.HasKey(x => x.Id);
           builder.Property(x=>x.Name).HasMaxLength(50).IsRequired();
           builder.Property(x=>x.Email).HasMaxLength(50).IsRequired();
           builder.Property(x=>x.Phone).HasMaxLength(11).IsRequired();
           builder.Property(x=>x.Address).HasMaxLength(30).IsRequired();
           ;
             }
    }
}
