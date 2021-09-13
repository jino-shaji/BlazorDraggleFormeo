using FormDesigner.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormDesignerData.Configuration
{
    public class FormDataConfiguration : IEntityTypeConfiguration<FormData>
    {
        public void Configure(EntityTypeBuilder<FormData> builder)
        {
            builder.HasKey(e => e.FormId);
            builder.Property(e => e.FormId).UseIdentityColumn();

            builder
           .HasOne(p => p.FormTemplate)
           .WithMany(b => b.FormData)
           .HasForeignKey(b => b.TemplateId);
        }
    }
}
