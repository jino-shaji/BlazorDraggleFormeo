using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormDesigner.Domain.Model
{
    public class FormData
    {
        public int FormId { get; set; }
        public int TemplateId { get; set; }
        public string FormName { get; set; }
        public string FormTemplateData { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual FormTemplates FormTemplate { get; set; }
    }
}
