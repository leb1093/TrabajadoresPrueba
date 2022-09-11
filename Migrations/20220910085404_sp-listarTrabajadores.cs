using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajadoresPrueba.Migrations
{
    public partial class splistarTrabajadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Departamento",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NombreDepartamento = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Departamento", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Provincia",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdDepartamento = table.Column<int>(type: "int", nullable: true),
            //        NombreProvincia = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Provincia", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Provincia__IdDep__2B3F6F97",
            //            column: x => x.IdDepartamento,
            //            principalTable: "Departamento",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Distrito",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdProvincia = table.Column<int>(type: "int", nullable: true),
            //        NombreDistrito = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Distrito", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Distrito__IdProv__2A4B4B5E",
            //            column: x => x.IdProvincia,
            //            principalTable: "Provincia",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Trabajadores",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TipoDocumento = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
            //        NumeroDocumento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Nombres = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
            //        Sexo = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
            //        IdDepartamento = table.Column<int>(type: "int", nullable: true),
            //        IdProvincia = table.Column<int>(type: "int", nullable: true),
            //        IdDistrito = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Trabajadores", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK__Trabajado__IdDep__2C3393D0",
            //            column: x => x.IdDepartamento,
            //            principalTable: "Departamento",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Trabajado__IdDis__2D27B809",
            //            column: x => x.IdDistrito,
            //            principalTable: "Distrito",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK__Trabajado__IdPro__2E1BDC42",
            //            column: x => x.IdProvincia,
            //            principalTable: "Provincia",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Distrito_IdProvincia",
            //    table: "Distrito",
            //    column: "IdProvincia");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Provincia_IdDepartamento",
            //    table: "Provincia",
            //    column: "IdDepartamento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Trabajadores_IdDepartamento",
            //    table: "Trabajadores",
            //    column: "IdDepartamento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Trabajadores_IdDistrito",
            //    table: "Trabajadores",
            //    column: "IdDistrito");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Trabajadores_IdProvincia",
            //    table: "Trabajadores",
            //    column: "IdProvincia");
            var sp = @"CREATE PROCEDURE [dbo].[sp_listarTrabajadores]
                        AS
                        select t.TipoDocumento, t.NumeroDocumento, t.Nombres, t.Sexo, dep.NombreDepartamento, p.NombreProvincia, d.NombreDistrito 
                        from Trabajadores t inner join Departamento dep on t.IdDepartamento=dep.Id
                        inner join Provincia p on t.IdProvincia=p.Id
                        inner join Distrito d on t.IdDistrito=d.Id";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
