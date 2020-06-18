﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace DevAVXPO.Models.DevAV
{

	[Persistent(@"Product_Catalogs")]
	public partial class XpProduct_Catalogs : XPLiteObject
	{
		int fCatalog_ID;
		[Key(true)]
		public int Catalog_ID
		{
			get { return fCatalog_ID; }
			set { SetPropertyValue<int>(nameof(Catalog_ID), ref fCatalog_ID, value); }
		}
		XpProducts fProduct_ID;
		[Association(@"XpProduct_CatalogsReferencesXpProducts")]
		public XpProducts Product_ID
		{
			get { return fProduct_ID; }
			set { SetPropertyValue<XpProducts>(nameof(Product_ID), ref fProduct_ID, value); }
		}
		byte[] fCatalog_PDF;
		[Size(SizeAttribute.Unlimited)]
		[MemberDesignTimeVisibility(true)]
		public byte[] Catalog_PDF
		{
			get { return fCatalog_PDF; }
			set { SetPropertyValue<byte[]>(nameof(Catalog_PDF), ref fCatalog_PDF, value); }
		}
	}

}
