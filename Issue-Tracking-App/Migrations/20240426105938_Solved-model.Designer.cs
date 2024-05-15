﻿// <auto-generated />
using System;
using Issue_Tracking_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240426105938_Solved-model")]
    partial class Solvedmodel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Issue_Tracking_App.Models.Assignee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssigneeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SolvedIssueNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SolvedIssueNumber");

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Issues", b =>
                {
                    b.Property<int>("IssueNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IssueNumber"));

                    b.Property<int>("AssigneeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstimateTime")
                        .HasColumnType("int");

                    b.Property<int>("SeverityID")
                        .HasColumnType("int");

                    b.Property<int?>("SolvedIssueNumber")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IssueNumber");

                    b.HasIndex("SolvedIssueNumber");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Severity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SeverityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SolvedIssueNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SolvedIssueNumber");

                    b.ToTable("Severities");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Solved", b =>
                {
                    b.Property<int>("IssueNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IssueNumber"));

                    b.Property<int>("AssigneeID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstimateTime")
                        .HasColumnType("int");

                    b.Property<int>("SeverityID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IssueNumber");

                    b.ToTable("Solveds");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SolvedIssueNumber")
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SolvedIssueNumber");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Assignee", b =>
                {
                    b.HasOne("Issue_Tracking_App.Models.Solved", null)
                        .WithMany("Assignees")
                        .HasForeignKey("SolvedIssueNumber");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Issues", b =>
                {
                    b.HasOne("Issue_Tracking_App.Models.Solved", null)
                        .WithMany("Issues")
                        .HasForeignKey("SolvedIssueNumber");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Severity", b =>
                {
                    b.HasOne("Issue_Tracking_App.Models.Solved", null)
                        .WithMany("Severities")
                        .HasForeignKey("SolvedIssueNumber");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Status", b =>
                {
                    b.HasOne("Issue_Tracking_App.Models.Solved", null)
                        .WithMany("Statuses")
                        .HasForeignKey("SolvedIssueNumber");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Solved", b =>
                {
                    b.Navigation("Assignees");

                    b.Navigation("Issues");

                    b.Navigation("Severities");

                    b.Navigation("Statuses");
                });
#pragma warning restore 612, 618
        }
    }
}
