﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnboardingBot.Server;

#nullable disable

namespace OnboardingBot.Server.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OnboardingBot.Server.Entities.AnswerEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsValid")
                        .HasColumnType("boolean");

                    b.Property<int?>("Mark")
                        .HasColumnType("integer");

                    b.Property<Guid?>("QuestionEntityID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("QuestionEntityID");

                    b.ToTable("AnswerEntity");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.ButtonEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TestEntityID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TextCommandEntityID")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("TestEntityID");

                    b.HasIndex("TextCommandEntityID");

                    b.ToTable("Buttons");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.PositionEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("MainUserID")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("MainUserID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.QuestionEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AnswerDisplayingType")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TestEntityID")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("TestEntityID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.QuizEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Options")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("RightOptionID")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Quizes");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.RoleOnboardingEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PositionID")
                        .HasColumnType("uuid");

                    b.Property<int>("StepsCount")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("PositionID");

                    b.ToTable("RoleOnboardings");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.StepEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Images")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionID")
                        .HasColumnType("uuid");

                    b.Property<int>("QuizesCount")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Urls")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("PositionID");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.TelegramCodeEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTimeCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeExist")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("TelegramCodes");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.TestEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("PositionID");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.TextCommandEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Images")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionID")
                        .HasColumnType("uuid");

                    b.Property<int>("QuizesCount")
                        .HasColumnType("integer");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Urls")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("PositionID");

                    b.ToTable("TextCommands");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.UserAnswerEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnswerID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestionID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserTestAnswerEntityID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("UserID");

                    b.HasIndex("UserTestAnswerEntityID");

                    b.ToTable("UserAnswerEntity");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<long?>("TelegramID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.UserOnboardingEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleOnboardingID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserCurrentStepID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("RoleOnboardingID");

                    b.HasIndex("UserCurrentStepID");

                    b.HasIndex("UserID");

                    b.ToTable("UserOnboardings");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.UserTestAnswerEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateTimeEnding")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeStarting")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("TestID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("TestID");

                    b.HasIndex("UserID");

                    b.ToTable("UserTestAnswers");
                });

            modelBuilder.Entity("QuizEntityStepEntity", b =>
                {
                    b.Property<Guid>("QuizesID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StepsID")
                        .HasColumnType("uuid");

                    b.HasKey("QuizesID", "StepsID");

                    b.HasIndex("StepsID");

                    b.ToTable("QuizEntityStepEntity");
                });

            modelBuilder.Entity("QuizEntityTextCommandEntity", b =>
                {
                    b.Property<Guid>("QuizesID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TextCommandsID")
                        .HasColumnType("uuid");

                    b.HasKey("QuizesID", "TextCommandsID");

                    b.HasIndex("TextCommandsID");

                    b.ToTable("QuizEntityTextCommandEntity");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.AnswerEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.QuestionEntity", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionEntityID");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.ButtonEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.TestEntity", null)
                        .WithMany("Buttons")
                        .HasForeignKey("TestEntityID");

                    b.HasOne("OnboardingBot.Server.Entities.TextCommandEntity", null)
                        .WithMany("Buttons")
                        .HasForeignKey("TextCommandEntityID");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.PositionEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.UserEntity", "MainUser")
                        .WithMany()
                        .HasForeignKey("MainUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainUser");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.QuestionEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.TestEntity", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestEntityID");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.RoleOnboardingEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.PositionEntity", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.StepEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.PositionEntity", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.TelegramCodeEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.TestEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.PositionEntity", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.TextCommandEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.PositionEntity", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.UserAnswerEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.AnswerEntity", "Answer")
                        .WithMany()
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingBot.Server.Entities.QuestionEntity", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingBot.Server.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingBot.Server.Entities.UserTestAnswerEntity", null)
                        .WithMany("Answers")
                        .HasForeignKey("UserTestAnswerEntityID");

                    b.Navigation("Answer");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.UserOnboardingEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.RoleOnboardingEntity", "RoleOnboarding")
                        .WithMany("Steps")
                        .HasForeignKey("RoleOnboardingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingBot.Server.Entities.StepEntity", "UserCurrentStep")
                        .WithMany()
                        .HasForeignKey("UserCurrentStepID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingBot.Server.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleOnboarding");

                    b.Navigation("User");

                    b.Navigation("UserCurrentStep");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.UserTestAnswerEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.TestEntity", "Test")
                        .WithMany()
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingBot.Server.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizEntityStepEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.QuizEntity", null)
                        .WithMany()
                        .HasForeignKey("QuizesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingBot.Server.Entities.StepEntity", null)
                        .WithMany()
                        .HasForeignKey("StepsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizEntityTextCommandEntity", b =>
                {
                    b.HasOne("OnboardingBot.Server.Entities.QuizEntity", null)
                        .WithMany()
                        .HasForeignKey("QuizesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingBot.Server.Entities.TextCommandEntity", null)
                        .WithMany()
                        .HasForeignKey("TextCommandsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.QuestionEntity", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.RoleOnboardingEntity", b =>
                {
                    b.Navigation("Steps");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.TestEntity", b =>
                {
                    b.Navigation("Buttons");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.TextCommandEntity", b =>
                {
                    b.Navigation("Buttons");
                });

            modelBuilder.Entity("OnboardingBot.Server.Entities.UserTestAnswerEntity", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
