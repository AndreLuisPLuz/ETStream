using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETStream.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type_Id = table.Column<int>(type: "int", nullable: false),
                    Type_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChannelEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Channels_ChannelEntityId",
                        column: x => x.ChannelEntityId,
                        principalTable: "Channels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MediaContent",
                columns: table => new
                {
                    ContentNumber = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContent", x => new { x.Id, x.ContentNumber });
                    table.ForeignKey(
                        name: "FK_MediaContent_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelPrivilegeGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChannelEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Privileges = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelPrivilegeGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelPrivilegeGroups_Channels_ChannelEntityId",
                        column: x => x.ChannelEntityId,
                        principalTable: "Channels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChannelPrivilegeGroups_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelPrivilegeGroups_ChannelEntityId",
                table: "ChannelPrivilegeGroups",
                column: "ChannelEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelPrivilegeGroups_MemberId",
                table: "ChannelPrivilegeGroups",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContent_MediaId",
                table: "MediaContent",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ChannelEntityId",
                table: "Members",
                column: "ChannelEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelPrivilegeGroups");

            migrationBuilder.DropTable(
                name: "MediaContent");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Channels");
        }
    }
}
