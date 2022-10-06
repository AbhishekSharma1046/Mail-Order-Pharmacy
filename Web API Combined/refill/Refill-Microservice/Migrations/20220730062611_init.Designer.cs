﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RefillApi.Models;

namespace RefillApi.Migrations
{
    [DbContext(typeof(RefillContext))]
    [Migration("20220730062611_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RefillApi.Models.RefillOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrugQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("Payment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RefillDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RefillDelivered")
                        .HasColumnType("bit");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TbRefillOrder");
                });
#pragma warning restore 612, 618
        }
    }
}
