using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace connos_example.Module.BusinessObjects.Data;

[NavigationItem("Reinert Immobilienverwaltung GmbH")]
[ModelDefault("Caption", "Miete")]
public class Rent : ReinertObject
{
    public Rent(Session session) : base(session) { }

    private string _description;

    private decimal _amount;

    private DateTime _date;

    private Apartment _apartment;

    [DisplayName("Beschreibung")]
    public string Description
    {
        get => _description;
        set => SetPropertyValue(nameof(Description), ref _description, value);
    }

    [DisplayName("Menge")]
    public decimal Amount
    {
        get => _amount;
        set => SetPropertyValue(nameof(Amount), ref _amount, value);
    }

    [DisplayName("Datum")]
    public DateTime Date
    {
        get => _date;
        set => SetPropertyValue(nameof(Date), ref _date, value);
    }

    [DisplayName("Wohnung")]
    [Association]
    public Apartment Apartment
    {
        get => _apartment;
        set => SetPropertyValue(nameof(Apartment), ref _apartment, value);
    }
}

