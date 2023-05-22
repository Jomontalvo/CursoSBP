using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoSBP.Common.Models.Entities.Configurations
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(p => p.SubjectName)
                 .HasMaxLength(50)
                 .IsRequired();
            builder.Property(p => p.TeacherName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.CostPerCycle)
                .HasColumnType("money")
                .HasDefaultValue(0.0m);
        }
    }
}
