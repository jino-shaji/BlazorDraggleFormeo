using FormDesigner.Domain.Model;
using FormDesigner.Domain.Model.ViewModel;
using FormDesignerData.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormDesignerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormTemplateController : ControllerBase
    {
        private readonly IFormDataRepo _formDataRepo;
        public FormTemplateController(IFormDataRepo formDataRepo)
        {
            _formDataRepo = formDataRepo;
        }
        // GET: api/<FormTemplateController>
        [HttpGet("GetAllFormTemplates")]
        public IActionResult GetAllFormTemplates()
        {
            return Ok(_formDataRepo.GetAllFormTemplates());
        }

        // GET api/<FormTemplateController>/5
        [HttpGet("GetFormTemplateById/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_formDataRepo.GetFormTemplateById(id));
        }

        // POST api/<FormTemplateController>
        [HttpPost("UpsertFormTemplate")]
        public IActionResult Post([FromBody] FormTemplatesViewModel formTemplate)
        {
            if (formTemplate.TemplateId > 0)
                return Ok(_formDataRepo.UpdateFormTemplate(new FormTemplates
                {
                    TemplateId = formTemplate.TemplateId,
                    TemplateName= formTemplate.TemplateName,
                    TemplateData= formTemplate.TemplateData,
                    
                }));
            else
                return Ok(_formDataRepo.AddFormTemplates(new FormTemplates
                {
                    TemplateId = formTemplate.TemplateId,
                    TemplateName = formTemplate.TemplateName,
                    TemplateData = formTemplate.TemplateData
                }));
        }

        // DELETE api/<FormTemplateController>/5
        [HttpDelete("DeleteFormTempalte/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_formDataRepo.DeleteFormTemplates(id));
        }

        // POST api/<FormTemplateController>
        [HttpPost("AddFormTemplateData")]
        public IActionResult AddFormTemplateData([FromBody] FormDataViewModel formData)
        {
            return Ok(_formDataRepo.AddFormTemplateFormData(new FormDataViewModel
            {
                TemplateId = formData.TemplateId,
                FormData = formData.FormData,
                FormName = formData.FormName,
                
            }));
        }

        // GET: api/<FormTemplateController>
        [HttpGet("GetAllFormTemplateData")]
        public IActionResult GetAllFormData()
        {
            return Ok(_formDataRepo.GetAllFormData());
        }

        // GET api/<FormTemplateController>/5
        [HttpGet("GetFormDataById/{id}")]
        public IActionResult GetFormDataById(int id)
        {
            return Ok(_formDataRepo.GetFormDataById(id));
        }
    }
}
