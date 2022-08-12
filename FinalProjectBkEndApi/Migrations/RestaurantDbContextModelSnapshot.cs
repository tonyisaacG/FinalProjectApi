﻿// <auto-generated />
using System;
using FinalProjectBkEndApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProjectBkEndApi.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    partial class RestaurantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Categories", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Expenses", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date")
                        .HasColumnType("date");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.ExpensesDetails", b =>
                {
                    b.Property<int>("item_id")
                        .HasColumnType("int");

                    b.Property<int>("expenses_id")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("item_id", "expenses_id");

                    b.HasIndex("expenses_id");

                    b.ToTable("ExpensesDetails");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Items", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("expectedQuantityInDay")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("priceKilo")
                        .HasColumnType("money");

                    b.Property<int>("totalQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressClient")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("nameClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notes")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("orderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("orderType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("totalPrice")
                        .HasColumnType("money");

                    b.Property<int?>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.OrderDetails", b =>
                {
                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<string>("desription")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("priceMeal")
                        .HasColumnType("money");

                    b.Property<int>("quantityMeal")
                        .HasColumnType("int");

                    b.HasKey("product_id", "order_id");

                    b.HasIndex("order_id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Products", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("catergory_id")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("money");

                    b.HasKey("id");

                    b.HasIndex("catergory_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.PurchasesConsumption", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("getdate()");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("money");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vendorName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("PurchasesConsumptions");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.PurchasesConsumptionDetails", b =>
                {
                    b.Property<int>("item_id")
                        .HasColumnType("int");

                    b.Property<int>("purchases_id")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("money");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("item_id", "purchases_id");

                    b.HasIndex("purchases_id");

                    b.ToTable("PurchasesDetails");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("permission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Role_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("Role_id");

                    b.HasIndex("phone")
                        .IsUnique()
                        .HasFilter("[phone] IS NOT NULL");

                    b.HasIndex("password", "username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.ExpensesDetails", b =>
                {
                    b.HasOne("FinalProjectBkEndApi.Models.Expenses", "Expenses")
                        .WithMany("ExpensesDetails")
                        .HasForeignKey("expenses_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectBkEndApi.Models.Items", "Items")
                        .WithMany()
                        .HasForeignKey("item_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expenses");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Order", b =>
                {
                    b.HasOne("FinalProjectBkEndApi.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.OrderDetails", b =>
                {
                    b.HasOne("FinalProjectBkEndApi.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectBkEndApi.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Products", b =>
                {
                    b.HasOne("FinalProjectBkEndApi.Models.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("catergory_id");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.PurchasesConsumptionDetails", b =>
                {
                    b.HasOne("FinalProjectBkEndApi.Models.Items", "Items")
                        .WithMany("PurchasesDetails")
                        .HasForeignKey("item_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectBkEndApi.Models.PurchasesConsumption", "PurchasesConsumption")
                        .WithMany("PurchasesDetails")
                        .HasForeignKey("purchases_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Items");

                    b.Navigation("PurchasesConsumption");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.User", b =>
                {
                    b.HasOne("FinalProjectBkEndApi.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Role_id");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Expenses", b =>
                {
                    b.Navigation("ExpensesDetails");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Items", b =>
                {
                    b.Navigation("PurchasesDetails");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.PurchasesConsumption", b =>
                {
                    b.Navigation("PurchasesDetails");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FinalProjectBkEndApi.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
