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
    {
        public VatTu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        double tongTienNhap;
        string maVatTu;
        int soLuongTonKho;
        double gia;
        string doViTinh;
        string tenVatTu;
        int soLuongNhap;
        NhomVatTu nhomVatTu;
        string moTa;
        byte[] hinhAnh;

        [XafDisplayName("Mã vật tư")]
        [RuleRequiredField("Bắt buộc phải có VatTu.MaVatTu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
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
        public int SoLuongNhap
        {
            get => soLuongNhap;
            set
            {
                SetPropertyValue(nameof(SoLuongNhap), ref soLuongNhap, value);
            }

        }
        [VisibleInDetailView(false)]
        [XafDisplayName("Số lượng tồn kho")]
        public int SoLuongTonKho
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (VatTu_PhieuXuatKhos != null && SoLuongNhap > 0)
                    {
                        return SoLuongNhap - (VatTu_PhieuXuatKhos.Sum(i => i.SoLuong));
                    }

                }
                return 0;
            }

        }
        [XafDisplayName("Giá tiền")]
        public double Gia
        {
            get => gia;
            set => SetPropertyValue(nameof(Gia), ref gia, value);
        }


        [XafDisplayName("Thành tiền")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public double TongTienNhap
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    return Gia * SoLuongNhap;
                }
                return 0;
            }
        }

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
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit,DetailViewImageEditorMode = ImageEditorMode.PictureEdit,ListViewImageEditorCustomHeight = 40)]
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
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
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