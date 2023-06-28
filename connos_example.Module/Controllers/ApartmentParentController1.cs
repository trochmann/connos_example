using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using connos_example.Module.BusinessObjects.Data;
using DevExpress.ExpressApp.Model;

namespace connos_example.Module.Controllers
{
    public partial class ApartmentParentController1 : ViewController
    {
        public ApartmentParentController1()
        {
            InitializeComponent();
            TargetObjectType = typeof(Apartment);
            TargetViewType = ViewType.DetailView;

            var setParentAction = new PopupWindowShowAction(this, "SetApartmentParent", PredefinedCategory.Edit)
            {
                Caption = "Objekt zuordnen"
            };

            setParentAction.CustomizePopupWindowParams += setParentAction_CustomizePopupWindowParams;
            setParentAction.Execute += setParentAction_Execute;
        }

        void setParentAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var objectType = typeof(RealEstateObject);
            var newObjectSpace = Application.CreateObjectSpace(objectType);
            var listViewId = Application.FindLookupListViewId(objectType);
            var modelListView = (IModelListView)Application.FindModelView(listViewId);
            var collectionSource = Application.CreateCollectionSource(newObjectSpace, objectType, listViewId);
            e.View = Application.CreateListView(modelListView, collectionSource, true);
        }

        void setParentAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var apartment = (Apartment)e.CurrentObject;
            var realEstateObjectFromDifferentSession = (RealEstateObject)e.PopupWindowViewCurrentObject;

            if (apartment is null || apartment.GetType() != typeof(Apartment)) return;

            var realEstateObject = ObjectSpace.GetObject(realEstateObjectFromDifferentSession);
            apartment.RealEstateObject = realEstateObject;
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
