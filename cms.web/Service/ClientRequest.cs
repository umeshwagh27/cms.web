using cms.web.Models;
using System.Globalization;
using System.Text;

namespace cms.web.Service
{
    public static class ClientRequest
    {
        private static HttpClient _httpClient = new HttpClient();
        public static void Initialize(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CMSHttpClient");
        }

        public static async Task<string> Get(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> Post(string url, CarRequestResponse data)
        {
            using (var formData = new MultipartFormDataContent())
            {
                var newDate = DateTime.ParseExact(data.DateofManufacturingString, "dd-MM-yyyy", CultureInfo.InvariantCulture);      
                string formattedDate = newDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
                formData.Add(new StringContent(data.Brand, Encoding.UTF8), "Brand");
                formData.Add(new StringContent(data.ModelName, Encoding.UTF8), "ModelName");
                formData.Add(new StringContent(data.ModelCode, Encoding.UTF8), "ModelCode");
                formData.Add(new StringContent(data.Description, Encoding.UTF8), "Description");
                formData.Add(new StringContent(formattedDate, Encoding.UTF8), "DateofManufacturing");
                var response = await _httpClient.PostAsync(url, formData);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PostCarModel(string url, AddCarModelRequest data)
        {
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(data.Brand, Encoding.UTF8), "Brand");
                formData.Add(new StringContent(data.Price.ToString("F2"), Encoding.UTF8), "Price"); 
                formData.Add(new StringContent(data.Features, Encoding.UTF8), "Features");
                formData.Add(new StringContent(data.ClassName, Encoding.UTF8), "ClassName");
                if (data.Images != null)
                {
                    foreach (var file in data.Images)
                    {
                        var fileContent = new StreamContent(file.OpenReadStream());
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        formData.Add(fileContent, "images", file.FileName);
                    }
                }
                var response = await _httpClient.PostAsync(url, formData);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
