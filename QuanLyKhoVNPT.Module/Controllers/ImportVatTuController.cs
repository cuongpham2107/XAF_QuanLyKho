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
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using OfficeOpenXml;
using QuanLyKhoVNPT.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhoVNPT.Module.Controllers
{

    public partial class ImportVatTuController : ObjectViewController<ListView, VatTu>
    {

        public ImportVatTuController()
        {
            InitializeComponent();
            var customUploadFileAction = new PopupWindowShowAction(this, "CustomUploadFileAction", PredefinedCategory.View)
            {
                Caption = "Nhập Vật Tư (File Excel)",
                ImageName = "AddFile",
                TargetViewNesting = Nesting.Nested,
                TargetObjectType = typeof(VatTu),
                TargetViewType = ViewType.ListView,
                SelectionDependencyType = SelectionDependencyType.Independent
            };
            customUploadFileAction.Execute += btn_importExcel;
            customUploadFileAction.CustomizePopupWindowParams += btn_importExcel_CustomizePopupWindowParams;

        }
        private void btn_importExcel_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            NonPersistentObjectSpace os = (NonPersistentObjectSpace)e.Application.CreateObjectSpace(typeof(UploadFileParameters));
            os.PopulateAdditionalObjectSpaces(Application);
            e.DialogController.SaveOnAccept = false;
            e.View = e.Application.CreateDetailView(os, os.CreateObject<UploadFileParameters>());
        }
        private void btn_importExcel(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            FileData fileData = ((UploadFileParameters)e.PopupWindowViewCurrentObject).File;

            if (((DetailView)ObjectSpace.Owner).CurrentObject is PhieuNhapKho pnk)
            {
                using (var stream = new MemoryStream())
                {
                    fileData.SaveToStream(stream);
                    stream.Position = 0;

                    var temp = Path.GetTempPath(); // Get %TEMP% path
                    var file = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()); // Get random file name without extension
                    var path = Path.Combine(temp, file + ".xlsx"); // Get random file path

                    using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        // Write content of your memory stream into file stream
                        stream.WriteTo(fs);
                    }
                    try
                    {
                        var package = new ExcelPackage(new FileInfo(path));
                        var phieuNhap = ObjectSpace.GetObject(pnk);
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"]; ;
                        for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                        {
                            try
                            {
                                var vt = ObjectSpace.CreateObject<VatTu>();
                                int j = 1;
                                vt.MaVatTu = workSheet.Cells[i, j++].Value.ToString();
                                vt.TenVatTu = workSheet.Cells[i, j++].Value.ToString();
                                vt.DoViTinh = workSheet.Cells[i, j++].Value.ToString();
                                vt.SoLuongNhap = int.Parse(workSheet.Cells[i, j++].Value.ToString());
                                vt.Gia = int.Parse(workSheet.Cells[i, j++].Value.ToString());
                                vt.PhieuNhapKho = phieuNhap;
                                vt.Kho = phieuNhap.Kho;
                                View.CollectionSource.Add(vt);
                                ObjectSpace.CommitChanges();

                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }
                        View.Refresh();
                        Application.ShowViewStrategy.ShowMessage("Nhập vật tư thành công", InformationType.Success, displayInterval: 3000, InformationPosition.Bottom);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

        }
        protected override void OnActivated()
        {
            base.OnActivated();

        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

        }
        protected override void OnDeactivated()
        {

            base.OnDeactivated();
        }
    }
    [DomainComponent]
    public class UploadFileParameters : NonPersistentObjectImpl
    {
        private FileDataEx file;
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        [RuleRequiredField("Save", "File should be assigned")]
        public FileDataEx File
        {
            get { return file; }
            set
            {
                SetPropertyValue(ref file, value);
                if (value != null)
                {
                    value.Changed += Value_Changed;
                }
            }
        }
        string fullName = null;
        private void Value_Changed(object sender, ObjectChangeEventArgs e)
        {
            if (e.PropertyName == "FullName")
            {
                fullName = (string)e.NewValue;
            }
        }
    }
}
