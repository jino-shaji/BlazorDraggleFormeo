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
    public class FormTemplatesConfiguration : IEntityTypeConfiguration<FormTemplates>
    {
        public void Configure(EntityTypeBuilder<FormTemplates> builder)
        {
            builder.HasKey(e => e.TemplateId);
            builder.Property(e => e.TemplateId).UseIdentityColumn();
        }
    }
}
