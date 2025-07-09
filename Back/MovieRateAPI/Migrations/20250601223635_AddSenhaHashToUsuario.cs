﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRateAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSenhaHashToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Usuarios");
        }
    }
}
