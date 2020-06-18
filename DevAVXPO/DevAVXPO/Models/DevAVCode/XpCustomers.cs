using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace DevAVXPO.Models.DevAV
{

	public partial class XpCustomers
	{
		public XpCustomers(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }
	}

}
