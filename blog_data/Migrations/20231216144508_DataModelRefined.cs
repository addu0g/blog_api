using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace blog_data.Migrations
{
    /// <inheritdoc />
    public partial class DataModelRefined : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "General" },
                    { 2, "Technology" },
                    { 3, "Random" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "Content", "TimeStamp", "Title" },
                values: new object[,]
                {
                    { 1, 2, "<p>Are you looking for something new to learn this year?  Then let me suggest <a href=\\\"http://www.typescriptlang.org/\\\">TypeScript</a> for development with Cloud Functions!</p><p>Not long ago, the Cloud Functions for Firebase team <a href=\\\"http://firebase.googleblog.com/2017/12/improve-productivity-with-typescript.html\\\">released an update</a> to the <a href=\\\"https://firebase.google.com/docs/cli/\\\">Firebase CLI</a> that makes it easy for you to write your functions in TypeScript, rather than JavaScript.  The Firebase team encourages you to consider switching to TypeScript, but I can imagine you might be reluctant to learn a new language, especially if you're already comfortable with JavaScript.  The great news is that TypeScript offers you a bunch of benefits that are easy to start using today.</p>", new DateTime(2023, 12, 16, 8, 45, 8, 62, DateTimeKind.Local).AddTicks(3783), "Why you should use TypeScript for writing Cloud Functions" },
                    { 2, 2, "<p>Securing your Firebase Realtime Database just got easier with our newest feature: <strong>query-based rules</strong>. Query-based rules allow you to limit access to a subset of data. Need to restrict a query to return a maximum of 10 records? Want to ensure users are only retrieving the first 20 records instead of the last 20? Want to let a user query for only their documents? Not a problem. Query-based rules has you covered. Query-based rules can even help you simplify your data structure. Read on to learn how!</p>", new DateTime(2023, 12, 16, 8, 45, 8, 62, DateTimeKind.Local).AddTicks(3797), "Introducing Query-based Security Rules" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
