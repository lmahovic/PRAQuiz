using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.ID);
                    table.ForeignKey(
                        name: "Quiz_Author_ID_fk",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizID = table.Column<int>(type: "int", nullable: false),
                    GamePIN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    FinishTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.ID);
                    table.ForeignKey(
                        name: "Game_Quiz_ID_fk",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TimeLimit = table.Column<int>(type: "int", nullable: false),
                    QuizID = table.Column<int>(type: "int", nullable: false),
                    QuestionOrder = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                    table.ForeignKey(
                        name: "Question_Quiz_ID_fk",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    HasQuit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.ID);
                    table.ForeignKey(
                        name: "Player_Game_ID_fk",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Correct = table.Column<bool>(type: "bit", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    AnswerOrder = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.ID);
                    table.ForeignKey(
                        name: "Answer_Question_ID_fk",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PlayerRanking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRanking", x => x.ID);
                    table.ForeignKey(
                        name: "PlayerRanking_Player_ID_fk",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PlayerQuestionAnswer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    AnswerID = table.Column<int>(type: "int", nullable: true),
                    AnswerTime = table.Column<long>(type: "bigint", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerQuestionAnswer", x => x.ID);
                    table.ForeignKey(
                        name: "PlayerQuestionAnswer_Answer_ID_fk",
                        column: x => x.AnswerID,
                        principalTable: "Answer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "PlayerQuestionAnswer_Player_ID_fk",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "PlayerQuestionAnswer_Question_ID_fk",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionID",
                table: "Answer",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_QuizID",
                table: "Game",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameID",
                table: "Player",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuestionAnswer_AnswerID",
                table: "PlayerQuestionAnswer",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuestionAnswer_PlayerID",
                table: "PlayerQuestionAnswer",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuestionAnswer_QuestionID",
                table: "PlayerQuestionAnswer",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "PlayerRanking_PlayerID_uindex",
                table: "PlayerRanking",
                column: "PlayerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizID",
                table: "Question",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_AuthorID",
                table: "Quiz",
                column: "AuthorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerQuestionAnswer");

            migrationBuilder.DropTable(
                name: "PlayerRanking");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
