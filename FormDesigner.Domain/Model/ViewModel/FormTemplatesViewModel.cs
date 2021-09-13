using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormDesigner.Domain.Model.ViewModel
{
    public class FormTemplatesViewModel
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateData { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
