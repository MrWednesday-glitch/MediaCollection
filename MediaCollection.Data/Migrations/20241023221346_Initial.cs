using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaCollection.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Owned = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeveloperId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finished = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Media_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Media_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Media_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c7a76a93-4f5a-4409-aa6f-a10b08e25972"), "Neil Gaiman" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("44834ccb-3cb8-439f-b18e-3ea8ea326e62"), "Supergiant Games" },
                    { new Guid("4894ae09-3aba-49a6-90f2-9c9950128e79"), "ZA/UM" },
                    { new Guid("e12cd967-fc5d-4ecc-bc02-ec595e7975a5"), "Square Product Development Division 1" },
                    { new Guid("edb6b2e4-5325-4e32-aec1-425ce0c9329a"), "Yacht Club Games" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2a12bf92-f007-4cda-853e-ac47afb32b58"), "George Miller" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0526a300-872f-4abe-825d-db8f6640408e"), "Warner Bros. Pictures" },
                    { new Guid("0cbf6f06-0cb8-44cb-9525-02d4d834181c"), "Supergiant Games" },
                    { new Guid("228f850d-ba52-4137-a9b1-7449f14f774c"), "ZA/UM" },
                    { new Guid("2d7fd4be-95be-45c7-884e-b8876bf97632"), "Square" },
                    { new Guid("2dd65acc-3298-4cb8-a5df-8f8c93059e04"), "HarperTorch" },
                    { new Guid("93eefc0a-de92-4cd0-9e82-9a59e5b443c8"), "Yacht Club Games" }
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DeveloperId", "Discriminator", "Finished", "Name", "Owned", "OwnedOn", "PublisherId", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("11fa67da-5ec1-4f24-a8f2-aa5fc02f9c9d"), new Guid("4894ae09-3aba-49a6-90f2-9c9950128e79"), "Game", false, "Disco Elysium", true, "GOG", new Guid("228f850d-ba52-4137-a9b1-7449f14f774c"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4040186e-770a-44ac-9323-1ea8107eb13d"), new Guid("edb6b2e4-5325-4e32-aec1-425ce0c9329a"), "Game", true, "Shovel Knight", true, "Steam", new Guid("93eefc0a-de92-4cd0-9e82-9a59e5b443c8"), new DateTime(2014, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4b4d641-041d-4a60-b1ff-32c122853751"), new Guid("e12cd967-fc5d-4ecc-bc02-ec595e7975a5"), "Game", true, "Final Fantasy 10", true, "Playstation 2", new Guid("2d7fd4be-95be-45c7-884e-b8876bf97632"), new DateTime(2002, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d64a24c6-7bd6-4ba8-a1a6-524d69305efe"), new Guid("44834ccb-3cb8-439f-b18e-3ea8ea326e62"), "Game", true, "Hades", true, "Steam", new Guid("0cbf6f06-0cb8-44cb-9525-02d4d834181c"), new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "AuthorId", "Discriminator", "Name", "Owned", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("ed980d9f-fc15-4cf5-844a-9b12566a8597"), new Guid("c7a76a93-4f5a-4409-aa6f-a10b08e25972"), "Book", "American Gods", true, new Guid("2dd65acc-3298-4cb8-a5df-8f8c93059e04"), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DirectorId", "Discriminator", "Name", "Owned", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("fff9a839-2710-46c9-96fb-fa1f585ae2e8"), new Guid("2a12bf92-f007-4cda-853e-ac47afb32b58"), "Film", "Mad Max: Fury Road", false, new Guid("0526a300-872f-4abe-825d-db8f6640408e"), new DateTime(2015, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Media_AuthorId",
                table: "Media",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_DeveloperId",
                table: "Media",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_DirectorId",
                table: "Media",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_PublisherId",
                table: "Media",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
