using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProductsStore.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClient_RoleType_RoleTypeId",
                table: "UserClient");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleTypeId",
                table: "UserClient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "RoleType",
                columns: new[] { "Id", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0079530e-415f-4df7-9422-2d0b55ef1f09"), new DateTime(2022, 1, 30, 22, 4, 59, 518, DateTimeKind.Local).AddTicks(6347), "Admin", "Admin" },
                    { new Guid("c1d6e045-4999-4209-bd14-fc1796d7d7b1"), new DateTime(2022, 1, 30, 22, 4, 59, 516, DateTimeKind.Local).AddTicks(9267), "Client", "Client" }
                });

            migrationBuilder.InsertData(
                table: "TypeProduct",
                columns: new[] { "Id", "CreatedDate", "Description", "TypeName" },
                values: new object[,]
                {
                    { new Guid("6a68d090-dbdc-4f62-bd12-70ac63b81864"), new DateTime(2022, 1, 30, 22, 4, 59, 517, DateTimeKind.Local).AddTicks(4614), "Bienes", "Bienes" },
                    { new Guid("98ee398b-5a56-4d15-ba2d-60e143ca3de1"), new DateTime(2022, 1, 30, 22, 4, 59, 517, DateTimeKind.Local).AddTicks(5179), "Vehiculos", "Vehiculos" },
                    { new Guid("2c708de0-3933-4054-abd4-ca13ddfb298e"), new DateTime(2022, 1, 30, 22, 4, 59, 517, DateTimeKind.Local).AddTicks(5201), "Terrenos", "Terrenos" },
                    { new Guid("c232b924-94fb-487e-9470-512543992db8"), new DateTime(2022, 1, 30, 22, 4, 59, 517, DateTimeKind.Local).AddTicks(5214), "Apartamentos", "Apartamentos" }
                });

            migrationBuilder.InsertData(
                table: "UserClient",
                columns: new[] { "Id", "CreatedDate", "LastName", "Name", "Password", "RoleTypeId", "UserName" },
                values: new object[] { new Guid("1f6fa97d-5908-4edc-a79d-3e0bfee11647"), new DateTime(2022, 1, 30, 22, 4, 59, 518, DateTimeKind.Local).AddTicks(8993), "Admin", "Admin", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", new Guid("0079530e-415f-4df7-9422-2d0b55ef1f09"), "Admin.dev" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserClient_RoleType_RoleTypeId",
                table: "UserClient",
                column: "RoleTypeId",
                principalTable: "RoleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClient_RoleType_RoleTypeId",
                table: "UserClient");

            migrationBuilder.DeleteData(
                table: "RoleType",
                keyColumn: "Id",
                keyValue: new Guid("0079530e-415f-4df7-9422-2d0b55ef1f09"));

            migrationBuilder.DeleteData(
                table: "TypeProduct",
                keyColumn: "Id",
                keyValue: new Guid("2c708de0-3933-4054-abd4-ca13ddfb298e"));

            migrationBuilder.DeleteData(
                table: "TypeProduct",
                keyColumn: "Id",
                keyValue: new Guid("6a68d090-dbdc-4f62-bd12-70ac63b81864"));

            migrationBuilder.DeleteData(
                table: "TypeProduct",
                keyColumn: "Id",
                keyValue: new Guid("98ee398b-5a56-4d15-ba2d-60e143ca3de1"));

            migrationBuilder.DeleteData(
                table: "TypeProduct",
                keyColumn: "Id",
                keyValue: new Guid("c232b924-94fb-487e-9470-512543992db8"));

            migrationBuilder.DeleteData(
                table: "UserClient",
                keyColumn: "Id",
                keyValue: new Guid("1f6fa97d-5908-4edc-a79d-3e0bfee11647"));

            migrationBuilder.DeleteData(
                table: "RoleType",
                keyColumn: "Id",
                keyValue: new Guid("c1d6e045-4999-4209-bd14-fc1796d7d7b1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleTypeId",
                table: "UserClient",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClient_RoleType_RoleTypeId",
                table: "UserClient",
                column: "RoleTypeId",
                principalTable: "RoleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
