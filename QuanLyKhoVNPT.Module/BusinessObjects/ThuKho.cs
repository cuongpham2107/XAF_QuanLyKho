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
    [DefaultProperty(nameof(TenThuKho))]
    [NavigationItem(Menu.QUANLYKHO)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Thủ kho")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class ThuKho : BaseObject
    { 
        public ThuKho(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string moTa;
        byte[] hinhAnh;
        string diaChi;
        string email;
        string soDienThoai;
        string tenThuKho;
        [XafDisplayName("Tên thủ kho")]
        [RuleRequiredField("Bắt buộc phải có ThuKho.TenThuKho", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenThuKho
        {
            get => tenThuKho;
            set => SetPropertyValue(nameof(TenThuKho), ref tenThuKho, value);
        }
        [XafDisplayName("Số điện thoại")]
        [RuleRequiredField("Bắt buộc phải có ThuKho.SoDienThoai", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string SoDienThoai
        {
            get => soDienThoai;
            set => SetPropertyValue(nameof(SoDienThoai), ref soDienThoai, value);
        }
        [XafDisplayName("Email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }
        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
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
    }
}