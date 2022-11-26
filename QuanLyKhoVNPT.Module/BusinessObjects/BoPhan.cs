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
    [DefaultProperty(nameof(TenBoPhan))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Bộ phận")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class BoPhan : BaseObject
    { 
        public BoPhan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        string soDienThoai;
        string nguoiPhuTrach;
        string tenBoPhan;
        [XafDisplayName("Tên bộ phận")]
        public string TenBoPhan
        {
            get => tenBoPhan;
            set => SetPropertyValue(nameof(TenBoPhan), ref tenBoPhan, value);
        }
        [XafDisplayName("Người phụ trách")]
        public string NguoiPhuTrach
        {
            get => nguoiPhuTrach;
            set => SetPropertyValue(nameof(NguoiPhuTrach), ref nguoiPhuTrach, value);
        }
        [XafDisplayName("Số điện thoại")]
        public string SoDienThoai
        {
            get => soDienThoai;
            set => SetPropertyValue(nameof(SoDienThoai), ref soDienThoai, value);
        }
    }
}