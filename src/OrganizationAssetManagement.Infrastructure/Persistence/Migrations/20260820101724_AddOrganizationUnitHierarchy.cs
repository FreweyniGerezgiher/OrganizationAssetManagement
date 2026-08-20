using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizationAssetManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationUnitHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentOrganizationUnitId",
                table: "OrganizationUnits",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUnits_ParentOrganizationUnitId",
                table: "OrganizationUnits",
                column: "ParentOrganizationUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationUnits_OrganizationUnits_ParentOrganizationUnitId",
                table: "OrganizationUnits",
                column: "ParentOrganizationUnitId",
                principalTable: "OrganizationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUnits_OrganizationUnits_ParentOrganizationUnitId",
                table: "OrganizationUnits");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationUnits_ParentOrganizationUnitId",
                table: "OrganizationUnits");

            migrationBuilder.DropColumn(
                name: "ParentOrganizationUnitId",
                table: "OrganizationUnits");
        }
    }
}
