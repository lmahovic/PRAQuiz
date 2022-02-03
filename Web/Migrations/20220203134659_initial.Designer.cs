﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Context;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(PRAQuizContext))]
    [Migration("20220203134659_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Web.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("AnswerOrder")
                        .HasColumnType("tinyint");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Correct")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer", (string)null);
                });

            modelBuilder.Entity("Web.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("Web.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("datetime");

                    b.Property<string>("GamePin")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("GamePIN");

                    b.Property<int>("QuizId")
                        .HasColumnType("int")
                        .HasColumnName("QuizID");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("Web.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("GameID");

                    b.Property<bool>("HasQuit")
                        .HasColumnType("bit");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("Web.Entities.PlayerQuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int")
                        .HasColumnName("AnswerID");

                    b.Property<long?>("AnswerTime")
                        .HasColumnType("bigint");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int")
                        .HasColumnName("PlayerID");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("PlayerQuestionAnswer", (string)null);
                });

            modelBuilder.Entity("Web.Entities.PlayerRanking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PlayerId")
                        .HasColumnType("int")
                        .HasColumnName("PlayerID");

                    b.Property<int>("Ranking")
                        .HasColumnType("int");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PlayerId" }, "PlayerRanking_PlayerID_uindex")
                        .IsUnique();

                    b.ToTable("PlayerRanking", (string)null);
                });

            modelBuilder.Entity("Web.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("QuestionOrder")
                        .HasColumnType("tinyint");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int")
                        .HasColumnName("QuizID");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Question", (string)null);
                });

            modelBuilder.Entity("Web.Entities.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("AuthorID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Quiz", (string)null);
                });

            modelBuilder.Entity("Web.Entities.Answer", b =>
                {
                    b.HasOne("Web.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .IsRequired()
                        .HasConstraintName("Answer_Question_ID_fk");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Web.Entities.Game", b =>
                {
                    b.HasOne("Web.Entities.Quiz", "Quiz")
                        .WithMany("Games")
                        .HasForeignKey("QuizId")
                        .IsRequired()
                        .HasConstraintName("Game_Quiz_ID_fk");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Web.Entities.Player", b =>
                {
                    b.HasOne("Web.Entities.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("Player_Game_ID_fk");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Web.Entities.PlayerQuestionAnswer", b =>
                {
                    b.HasOne("Web.Entities.Answer", "Answer")
                        .WithMany("PlayerQuestionAnswers")
                        .HasForeignKey("AnswerId")
                        .HasConstraintName("PlayerQuestionAnswer_Answer_ID_fk");

                    b.HasOne("Web.Entities.Player", "Player")
                        .WithMany("PlayerQuestionAnswers")
                        .HasForeignKey("PlayerId")
                        .IsRequired()
                        .HasConstraintName("PlayerQuestionAnswer_Player_ID_fk");

                    b.HasOne("Web.Entities.Question", "Question")
                        .WithMany("PlayerQuestionAnswers")
                        .HasForeignKey("QuestionId")
                        .IsRequired()
                        .HasConstraintName("PlayerQuestionAnswer_Question_ID_fk");

                    b.Navigation("Answer");

                    b.Navigation("Player");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Web.Entities.PlayerRanking", b =>
                {
                    b.HasOne("Web.Entities.Player", "Player")
                        .WithOne("PlayerRanking")
                        .HasForeignKey("Web.Entities.PlayerRanking", "PlayerId")
                        .IsRequired()
                        .HasConstraintName("PlayerRanking_Player_ID_fk");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Web.Entities.Question", b =>
                {
                    b.HasOne("Web.Entities.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .IsRequired()
                        .HasConstraintName("Question_Quiz_ID_fk");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Web.Entities.Quiz", b =>
                {
                    b.HasOne("Web.Entities.Author", "Author")
                        .WithMany("Quizzes")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("Quiz_Author_ID_fk");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Web.Entities.Answer", b =>
                {
                    b.Navigation("PlayerQuestionAnswers");
                });

            modelBuilder.Entity("Web.Entities.Author", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("Web.Entities.Game", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Web.Entities.Player", b =>
                {
                    b.Navigation("PlayerQuestionAnswers");

                    b.Navigation("PlayerRanking")
                        .IsRequired();
                });

            modelBuilder.Entity("Web.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("PlayerQuestionAnswers");
                });

            modelBuilder.Entity("Web.Entities.Quiz", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
