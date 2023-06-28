using System.ComponentModel;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DN = DevExpress.Xpo.DisplayNameAttribute;

namespace connos_example.Module.BusinessObjects.Data
{
    [NavigationItem("Reinert Immobilienverwaltung GmbH")]
    [ModelDefault("Caption", "Wohnung")]
    public class Apartment : ReinertObject
    {
        public Apartment(Session session) : base(session) { }

        public Apartment() {}

        private string _description;

        private int _countOfKeys;

        private int _countOfRooms;

        private int _squareMeters;

        private bool _rented;

        private DateTime _lastModernization;

        private RealEstateObject _realEstateObject;

        [DN("Beschreibung")]
        public string Description
        {
            get => _description;
            set => SetPropertyValue(nameof(Description), ref _description, value);
        }

        [DN("Anzahl Schlüssel")]
        public int CountOfKeys
        {
            get => _countOfKeys;
            set => SetPropertyValue(nameof(CountOfKeys), ref _countOfKeys, value);
        }

        [DN("Anzahl Zimmer")]
        public int CountOfRooms
        {
            get => _countOfRooms;
            set => SetPropertyValue(nameof(CountOfRooms), ref _countOfRooms, value);
        }

        [DN("Quadratmeter")]
        public int SquareMeters
        {
            get => _squareMeters;
            set => SetPropertyValue(nameof(SquareMeters), ref _squareMeters, value);
        }

        [DN("Vermietet")]
        public bool Rented
        {
            get => _rented;
            set => SetPropertyValue(nameof(Rented), ref _rented, value);
        }

        [DN("Letzte Modernisierung")]
        public DateTime LastModernization
        {
            get => _lastModernization;
            set => SetPropertyValue(nameof(LastModernization), ref _lastModernization, value);
        }
        
        [Association]
        public RealEstateObject RealEstateObject
        {
            get => _realEstateObject; 
            set => SetPropertyValue(nameof(RealEstateObject), ref _realEstateObject, value); 
        }

        [ManyToManyAlias(nameof(ApartmentRenters), nameof(ApartmentRenter.Renter))]
        public IList<Renter> Renters => GetList<Renter>();

        [Association, Aggregated, Browsable(false)]
        public virtual XPCollection<ApartmentRenter> ApartmentRenters => GetCollection<ApartmentRenter>();

        [Association, Aggregated]
        public virtual XPCollection<Repair> Repairs => GetCollection<Repair>();

        [Association, Aggregated]
        public virtual XPCollection<Rent> Rent => GetCollection<Rent>();
    }
}
