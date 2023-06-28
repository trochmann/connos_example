using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace connos_example.Module.BusinessObjects.Data
{
    [NavigationItem("Reinert Immobilienverwaltung GmbH")]
    [ModelDefault("Caption", "Objekt")]
    public class RealEstateObject : ReinertObject
    {
        public RealEstateObject(Session session) : base(session) { }

        private string _street;

        private string _houseNumber;

        private string _postCode;

        private string _city;

        private string _country;

        private Client _client;

        [DisplayName("Straße")]
        public string Street
        {
            get => _street;
            set => SetPropertyValue(nameof(Street), ref _street, value);
        }

        [DisplayName("Hausnummer")]
        public string HouseNumber
        {
            get => _houseNumber;
            set => SetPropertyValue(nameof(HouseNumber), ref _houseNumber, value);
        }

        [DisplayName("Postleitzahl")]
        public string PostCode
        {
            get => _postCode;
            set => SetPropertyValue(nameof(PostCode), ref _postCode, value);
        }

        [DisplayName("Stadt")]
        public string City
        {
            get => _city;
            set => SetPropertyValue(nameof(City), ref _city, value);
        }

        [DisplayName("Land")]
        public string Country
        {
            get => _country;
            set => SetPropertyValue(nameof(Country), ref _country, value);
        }

        [Association]
        public Client Client
        {
            get => _client; 
            set => SetPropertyValue(nameof(Client), ref _client, value); 
        }

        [DisplayName("Wohnungen")]
        [Association, Aggregated]
        public virtual XPCollection<Apartment> Apartments => GetCollection<Apartment>();
    }
}
