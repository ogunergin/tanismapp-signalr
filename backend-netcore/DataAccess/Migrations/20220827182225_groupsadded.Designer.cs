﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20220827182225_groupsadded")]
    partial class groupsadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnownAs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<string>("LookingFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Concrete.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConnectionId");

                    b.HasIndex("GroupName");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("Entities.Concrete.Group", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Entities.Concrete.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MessageSent")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RecipientDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SenderDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("SenderUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Entities.Concrete.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Entities.Concrete.UserLike", b =>
                {
                    b.Property<int>("SourceUserId")
                        .HasColumnType("int");

                    b.Property<int>("LikedUserId")
                        .HasColumnType("int");

                    b.HasKey("SourceUserId", "LikedUserId");

                    b.HasIndex("LikedUserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Entities.Concrete.Connection", b =>
                {
                    b.HasOne("Entities.Concrete.Group", null)
                        .WithMany("Connections")
                        .HasForeignKey("GroupName");
                });

            modelBuilder.Entity("Entities.Concrete.Message", b =>
                {
                    b.HasOne("Entities.Concrete.AppUser", "Recipient")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.AppUser", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Entities.Concrete.Photo", b =>
                {
                    b.HasOne("Entities.Concrete.AppUser", null)
                        .WithMany("Photos")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.UserLike", b =>
                {
                    b.HasOne("Entities.Concrete.AppUser", "LikedUser")
                        .WithMany("LikedByUsers")
                        .HasForeignKey("LikedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.AppUser", "SourceUser")
                        .WithMany("LikedUsers")
                        .HasForeignKey("SourceUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LikedUser");

                    b.Navigation("SourceUser");
                });

            modelBuilder.Entity("Entities.Concrete.AppUser", b =>
                {
                    b.Navigation("LikedByUsers");

                    b.Navigation("LikedUsers");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Entities.Concrete.Group", b =>
                {
                    b.Navigation("Connections");
                });
#pragma warning restore 612, 618
        }
    }
}
