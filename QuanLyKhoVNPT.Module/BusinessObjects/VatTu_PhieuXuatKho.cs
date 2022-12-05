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
    
    public class VatTu_PhieuXuatKho : BaseObject
    { 
        public VatTu_PhieuXuatKho(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int soLuongTon;
        PhieuXuatKho phieuXuatKho;
        int soLuong;
        VatTu vatTu;
        [XafDisplayName("Tên vật tư")]
        [Association("VatTu-VatTu_PhieuXuatKhos")]
        public VatTu VatTu
        {
            get => vatTu;
            set => SetPropertyValue(nameof(VatTu), ref vatTu, value);
        }
        [XafDisplayName("Số lượng tồn kho")]
        public int SoLuongTon
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if( VatTu != null)
                    {
                        return VatTu.SoLuongTonKho;
                    }
                }
                return 0;
            }
        }
        [Association("PhieuXuatKho-VatTu_PhieuXuatKhos")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public PhieuXuatKho PhieuXuatKho
        {
            get => phieuXuatKho;
            set => SetPropertyValue(nameof(PhieuXuatKho), ref phieuXuatKho, value);
        }
        [XafDisplayName("Số lượng xuất")]
        public int SoLuong
        {
            get => soLuong;
            set => SetPropertyValue(nameof(SoLuong), ref soLuong, value);
        }
        double thanhTien;
        [XafDisplayName("Thành tiền")]
        public double ThanhTien
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(VatTu != null && SoLuong > 0 )
                    {
                        return SoLuong * VatTu.Gia;
                    }
                }
                return 0;
            }
        }
    }
}