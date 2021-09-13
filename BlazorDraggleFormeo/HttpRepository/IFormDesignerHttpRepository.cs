using FormDesigner.Domain.Model;
using FormDesigner.Domain.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDraggleFormeo.HttpRepository
{
    public interface IFormDesignerHttpRepository
    {
        Task<List<FormTemplatesViewModel>> GetAllFormTemplates();
        Task<FormTemplatesViewModel> GetFormTemplateById(int id);
        Task<string> UpsertFormTemplate(FormTemplatesViewModel data);
        Task<string> DeleteFormTemplate(int TemplateId);
        Task<string> AddFormTemplateData(FormDataViewModel formData);
        Task<List<FormDataTemplateViewModel>> GetAllFormTemplateData();
        Task<FormDataTemplateViewModel> GetFormDataById(int id);
    }
}
