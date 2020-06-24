using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace DevAVXPO.Models.XPO.DevAV
{

	public partial class XpDepartments
	{
		public XpDepartments(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }
	}

}
