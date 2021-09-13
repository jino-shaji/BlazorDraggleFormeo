using FormDesigner.Domain.Model;
using FormDesigner.Domain.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorDraggleFormeo.HttpRepository
{
    public class FormDesignerHttpRepository: IFormDesignerHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public FormDesignerHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<FormTemplatesViewModel>> GetAllFormTemplates()
        {
            var response = await _client.GetAsync("FormTemplate/GetAllFormTemplates");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var products = JsonSerializer.Deserialize<List<FormTemplatesViewModel>>(content, _options);
            return products;
        }
        public async Task<FormTemplatesViewModel> GetFormTemplateById(int id)
        {
            var response = await _client.GetAsync($"FormTemplate/GetFormTemplateById/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var template = JsonSerializer.Deserialize<FormTemplatesViewModel>(content, _options);
            return template;
        }
        public async Task<string> UpsertFormTemplate(FormTemplatesViewModel data)
        {
            using var response = await _client.PostAsJsonAsync("FormTemplate/UpsertFormTemplate", data);
            var content = await response.Content.ReadAsStringAsync();
            string Message = "";
            if (!response.IsSuccessStatusCode)
            {
                // set error message for display, log to console and return
                Message = response.ReasonPhrase;
                Console.WriteLine($"There was an error! {Message}");
                return $"There was an error! {Message}";
            }

            // convert response data to Article object
            var res = await response.Content.ReadFromJsonAsync<bool>();
            if (res)
            {
                return data.TemplateId > 0 ? "Form templated updated successfully": "Form templated saved successfully";
            }
            else
            {
                return data.TemplateId > 0 ? "There was an error while updating form template" : "There was an error while saving form template";
            }
        }
        

        public async Task<string> DeleteFormTemplate(int TemplateId)
        {
            var response = await _client.DeleteAsync($"FormTemplate/DeleteFormTempalte/{TemplateId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var res = await response.Content.ReadFromJsonAsync<bool>();
            if (res)
            {
                return "Form templated deleted successfully";
            }
            else
            {
                return  "There was an error while deleting form template";
            }
        }

        public async Task<string> AddFormTemplateData(FormDataViewModel formData)
        {
            using var response = await _client.PostAsJsonAsync("FormTemplate/AddFormTemplateData", formData);
            var content = await response.Content.ReadAsStringAsync();
            string Message = "";
            if (!response.IsSuccessStatusCode)
            {
                // set error message for display, log to console and return
                Message = response.ReasonPhrase;
                Console.WriteLine($"There was an error! {Message}");
                return $"There was an error! {Message}";
            }

            // convert response data to Article object
            var res = await response.Content.ReadFromJsonAsync<bool>();
            if (res)
            {
                return "Form data saved successfully";
            }
            else
            {
                return "There was an error while saving form data";
            }
        }

        public async Task<List<FormDataTemplateViewModel>> GetAllFormTemplateData()
        {
            var response = await _client.GetAsync("FormTemplate/GetAllFormTemplateData");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var products = JsonSerializer.Deserialize<List<FormDataTemplateViewModel>>(content, _options);
            return products;
        }

        public async Task<FormDataTemplateViewModel> GetFormDataById(int id)
        {
            var response = await _client.GetAsync($"FormTemplate/GetFormDataById/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var template = JsonSerializer.Deserialize<FormDataTemplateViewModel>(content, _options);
            return template;
        }
    }
}
