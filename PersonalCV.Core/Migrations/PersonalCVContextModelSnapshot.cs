﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalCV.Core.Context;

namespace PersonalCV.Core.Migrations
{
    [DbContext(typeof(PersonalCVContext))]
    partial class PersonalCVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalCV.Core.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Phone")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasMaxLength(4500)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.HostPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("HostPlans");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.SiteInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SiteInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = 13,
                            Value = "Mohammadev@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            Key = 14,
                            Value = "MamaliDev871374"
                        });
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.SkillDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Percent")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillDetails");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("MainImage")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("MainSiteUrl")
                        .IsRequired()
                        .HasMaxLength(3600)
                        .HasColumnType("nvarchar(3600)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SiteUrlForPreview")
                        .HasMaxLength(3600)
                        .HasColumnType("nvarchar(3600)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1600)
                        .HasColumnType("nvarchar(1600)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.TemplateGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.HasKey("Id");

                    b.ToTable("TemplateGroups");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.SkillDetail", b =>
                {
                    b.HasOne("PersonalCV.Core.Entities.Skill", "Skill")
                        .WithMany("SkillDetails")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.Template", b =>
                {
                    b.HasOne("PersonalCV.Core.Entities.TemplateGroup", "TemplateGroup")
                        .WithMany("Templates")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TemplateGroup");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.Skill", b =>
                {
                    b.Navigation("SkillDetails");
                });

            modelBuilder.Entity("PersonalCV.Core.Entities.TemplateGroup", b =>
                {
                    b.Navigation("Templates");
                });
#pragma warning restore 612, 618
        }
    }
}
