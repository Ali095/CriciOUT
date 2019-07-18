﻿// <auto-generated />
using CricInfo.Data;
using CricInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CricInfo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CricInfo.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CricInfo.Models.Bowl", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Fives");

                    b.Property<int>("Hatricks");

                    b.Property<int>("Threes");

                    b.Property<int>("TotalWickets");

                    b.HasKey("id");

                    b.ToTable("Bowls");
                });

            modelBuilder.Entity("CricInfo.Models.Ground", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<bool>("Availabity");

                    b.Property<string>("Location");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("contact")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ground");
                });

            modelBuilder.Entity("CricInfo.Models.GroundReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroundId");

                    b.Property<DateTime>("ReservationDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GroundId");

                    b.HasIndex("UserId");

                    b.ToTable("GroundReservation");
                });

            modelBuilder.Entity("CricInfo.Models.Match", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BowlerId");

                    b.Property<double>("CurrentOver");

                    b.Property<int>("CurrentScore");

                    b.Property<int>("CurrentWickets");

                    b.Property<int>("Ground");

                    b.Property<int?>("ManoftheMatchId");

                    b.Property<int?>("NonStrikerId");

                    b.Property<string>("Result");

                    b.Property<int?>("StrikerId");

                    b.Property<int>("TeamA");

                    b.Property<int?>("TeamB")
                        .IsRequired();

                    b.Property<int>("TotalOvers");

                    b.Property<int>("Umpire1");

                    b.Property<int?>("Umpire2");

                    b.HasKey("id");

                    b.HasIndex("BowlerId");

                    b.HasIndex("Ground");

                    b.HasIndex("ManoftheMatchId");

                    b.HasIndex("NonStrikerId");

                    b.HasIndex("StrikerId");

                    b.HasIndex("TeamA");

                    b.HasIndex("TeamB");

                    b.HasIndex("Umpire1");

                    b.HasIndex("Umpire2");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("CricInfo.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int?>("BowlId");

                    b.Property<string>("HowOut");

                    b.Property<int>("MatchesPlayed");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("OutBy");

                    b.Property<int?>("ScoreId");

                    b.Property<int>("ShirtNumber");

                    b.Property<int>("TeamId");

                    b.Property<int>("role");

                    b.HasKey("Id");

                    b.HasIndex("BowlId");

                    b.HasIndex("ScoreId")
                        .IsUnique()
                        .HasFilter("[ScoreId] IS NOT NULL");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CricInfo.Models.Score", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BallsPlayed");

                    b.Property<int>("BestScore");

                    b.Property<int>("Centuries");

                    b.Property<int>("Fifties");

                    b.Property<int>("Fours");

                    b.Property<int>("ScoredTotal");

                    b.Property<int>("Sixes");

                    b.HasKey("id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("CricInfo.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Captain")
                        .IsRequired();

                    b.Property<int>("MatchLoose");

                    b.Property<int>("MatchPlayed");

                    b.Property<int>("MatchTie");

                    b.Property<int>("MatchWin");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Owner");

                    b.HasKey("Id");

                    b.HasIndex("Owner");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("CricInfo.Models.Umpire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<bool>("Availability");

                    b.Property<string>("Contact")
                        .IsRequired();

                    b.Property<int>("Experience");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProExperience");

                    b.HasKey("Id");

                    b.ToTable("Umpire");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CricInfo.Models.GroundReservation", b =>
                {
                    b.HasOne("CricInfo.Models.Ground", "GroundRef")
                        .WithMany()
                        .HasForeignKey("GroundId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricInfo.Models.ApplicationUser", "UserRef")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CricInfo.Models.Match", b =>
                {
                    b.HasOne("CricInfo.Models.Player", "Bowler")
                        .WithMany()
                        .HasForeignKey("BowlerId");

                    b.HasOne("CricInfo.Models.Ground", "GroundRef")
                        .WithMany()
                        .HasForeignKey("Ground")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricInfo.Models.Player", "ManoftheMatch")
                        .WithMany()
                        .HasForeignKey("ManoftheMatchId");

                    b.HasOne("CricInfo.Models.Player", "NonStriker")
                        .WithMany()
                        .HasForeignKey("NonStrikerId");

                    b.HasOne("CricInfo.Models.Player", "Striker")
                        .WithMany()
                        .HasForeignKey("StrikerId");

                    b.HasOne("CricInfo.Models.Team", "BatTeam")
                        .WithMany()
                        .HasForeignKey("TeamA")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricInfo.Models.Team", "BowlTeam")
                        .WithMany()
                        .HasForeignKey("TeamB")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricInfo.Models.Umpire", "UmpireRef")
                        .WithMany()
                        .HasForeignKey("Umpire1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricInfo.Models.Umpire", "UmpireRef2")
                        .WithMany()
                        .HasForeignKey("Umpire2");
                });

            modelBuilder.Entity("CricInfo.Models.Player", b =>
                {
                    b.HasOne("CricInfo.Models.Bowl", "Bowl")
                        .WithMany()
                        .HasForeignKey("BowlId");

                    b.HasOne("CricInfo.Models.Score", "Score")
                        .WithOne("Player")
                        .HasForeignKey("CricInfo.Models.Player", "ScoreId");

                    b.HasOne("CricInfo.Models.Team", "TeamRef")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CricInfo.Models.Team", b =>
                {
                    b.HasOne("CricInfo.Models.ApplicationUser", "UserRef")
                        .WithMany()
                        .HasForeignKey("Owner");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CricInfo.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CricInfo.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricInfo.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CricInfo.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
