using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaCollection.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class AddedPictureUriProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("11fa67da-5ec1-4f24-a8f2-aa5fc02f9c9d"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("4040186e-770a-44ac-9323-1ea8107eb13d"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("c4b4d641-041d-4a60-b1ff-32c122853751"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("d64a24c6-7bd6-4ba8-a1a6-524d69305efe"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("ed980d9f-fc15-4cf5-844a-9b12566a8597"));

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: new Guid("fff9a839-2710-46c9-96fb-fa1f585ae2e8"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("c7a76a93-4f5a-4409-aa6f-a10b08e25972"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("44834ccb-3cb8-439f-b18e-3ea8ea326e62"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("4894ae09-3aba-49a6-90f2-9c9950128e79"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("e12cd967-fc5d-4ecc-bc02-ec595e7975a5"));

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: new Guid("edb6b2e4-5325-4e32-aec1-425ce0c9329a"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("2a12bf92-f007-4cda-853e-ac47afb32b58"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("0526a300-872f-4abe-825d-db8f6640408e"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("0cbf6f06-0cb8-44cb-9525-02d4d834181c"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("228f850d-ba52-4137-a9b1-7449f14f774c"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("2d7fd4be-95be-45c7-884e-b8876bf97632"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("2dd65acc-3298-4cb8-a5df-8f8c93059e04"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("93eefc0a-de92-4cd0-9e82-9a59e5b443c8"));

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Authors");

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
        }
    }
}
