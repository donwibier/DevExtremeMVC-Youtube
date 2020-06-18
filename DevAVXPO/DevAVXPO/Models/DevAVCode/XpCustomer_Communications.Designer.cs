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

	[Persistent(@"Customer_Communications")]
	public partial class XpCustomer_Communications : XPLiteObject
	{
		int fComm_ID;
		[Key(true)]
		public int Comm_ID
		{
			get { return fComm_ID; }
			set { SetPropertyValue<int>(nameof(Comm_ID), ref fComm_ID, value); }
		}
		XpEmployees fComm_Employee_ID;
		[Association(@"XpCustomer_CommunicationsReferencesXpEmployees")]
		public XpEmployees Comm_Employee_ID
		{
			get { return fComm_Employee_ID; }
			set { SetPropertyValue<XpEmployees>(nameof(Comm_Employee_ID), ref fComm_Employee_ID, value); }
		}
		XpCustomer_Employees fComm_Customer_Employee_ID;
		[Association(@"XpCustomer_CommunicationsReferencesXpCustomer_Employees")]
		public XpCustomer_Employees Comm_Customer_Employee_ID
		{
			get { return fComm_Customer_Employee_ID; }
			set { SetPropertyValue<XpCustomer_Employees>(nameof(Comm_Customer_Employee_ID), ref fComm_Customer_Employee_ID, value); }
		}
		DateTime? fComm_Date;
		public DateTime? Comm_Date
		{
			get { return fComm_Date; }
			set { SetPropertyValue<DateTime?>(nameof(Comm_Date), ref fComm_Date, value); }
		}
		string fComm_Type;
		[Size(25)]
		public string Comm_Type
		{
			get { return fComm_Type; }
			set { SetPropertyValue<string>(nameof(Comm_Type), ref fComm_Type, value); }
		}
		string fComm_Purpose;
		[Size(255)]
		public string Comm_Purpose
		{
			get { return fComm_Purpose; }
			set { SetPropertyValue<string>(nameof(Comm_Purpose), ref fComm_Purpose, value); }
		}
	}

}
