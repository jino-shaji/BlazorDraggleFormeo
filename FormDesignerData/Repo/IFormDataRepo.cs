using FormDesigner.Domain.Model;
using FormDesigner.Domain.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormDesignerData.Repo
{
    public interface IFormDataRepo
    {
        public bool AddFormTemplates(FormTemplates formTemplates);
        public List<FormTemplatesViewModel> GetAllFormTemplates();
        public bool AddFormTemplateFormData(FormDataViewModel formTemplates);
        bool DeleteFormTemplates(int TemplateId);
        bool UpdateFormTemplate(FormTemplates formTemplates);
        FormTemplatesViewModel GetFormTemplateById(int TemplateId);
        List<FormDataTemplateViewModel> GetAllFormData();
        FormDataTemplateViewModel GetFormDataById(int FormId);
    }
}
