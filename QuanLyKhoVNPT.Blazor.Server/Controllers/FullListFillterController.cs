using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhoVNPT.Blazor.Server.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FullListFillterController : ViewController<ListView>
    {
        
        public FullListFillterController()
        {
            InitializeComponent();
        }
        
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

            if (View.Editor is DxGridListEditor gridListEditor)
            {
                IDxGridAdapter dataGridAdapter = gridListEditor.GetGridAdapter();
                //dataGridAdapter.GridModel.ColumnResizeMode = DevExpress.Blazor.GridColumnResizeMode.Disabled;
                //dataGridAdapter.GridModel.ShowGroupPanel = true;
                dataGridAdapter.GridModel.FooterDisplayMode = DevExpress.Blazor.GridFooterDisplayMode.Auto;
                dataGridAdapter.GridModel.AutoExpandAllGroupRows = true;
                dataGridAdapter.GridModel.ShowFilterRow = true;
            }
        }
       
    }
}
