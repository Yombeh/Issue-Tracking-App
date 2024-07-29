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
    [Migration("20240701115128_ToDev")]
    partial class ToDev
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Issue_Tracking_App.Models.Applications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Applications");
                });

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

            modelBuilder.Entity("Issue_Tracking_App.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssigneeID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeverityID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.IssueCreated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DatePicker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("IssueCreated");
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

                    b.Property<string>("DateTimePicker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("DatePicker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstimateTime")
                        .HasColumnType("int");

                    b.Property<int>("IssuesID")
                        .HasColumnType("int");

                    b.Property<int>("SeverityID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

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

            modelBuilder.Entity("Issue_Tracking_App.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IssueCreatedID")
                        .HasColumnType("int");

                    b.Property<int>("TestersID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Testers", b =>
                {
                    b.Property<int>("TesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TesterId"));

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("testerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TesterId");

                    b.HasIndex("TestId");

                    b.ToTable("Tester");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Assignee", b =>
                {
                    b.HasOne("Issue_Tracking_App.Models.Solved", null)
                        .WithMany("Assignees")
                        .HasForeignKey("SolvedIssueNumber");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.IssueCreated", b =>
                {
                    b.HasOne("Issue_Tracking_App.Models.Test", null)
                        .WithMany("IssueCreateds")
                        .HasForeignKey("TestId");
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

            modelBuilder.Entity("Issue_Tracking_App.Models.Testers", b =>
                {
                    b.HasOne("Issue_Tracking_App.Models.Test", null)
                        .WithMany("Testers")
                        .HasForeignKey("TestId");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Solved", b =>
                {
                    b.Navigation("Assignees");

                    b.Navigation("Issues");

                    b.Navigation("Severities");

                    b.Navigation("Statuses");
                });

            modelBuilder.Entity("Issue_Tracking_App.Models.Test", b =>
                {
                    b.Navigation("IssueCreateds");

                    b.Navigation("Testers");
                });
#pragma warning restore 612, 618
        }
    }
}
