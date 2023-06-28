using System.ComponentModel;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DN = DevExpress.Xpo.DisplayNameAttribute;

namespace connos_example.Module.BusinessObjects.Data
{
    [NavigationItem("Reinert Immobilienverwaltung GmbH")]
    [ModelDefault("Caption", "Mieter")]
    public class Renter : ReinertObject
    {
        public Renter(Session session) : base(session) { }

        private string _lastname;

        private string _firstname;

        private string _idNumber;

        private string _problems;

        private DateTime _renterSince;

        [DN("Name")]
        public string Lastname
        {
            get => _lastname;
            set => SetPropertyValue(nameof(Lastname), ref _lastname, value);
        }

        [DN("Vorname")]
        public string Firstname
        {
            get => _firstname;
            set => SetPropertyValue(nameof(Firstname), ref _firstname, value);
        }

        [DN("Personummer")]
        public string IdNumber
        {
            get => _idNumber;
            set => SetPropertyValue(nameof(IdNumber), ref _idNumber, value);
        }

        [DN("Probleme")]
        public string Problems
        {
            get => _problems;
            set => SetPropertyValue(nameof(Problems), ref _problems, value);
        }

        [DN("Mieter seit")]
        public DateTime RenterSince
        {
            get => _renterSince;
            set => SetPropertyValue(nameof(RenterSince), ref _renterSince, value);
        }
        
        [DN("Wohnungen")]
        [ManyToManyAlias(nameof(ApartmentRenters), nameof(ApartmentRenter.Apartment))]
        public IList<Apartment> Apartments => GetList<Apartment>();

        [Association, Aggregated, Browsable(false)]
        public virtual XPCollection<ApartmentRenter> ApartmentRenters => GetCollection<ApartmentRenter>();
    }
}
