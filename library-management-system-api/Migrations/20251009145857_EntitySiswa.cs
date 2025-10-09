using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library_management_system_api.Migrations
{
    /// <inheritdoc />
    public partial class EntitySiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Siswas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nama = table.Column<string>(type: "TEXT", nullable: false),
                    Umur = table.Column<int>(type: "INTEGER", nullable: false),
                    Kelas = table.Column<string>(type: "TEXT", nullable: true),
                    TanggalDaftar = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siswas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siswas");
        }
    }
}
