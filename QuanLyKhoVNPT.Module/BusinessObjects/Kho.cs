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
    [DefaultProperty(nameof(TenKho))]
    [NavigationItem(Menu.QUANLYKHO)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Kho")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class Kho : BaseObject
    { 
        public Kho(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string diaDiem;
        string tenKho;
        [XafDisplayName("Tên kho")]
        public string TenKho
        {
            get => tenKho;
            set => SetPropertyValue(nameof(TenKho), ref tenKho, value);
        }
        ThuKho thuKho;
        [XafDisplayName("Thủ kho")]
        public ThuKho ThuKho
        {
            get => thuKho;
            set => SetPropertyValue(nameof(ThuKho), ref thuKho, value);
        }
        [XafDisplayName("Địa điểm")]
        public string DiaDiem
        {
            get => diaDiem;
            set => SetPropertyValue(nameof(DiaDiem), ref diaDiem, value);
        }
        [XafDisplayName("Danh sách phiếu nhập kho")]
        [Association("Kho-PhieuNhapKhos")]
        public XPCollection<PhieuNhapKho> PhieuNhapKhos
        {
            get
            {
                return GetCollection<PhieuNhapKho>(nameof(PhieuNhapKhos));
            }
        }
        [XafDisplayName("Danh sách phiếu xuất kho")]
        [Association("Kho-PhieuXuatKhos")]
        public XPCollection<PhieuXuatKho> PhieuXuatKhos
        {
            get
            {
                return GetCollection<PhieuXuatKho>(nameof(PhieuXuatKhos));
            }
        }
        [XafDisplayName("Số lượng vật tư trong kho")]
        [Association("Kho-VatTus")]
        public XPCollection<VatTu> VatTus
        {
            get
            {
                return GetCollection<VatTu>(nameof(VatTus));
            }
        }

    }
}