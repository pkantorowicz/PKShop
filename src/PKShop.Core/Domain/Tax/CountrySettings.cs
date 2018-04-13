using PKShop.Core.Domain.Countries;

namespace PKShop.Core.Domain.Tax
{
    public class CountrySettings
    {
        public Country BusinessCountry { get; protected set; }

        protected CountrySettings()
        {           
        }

        public CountrySettings(Country businessCountry)
        {
            BusinessCountry = businessCountry;
        }
    }
}