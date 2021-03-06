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

	[Persistent(@"Tasks")]
	public partial class XpTasks : XPLiteObject
	{
		int fTask_ID;
		[Key(true)]
		public int Task_ID
		{
			get { return fTask_ID; }
			set { SetPropertyValue<int>(nameof(Task_ID), ref fTask_ID, value); }
		}
		XpEmployees fTask_Assigned_Employee_ID;
		[Association(@"XpTasksReferencesXpEmployees")]
		public XpEmployees Task_Assigned_Employee_ID
		{
			get { return fTask_Assigned_Employee_ID; }
			set { SetPropertyValue<XpEmployees>(nameof(Task_Assigned_Employee_ID), ref fTask_Assigned_Employee_ID, value); }
		}
		XpEmployees fTask_Owner_ID;
		[Association(@"XpTasksReferencesXpEmployees1")]
		public XpEmployees Task_Owner_ID
		{
			get { return fTask_Owner_ID; }
			set { SetPropertyValue<XpEmployees>(nameof(Task_Owner_ID), ref fTask_Owner_ID, value); }
		}
		XpCustomer_Employees fTask_Customer_Employee_ID;
		[Association(@"XpTasksReferencesXpCustomer_Employees")]
		public XpCustomer_Employees Task_Customer_Employee_ID
		{
			get { return fTask_Customer_Employee_ID; }
			set { SetPropertyValue<XpCustomer_Employees>(nameof(Task_Customer_Employee_ID), ref fTask_Customer_Employee_ID, value); }
		}
		string fTask_Subject;
		[Size(255)]
		public string Task_Subject
		{
			get { return fTask_Subject; }
			set { SetPropertyValue<string>(nameof(Task_Subject), ref fTask_Subject, value); }
		}
		string fTask_Description;
		[Size(SizeAttribute.Unlimited)]
		public string Task_Description
		{
			get { return fTask_Description; }
			set { SetPropertyValue<string>(nameof(Task_Description), ref fTask_Description, value); }
		}
		DateTime? fTask_Start_Date;
		public DateTime? Task_Start_Date
		{
			get { return fTask_Start_Date; }
			set { SetPropertyValue<DateTime?>(nameof(Task_Start_Date), ref fTask_Start_Date, value); }
		}
		DateTime? fTask_Due_Date;
		public DateTime? Task_Due_Date
		{
			get { return fTask_Due_Date; }
			set { SetPropertyValue<DateTime?>(nameof(Task_Due_Date), ref fTask_Due_Date, value); }
		}
		string fTask_Status;
		[Size(25)]
		public string Task_Status
		{
			get { return fTask_Status; }
			set { SetPropertyValue<string>(nameof(Task_Status), ref fTask_Status, value); }
		}
		int? fTask_Completion;
		[ColumnDbDefaultValue("((0))")]
		public int? Task_Completion
		{
			get { return fTask_Completion; }
			set { SetPropertyValue<int?>(nameof(Task_Completion), ref fTask_Completion, value); }
		}
		bool? fTask_Reminder;
		[ColumnDbDefaultValue("((0))")]
		public bool? Task_Reminder
		{
			get { return fTask_Reminder; }
			set { SetPropertyValue<bool?>(nameof(Task_Reminder), ref fTask_Reminder, value); }
		}
		DateTime? fTask_Reminder_Date;
		public DateTime? Task_Reminder_Date
		{
			get { return fTask_Reminder_Date; }
			set { SetPropertyValue<DateTime?>(nameof(Task_Reminder_Date), ref fTask_Reminder_Date, value); }
		}
		DateTime? fTask_Reminder_Time;
		public DateTime? Task_Reminder_Time
		{
			get { return fTask_Reminder_Time; }
			set { SetPropertyValue<DateTime?>(nameof(Task_Reminder_Time), ref fTask_Reminder_Time, value); }
		}
		int fTask_Priority;
		[ColumnDbDefaultValue("((0))")]
		public int Task_Priority
		{
			get { return fTask_Priority; }
			set { SetPropertyValue<int>(nameof(Task_Priority), ref fTask_Priority, value); }
		}
	}

}
