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
   
    public class FileDataEx : FileData, ISupportFullName, IFileData
    { 
        public FileDataEx(Session session)
            : base(session)
        {
        }

        private string fullName;
        [ModelDefault("AllowEdit", "False")]
        public string FullName
        {
            get { return fullName; }
            set { SetPropertyValue("FullName", ref fullName, value); }
        }
        void IFileData.Clear()
        {
            base.Clear();
            FullName = string.Empty;
        }
    }
}