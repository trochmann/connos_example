using DevExpress.Persistent.Base;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connos_example.Module.Helpers
{
    public class ApartmentCloner : Cloner
    {
        public override void CopyMemberValue(XPMemberInfo memberInfo, IXPSimpleObject sourceObject, IXPSimpleObject targetObject)
        {
            if (!memberInfo.IsAssociation)
            {
                base.CopyMemberValue(memberInfo, sourceObject, targetObject);
            }
        }
    }
}
