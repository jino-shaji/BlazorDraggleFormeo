using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormDesigner.Domain.Model
{
    public class FormTemplates
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateData { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual IList<FormData> FormData { get; set; }
    }
}
