

using connos_example.Module.BusinessObjects.Data;
using DevExpress.ExpressApp;
using System.Data.OleDb;

namespace connos_example.Module.BusinessObjects
{
    public static class MsAccessDataMapper
    {
        public static Client GetClientDataFromAccess(IObjectSpace objectSpace, OleDbDataReader oleDbReader)
        {
            var client = objectSpace.CreateObject<Client>();
            client.OldId = int.Parse(oleDbReader["Id"]?.ToString() ?? "-1");
            client.OldTableName = "Mandant";
            client.Lastname = oleDbReader["Name"].ToString();
            client.Firstname = oleDbReader["Vorname"].ToString();
            client.Street = oleDbReader["Strasse"].ToString();
            client.HouseNumber = oleDbReader["Hausnummer"].ToString();
            client.Postcode = oleDbReader["Postleitzahl"].ToString();
            client.City = oleDbReader["Ort"].ToString();
            client.Country = oleDbReader["Land"].ToString();
            return client;
        }

        public static RealEstateObject GetRealEstateObjectDataFromAccess(IObjectSpace objectSpace, OleDbDataReader oleDbReader)
        {
            var realEstateObject = objectSpace.CreateObject<RealEstateObject>();
            realEstateObject.OldId = int.Parse(oleDbReader["Id"]?.ToString() ?? "-1");
            realEstateObject.OldTableName = "Objekt";
            realEstateObject.Street = oleDbReader["Strasse"].ToString();
            realEstateObject.HouseNumber = oleDbReader["Hausnummer"].ToString();
            realEstateObject.PostCode = oleDbReader["Postleitzahl"].ToString();
            realEstateObject.City = oleDbReader["Ort"].ToString();
            realEstateObject.Country = oleDbReader["Land"].ToString();
            realEstateObject.OldParentId = int.Parse(oleDbReader["Mandant"]?.ToString() ?? "-1");
            return realEstateObject;
        }

        public static Apartment GetApartmentDataFromAccess(IObjectSpace objectSpace, OleDbDataReader oleDbReader)
        {
            var apartment = objectSpace.CreateObject<Apartment>();
            apartment.OldId = int.Parse(oleDbReader["Id"]?.ToString() ?? "-1");
            apartment.OldTableName = "Wohnung";
            apartment.Description = oleDbReader["Bezeichnung"].ToString();
            apartment.CountOfKeys = int.Parse(oleDbReader["AnzahlSchluessel"].ToString() ?? "-1");
            apartment.CountOfRooms = int.Parse(oleDbReader["AnzahlZimmer"].ToString() ?? "-1");
            apartment.SquareMeters = int.Parse(oleDbReader["AnzahlQM"].ToString() ?? "-1");
            apartment.Rented = bool.Parse(oleDbReader["Vermietet"].ToString() ?? "0");
            apartment.LastModernization = DateTime.Parse(oleDbReader["LetzteModernisierung"].ToString() ?? "01.01.1970");
            apartment.OldParentId = int.Parse(oleDbReader["Objekt"]?.ToString() ?? "-1");
            return apartment;
        }

        public static ApartmentRenter GetApartmentRenterFromAccess(IObjectSpace objectSpace, OleDbDataReader oleDbReader)
        {
            var apartmentRenter = objectSpace.CreateObject<ApartmentRenter>();
            apartmentRenter.OldId = int.Parse(oleDbReader["Id"]?.ToString() ?? "-1");
            apartmentRenter.OldTableName = "WohnungMieter";
            apartmentRenter.ApartmentId = int.Parse(oleDbReader["Wohnung"].ToString() ?? "-1");
            apartmentRenter.RenterId = int.Parse(oleDbReader["Mieter"].ToString() ?? "-1");
            return apartmentRenter;
        }

        public static Renter GetRenterDataFromAccess(IObjectSpace objectSpace, OleDbDataReader oleDbReader)
        {
            var renter = objectSpace.CreateObject<Renter>();
            renter.OldId = int.Parse(oleDbReader["Id"]?.ToString() ?? "-1");
            renter.OldTableName = "Mieter";
            renter.Lastname = oleDbReader["Name"].ToString();
            renter.Firstname = oleDbReader["Vorname"].ToString();
            renter.IdNumber = oleDbReader["PersoNummer"].ToString();
            renter.Problems = oleDbReader["Probleme"].ToString();
            renter.RenterSince = DateTime.Parse(oleDbReader["MieterSeit"].ToString() ?? "01.01.1970");
            return renter;
        }

        public static Repair GetRepairDataFromAccess(IObjectSpace objectSpace, OleDbDataReader oleDbReader)
        {
            var repair = objectSpace.CreateObject<Repair>();
            repair.OldId = int.Parse(oleDbReader["Id"]?.ToString() ?? "-1");
            repair.OldTableName = "Reparatur";
            repair.Description = oleDbReader["Bezeichnung"].ToString();
            repair.Amount = decimal.Parse(oleDbReader["Betrag"].ToString() ?? "0");
            repair.Date = DateTime.Parse(oleDbReader["Datum"].ToString() ?? "01.01.1970");
            repair.OldParentId = int.Parse(oleDbReader["Wohnung"]?.ToString() ?? "-1");
            return repair;
        }

        public static Rent GetRentDataFromAccess(IObjectSpace objectSpace, OleDbDataReader oleDbReader)
        {
            var rent = objectSpace.CreateObject<Rent>();
            rent.OldId = int.Parse(oleDbReader["Id"]?.ToString() ?? "-1");
            rent.OldTableName = "Miete";
            rent.Amount = decimal.Parse(oleDbReader["Betrag"].ToString() ?? "0");
            rent.Date = DateTime.Parse(oleDbReader["Datum"].ToString() ?? "01.01.1970");
            rent.OldParentId = int.Parse(oleDbReader["Wohnung"]?.ToString() ?? "-1");
            return rent;
        }
    }
}
