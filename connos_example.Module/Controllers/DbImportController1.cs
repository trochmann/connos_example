using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System.Data;
using System.Data.OleDb;
using connos_example.Module.BusinessObjects;
using connos_example.Module.BusinessObjects.Data;
using DevExpress.ExpressApp.Win;

namespace connos_example.Module.Controllers
{
    public partial class DbImportController1 : ViewController
    {
        private readonly string _provider = "Microsoft.ACE.OLEDB.12.0";
        private readonly string _file = "C:\\src\\connos_example\\connos_example.Module\\bin\\Debug\\net6.0\\Reinert.accdb";
        private readonly List<Client> _clients = new();
        private readonly List<RealEstateObject> _realEstateObjects = new();
        private readonly List<Apartment> _apartments = new();
        private readonly List<ApartmentRenter> _apartmentRenters = new();
        private readonly List<Renter> _renters = new();
        private readonly List<Repair> _repairs = new();
        private readonly List<Rent> _rent = new();

        public DbImportController1()
        {
            InitializeComponent();

            //TargetObjectType = typeof(Client);
            TargetViewType = ViewType.Any;

            var importDb = new SimpleAction(this, "ImportDbAction", PredefinedCategory.Tools)
            {
                Caption = "Import DB",
                ImageName = "Action_Clear"
            };

            importDb.Execute += (obj, eventArgs) =>
            {
                var tables = GetTables();

                tables.ForEach(ImportAccessTableToSql);

                _clients.ForEach(c =>
                {
                    c
                        .RealEstateObjects
                        .AddRange(_realEstateObjects.Where(x => x.OldParentId == c.OldId));
                });

                _realEstateObjects.ForEach(r =>
                {
                    r
                        .Apartments
                        .AddRange(_apartments.Where(x => x.OldParentId == r.OldId));
                    r
                        .Client = _clients.FirstOrDefault(x => x.OldId == r.OldParentId);
                });

                _apartments.ForEach(a =>
                {
                    a
                        .ApartmentRenters
                        .AddRange(_apartmentRenters.Where(x => x.ApartmentId == a.OldId));
                    a
                        .Rent
                        .AddRange(_rent.Where(x => x.OldParentId == a.OldId));
                    a
                        .Repairs
                        .AddRange(_repairs.Where(x => x.OldParentId == a.OldId));
                    a
                        .RealEstateObject = _realEstateObjects.FirstOrDefault(x => x.OldId == a.OldParentId);
                });

                _renters.ForEach(r =>
                {
                    r
                        .ApartmentRenters
                        .AddRange(_apartmentRenters.Where(x => x.RenterId == r.OldId));
                });
                        
                _apartmentRenters.ForEach(ar =>
                {
                    ar.Renter = _renters.FirstOrDefault(x => x.OldId == ar.RenterId);
                    ar.Apartment = _apartments.FirstOrDefault(x => x.OldId == ar.ApartmentId);
                });

                _repairs.ForEach(r =>
                {
                    r.Apartment = _apartments.FirstOrDefault(x => x.OldId == r.OldParentId);
                });

                _rent.ForEach(r =>
                {
                    r.Apartment = _apartments.FirstOrDefault(x => x.OldId == r.OldParentId);
                });

                ObjectSpace.CommitChanges();
            };
        }

        private void ImportAccessTableToSql(string table)
        {
            var query = $"select * from {table}";

            using var oleDbConnection = new OleDbConnection($"Provider={_provider};Data Source={_file}");
            oleDbConnection.Open();
            using var oleDbCommand = new OleDbCommand(query, oleDbConnection);
            using var oleDbReader = oleDbCommand.ExecuteReader();

            while (oleDbReader.Read())
            {
                switch (table)
                {
                    case "Mandant":
                        _clients.Add(MsAccessDataMapper.GetClientDataFromAccess(ObjectSpace, oleDbReader));
                        break;
                    case "Objekt":
                        _realEstateObjects.Add(MsAccessDataMapper.GetRealEstateObjectDataFromAccess(ObjectSpace, oleDbReader));
                        break;
                    case "Wohnung":
                        _apartments.Add(MsAccessDataMapper.GetApartmentDataFromAccess(ObjectSpace, oleDbReader));
                        break;
                    case "WohnungMieter":
                        _apartmentRenters.Add(MsAccessDataMapper.GetApartmentRenterFromAccess(ObjectSpace, oleDbReader));
                        break;
                    case "Mieter":
                        _renters.Add(MsAccessDataMapper.GetRenterDataFromAccess(ObjectSpace, oleDbReader));
                        break;
                    case "Miete":
                        _rent.Add(MsAccessDataMapper.GetRentDataFromAccess(ObjectSpace, oleDbReader));
                        break;
                    case "Reparatur":
                        _repairs.Add(MsAccessDataMapper.GetRepairDataFromAccess(ObjectSpace, oleDbReader));
                        break;
                }
            }
        }

        private List<string> GetTables()
        {
            using var oleDbConnection = new OleDbConnection($"Provider={_provider};Data Source={_file}");

            oleDbConnection.Open();

            var schema = oleDbConnection.GetSchema("Tables");

            return (
                from DataRow row in schema.Rows
                select row["TABLE_NAME"].ToString()
                into tableName
                where tableName != null && !tableName.StartsWith("MSys")
                select tableName)
                .ToList();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
