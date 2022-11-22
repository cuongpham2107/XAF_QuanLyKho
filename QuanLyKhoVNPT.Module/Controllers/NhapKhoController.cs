using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraRichEdit.Model;
using Microsoft.Extensions.Options;
using QuanLyKhoVNPT.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhoVNPT.Module.Controllers
{
    
    public partial class NhapKhoController : ViewController
    {

        public NhapKhoController()
        {
            InitializeComponent();
            Btn_NhapVatTu();
            Btn_XuatVatTu();
        }
        private void Btn_NhapVatTu()
        {
            var action = new SimpleAction(this, $"{nameof(PhieuNhapKho)}-{nameof(Btn_NhapVatTu)}", "Edit")
            {
                Caption = "Nhập kho",
                ImageName = "SnapInsertHeader",
                TargetViewNesting = Nesting.Nested,
                TargetObjectType = typeof(VatTu),
                TargetViewType = ViewType.ListView,
                SelectionDependencyType = SelectionDependencyType.Independent,
            };
            action.Execute += (sender, args) =>
            {
                if (((DetailView)ObjectSpace.Owner).CurrentObject is PhieuNhapKho pnk)
                {

                    NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
                    if (controller != null)
                    {
                        void Created(object sender, ObjectCreatedEventArgs e)
                        {
                            var vt = e.CreatedObject as VatTu;
                            var phieuNhap = e.ObjectSpace.GetObject(pnk);
                            vt.PhieuNhapKho = phieuNhap;
                        }
                        controller.ObjectCreated += Created;
                        controller.NewObjectAction.DoExecute(controller.NewObjectAction.Items[0]);
                        Application.ShowViewStrategy.ShowMessage("Nhập kho thành công", InformationType.Info, displayInterval: 3000, InformationPosition.Bottom);

                    }

                }
            };
        }
        private void Btn_XuatVatTu()
        {
            PopupWindowShowAction action = new(this, "Xuất kho", "Edit")
            {
                Caption = "Xuất kho",
                TargetViewNesting = Nesting.Nested,
                TargetObjectType = typeof(VatTu),
                TargetViewType = ViewType.ListView,
                SelectionDependencyType = SelectionDependencyType.RequireSingleObject
            };
            action.CustomizePopupWindowParams += (s, e) => {
                IObjectSpace objectSpace = Application.CreateObjectSpace();
                var keHoach = new DomainClass();
                e.View = Application.CreateDetailView(objectSpace,keHoach, true);
            };
            action.Execute += (s, e) => {
                var popupParameter = e.PopupWindowViewCurrentObject as DomainClass;
                var parameter = ObjectSpace.GetObject(popupParameter);
                foreach (object item in View.SelectedObjects)
                {
                    if ((item as VatTu).SoLuongXuat <= (item as VatTu).SoLuongNhap && (item as VatTu).SoLuongNhap >= ((item as VatTu).SoLuongXuat + parameter.SoLuong))
                    {

                        (item as VatTu).SoLuongXuat = (item as VatTu).SoLuongXuat + parameter.SoLuong;
                       
                    }
                    else
                    {
                        Application.ShowViewStrategy.ShowMessage("Vật tư này trong khong đã hết", InformationType.Error, displayInterval: 3000, InformationPosition.Bottom);
                    }
                }
                ObjectSpace.CommitChanges();
            };
        }
    }

    [DomainComponent]
    [XafDisplayName("Số lượng xuất")]
    public class DomainClass
    {
        [XafDisplayName("Số lượng")]
        public int SoLuong { get; set; }
    }

}

    

