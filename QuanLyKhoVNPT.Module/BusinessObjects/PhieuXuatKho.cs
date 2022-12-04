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
    [DefaultProperty(nameof(TenPhieu))]
    [NavigationItem(Menu.QUANLYNHAPXUAT)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Xuất kho")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class PhieuXuatKho : BaseObject
    { 
        public PhieuXuatKho(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        BoPhan boPhan;
        string maPhieuXuat;

        [XafDisplayName("Mã phiếu xuất")]
        [RuleRequiredField("Bắt buộc phải có PhieuXuatKho.MaPhieuXuat", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaPhieuXuat
        {
            get => maPhieuXuat;
            set => SetPropertyValue(nameof(MaPhieuXuat), ref maPhieuXuat, value);
        }
        string tenPhieu;
        [XafDisplayName("Tên phiếu xuất")]
        [RuleRequiredField("Bắt buộc phải có PhieuXuatKho.TenPhieu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenPhieu
        {
            get => tenPhieu;
            set => SetPropertyValue(nameof(TenPhieu), ref tenPhieu, value);
        }

        DateTime ngayXuat;
        [XafDisplayName("Ngày xuất")]
        [RuleRequiredField("Bắt buộc phải có PhieuXuatKho.NgayXuat", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime NgayXuat
        {
            get => ngayXuat;
            set => SetPropertyValue(nameof(NgayXuat), ref ngayXuat, value);
        }
        //int tongSoLuongXuat;
        //[ModelDefault("AllowEdit", "False")]
        //[XafDisplayName("Tổng số lượng xuất")]
        //public int TongSoLuongXuat
        //{
        //    get
        //    {
        //        if (!IsLoading && !IsSaving)
        //        {
        //            return VatTus.Sum(i => i.SoLuongXuat);
        //        }
        //        return 0;
        //    }
        //}
        //int tongSoTien;
        //[ModelDefault("AllowEdit", "False")]
        //[XafDisplayName("Tổng số tiền")]
        //public int TongSoTien
        //{
        //    get
        //    {
        //        if (!IsLoading && !IsSaving)
        //        {
        //            return VatTus.Sum(i => i.TongTienXuat);
        //        }
        //        return 0;
        //    }
        //}
        Kho kho;
        [XafDisplayName("Kho")]
        [RuleRequiredField("Bắt buộc phải có PhieuXuatKho.Kho", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Association("Kho-PhieuXuatKhos")]
        public Kho Kho
        {
            get => kho;
            set => SetPropertyValue(nameof(Kho), ref kho, value);
        }
        [XafDisplayName("Xuất cho bộ phận")]
        [RuleRequiredField("Bắt buộc phải có PhieuXuatKho.BoPhan", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public BoPhan BoPhan
        {
            get => boPhan;
            set => SetPropertyValue(nameof(BoPhan), ref boPhan, value);
        }
        string ghiChu;
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Danh sách xuất vật tư")]
        [Association("PhieuXuatKho-VatTu_PhieuXuatKhos")]
        public XPCollection<VatTu_PhieuXuatKho> VatTu_PhieuXuatKhos
        {
            get
            {
                return GetCollection<VatTu_PhieuXuatKho>(nameof(VatTu_PhieuXuatKhos));
            }
        }
    }
}