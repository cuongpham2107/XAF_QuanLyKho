using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraReports.Parameters;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace QuanLyKhoVNPT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenPhieu))]
    [NavigationItem(Menu.QUANLYNHAPXUAT)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Nhập kho")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class PhieuNhapKho : BaseObject
    { 
        public PhieuNhapKho(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string ghiChu;
        int tongSoTien;
        int tongSoLuongNhap;
        DateTime ngayNhap;
        string tenPhieu;
        string maPhieu;
        [XafDisplayName("Mã phiếu nhập")]
        [RuleRequiredField("Bắt buộc phải có PhieuNhapKho.MaPhieu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaPhieu
        {
            get => maPhieu;
            set => SetPropertyValue(nameof(MaPhieu), ref maPhieu, value);
        }
        [XafDisplayName("Tên phiếu nhập")]
        [RuleRequiredField("Bắt buộc phải có PhieuNhapKho.TenPhieu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenPhieu
        {
            get => tenPhieu;
            set => SetPropertyValue(nameof(TenPhieu), ref tenPhieu, value);
        }

        [XafDisplayName("Ngày nhập")]
        [RuleRequiredField("Bắt buộc phải có PhieuNhapKho.NgayNhap", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime NgayNhap
        {
            get => ngayNhap;
            set => SetPropertyValue(nameof(NgayNhap), ref ngayNhap, value);
        }
        [XafDisplayName("Tổng số lượng nhập")]
        [ModelDefault("AlowEdit", "False")]
        public int TongSoLuongNhap
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    return VatTus.Sum(i => i.SoLuongNhap);
                }
                return 0;
            }
        }
        [XafDisplayName("Tổng số tiền")]
        [ModelDefault("AlowEdit", "False")]
        public int TongSoTien
        {
            get
            {
                return tongSoTien;
            }
            set
            {
                SetPropertyValue(nameof(TongSoTien), ref tongSoTien, value);
            }
        }

        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        Kho kho;
        [XafDisplayName("Kho")]
        [Association("Kho-PhieuNhapKhos")]
        public Kho Kho
        {
            get => kho;
            set => SetPropertyValue(nameof(Kho), ref kho, value);
        }

        [XafDisplayName("Danh sách nhập vật tư")]
        [Association("PhieuNhapKho-VatTus")]
        public XPCollection<VatTu> VatTus
        {
            get
            {
                return GetCollection<VatTu>(nameof(VatTus));
            }
        }
    }
 
}