using PKShop.Domain.DomainClasses.Countries;

namespace PKShop.Domain.DomainClasses.Tax
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