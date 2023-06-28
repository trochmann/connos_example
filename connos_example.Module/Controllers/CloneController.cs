using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.CloneObject;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using connos_example.Module.Helpers;

namespace connos_example.Module.Controllers
{
    public partial class CloneController : ObjectViewController
    {
        public CloneController()
        {
            InitializeComponent();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            var cloneObjectController = Frame.GetController<CloneObjectViewController>();
            if (cloneObjectController != null)
            {
                cloneObjectController.CustomCloneObject += cloneObjectController_CustomCloneObject;
            }
        }

        void cloneObjectController_CustomCloneObject(object sender, CustomCloneObjectEventArgs e)
        {
            var apartmentCloner = new ApartmentCloner();
            e.TargetObjectSpace = e.CreateDefaultTargetObjectSpace();
            var objectFromTargetObjectSpace = e.TargetObjectSpace.GetObject(e.SourceObject);
            e.ClonedObject = apartmentCloner.CloneTo(objectFromTargetObjectSpace, e.TargetType);
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
