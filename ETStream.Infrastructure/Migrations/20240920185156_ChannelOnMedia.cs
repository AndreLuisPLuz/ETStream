using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETStream.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChannelOnMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Medias_ChannelId",
                table: "Medias",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Schools_ChannelId",
                table: "Medias",
                column: "ChannelId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Schools_ChannelId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ChannelId",
                table: "Medias");
        }
    }
}
