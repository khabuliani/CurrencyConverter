﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValuteConverter.EntityFrameworkCore;

#nullable disable

namespace ValuteConverter.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ValuteConverterDbContext))]
    [Migration("20240801021455_Transaction_fixed")]
    partial class Transaction_fixed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ValuteConverter.Domain.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("RecomendatorPersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Clients", "CurrencyDB");
                });

            modelBuilder.Entity("ValuteConverter.Domain.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("NameLatin")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Currencies", "CurrencyDB");
                });

            modelBuilder.Entity("ValuteConverter.Domain.Models.CurrencyCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BuyingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId")
                        .IsUnique();

                    b.ToTable("CurrencyCourses", "CurrencyDB");
                });

            modelBuilder.Entity("ValuteConverter.Domain.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("ToBuy")
                        .HasColumnType("MONEY");

                    b.Property<int>("ToBuyCurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("ToSell")
                        .HasColumnType("MONEY");

                    b.Property<int>("ToSellCurrencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorClientId");

                    b.HasIndex("ToBuyCurrencyId");

                    b.HasIndex("ToSellCurrencyId");

                    b.ToTable("Transactions", "CurrencyDB");
                });

            modelBuilder.Entity("ValuteConverter.Domain.Models.CurrencyCourse", b =>
                {
                    b.HasOne("ValuteConverter.Domain.Models.Currency", "Currency")
                        .WithOne()
                        .HasForeignKey("ValuteConverter.Domain.Models.CurrencyCourse", "CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("ValuteConverter.Domain.Models.Transaction", b =>
                {
                    b.HasOne("ValuteConverter.Domain.Models.Client", "CreatorClient")
                        .WithMany()
                        .HasForeignKey("CreatorClientId");

                    b.HasOne("ValuteConverter.Domain.Models.Currency", "ToBuyCurrency")
                        .WithMany()
                        .HasForeignKey("ToBuyCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ValuteConverter.Domain.Models.Currency", "ToSellCurrency")
                        .WithMany()
                        .HasForeignKey("ToSellCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatorClient");

                    b.Navigation("ToBuyCurrency");

                    b.Navigation("ToSellCurrency");
                });
#pragma warning restore 612, 618
        }
    }
}
