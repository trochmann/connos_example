using System.ComponentModel;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace connos_example.Module.BusinessObjects.Data
{
    public class ReinertObject: BaseObject
    {
        public ReinertObject(Session session) : base(session) { }

        public ReinertObject()
        {
            
        }

        private int _oldId;
        private string _oldTableName;
        private int _oldParentId;

        [Browsable(false)]
        public virtual int OldId
        {
            get => _oldId;
            set => SetPropertyValue(nameof(OldId), ref _oldId, value);
        }

        [Browsable(false)]
        public virtual string OldTableName
        {
            get => _oldTableName;
            set => SetPropertyValue(nameof(OldTableName), ref _oldTableName, value);
        }

        [Browsable(false)]
        public virtual int OldParentId
        {
            get => _oldParentId;
            set => SetPropertyValue(nameof(OldParentId), ref _oldParentId, value);
        }
    }
}
