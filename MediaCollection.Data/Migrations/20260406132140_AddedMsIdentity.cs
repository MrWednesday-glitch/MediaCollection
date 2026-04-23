using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaCollection.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class AddedMsIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name", "PictureUri" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), "Neil Gaiman", "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1687,w_2999,x_0,y_0/dpr_1.5/c_limit,w_1600/fl_lossy,q_auto/v1610347631/210108-leon-neil-gaiman-hero_vhtgng" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name", "PictureUri" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Supergiant Games", null },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Square Product Development Division 1", null },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Yacht Club Games", null },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "ZA/UM", "https://videogames.si.com/.image/t_share/MjA0MzY3MDI4MDcxNDQyMjA4/zaum-studio-logo-1.png" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name", "PictureUri" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), "George Miller", "https://i1.wp.com/www.filminquiry.com/wp-content/uploads/2020/05/George-Miller.jpg?fit=1050%2C700&ssl=1" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name", "PictureUri" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "HarperTorch", null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Warner Bros. Pictures", "https://www.fotolip.com/wp-content/uploads/2016/05/Warner-Bros-logo-23.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Supergiant Games", null },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Square", "https://www.square-enix-games.com/home/public/selogo_onwhite.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Yacht Club Games", "https://images.nintendolife.com/9081f8a938747/yacht-club-games.original.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "ZA/UM", "https://videogames.si.com/.image/t_share/MjA0MzY3MDI4MDcxNDQyMjA4/zaum-studio-logo-1.png" }
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DeveloperId", "Discriminator", "Finished", "Name", "Owned", "OwnedOn", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000009"), "Game", true, "Hades", true, "Steam", "https://image.api.playstation.com/vulcan/ap/rnd/202104/0517/9AcM3vy5t77zPiJyKHwRfnNT.png", new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "AuthorId", "Discriminator", "Name", "Owned", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000008"), "Book", "American Gods", true, "https://1.bp.blogspot.com/-sIcmR6Ve9uk/UT4G1N7iAaI/AAAAAAAASJU/KEzdlynscVE/s1600/american-gods-ebook-9788499185415.jpg", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DeveloperId", "Discriminator", "Finished", "Name", "Owned", "OwnedOn", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000010"), "Game", true, "Final Fantasy 10", true, "Playstation 2", "https://m.media-amazon.com/images/I/91rQrZ+BRHL._AC_SL1500_.jpg", new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2002, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DirectorId", "Discriminator", "Name", "Owned", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000007"), "Film", "Mad Max: Fury Road", false, "https://cdn.traileraddict.com/content/warner-bros-pictures/mad_max_fury_road-7.jpg", new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2015, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DeveloperId", "Discriminator", "Finished", "Name", "Owned", "OwnedOn", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000011"), "Game", true, "Shovel Knight", true, "Steam", "https://www.gamespot.com/a/uploads/scale_medium/mig/0/0/6/2/2230062-box_sk.png", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2014, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000012"), "Game", false, "Disco Elysium", true, "GOG", "https://static0.gamerantimages.com/wordpress/wp-content/uploads/2022/10/disco-elysium-final-cut.jpg", new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
