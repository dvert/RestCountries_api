using Newtonsoft.Json;

namespace Restcountries_api.Models
{
    public class CountryInfo
    {
        public string Name { get; set; }
        public List<string>? Capitals { get; set; }

        public CountryInfo (CountryDetailInfo cdi) 
        {
            Name = cdi.Name.Common;
            Capitals = cdi.Capitals;
        }
    }
}
