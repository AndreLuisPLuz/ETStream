﻿// <auto-generated />
using System;
using ETStream.Infrastructure.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ETStream.Infrastructure.Migrations
{
    [DbContext(typeof(ETStreamContext))]
    [Migration("20240920183009_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ETStream.Domain.Aggregates.Channel.ChannelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Channels", (string)null);
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.Channel.ChannelPrivilegeGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.ToTable("ChannelPrivilegeGroups", (string)null);
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.Media.MediaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("tinyint")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("Medias", (string)null);
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.School.SchoolEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools", (string)null);
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.User.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.Channel.ChannelEntity", b =>
                {
                    b.HasOne("ETStream.Domain.Aggregates.School.SchoolEntity", null)
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("ETStream.Domain.Aggregates.Channel.Member", "Members", b1 =>
                        {
                            b1.Property<Guid>("ChannelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ChannelPrivilegeGroupId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ChannelId", "UserId");

                            b1.HasIndex("ChannelPrivilegeGroupId");

                            b1.ToTable("Member");

                            b1.WithOwner()
                                .HasForeignKey("ChannelId");

                            b1.HasOne("ETStream.Domain.Aggregates.Channel.ChannelPrivilegeGroup", null)
                                .WithMany()
                                .HasForeignKey("ChannelPrivilegeGroupId")
                                .OnDelete(DeleteBehavior.Restrict)
                                .IsRequired();
                        });

                    b.Navigation("Members");
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.Channel.ChannelPrivilegeGroup", b =>
                {
                    b.HasOne("ETStream.Domain.Aggregates.Channel.ChannelEntity", null)
                        .WithMany("PrivilegeGroups")
                        .HasForeignKey("ChannelId");

                    b.OwnsOne("ETStream.Domain.Aggregates.Channel.Privileges", "Privileges", b1 =>
                        {
                            b1.Property<Guid>("ChannelPrivilegeGroupId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("CanDeleteChannel")
                                .HasColumnType("bit");

                            b1.Property<bool>("CanDeleteContent")
                                .HasColumnType("bit");

                            b1.Property<bool>("CanEditChannel")
                                .HasColumnType("bit");

                            b1.Property<bool>("CanEditContent")
                                .HasColumnType("bit");

                            b1.Property<bool>("CanModerateComments")
                                .HasColumnType("bit");

                            b1.Property<bool>("CanPostContent")
                                .HasColumnType("bit");

                            b1.HasKey("ChannelPrivilegeGroupId");

                            b1.ToTable("ChannelPrivilegeGroups");

                            b1.ToJson("Privileges");

                            b1.WithOwner()
                                .HasForeignKey("ChannelPrivilegeGroupId");
                        });

                    b.Navigation("Privileges")
                        .IsRequired();
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.Media.MediaEntity", b =>
                {
                    b.OwnsMany("ETStream.Domain.Aggregates.Media.MediaContent", "Contents", b1 =>
                        {
                            b1.Property<Guid>("MediaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ContentNumber")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("ContentNumber"));

                            b1.Property<int>("Type")
                                .HasColumnType("int");

                            b1.HasKey("MediaId", "ContentNumber");

                            b1.ToTable("MediaContent");

                            b1.WithOwner()
                                .HasForeignKey("MediaId");
                        });

                    b.Navigation("Contents");
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.User.UserEntity", b =>
                {
                    b.HasOne("ETStream.Domain.Aggregates.School.SchoolEntity", null)
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ETStream.Domain.Aggregates.Channel.ChannelEntity", b =>
                {
                    b.Navigation("PrivilegeGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
