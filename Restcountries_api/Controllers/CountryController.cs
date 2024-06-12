using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restcountries_api.Models;

namespace Restcountries_api.Controllers
{
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _countryPath = "Countries";
        public CountryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var response = await GetAll();
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet ("name")]
        public async Task<IActionResult> GetCountryName(string name)
        {
            try
            {
                var response = await GetName(name);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<List<CountryInfo>> GetAll()
        {
            CountryDetailInfo cdi = new CountryDetailInfo();
            var client = _httpClientFactory.CreateClient(_countryPath);
            var response = await client.GetAsync($"all");
            string content = await response.Content.ReadAsStringAsync();

            var countryDetail = JsonConvert.DeserializeObject<List<CountryDetailInfo>>(content);
            var countries = countryDetail?.Select(c => new CountryInfo(c)).ToList();
            countries = countries.OrderBy(c => c.Name).ToList();

            return countries ?? new List<CountryInfo>();
        }

        private async Task<List<CountryDetailInfo>> GetName(string name)
        {
            var client = _httpClientFactory.CreateClient(_countryPath);
            var response = await client.GetAsync($"name/{name}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var countryDetail = JsonConvert.DeserializeObject<List<CountryDetailInfo>>(content);

                return countryDetail ?? new List<CountryDetailInfo>();
            } 
            else
            {
                return null;
            }
        }


    }
}
