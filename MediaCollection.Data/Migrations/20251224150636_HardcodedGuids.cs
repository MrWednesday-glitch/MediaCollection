using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaCollection.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class HardcodedGuids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("2b1458d6-3758-42d0-aeb2-8ded3611120e"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("4d9e6cc9-212c-4292-b211-1fcb6d362f25"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("b239517a-59ca-486f-a9bd-5eaff6e24743"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("b9742b9c-146c-4b31-82a1-d8ff3ead20e4"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("bb916761-0f0f-40e9-a3c5-e49b55bdd05c"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("dcb9561e-b753-4269-af33-480958964d4d"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("fe639e17-33b5-4760-902a-505f1d2c1a39"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("0f23d874-d359-4981-8666-67a3797af7be"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("4bce51c1-e109-453d-8636-a23b491dd98f"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("9321e4f8-95d6-4ab8-9ed8-b9969ff29f78"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("a0ce19a0-44ab-43c0-a509-a3e14efb1e83"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("d4b3c368-71ff-4087-b104-861471a0984e"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("109def28-5d47-4efe-ab62-eb3cd170eb97"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("1aac03f1-2841-439d-84e0-799860803fdf"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("29bd7012-e575-4e2b-9f81-d7791d3bcb8f"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("5a8fa818-4244-4787-97b7-b030aa4c1eb2"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("e5487813-42fe-4688-a2c4-6e84aa49a326"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("f5e844a0-764d-4a3a-aa86-9ba142c0336e"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name", "PictureUri" },
                values: new object[] { new Guid("fe639e17-33b5-4760-902a-505f1d2c1a39"), "Neil Gaiman", "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1687,w_2999,x_0,y_0/dpr_1.5/c_limit,w_1600/fl_lossy,q_auto/v1610347631/210108-leon-neil-gaiman-hero_vhtgng" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name", "PictureUri" },
                values: new object[,]
                {
                    { new Guid("0f23d874-d359-4981-8666-67a3797af7be"), "Yacht Club Games", null },
                    { new Guid("4bce51c1-e109-453d-8636-a23b491dd98f"), "Supergiant Games", null },
                    { new Guid("9321e4f8-95d6-4ab8-9ed8-b9969ff29f78"), "Square Product Development Division 1", null },
                    { new Guid("a0ce19a0-44ab-43c0-a509-a3e14efb1e83"), "ZA/UM", "https://videogames.si.com/.image/t_share/MjA0MzY3MDI4MDcxNDQyMjA4/zaum-studio-logo-1.png" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name", "PictureUri" },
                values: new object[] { new Guid("d4b3c368-71ff-4087-b104-861471a0984e"), "George Miller", "https://i1.wp.com/www.filminquiry.com/wp-content/uploads/2020/05/George-Miller.jpg?fit=1050%2C700&ssl=1" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name", "PictureUri" },
                values: new object[,]
                {
                    { new Guid("109def28-5d47-4efe-ab62-eb3cd170eb97"), "Supergiant Games", null },
                    { new Guid("1aac03f1-2841-439d-84e0-799860803fdf"), "ZA/UM", "https://videogames.si.com/.image/t_share/MjA0MzY3MDI4MDcxNDQyMjA4/zaum-studio-logo-1.png" },
                    { new Guid("29bd7012-e575-4e2b-9f81-d7791d3bcb8f"), "HarperTorch", null },
                    { new Guid("5a8fa818-4244-4787-97b7-b030aa4c1eb2"), "Warner Bros. Pictures", "https://www.fotolip.com/wp-content/uploads/2016/05/Warner-Bros-logo-23.jpg" },
                    { new Guid("e5487813-42fe-4688-a2c4-6e84aa49a326"), "Yacht Club Games", "https://images.nintendolife.com/9081f8a938747/yacht-club-games.original.jpg" },
                    { new Guid("f5e844a0-764d-4a3a-aa86-9ba142c0336e"), "Square", "https://www.square-enix-games.com/home/public/selogo_onwhite.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DeveloperId", "Discriminator", "Finished", "Name", "Owned", "OwnedOn", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("2b1458d6-3758-42d0-aeb2-8ded3611120e"), new Guid("a0ce19a0-44ab-43c0-a509-a3e14efb1e83"), "Game", false, "Disco Elysium", true, "GOG", "https://static0.gamerantimages.com/wordpress/wp-content/uploads/2022/10/disco-elysium-final-cut.jpg", new Guid("1aac03f1-2841-439d-84e0-799860803fdf"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d9e6cc9-212c-4292-b211-1fcb6d362f25"), new Guid("9321e4f8-95d6-4ab8-9ed8-b9969ff29f78"), "Game", true, "Final Fantasy 10", true, "Playstation 2", "https://m.media-amazon.com/images/I/91rQrZ+BRHL._AC_SL1500_.jpg", new Guid("f5e844a0-764d-4a3a-aa86-9ba142c0336e"), new DateTime(2002, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b239517a-59ca-486f-a9bd-5eaff6e24743"), new Guid("4bce51c1-e109-453d-8636-a23b491dd98f"), "Game", true, "Hades", true, "Steam", "https://image.api.playstation.com/vulcan/ap/rnd/202104/0517/9AcM3vy5t77zPiJyKHwRfnNT.png", new Guid("109def28-5d47-4efe-ab62-eb3cd170eb97"), new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DirectorId", "Discriminator", "Name", "Owned", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("b9742b9c-146c-4b31-82a1-d8ff3ead20e4"), new Guid("d4b3c368-71ff-4087-b104-861471a0984e"), "Film", "Mad Max: Fury Road", false, "https://cdn.traileraddict.com/content/warner-bros-pictures/mad_max_fury_road-7.jpg", new Guid("5a8fa818-4244-4787-97b7-b030aa4c1eb2"), new DateTime(2015, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "DeveloperId", "Discriminator", "Finished", "Name", "Owned", "OwnedOn", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("bb916761-0f0f-40e9-a3c5-e49b55bdd05c"), new Guid("0f23d874-d359-4981-8666-67a3797af7be"), "Game", true, "Shovel Knight", true, "Steam", "https://www.gamespot.com/a/uploads/scale_medium/mig/0/0/6/2/2230062-box_sk.png", new Guid("e5487813-42fe-4688-a2c4-6e84aa49a326"), new DateTime(2014, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "AuthorId", "Discriminator", "Name", "Owned", "PictureUri", "PublisherId", "ReleaseDate" },
                values: new object[] { new Guid("dcb9561e-b753-4269-af33-480958964d4d"), new Guid("fe639e17-33b5-4760-902a-505f1d2c1a39"), "Book", "American Gods", true, "https://1.bp.blogspot.com/-sIcmR6Ve9uk/UT4G1N7iAaI/AAAAAAAASJU/KEzdlynscVE/s1600/american-gods-ebook-9788499185415.jpg", new Guid("29bd7012-e575-4e2b-9f81-d7791d3bcb8f"), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
