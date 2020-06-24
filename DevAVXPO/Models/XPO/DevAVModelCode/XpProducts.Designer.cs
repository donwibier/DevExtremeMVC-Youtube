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
namespace DevAVXPO.Models.XPO.DevAV
{

	[Persistent(@"Products")]
	public partial class XpProducts : XPLiteObject
	{
		int fProduct_ID;
		[Key(true)]
		public int Product_ID
		{
			get { return fProduct_ID; }
			set { SetPropertyValue<int>(nameof(Product_ID), ref fProduct_ID, value); }
		}
		string fProduct_Name;
		[Size(50)]
		public string Product_Name
		{
			get { return fProduct_Name; }
			set { SetPropertyValue<string>(nameof(Product_Name), ref fProduct_Name, value); }
		}
		string fProduct_Description;
		[Size(SizeAttribute.Unlimited)]
		public string Product_Description
		{
			get { return fProduct_Description; }
			set { SetPropertyValue<string>(nameof(Product_Description), ref fProduct_Description, value); }
		}
		DateTime? fProduct_Production_Start;
		public DateTime? Product_Production_Start
		{
			get { return fProduct_Production_Start; }
			set { SetPropertyValue<DateTime?>(nameof(Product_Production_Start), ref fProduct_Production_Start, value); }
		}
		bool? fProduct_Available;
		[ColumnDbDefaultValue("((0))")]
		public bool? Product_Available
		{
			get { return fProduct_Available; }
			set { SetPropertyValue<bool?>(nameof(Product_Available), ref fProduct_Available, value); }
		}
		byte[] fProduct_Image;
		[Size(SizeAttribute.Unlimited)]
		[MemberDesignTimeVisibility(true)]
		public byte[] Product_Image
		{
			get { return fProduct_Image; }
			set { SetPropertyValue<byte[]>(nameof(Product_Image), ref fProduct_Image, value); }
		}
		XpEmployees fProduct_Support_ID;
		[Association(@"XpProductsReferencesXpEmployees1")]
		public XpEmployees Product_Support_ID
		{
			get { return fProduct_Support_ID; }
			set { SetPropertyValue<XpEmployees>(nameof(Product_Support_ID), ref fProduct_Support_ID, value); }
		}
		XpEmployees fProduct_Engineer_ID;
		[Association(@"XpProductsReferencesXpEmployees")]
		public XpEmployees Product_Engineer_ID
		{
			get { return fProduct_Engineer_ID; }
			set { SetPropertyValue<XpEmployees>(nameof(Product_Engineer_ID), ref fProduct_Engineer_ID, value); }
		}
		int? fProduct_Current_Inventory;
		[ColumnDbDefaultValue("((0))")]
		public int? Product_Current_Inventory
		{
			get { return fProduct_Current_Inventory; }
			set { SetPropertyValue<int?>(nameof(Product_Current_Inventory), ref fProduct_Current_Inventory, value); }
		}
		int? fProduct_Backorder;
		[ColumnDbDefaultValue("((0))")]
		public int? Product_Backorder
		{
			get { return fProduct_Backorder; }
			set { SetPropertyValue<int?>(nameof(Product_Backorder), ref fProduct_Backorder, value); }
		}
		int? fProduct_Manufacturing;
		[ColumnDbDefaultValue("((0))")]
		public int? Product_Manufacturing
		{
			get { return fProduct_Manufacturing; }
			set { SetPropertyValue<int?>(nameof(Product_Manufacturing), ref fProduct_Manufacturing, value); }
		}
		byte[] fProduct_Barcode;
		[Size(SizeAttribute.Unlimited)]
		[MemberDesignTimeVisibility(true)]
		public byte[] Product_Barcode
		{
			get { return fProduct_Barcode; }
			set { SetPropertyValue<byte[]>(nameof(Product_Barcode), ref fProduct_Barcode, value); }
		}
		byte[] fProduct_Primary_Image;
		[Size(SizeAttribute.Unlimited)]
		[MemberDesignTimeVisibility(true)]
		public byte[] Product_Primary_Image
		{
			get { return fProduct_Primary_Image; }
			set { SetPropertyValue<byte[]>(nameof(Product_Primary_Image), ref fProduct_Primary_Image, value); }
		}
		decimal? fProduct_Cost;
		[ColumnDbDefaultValue("((0))")]
		public decimal? Product_Cost
		{
			get { return fProduct_Cost; }
			set { SetPropertyValue<decimal?>(nameof(Product_Cost), ref fProduct_Cost, value); }
		}
		decimal? fProduct_Sale_Price;
		[ColumnDbDefaultValue("((0))")]
		public decimal? Product_Sale_Price
		{
			get { return fProduct_Sale_Price; }
			set { SetPropertyValue<decimal?>(nameof(Product_Sale_Price), ref fProduct_Sale_Price, value); }
		}
		decimal? fProduct_Retail_Price;
		[ColumnDbDefaultValue("((0))")]
		public decimal? Product_Retail_Price
		{
			get { return fProduct_Retail_Price; }
			set { SetPropertyValue<decimal?>(nameof(Product_Retail_Price), ref fProduct_Retail_Price, value); }
		}
		double? fProduct_Consumer_Rating;
		[ColumnDbDefaultValue("((0))")]
		public double? Product_Consumer_Rating
		{
			get { return fProduct_Consumer_Rating; }
			set { SetPropertyValue<double?>(nameof(Product_Consumer_Rating), ref fProduct_Consumer_Rating, value); }
		}
		string fProduct_Category;
		[Size(15)]
		public string Product_Category
		{
			get { return fProduct_Category; }
			set { SetPropertyValue<string>(nameof(Product_Category), ref fProduct_Category, value); }
		}
		[Association(@"XpOrder_ItemsReferencesXpProducts")]
		public XPCollection<XpOrder_Items> Order_Itemss { get { return GetCollection<XpOrder_Items>(nameof(Order_Itemss)); } }
		[Association(@"XpProduct_CatalogsReferencesXpProducts")]
		public XPCollection<XpProduct_Catalogs> Product_Catalogss { get { return GetCollection<XpProduct_Catalogs>(nameof(Product_Catalogss)); } }
		[Association(@"XpProduct_ImagesReferencesXpProducts")]
		public XPCollection<XpProduct_Images> Product_Imagess { get { return GetCollection<XpProduct_Images>(nameof(Product_Imagess)); } }
		[Association(@"XpQuote_ItemsReferencesXpProducts")]
		public XPCollection<XpQuote_Items> Quote_Itemss { get { return GetCollection<XpQuote_Items>(nameof(Quote_Itemss)); } }
	}

}