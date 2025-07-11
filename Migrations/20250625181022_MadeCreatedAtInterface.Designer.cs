﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPGMakerAPI.Data;

#nullable disable

namespace RPGMakerAPI.Migrations
{
    [DbContext(typeof(RPGMakerContext))]
    [Migration("20250625181022_MadeCreatedAtInterface")]
    partial class MadeCreatedAtInterface
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AbilityTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PointCost")
                        .HasColumnType("int");

                    b.Property<int>("PointsAllocated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbilityTemplateId");

                    b.HasIndex("CharacterId");

                    b.ToTable("AbilityInstances");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityTag", b =>
                {
                    b.Property<int>("AbilityTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("AbilityTemplateId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("AbilityTags");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PointCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("AbilityTemplates");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityTemplateLineage", b =>
                {
                    b.Property<int>("ChildAbilityTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("ParentAbilityTemplateId")
                        .HasColumnType("int");

                    b.HasKey("ChildAbilityTemplateId", "ParentAbilityTemplateId");

                    b.HasIndex("ParentAbilityTemplateId");

                    b.ToTable("AbilityTemplateLineages");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AttributeInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AbilityInstanceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AbilityInstanceId");

                    b.ToTable("AttributeInstances");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AttributeTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AbilityTemplateId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AbilityTemplateId");

                    b.ToTable("AttributeTemplates");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.BoolAttributeValueInstance", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<bool>("CurrentValue")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("DefaultValue")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AttributeId");

                    b.ToTable("BoolAttributeValueInstances");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.BoolAttributeValueTemplate", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<bool>("DefaultValue")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AttributeId");

                    b.ToTable("BoolAttributeValueTemplates");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumAttributeValueInstance", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentOptionId")
                        .HasColumnType("int");

                    b.Property<int>("DefaultOptionId")
                        .HasColumnType("int");

                    b.HasKey("AttributeId");

                    b.HasIndex("CurrentOptionId");

                    b.HasIndex("DefaultOptionId");

                    b.ToTable("EnumAttributeValueInstances");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumAttributeValueTemplate", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<int>("DefaultOptionId")
                        .HasColumnType("int");

                    b.Property<int>("EnumDefinitionId")
                        .HasColumnType("int");

                    b.HasKey("AttributeId");

                    b.HasIndex("DefaultOptionId");

                    b.HasIndex("EnumDefinitionId");

                    b.ToTable("EnumAttributeValueTemplates");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("EnumDefinitions");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnumDefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnumDefinitionId");

                    b.ToTable("EnumOptions");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.FloatAttributeValueInstance", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<float>("CurrentValue")
                        .HasColumnType("float");

                    b.Property<float>("DefaultValue")
                        .HasColumnType("float");

                    b.HasKey("AttributeId");

                    b.ToTable("FloatAttributeValueInstances");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.FloatAttributeValueTemplate", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<float>("DefaultValue")
                        .HasColumnType("float");

                    b.HasKey("AttributeId");

                    b.ToTable("FloatAttributeValueTemplates");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.StringAttributeValueInstance", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<string>("CurrentValue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DefaultValue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AttributeId");

                    b.ToTable("StringAttributeValueInstances");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.StringAttributeValueTemplate", b =>
                {
                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<string>("DefaultValue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AttributeId");

                    b.ToTable("StringAttributeValueTemplates");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityInstance", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AbilityTemplate", "AbilityTemplate")
                        .WithMany()
                        .HasForeignKey("AbilityTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGMakerAPI.Models.Character", "Character")
                        .WithMany("AbilityInstances")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbilityTemplate");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityTag", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AbilityTemplate", "AbilityTemplate")
                        .WithMany("Tags")
                        .HasForeignKey("AbilityTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGMakerAPI.Models.Tag", "Tag")
                        .WithMany("AbilityTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbilityTemplate");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityTemplate", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.User", "CreatedByUser")
                        .WithMany("CreatedAbilities")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityTemplateLineage", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AbilityTemplate", "ChildAbilityTemplate")
                        .WithMany()
                        .HasForeignKey("ChildAbilityTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGMakerAPI.Models.AbilityTemplate", "ParentAbilityTemplate")
                        .WithMany()
                        .HasForeignKey("ParentAbilityTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChildAbilityTemplate");

                    b.Navigation("ParentAbilityTemplate");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AttributeInstance", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AbilityInstance", "AbilityInstance")
                        .WithMany()
                        .HasForeignKey("AbilityInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbilityInstance");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AttributeTemplate", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AbilityTemplate", "AbilityTemplate")
                        .WithMany("AttributeTemplates")
                        .HasForeignKey("AbilityTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbilityTemplate");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.BoolAttributeValueInstance", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AttributeInstance", "AttributeInstance")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeInstance");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.BoolAttributeValueTemplate", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AttributeTemplate", "AttributeTemplate")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeTemplate");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.Character", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumAttributeValueInstance", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AttributeInstance", "AttributeInstance")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGMakerAPI.Models.EnumOption", "CurrentOption")
                        .WithMany()
                        .HasForeignKey("CurrentOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RPGMakerAPI.Models.EnumOption", "DefaultOption")
                        .WithMany()
                        .HasForeignKey("DefaultOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeInstance");

                    b.Navigation("CurrentOption");

                    b.Navigation("DefaultOption");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumAttributeValueTemplate", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AttributeTemplate", "AttributeTemplate")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGMakerAPI.Models.EnumOption", "DefaultOption")
                        .WithMany()
                        .HasForeignKey("DefaultOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RPGMakerAPI.Models.EnumDefinition", "EnumDefinition")
                        .WithMany()
                        .HasForeignKey("EnumDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeTemplate");

                    b.Navigation("DefaultOption");

                    b.Navigation("EnumDefinition");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumDefinition", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumOption", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.EnumDefinition", "EnumDefinition")
                        .WithMany("Options")
                        .HasForeignKey("EnumDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnumDefinition");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.FloatAttributeValueInstance", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AttributeInstance", "AttributeInstance")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeInstance");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.FloatAttributeValueTemplate", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AttributeTemplate", "AttributeTemplate")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeTemplate");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.StringAttributeValueInstance", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AttributeInstance", "AttributeInstance")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeInstance");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.StringAttributeValueTemplate", b =>
                {
                    b.HasOne("RPGMakerAPI.Models.AttributeTemplate", "AttributeTemplate")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeTemplate");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.AbilityTemplate", b =>
                {
                    b.Navigation("AttributeTemplates");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.Character", b =>
                {
                    b.Navigation("AbilityInstances");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.EnumDefinition", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.Tag", b =>
                {
                    b.Navigation("AbilityTags");
                });

            modelBuilder.Entity("RPGMakerAPI.Models.User", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("CreatedAbilities");
                });
#pragma warning restore 612, 618
        }
    }
}
