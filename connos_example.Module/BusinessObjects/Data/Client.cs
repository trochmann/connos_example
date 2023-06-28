using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace connos_example.Module.BusinessObjects.Data
{
    [NavigationItem("Reinert Immobilienverwaltung GmbH")]
    [ModelDefault("Caption", "Mandant")]
    public class Client : ReinertObject
    {
        public Client(Session session) : base(session) { }

        private string _lastname;

        private string _firstname;

        private string _street;

        private string _houseNumber;

        private string _postCode;

        private string _city;

        private string _country;

        [DisplayName("Name")]
        public virtual string Lastname
        {
            get => _lastname;
            set => SetPropertyValue(nameof(Lastname), ref _lastname, value);
        }

        [DisplayName("Vorname")]
        public virtual string Firstname
        {
            get => _firstname;
            set => SetPropertyValue(nameof(Firstname), ref _firstname, value);
        }

        [DisplayName("Straße")]
        public virtual string Street
        {
            get => _street;
            set => SetPropertyValue(nameof(Street), ref _street, value);
        }

        [DisplayName("Hausnummer")]
        public virtual string HouseNumber
        {
            get => _houseNumber;
            set => SetPropertyValue(nameof(HouseNumber), ref _houseNumber, value);
        }

        [DisplayName("Postleitzahl")]
        public virtual string Postcode
        {
            get => _postCode;
            set => SetPropertyValue(nameof(Postcode), ref _postCode, value);
        }

        [DisplayName("Stadt")]
        public virtual string City
        {
            get => _city;
            set => SetPropertyValue(nameof(City), ref _city, value);
        }

        [DisplayName("Land")]
        public virtual string Country
        {
            get => _country;
            set => SetPropertyValue(nameof(Country), ref _country, value);
        }

        [DisplayName("Anzahl Objekte")]
        [NotMapped]
        public virtual int RealEstateObjectCount => RealEstateObjects.Count;

        [DisplayName("Anzahl Wohnungen")]
        [NotMapped]
        public virtual int ApartmentCount => RealEstateObjects.SelectMany(x => x.Apartments).Count();

        [DisplayName("Summe Miete")]
        [NotMapped]
        public virtual decimal OverallRent =>
            RealEstateObjects
                .SelectMany(x => x.Apartments)
                .SelectMany(x => x.Rent)
                .Sum(x => x.Amount);

        [DisplayName("Summe Reparaturen")]
        [NotMapped]
        public virtual decimal OverallRepairs =>
            RealEstateObjects
            .SelectMany(x => x.Apartments)
            .SelectMany(x => x.Repairs)
            .Sum(x => x.Amount);

        [DisplayName("Wohnungen")]
        [Association, Aggregated]
        public virtual XPCollection<RealEstateObject> RealEstateObjects => GetCollection<RealEstateObject>();
    }
}
