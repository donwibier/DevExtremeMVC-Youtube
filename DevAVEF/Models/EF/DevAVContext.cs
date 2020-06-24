//-----------------------------------------------------------------------
// <copyright file="C:\git\DevExtremeMVC-YouTube\DevAVEF\DevAVEF\Models\EF\DevAVContext.cs" company="">
//     Author: Don Wibier
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace DevAVEF.Models.EF
{
    public partial class DevAVContext : DbContext
    {
        public DevAVContext()
        {
        }

        public DevAVContext(DbContextOptions<DevAVContext> options) : base(options)
        {
        }

        public virtual DbSet<Crests> Crests { get; set; }

        public virtual DbSet<CustomerCommunications> CustomerCommunications { get; set; }

        public virtual DbSet<CustomerEmployees> CustomerEmployees { get; set; }

        public virtual DbSet<CustomerStoreLocations> CustomerStoreLocations { get; set; }

        public virtual DbSet<Customers> Customers { get; set; }

        public virtual DbSet<Departments> Departments { get; set; }

        public virtual DbSet<Employees> Employees { get; set; }

        public virtual DbSet<Evaluations> Evaluations { get; set; }

        public virtual DbSet<OrderItems> OrderItems { get; set; }

        public virtual DbSet<Orders> Orders { get; set; }

        public virtual DbSet<PasteErrors> PasteErrors { get; set; }

        public virtual DbSet<Probation> Probation { get; set; }

        public virtual DbSet<ProductCatalogs> ProductCatalogs { get; set; }

        public virtual DbSet<ProductImages> ProductImages { get; set; }

        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<QuoteItems> QuoteItems { get; set; }

        public virtual DbSet<Quotes> Quotes { get; set; }

        public virtual DbSet<States> States { get; set; }

        public virtual DbSet<Tasks> Tasks { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=DevAV;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crests>(entity =>
            {
                entity.HasKey(e => e.CrestId).HasName("Crests$PrimaryKey");

                entity.Property(e => e.CrestId).HasColumnName("Crest_ID");

                entity.Property(e => e.CityName).HasColumnName("City_Name").HasMaxLength(255);

                entity.Property(e => e.CrestImage).HasColumnName("Crest_Image");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<CustomerCommunications>(entity =>
            {
                entity.HasKey(e => e.CommId).HasName("Customer_Communications$PrimaryKey");

                entity.ToTable("Customer_Communications");

                entity.HasIndex(e => e.CommCustomerEmployeeId).HasName("Customer_Communications$Customer_Employee_ID");

                entity.HasIndex(e => e.CommEmployeeId).HasName("Customer_Communications$Employee_ID");

                entity.Property(e => e.CommId).HasColumnName("Comm_ID");

                entity.Property(e => e.CommCustomerEmployeeId).HasColumnName("Comm_Customer_Employee_ID");

                entity.Property(e => e.CommDate).HasColumnName("Comm_Date").HasColumnType("datetime2(0)");

                entity.Property(e => e.CommEmployeeId).HasColumnName("Comm_Employee_ID");

                entity.Property(e => e.CommPurpose).HasColumnName("Comm_Purpose").HasMaxLength(255);

                entity.Property(e => e.CommType).HasColumnName("Comm_Type").HasMaxLength(25);

                entity.HasOne(d => d.CommCustomerEmployee)
                    .WithMany(p => p.CustomerCommunications)
                    .HasForeignKey(d => d.CommCustomerEmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Customer_Communications_Customer_Employees");

                entity.HasOne(d => d.CommEmployee)
                    .WithMany(p => p.CustomerCommunications)
                    .HasForeignKey(d => d.CommEmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Customer_Communications_Employees");
            });

            modelBuilder.Entity<CustomerEmployees>(entity =>
            {
                entity.HasKey(e => e.CustomerEmployeeId).HasName("Customer_Employees$PrimaryKey");

                entity.ToTable("Customer_Employees");

                entity.HasIndex(e => e.CustomerEmployeePrefix).HasName("Customer_Employees$Zipcode");

                entity.HasIndex(e => e.CustomerId).HasName("Customer_Employees$Customer_ID");

                entity.HasIndex(e => e.CustomerStoreId).HasName("Customer_Employees$Customer_Store_ID");

                entity.Property(e => e.CustomerEmployeeId).HasColumnName("Customer_Employee_ID");

                entity.Property(e => e.CustomerEmployeeEmail).HasColumnName("Customer_Employee_Email").HasMaxLength(100);

                entity.Property(e => e.CustomerEmployeeFirstName)
                    .HasColumnName("Customer_Employee_First_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerEmployeeFullName)
                    .HasColumnName("Customer_Employee_Full_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerEmployeeLastName)
                    .HasColumnName("Customer_Employee_Last_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerEmployeeMobilePhone)
                    .HasColumnName("Customer_Employee_Mobile_Phone")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerEmployeePicture).HasColumnName("Customer_Employee_Picture");

                entity.Property(e => e.CustomerEmployeePosition)
                    .HasColumnName("Customer_Employee_Position")
                    .HasMaxLength(25);

                entity.Property(e => e.CustomerEmployeePrefix)
                    .HasColumnName("Customer_Employee_Prefix")
                    .HasMaxLength(15);

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerPurchaseAuthority)
                    .HasColumnName("Customer_Purchase_Authority")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerStoreId).HasColumnName("Customer_Store_ID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerEmployees)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Customer_Employees_Customers");

                entity.HasOne(d => d.CustomerStore)
                    .WithMany(p => p.CustomerEmployees)
                    .HasForeignKey(d => d.CustomerStoreId)
                    .HasConstraintName("FK_Customer_Employees_Customer_Store_Locations");
            });

            modelBuilder.Entity<CustomerStoreLocations>(entity =>
            {
                entity.HasKey(e => e.CustomerStoreId).HasName("Customer_Store_Locations$PrimaryKey");

                entity.ToTable("Customer_Store_Locations");

                entity.HasIndex(e => e.CrestId).HasName("Customer_Store_Locations$Crest_ID");

                entity.HasIndex(e => e.CustomerId).HasName("Customer_Store_Locations$Customer_ID");

                entity.HasIndex(e => e.CustomerStoreZipcode).HasName("Customer_Store_Locations$Customer_Store_Zipcode");

                entity.Property(e => e.CustomerStoreId).HasColumnName("Customer_Store_ID");

                entity.Property(e => e.CrestId).HasColumnName("Crest_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerStoreAddress).HasColumnName("Customer_Store_Address").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreAnnualSales)
                    .HasColumnName("Customer_Store_Annual_Sales")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerStoreCity).HasColumnName("Customer_Store_City").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreFax).HasColumnName("Customer_Store_Fax").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreLocation).HasColumnName("Customer_Store_Location").HasMaxLength(255);

                entity.Property(e => e.CustomerStorePhone).HasColumnName("Customer_Store_Phone").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreSquareFootage)
                    .HasColumnName("Customer_Store_Square_Footage")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerStoreState).HasColumnName("Customer_Store_State");

                entity.Property(e => e.CustomerStoreTotalEmployees)
                    .HasColumnName("Customer_Store_Total_Employees")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerStoreZipcode)
                    .HasColumnName("Customer_Store_Zipcode")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Crest)
                    .WithMany(p => p.CustomerStoreLocations)
                    .HasForeignKey(d => d.CrestId)
                    .HasConstraintName("FK_Customer_Store_Locations_Crests");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerStoreLocations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Customer_Store_Locations_Customers");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId).HasName("Customers$PrimaryKey");

                entity.HasIndex(e => e.CustomerBillingZipcode).HasName("Customers$Customer_Billing_Zipcode");

                entity.HasIndex(e => e.CustomerZipcode).HasName("Customers$Customer_Zipcode");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerAddress).HasColumnName("Customer_Address").HasMaxLength(255);

                entity.Property(e => e.CustomerAnnualRevenue)
                    .HasColumnName("Customer_Annual_Revenue")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerBillingAddress)
                    .HasColumnName("Customer_Billing_Address")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerBillingCity).HasColumnName("Customer_Billing_City").HasMaxLength(255);

                entity.Property(e => e.CustomerBillingState).HasColumnName("Customer_Billing_State");

                entity.Property(e => e.CustomerBillingZipcode)
                    .HasColumnName("Customer_Billing_Zipcode")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerCity).HasColumnName("Customer_CIty").HasMaxLength(50);

                entity.Property(e => e.CustomerFax).HasColumnName("Customer_Fax").HasMaxLength(25);

                entity.Property(e => e.CustomerLogo).HasColumnName("Customer_Logo");

                entity.Property(e => e.CustomerName).HasColumnName("Customer_Name").HasMaxLength(255);

                entity.Property(e => e.CustomerPhone).HasColumnName("Customer_Phone").HasMaxLength(25);

                entity.Property(e => e.CustomerProfile).HasColumnName("Customer_Profile");

                entity.Property(e => e.CustomerState).HasColumnName("Customer_State");

                entity.Property(e => e.CustomerStatus).HasColumnName("Customer_Status").HasMaxLength(25);

                entity.Property(e => e.CustomerTotalEmployees)
                    .HasColumnName("Customer_Total_Employees")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerTotalStores)
                    .HasColumnName("Customer_Total_Stores")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerWebsite).HasColumnName("Customer_Website").HasMaxLength(100);

                entity.Property(e => e.CustomerZipcode).HasColumnName("Customer_Zipcode").HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CustomerStateNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerState)
                    .HasConstraintName("FK_Customers_States");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId).HasName("Departments$PrimaryKey");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");

                entity.Property(e => e.DepartmentName).HasColumnName("Department_Name").HasMaxLength(25);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId).HasName("Employees$PrimaryKey");

                entity.HasIndex(e => e.EmployeeDepartmentId).HasName("Employees$DepartmentsEmployees");

                entity.HasIndex(e => e.EmployeeZipcode).HasName("Employees$Employee_Zipcode");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.EmployeeAddress).HasColumnName("Employee_Address").HasMaxLength(255);

                entity.Property(e => e.EmployeeBirthDate)
                    .HasColumnName("Employee_Birth_Date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.EmployeeCity).HasColumnName("Employee_City").HasMaxLength(255);

                entity.Property(e => e.EmployeeDepartmentId).HasColumnName("Employee_Department_ID");

                entity.Property(e => e.EmployeeEmail).HasColumnName("Employee_Email").HasMaxLength(100);

                entity.Property(e => e.EmployeeFirstName).HasColumnName("Employee_First_Name").HasMaxLength(255);

                entity.Property(e => e.EmployeeFullName).HasColumnName("Employee_Full_Name").HasMaxLength(255);

                entity.Property(e => e.EmployeeHireDate)
                    .HasColumnName("Employee_Hire_Date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.EmployeeHomePhone).HasColumnName("Employee_Home_Phone").HasMaxLength(255);

                entity.Property(e => e.EmployeeLastName).HasColumnName("Employee_Last_Name").HasMaxLength(255);

                entity.Property(e => e.EmployeeMobilePhone).HasColumnName("Employee_Mobile_Phone").HasMaxLength(25);

                entity.Property(e => e.EmployeePersonalProfile).HasColumnName("Employee_Personal_Profile");

                entity.Property(e => e.EmployeePicture).HasColumnName("Employee_Picture");

                entity.Property(e => e.EmployeePrefix).HasColumnName("Employee_Prefix").HasMaxLength(5);

                entity.Property(e => e.EmployeeSkype).HasColumnName("Employee_Skype").HasMaxLength(100);

                entity.Property(e => e.EmployeeStateId).HasColumnName("Employee_State_ID");

                entity.Property(e => e.EmployeeStatus).HasColumnName("Employee_Status").HasMaxLength(25);

                entity.Property(e => e.EmployeeTitle).HasColumnName("Employee_Title").HasMaxLength(25);

                entity.Property(e => e.EmployeeZipcode).HasColumnName("Employee_Zipcode").HasDefaultValueSql("((0))");

                entity.Property(e => e.ProbationReason).HasColumnName("Probation_Reason");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.EmployeeDepartment)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeDepartmentId)
                    .HasConstraintName("Employees$DepartmentsEmployees");

                entity.HasOne(d => d.EmployeeState)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeStateId)
                    .HasConstraintName("FK_Employees_States");
            });

            modelBuilder.Entity<Evaluations>(entity =>
            {
                entity.HasKey(e => e.NoteId).HasName("Evaluations$PrimaryKey");

                entity.HasIndex(e => e.CreatedById).HasName("Evaluations$Created_By_ID");

                entity.HasIndex(e => e.EmployeeId).HasName("Evaluations$Employee_ID");

                entity.Property(e => e.NoteId).HasColumnName("Note_ID");

                entity.Property(e => e.CreatedById).HasColumnName("Created_By_ID");

                entity.Property(e => e.CreatedOn).HasColumnName("Created_On").HasColumnType("datetime2(0)");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Subject).HasMaxLength(255);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.EvaluationsCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Evaluations_CreatedBy");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EvaluationsEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Evaluations_Employees");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId).HasName("Order_Items$PrimaryKey");

                entity.ToTable("Order_Items");

                entity.HasIndex(e => e.OrderId).HasName("Order_Items$Order_ID");

                entity.Property(e => e.OrderItemId).HasColumnName("Order_Item_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.OrderItemDiscount)
                    .HasColumnName("Order_Item_Discount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderItemProductId).HasColumnName("Order_Item_Product_ID");

                entity.Property(e => e.OrderItemProductPrice)
                    .HasColumnName("Order_Item_Product_Price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderItemProductUnits)
                    .HasColumnName("Order_Item_Product_Units")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderItemTotal)
                    .HasColumnName("Order_Item_Total")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Order_Items_Orders");

                entity.HasOne(d => d.OrderItemProduct)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderItemProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Order_Items_Products");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("Orders$PrimaryKey");

                entity.HasIndex(e => e.OrderCustomerId).HasName("Orders$Order_Customer_ID");

                entity.HasIndex(e => e.OrderCustomerLocationId).HasName("Orders$Order_Customer_Location_ID");

                entity.HasIndex(e => e.OrderEmployeeId).HasName("Orders$Order_Employee_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.OrderComments).HasColumnName("Order_Comments").HasMaxLength(255);

                entity.Property(e => e.OrderCustomerId).HasColumnName("Order_Customer_ID");

                entity.Property(e => e.OrderCustomerLocationId).HasColumnName("Order_Customer_Location_ID");

                entity.Property(e => e.OrderDate).HasColumnName("Order_Date").HasColumnType("datetime2(0)");

                entity.Property(e => e.OrderEmployeeId).HasColumnName("Order_Employee_ID");

                entity.Property(e => e.OrderInvoiceNumber)
                    .HasColumnName("Order_Invoice_Number")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderPoNumber).HasColumnName("Order_PO_Number").HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderSaleAmount)
                    .HasColumnName("Order_Sale_Amount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderShipDate).HasColumnName("Order_Ship_Date").HasColumnType("datetime2(0)");

                entity.Property(e => e.OrderShipMethod).HasColumnName("Order_Ship_Method").HasMaxLength(15);

                entity.Property(e => e.OrderShippingAmount)
                    .HasColumnName("Order_Shipping_Amount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderTerms).HasColumnName("Order_Terms").HasMaxLength(15);

                entity.Property(e => e.OrderTotalAmount)
                    .HasColumnName("Order_Total_Amount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.OrderCustomer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderCustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.OrderEmployee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderEmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Employees");
            });

            modelBuilder.Entity<PasteErrors>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Paste Errors");

                entity.Property(e => e.CrestId).HasColumnName("Crest_ID").HasMaxLength(255);

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreAddress).HasColumnName("Customer_Store_Address").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreAnnualSales)
                    .HasColumnName("Customer_Store_Annual_Sales")
                    .HasColumnType("money");

                entity.Property(e => e.CustomerStoreCity).HasColumnName("Customer_Store_City").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreFax).HasColumnName("Customer_Store_Fax").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreId).HasColumnName("Customer_Store_ID");

                entity.Property(e => e.CustomerStoreLocation).HasColumnName("Customer_Store_Location").HasMaxLength(255);

                entity.Property(e => e.CustomerStorePhone).HasColumnName("Customer_Store_Phone").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreSquareFootage).HasColumnName("Customer_Store_Square_Footage");

                entity.Property(e => e.CustomerStoreState).HasColumnName("Customer_Store_State").HasMaxLength(255);

                entity.Property(e => e.CustomerStoreTotalEmployees).HasColumnName("Customer_Store_Total_Employees");

                entity.Property(e => e.CustomerStoreZipcode).HasColumnName("Customer_Store_Zipcode");
            });

            modelBuilder.Entity<Probation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Reason).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductCatalogs>(entity =>
            {
                entity.HasKey(e => e.CatalogId).HasName("Product_Catalogs$PrimaryKey");

                entity.ToTable("Product_Catalogs");

                entity.HasIndex(e => e.ProductId).HasName("Product_Catalogs$Product_ID");

                entity.Property(e => e.CatalogId).HasColumnName("Catalog_ID");

                entity.Property(e => e.CatalogPdf).HasColumnName("Catalog_PDF");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCatalogs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_Catalogs_Products");
            });

            modelBuilder.Entity<ProductImages>(entity =>
            {
                entity.HasKey(e => e.ImageId).HasName("Product_Images$PrimaryKey");

                entity.ToTable("Product_Images");

                entity.HasIndex(e => e.ProductId).HasName("Product_Images$Product_ID");

                entity.Property(e => e.ImageId).HasColumnName("Image_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductImage).HasColumnName("Product_Image");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_Images_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("Products$PrimaryKey");

                entity.HasIndex(e => e.ProductEngineerId).HasName("Products$Product_Engineer_ID");

                entity.HasIndex(e => e.ProductSupportId).HasName("Products$Product_Support_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductAvailable).HasColumnName("Product_Available").HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductBackorder).HasColumnName("Product_Backorder").HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductBarcode).HasColumnName("Product_Barcode");

                entity.Property(e => e.ProductCategory).HasColumnName("Product_Category").HasMaxLength(15);

                entity.Property(e => e.ProductConsumerRating)
                    .HasColumnName("Product_Consumer_Rating")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductCost)
                    .HasColumnName("Product_Cost")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductCurrentInventory)
                    .HasColumnName("Product_Current_Inventory")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductDescription).HasColumnName("Product_Description");

                entity.Property(e => e.ProductEngineerId).HasColumnName("Product_Engineer_ID");

                entity.Property(e => e.ProductImage).HasColumnName("Product_Image");

                entity.Property(e => e.ProductManufacturing)
                    .HasColumnName("Product_Manufacturing")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductName).HasColumnName("Product_Name").HasMaxLength(50);

                entity.Property(e => e.ProductPrimaryImage).HasColumnName("Product_Primary_Image");

                entity.Property(e => e.ProductProductionStart)
                    .HasColumnName("Product_Production_Start")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.ProductRetailPrice)
                    .HasColumnName("Product_Retail_Price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductSalePrice)
                    .HasColumnName("Product_Sale_Price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductSupportId).HasColumnName("Product_Support_ID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ProductEngineer)
                    .WithMany(p => p.ProductsProductEngineer)
                    .HasForeignKey(d => d.ProductEngineerId)
                    .HasConstraintName("FK_Products_Engineers");

                entity.HasOne(d => d.ProductSupport)
                    .WithMany(p => p.ProductsProductSupport)
                    .HasForeignKey(d => d.ProductSupportId)
                    .HasConstraintName("FK_Products_Supporters");
            });

            modelBuilder.Entity<QuoteItems>(entity =>
            {
                entity.HasKey(e => e.QuoteItemId).HasName("Quote_Items$PrimaryKey");

                entity.ToTable("Quote_Items");

                entity.HasIndex(e => e.QuoteId).HasName("Quote_Items$Order_ID");

                entity.Property(e => e.QuoteItemId).HasColumnName("Quote_Item_ID");

                entity.Property(e => e.QuoteId).HasColumnName("Quote_ID");

                entity.Property(e => e.QuoteItemDiscount)
                    .HasColumnName("Quote_Item_Discount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuoteItemProductId).HasColumnName("Quote_Item_Product_ID");

                entity.Property(e => e.QuoteItemProductPrice)
                    .HasColumnName("Quote_Item_Product_Price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuoteItemProductUnits)
                    .HasColumnName("Quote_Item_Product_Units")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuoteItemTotal)
                    .HasColumnName("Quote_Item_Total")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.QuoteItems)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Quote_Items_Quotes");

                entity.HasOne(d => d.QuoteItemProduct)
                    .WithMany(p => p.QuoteItems)
                    .HasForeignKey(d => d.QuoteItemProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Quote_Items_Products");
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.HasKey(e => e.QuoteId).HasName("Quotes$PrimaryKey");

                entity.HasIndex(e => e.QuoteCustomerId).HasName("Quotes$Order_Customer_ID");

                entity.HasIndex(e => e.QuoteCustomerLocationId).HasName("Quotes$Order_Customer_Location_ID");

                entity.HasIndex(e => e.QuoteEmployeeId).HasName("Quotes$Order_Employee_ID");

                entity.Property(e => e.QuoteId).HasColumnName("Quote_ID");

                entity.Property(e => e.OrderTotal)
                    .HasColumnName("Order_Total")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuoteCustomerId).HasColumnName("Quote_Customer_ID");

                entity.Property(e => e.QuoteCustomerLocationId).HasColumnName("Quote_Customer_Location_ID");

                entity.Property(e => e.QuoteDate).HasColumnName("Quote_Date").HasColumnType("datetime2(0)");

                entity.Property(e => e.QuoteEmployeeId).HasColumnName("Quote_Employee_ID");

                entity.Property(e => e.QuoteNumber).HasColumnName("Quote_Number").HasDefaultValueSql("((0))");

                entity.Property(e => e.QuoteOpportunity).HasColumnName("Quote_Opportunity");

                entity.Property(e => e.QuoteShippingAmount)
                    .HasColumnName("Quote_Shipping_Amount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuoteSubTotal)
                    .HasColumnName("Quote_SubTotal")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuoteTotal).HasColumnName("Quote_Total").HasColumnType("money");

                entity.HasOne(d => d.QuoteCustomer)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.QuoteCustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Quotes_Customers");

                entity.HasOne(d => d.QuoteEmployee)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.QuoteEmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Quotes_Employees");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.SateId).HasName("States$PrimaryKey");

                entity.Property(e => e.SateId).HasColumnName("Sate_ID");

                entity.Property(e => e.Flag24px).HasColumnName("Flag_24px");

                entity.Property(e => e.Flag48px).HasColumnName("Flag_48px");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StateLong).HasColumnName("State_Long").HasMaxLength(255);

                entity.Property(e => e.StateShort).HasColumnName("State_Short").HasMaxLength(2);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId).HasName("Tasks$PrimaryKey");

                entity.HasIndex(e => e.TaskAssignedEmployeeId).HasName("Tasks$Task_Employee_ID");

                entity.HasIndex(e => e.TaskCustomerEmployeeId).HasName("Tasks$Task_Customer_Employee_ID");

                entity.HasIndex(e => e.TaskOwnerId).HasName("Tasks$Task_Owner_ID");

                entity.Property(e => e.TaskId).HasColumnName("Task_ID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TaskAssignedEmployeeId).HasColumnName("Task_Assigned_Employee_ID");

                entity.Property(e => e.TaskCompletion).HasColumnName("Task_Completion").HasDefaultValueSql("((0))");

                entity.Property(e => e.TaskCustomerEmployeeId).HasColumnName("Task_Customer_Employee_ID");

                entity.Property(e => e.TaskDescription).HasColumnName("Task_Description");

                entity.Property(e => e.TaskDueDate).HasColumnName("Task_Due_Date").HasColumnType("datetime2(0)");

                entity.Property(e => e.TaskOwnerId).HasColumnName("Task_Owner_ID");

                entity.Property(e => e.TaskPriority).HasColumnName("Task_Priority");

                entity.Property(e => e.TaskReminder).HasColumnName("Task_Reminder").HasDefaultValueSql("((0))");

                entity.Property(e => e.TaskReminderDate)
                    .HasColumnName("Task_Reminder_Date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.TaskReminderTime)
                    .HasColumnName("Task_Reminder_Time")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.TaskStartDate).HasColumnName("Task_Start_Date").HasColumnType("datetime2(0)");

                entity.Property(e => e.TaskStatus).HasColumnName("Task_Status").HasMaxLength(25);

                entity.Property(e => e.TaskSubject).HasColumnName("Task_Subject").HasMaxLength(255);

                entity.HasOne(d => d.TaskAssignedEmployee)
                    .WithMany(p => p.TasksTaskAssignedEmployee)
                    .HasForeignKey(d => d.TaskAssignedEmployeeId)
                    .HasConstraintName("FK_Tasks_Assigned");

                entity.HasOne(d => d.TaskCustomerEmployee)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskCustomerEmployeeId)
                    .HasConstraintName("FK_Tasks_Customer_Employees");

                entity.HasOne(d => d.TaskOwner)
                    .WithMany(p => p.TasksTaskOwner)
                    .HasForeignKey(d => d.TaskOwnerId)
                    .HasConstraintName("FK_Tasks_Owners");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
