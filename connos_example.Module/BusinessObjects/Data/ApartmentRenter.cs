using DevExpress.Xpo;

namespace connos_example.Module.BusinessObjects.Data
{
    public class ApartmentRenter : ReinertObject
    {
        public ApartmentRenter(Session session) : base(session) { }

        private int _apartmentId;

        private int _renterId;

        private Apartment _apartment;

        private Renter _renter;

        public int ApartmentId
        {
            get => _apartmentId;
            set => SetPropertyValue(nameof(ApartmentId), ref _apartmentId, value);
        }

        public int RenterId
        {
            get => _renterId;
            set => SetPropertyValue(nameof(RenterId), ref _renterId, value);
        }

        [Association]
        public Apartment Apartment
        {
            get => _apartment; 
            set => SetPropertyValue(nameof(Apartment), ref _apartment, value); 
        }

        [Association]
        public Renter Renter
        {
            get => _renter;
            set => SetPropertyValue(nameof(Renter), ref _renter, value);
        }
    }
}
