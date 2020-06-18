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

	[Persistent(@"Employees")]
	public partial class XpEmployees : XPLiteObject
	{
		int fEmployee_ID;
		[Key(true)]
		public int Employee_ID
		{
			get { return fEmployee_ID; }
			set { SetPropertyValue<int>(nameof(Employee_ID), ref fEmployee_ID, value); }
		}
		string fEmployee_First_Name;
		[Size(255)]
		public string Employee_First_Name
		{
			get { return fEmployee_First_Name; }
			set { SetPropertyValue<string>(nameof(Employee_First_Name), ref fEmployee_First_Name, value); }
		}
		string fEmployee_Last_Name;
		[Size(255)]
		public string Employee_Last_Name
		{
			get { return fEmployee_Last_Name; }
			set { SetPropertyValue<string>(nameof(Employee_Last_Name), ref fEmployee_Last_Name, value); }
		}
		string fEmployee_Full_Name;
		[Size(255)]
		public string Employee_Full_Name
		{
			get { return fEmployee_Full_Name; }
			set { SetPropertyValue<string>(nameof(Employee_Full_Name), ref fEmployee_Full_Name, value); }
		}
		string fEmployee_Prefix;
		[Size(5)]
		public string Employee_Prefix
		{
			get { return fEmployee_Prefix; }
			set { SetPropertyValue<string>(nameof(Employee_Prefix), ref fEmployee_Prefix, value); }
		}
		string fEmployee_Title;
		[Size(25)]
		public string Employee_Title
		{
			get { return fEmployee_Title; }
			set { SetPropertyValue<string>(nameof(Employee_Title), ref fEmployee_Title, value); }
		}
		byte[] fEmployee_Picture;
		[Size(SizeAttribute.Unlimited)]
		[MemberDesignTimeVisibility(true)]
		public byte[] Employee_Picture
		{
			get { return fEmployee_Picture; }
			set { SetPropertyValue<byte[]>(nameof(Employee_Picture), ref fEmployee_Picture, value); }
		}
		string fEmployee_Address;
		[Size(255)]
		public string Employee_Address
		{
			get { return fEmployee_Address; }
			set { SetPropertyValue<string>(nameof(Employee_Address), ref fEmployee_Address, value); }
		}
		string fEmployee_City;
		[Size(255)]
		public string Employee_City
		{
			get { return fEmployee_City; }
			set { SetPropertyValue<string>(nameof(Employee_City), ref fEmployee_City, value); }
		}
		XpStates fEmployee_State_ID;
		[Association(@"XpEmployeesReferencesXpStates")]
		public XpStates Employee_State_ID
		{
			get { return fEmployee_State_ID; }
			set { SetPropertyValue<XpStates>(nameof(Employee_State_ID), ref fEmployee_State_ID, value); }
		}
		int? fEmployee_Zipcode;
		[Indexed(Name = @"Employees$Employee_Zipcode")]
		[ColumnDbDefaultValue("((0))")]
		public int? Employee_Zipcode
		{
			get { return fEmployee_Zipcode; }
			set { SetPropertyValue<int?>(nameof(Employee_Zipcode), ref fEmployee_Zipcode, value); }
		}
		string fEmployee_Email;
		public string Employee_Email
		{
			get { return fEmployee_Email; }
			set { SetPropertyValue<string>(nameof(Employee_Email), ref fEmployee_Email, value); }
		}
		string fEmployee_Skype;
		public string Employee_Skype
		{
			get { return fEmployee_Skype; }
			set { SetPropertyValue<string>(nameof(Employee_Skype), ref fEmployee_Skype, value); }
		}
		string fEmployee_Mobile_Phone;
		[Size(25)]
		public string Employee_Mobile_Phone
		{
			get { return fEmployee_Mobile_Phone; }
			set { SetPropertyValue<string>(nameof(Employee_Mobile_Phone), ref fEmployee_Mobile_Phone, value); }
		}
		string fEmployee_Home_Phone;
		[Size(255)]
		public string Employee_Home_Phone
		{
			get { return fEmployee_Home_Phone; }
			set { SetPropertyValue<string>(nameof(Employee_Home_Phone), ref fEmployee_Home_Phone, value); }
		}
		DateTime? fEmployee_Birth_Date;
		public DateTime? Employee_Birth_Date
		{
			get { return fEmployee_Birth_Date; }
			set { SetPropertyValue<DateTime?>(nameof(Employee_Birth_Date), ref fEmployee_Birth_Date, value); }
		}
		DateTime? fEmployee_Hire_Date;
		public DateTime? Employee_Hire_Date
		{
			get { return fEmployee_Hire_Date; }
			set { SetPropertyValue<DateTime?>(nameof(Employee_Hire_Date), ref fEmployee_Hire_Date, value); }
		}
		XpDepartments fEmployee_Department_ID;
		[Association(@"XpEmployeesReferencesXpDepartments")]
		public XpDepartments Employee_Department_ID
		{
			get { return fEmployee_Department_ID; }
			set { SetPropertyValue<XpDepartments>(nameof(Employee_Department_ID), ref fEmployee_Department_ID, value); }
		}
		string fEmployee_Status;
		[Size(25)]
		public string Employee_Status
		{
			get { return fEmployee_Status; }
			set { SetPropertyValue<string>(nameof(Employee_Status), ref fEmployee_Status, value); }
		}
		string fEmployee_Personal_Profile;
		[Size(SizeAttribute.Unlimited)]
		public string Employee_Personal_Profile
		{
			get { return fEmployee_Personal_Profile; }
			set { SetPropertyValue<string>(nameof(Employee_Personal_Profile), ref fEmployee_Personal_Profile, value); }
		}
		int? fProbation_Reason;
		public int? Probation_Reason
		{
			get { return fProbation_Reason; }
			set { SetPropertyValue<int?>(nameof(Probation_Reason), ref fProbation_Reason, value); }
		}
		[Association(@"XpCustomer_CommunicationsReferencesXpEmployees")]
		public XPCollection<XpCustomer_Communications> Customer_Communicationss { get { return GetCollection<XpCustomer_Communications>(nameof(Customer_Communicationss)); } }
		[Association(@"XpEvaluationsReferencesXpEmployees")]
		public XPCollection<XpEvaluations> XpEvaluationsCollection { get { return GetCollection<XpEvaluations>(nameof(XpEvaluationsCollection)); } }
		[Association(@"XpEvaluationsReferencesXpEmployees1")]
		public XPCollection<XpEvaluations> XpEvaluationsCollection1 { get { return GetCollection<XpEvaluations>(nameof(XpEvaluationsCollection1)); } }
		[Association(@"XpOrdersReferencesXpEmployees")]
		public XPCollection<XpOrders> XpOrdersCollection { get { return GetCollection<XpOrders>(nameof(XpOrdersCollection)); } }
		[Association(@"XpProductsReferencesXpEmployees")]
		public XPCollection<XpProducts> XpProductsCollection { get { return GetCollection<XpProducts>(nameof(XpProductsCollection)); } }
		[Association(@"XpProductsReferencesXpEmployees1")]
		public XPCollection<XpProducts> XpProductsCollection1 { get { return GetCollection<XpProducts>(nameof(XpProductsCollection1)); } }
		[Association(@"XpQuotesReferencesXpEmployees")]
		public XPCollection<XpQuotes> XpQuotesCollection { get { return GetCollection<XpQuotes>(nameof(XpQuotesCollection)); } }
		[Association(@"XpTasksReferencesXpEmployees")]
		public XPCollection<XpTasks> XpTasksCollection { get { return GetCollection<XpTasks>(nameof(XpTasksCollection)); } }
		[Association(@"XpTasksReferencesXpEmployees1")]
		public XPCollection<XpTasks> XpTasksCollection1 { get { return GetCollection<XpTasks>(nameof(XpTasksCollection1)); } }
	}

}
