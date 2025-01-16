using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCups.Migrations
{
    /// <inheritdoc />
    public partial class k2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tableFootballs_stadiums_Stadiums",
                table: "tableFootballs");

            migrationBuilder.DropForeignKey(
                name: "FK_transports_transportations_CategorisTransportation",
                table: "transports");

            migrationBuilder.DropIndex(
                name: "IX_tableFootballs_Stadiums",
                table: "tableFootballs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transports",
                table: "transports");

            migrationBuilder.DropIndex(
                name: "IX_transports_CategorisTransportation",
                table: "transports");

            migrationBuilder.RenameTable(
                name: "transports",
                newName: "transport");

            migrationBuilder.RenameColumn(
                name: "Stadiums",
                table: "tableFootballs",
                newName: "Stadiums_id");

            migrationBuilder.RenameColumn(
                name: "CategorisTransportation",
                table: "transport",
                newName: "CategoriesTransportationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transport",
                table: "transport",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_transport",
                table: "transport");

            migrationBuilder.RenameTable(
                name: "transport",
                newName: "transports");

            migrationBuilder.RenameColumn(
                name: "Stadiums_id",
                table: "tableFootballs",
                newName: "Stadiums");

            migrationBuilder.RenameColumn(
                name: "CategoriesTransportationId",
                table: "transports",
                newName: "CategorisTransportation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transports",
                table: "transports",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tableFootballs_Stadiums",
                table: "tableFootballs",
                column: "Stadiums");

            migrationBuilder.CreateIndex(
                name: "IX_transports_CategorisTransportation",
                table: "transports",
                column: "CategorisTransportation");

            migrationBuilder.AddForeignKey(
                name: "FK_tableFootballs_stadiums_Stadiums",
                table: "tableFootballs",
                column: "Stadiums",
                principalTable: "stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transports_transportations_CategorisTransportation",
                table: "transports",
                column: "CategorisTransportation",
                principalTable: "transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
