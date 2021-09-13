using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormDesigner.Domain.Model.ViewModel
{
    public class FormDataViewModel
    {
        public int TemplateId { get; set; }
        public string FormName { get; set; }
        public string FormData { get; set; }
    }
    public class FormDataTemplateViewModel
    {
        public int FormId { get; set; }
        public int TemplateId { get; set; }
        public string FormName { get; set; }
        public DateTime FilledDate { get; set; }
        public string TemplateData { get; set; }
        public string TemplateName { get; set; }
        public string FormTemplateData { get; set; }
    }
}
