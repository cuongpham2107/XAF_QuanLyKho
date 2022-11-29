using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuanLyKhoVNPT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenMa))]
    [NavigationItem(Menu.QUANLYVATTU)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Mã vật tư")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class MaVatTu : BaseObject
    { 
        public MaVatTu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string tenMa;

        public string TenMa
        {
            get => tenMa;
            set => SetPropertyValue(nameof(TenMa), ref tenMa, value);
        }
        [XafDisplayName("Danh sách vật tư")]
        [Association("MaVatTu-VatTus")]
        public XPCollection<VatTu> VatTus
        {
            get
            {
                return GetCollection<VatTu>(nameof(VatTus));
            }
        }
    }
}