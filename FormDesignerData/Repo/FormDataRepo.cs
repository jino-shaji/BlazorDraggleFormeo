using FormDesigner.Domain.Model;
using FormDesigner.Domain.Model.ViewModel;
using FormDesignerData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormDesignerData.Repo
{
    public class FormDataRepo : IFormDataRepo
    {
        private readonly ApplicationDbContext _dbContext;
        public FormDataRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddFormTemplateFormData(FormDataViewModel formTemplate)
        {
            var result = true ;
            try
            {
                _dbContext.FormData.Add(new FormData
                {
                    TemplateId = formTemplate.TemplateId,
                    FormTemplateData = formTemplate.FormData,
                    CreatedDate = DateTime.Now,
                    FormName = formTemplate.FormName,
                });
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool AddFormTemplates(FormTemplates formTemplates)
        {
            var result = true ;
            try
            {
                _dbContext.FormTemplates.Add(formTemplates);
                _dbContext.SaveChanges();
            }catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
        public bool DeleteFormTemplates(int TemplateId)
        {
            var result = true;
            try
            {
                var Templates = _dbContext.FormData.Where(u => u.TemplateId == TemplateId);
                _dbContext.RemoveRange(Templates);

                var FormData = _dbContext.FormTemplates.FirstOrDefault(u => u.TemplateId == TemplateId);
                _dbContext.Remove(FormData);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool UpdateFormTemplate(FormTemplates formTemplates)
        {
            var result = true;
            try
            {
                //var FormTemplate = _dbContext.FormTemplates.FirstOrDefault(u => u.TemplateId == formTemplates.TemplateId);
                //formTemplates.id
                //FormTemplate.TemplateData = formTemplates.TemplateData;
                //FormTemplate.TemplateName = formTemplates.TemplateName;
                _dbContext.Update(formTemplates);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public List<FormTemplatesViewModel> GetAllFormTemplates()
        {
            return _dbContext.FormTemplates.Select(u => new FormTemplatesViewModel
            {
                TemplateId = u.TemplateId,
                TemplateData = u.TemplateData,
                TemplateName = u.TemplateName,
                CreatedDate = u.CreatedDate,
                
            }).ToList();
        }
        public FormTemplatesViewModel GetFormTemplateById(int TemplateId)
        {
            return _dbContext.FormTemplates.Select(u => new FormTemplatesViewModel
            {
                TemplateId = u.TemplateId,
                TemplateData = u.TemplateData,
                TemplateName = u.TemplateName,
                CreatedDate = u.CreatedDate,
                
            }).FirstOrDefault(u => u.TemplateId == TemplateId);
        }

        public List<FormDataTemplateViewModel> GetAllFormData()
        {
            return _dbContext.FormData.Include(u=>u.FormTemplate).Select(u=>new FormDataTemplateViewModel
            {
                FormId = u.FormId,
                TemplateId = u.TemplateId,
                FormTemplateData=u.FormTemplateData,
                TemplateData = u.FormTemplate.TemplateData,
                FilledDate = u.CreatedDate,
                TemplateName = u.FormTemplate.TemplateName,
                FormName = u.FormName ?? ""
            }).ToList();
        }
        
        public FormDataTemplateViewModel GetFormDataById(int FormId)
        {
            return _dbContext.FormData.Include(u=>u.FormTemplate).Select(u => new FormDataTemplateViewModel
            {
                FormId = u.FormId,
                TemplateId = u.TemplateId,
                FormTemplateData = u.FormTemplateData,
                FilledDate = u.CreatedDate,
                TemplateData = u.FormTemplate.TemplateData,
                TemplateName = u.FormTemplate.TemplateName,
                FormName = u.FormName ??"",
                
            }).FirstOrDefault(u => u.FormId == FormId);
        }
    }
}
