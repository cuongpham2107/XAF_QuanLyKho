using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
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
    [DefaultProperty(nameof(TenVatTu))]
    [NavigationItem(Menu.QUANLYVATTU)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Vật tư")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [Appearance("Error", BackColor = "Red", FontStyle = System.Drawing.FontStyle.Bold, TargetItems = "*", Criteria = "[SoLuongTonKho] = 0 And [SoLuongNhap] <> 0")]

    public class VatTu : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public VatTu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string maVatTu;
        int tongTienXuat;
        int tongTienNhap;
        int soLuongTonKho;
        int soLuongXuat;
        int gia;
        string doViTinh;
        string tenVatTu;
        int soLuongNhap;
        NhomVatTu nhomVatTu;
        string moTa;
        byte[] hinhAnh;

        [XafDisplayName("Mã vật tư")]
        [RuleRequiredField("Bắt buộc phải có VatTu.MaVatTu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        //[Association("MaVatTu-VatTus")]
        public string MaVatTu
        {
            get => maVatTu;
            set => SetPropertyValue(nameof(MaVatTu), ref maVatTu, value);
        }
        [XafDisplayName("Tên vật tư")]
        [RuleRequiredField("Bắt buộc phải có VatTu.TenVatTu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenVatTu
        {
            get => tenVatTu;
            set => SetPropertyValue(nameof(TenVatTu), ref tenVatTu, value);
        }
        [XafDisplayName("Đơn vị tính")]
        [RuleRequiredField("Bắt buộc phải có VatTu.DoViTinh", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string DoViTinh
        {
            get => doViTinh;
            set => SetPropertyValue(nameof(DoViTinh), ref doViTinh, value);
        }
        [XafDisplayName("Số lượng nhập")]
        [Appearance("HidePhieuNhap", AppearanceItemType.ViewItem, "[PhieuNhapKho] Is Null", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public int SoLuongNhap
        {
            get => soLuongNhap;
            set
            {
                SetPropertyValue(nameof(SoLuongNhap), ref soLuongNhap, value);
            }

        }
        [XafDisplayName("Số lượng xuất")]
        [Appearance("HidePhieuXuat", AppearanceItemType.ViewItem, "[PhieuXuatKho] Is Null", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
        public int SoLuongXuat
        {
            get => soLuongXuat;
            set => SetPropertyValue(nameof(SoLuongXuat), ref soLuongXuat, value);
        }
        [VisibleInDetailView(false)]
        [XafDisplayName("Số lượng tồn kho")]
        public int SoLuongTonKho
        {
            get
            {
                return soLuongTonKho;
            }
            set { SetPropertyValue(nameof(SoLuongTonKho),ref soLuongTonKho, value); }   
        }
        [XafDisplayName("Giá tiền")]
        public int Gia
        {
            get => gia;
            set => SetPropertyValue(nameof(Gia), ref gia, value);
        }

        //[XafDisplayName("Tổng số tiền nhập")]
        //[VisibleInDetailView(false)]
        //[VisibleInListView(false)]
        //public int TongTienNhap
        //{
        //    get
        //    {
        //        if (!IsSaving && !IsLoading)
        //        {
        //            return SoLuongNhap * Gia;
        //        }
        //        return 0;
        //    }
        //}
        //[XafDisplayName("Tổng số tiền xuất")]
        //[VisibleInDetailView(false)]
        //[VisibleInListView(false)]
        //public int TongTienXuat
        //{
        //    get
        //    {
        //        if (!IsSaving && !IsLoading)
        //        {
        //            return SoLuongXuat * Gia;
        //        }
        //        return 0;
        //    }
        //}

        [XafDisplayName("Nhóm vật tư")]
        public NhomVatTu NhomVatTu
        {
            get => nhomVatTu;
            set => SetPropertyValue(nameof(NhomVatTu), ref nhomVatTu, value);
        }
        PhieuNhapKho phieuNhapKho;
        [XafDisplayName("Phiếu nhập kho")]
        [Association("PhieuNhapKho-VatTus")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public PhieuNhapKho PhieuNhapKho
        {
            get => phieuNhapKho;
            set => SetPropertyValue(nameof(PhieuNhapKho), ref phieuNhapKho, value);
        }
        //PhieuXuatKho phieuXuatKho;
        //[XafDisplayName("Phiếu xuất kho")]
        //[Association("PhieuXuatKho-VatTus")]
        //[VisibleInDetailView(false)]
        //[VisibleInListView(false)]
        //public PhieuXuatKho PhieuXuatKho
        //{
        //    get => phieuXuatKho;
        //    set => SetPropertyValue(nameof(PhieuXuatKho), ref phieuXuatKho, value);
        //}
        [XafDisplayName("Kho")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        Kho kho;
        [Association("Kho-VatTus")]
        public Kho Kho
        {
            get => kho;
            set => SetPropertyValue(nameof(Kho), ref kho, value);
        }
        [XafDisplayName("Hình ảnh")]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit,
    DetailViewImageEditorMode = ImageEditorMode.PictureEdit,
    ListViewImageEditorCustomHeight = 40)]
        public byte[] HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }
        [XafDisplayName("Mô tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Phiếu xuất kho")]
        [Association("VatTu-VatTu_PhieuXuatKhos")]
        public XPCollection<VatTu_PhieuXuatKho> VatTu_PhieuXuatKhos
        {
            get
            {
                return GetCollection<VatTu_PhieuXuatKho>(nameof(VatTu_PhieuXuatKhos));
            }
        }
    }

}