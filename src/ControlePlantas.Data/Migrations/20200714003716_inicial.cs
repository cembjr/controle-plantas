using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePlantas.Infra.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLEmpr",
                columns: table => new
                {
                    IdEmpr = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    NomeEmpr = table.Column<string>(type: "varchar(150)", nullable: false),
                    DocuEmpr = table.Column<string>(type: "varchar(150)", nullable: false),
                    TeleEmpr = table.Column<string>(type: "varchar(15)", nullable: false),
                    EndeCEP = table.Column<string>(type: "varchar(8)", nullable: true),
                    EndeLogr = table.Column<string>(type: "varchar(150)", nullable: true),
                    EndeNum = table.Column<string>(type: "varchar(50)", nullable: true),
                    EndeCompl = table.Column<string>(type: "varchar(150)", nullable: true),
                    Endereco_Cidade = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLEmpr", x => x.IdEmpr);
                });

            migrationBuilder.CreateTable(
                name: "PLArePlan",
                columns: table => new
                {
                    IdAreaPlan = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    DescAreaPlan = table.Column<string>(type: "varchar(150)", nullable: false),
                    ValTamaAlqu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValTamaHect = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdEmpr = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLArePlan", x => x.IdAreaPlan);
                    table.ForeignKey(
                        name: "FK_PLArePlan_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                });

            migrationBuilder.CreateTable(
                name: "PLForn",
                columns: table => new
                {
                    IdForn = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    NomForn = table.Column<string>(type: "varchar(150)", nullable: false),
                    DocuForn = table.Column<string>(type: "varchar(50)", nullable: true),
                    IdEmpr = table.Column<Guid>(nullable: false),
                    EndeCEP = table.Column<string>(type: "varchar(8)", nullable: true),
                    EndeLogr = table.Column<string>(type: "varchar(150)", nullable: true),
                    EndeNum = table.Column<string>(type: "varchar(50)", nullable: true),
                    EndeCompl = table.Column<string>(type: "varchar(150)", nullable: true),
                    EndeCida = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLForn", x => x.IdForn);
                    table.ForeignKey(
                        name: "FK_PLForn_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                });

            migrationBuilder.CreateTable(
                name: "PLInsu",
                columns: table => new
                {
                    IdInsu = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    NomInsu = table.Column<string>(type: "varchar(150)", nullable: false),
                    IdTipoInsu = table.Column<int>(nullable: false),
                    IdEmpr = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLInsu", x => x.IdInsu);
                    table.ForeignKey(
                        name: "FK_PLInsu_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                });

            migrationBuilder.CreateTable(
                name: "PLUsua",
                columns: table => new
                {
                    IdUsua = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    NomUsua = table.Column<string>(nullable: false),
                    LogiUsua = table.Column<string>(nullable: false),
                    SenhUsua = table.Column<string>(nullable: false),
                    IdEmpr = table.Column<Guid>(nullable: false),
                    TipoUsua = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLUsua", x => x.IdUsua);
                    table.ForeignKey(
                        name: "FK_PLUsua_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                });

            migrationBuilder.CreateTable(
                name: "PLPlan",
                columns: table => new
                {
                    IdPlan = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    DesPlan = table.Column<string>(type: "varchar(150)", nullable: false),
                    DatInic = table.Column<DateTime>(nullable: true),
                    DatFina = table.Column<DateTime>(nullable: true),
                    IdAreaPlan = table.Column<Guid>(nullable: false),
                    IdEmpr = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLPlan", x => x.IdPlan);
                    table.ForeignKey(
                        name: "FK_PLPlan_PLArePlan_IdAreaPlan",
                        column: x => x.IdAreaPlan,
                        principalTable: "PLArePlan",
                        principalColumn: "IdAreaPlan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLPlan_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                });

            migrationBuilder.CreateTable(
                name: "PLEntrInsu",
                columns: table => new
                {
                    IdEntrInsu = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    IdInsu = table.Column<Guid>(nullable: false),
                    DatEntr = table.Column<DateTime>(nullable: false),
                    QtdEntr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValEntr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdForn = table.Column<Guid>(nullable: false),
                    DescDocu = table.Column<string>(type: "varchar(150)", nullable: false),
                    IdEmpr = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLEntrInsu", x => x.IdEntrInsu);
                    table.ForeignKey(
                        name: "FK_PLEntrInsu_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                    table.ForeignKey(
                        name: "FK_PLEntrInsu_PLForn_IdForn",
                        column: x => x.IdForn,
                        principalTable: "PLForn",
                        principalColumn: "IdForn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLEntrInsu_PLInsu_IdInsu",
                        column: x => x.IdInsu,
                        principalTable: "PLInsu",
                        principalColumn: "IdInsu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLServRealPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    IdPlantacao = table.Column<Guid>(nullable: false),
                    IdTipoServReal = table.Column<int>(nullable: false),
                    DatServ = table.Column<DateTime>(nullable: false),
                    ValServ = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescObse = table.Column<string>(type: "varchar(2000)", nullable: true),
                    IdEmpr = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLServRealPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PLServRealPlan_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                    table.ForeignKey(
                        name: "FK_PLServRealPlan_PLPlan_IdPlantacao",
                        column: x => x.IdPlantacao,
                        principalTable: "PLPlan",
                        principalColumn: "IdPlan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLUtilInsu",
                columns: table => new
                {
                    IdUtilInsu = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    IdPlan = table.Column<Guid>(nullable: false),
                    DatUtil = table.Column<DateTime>(nullable: false),
                    ObsUtilInsu = table.Column<string>(type: "varchar(200)", nullable: true),
                    IdEmpr = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLUtilInsu", x => x.IdUtilInsu);
                    table.ForeignKey(
                        name: "FK_PLUtilInsu_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                    table.ForeignKey(
                        name: "FK_PLUtilInsu_PLPlan_IdPlan",
                        column: x => x.IdPlan,
                        principalTable: "PLPlan",
                        principalColumn: "IdPlan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLSaidInsu",
                columns: table => new
                {
                    IdSaidInsu = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    IdEntrInsu = table.Column<Guid>(nullable: false),
                    DatSaid = table.Column<DateTime>(nullable: false),
                    QtdSaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescSaid = table.Column<string>(type: "varchar(150)", nullable: false),
                    IdEmpr = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLSaidInsu", x => x.IdSaidInsu);
                    table.ForeignKey(
                        name: "FK_PLSaidInsu_PLEmpr_IdEmpr",
                        column: x => x.IdEmpr,
                        principalTable: "PLEmpr",
                        principalColumn: "IdEmpr");
                    table.ForeignKey(
                        name: "FK_PLSaidInsu_PLEntrInsu_IdEntrInsu",
                        column: x => x.IdEntrInsu,
                        principalTable: "PLEntrInsu",
                        principalColumn: "IdEntrInsu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLUtilInsuItem",
                columns: table => new
                {
                    IdUtilInsuItem = table.Column<Guid>(nullable: false),
                    DatCada = table.Column<DateTime>(nullable: false),
                    IdUtilInsu = table.Column<Guid>(nullable: false),
                    IdEntrInsu = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLUtilInsuItem", x => x.IdUtilInsuItem);
                    table.ForeignKey(
                        name: "FK_PLUtilInsuItem_PLEntrInsu_IdEntrInsu",
                        column: x => x.IdEntrInsu,
                        principalTable: "PLEntrInsu",
                        principalColumn: "IdEntrInsu");
                    table.ForeignKey(
                        name: "FK_PLUtilInsuItem_PLUtilInsu_IdUtilInsu",
                        column: x => x.IdUtilInsu,
                        principalTable: "PLUtilInsu",
                        principalColumn: "IdUtilInsu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLArePlan_IdEmpr",
                table: "PLArePlan",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLEntrInsu_IdEmpr",
                table: "PLEntrInsu",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLEntrInsu_IdForn",
                table: "PLEntrInsu",
                column: "IdForn");

            migrationBuilder.CreateIndex(
                name: "IX_PLEntrInsu_IdInsu",
                table: "PLEntrInsu",
                column: "IdInsu");

            migrationBuilder.CreateIndex(
                name: "IX_PLForn_IdEmpr",
                table: "PLForn",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLInsu_IdEmpr",
                table: "PLInsu",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLPlan_IdAreaPlan",
                table: "PLPlan",
                column: "IdAreaPlan");

            migrationBuilder.CreateIndex(
                name: "IX_PLPlan_IdEmpr",
                table: "PLPlan",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLSaidInsu_IdEmpr",
                table: "PLSaidInsu",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLSaidInsu_IdEntrInsu",
                table: "PLSaidInsu",
                column: "IdEntrInsu");

            migrationBuilder.CreateIndex(
                name: "IX_PLServRealPlan_IdEmpr",
                table: "PLServRealPlan",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLServRealPlan_IdPlantacao",
                table: "PLServRealPlan",
                column: "IdPlantacao");

            migrationBuilder.CreateIndex(
                name: "IX_PLUsua_IdEmpr",
                table: "PLUsua",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLUtilInsu_IdEmpr",
                table: "PLUtilInsu",
                column: "IdEmpr");

            migrationBuilder.CreateIndex(
                name: "IX_PLUtilInsu_IdPlan",
                table: "PLUtilInsu",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_PLUtilInsuItem_IdEntrInsu",
                table: "PLUtilInsuItem",
                column: "IdEntrInsu");

            migrationBuilder.CreateIndex(
                name: "IX_PLUtilInsuItem_IdUtilInsu",
                table: "PLUtilInsuItem",
                column: "IdUtilInsu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLSaidInsu");

            migrationBuilder.DropTable(
                name: "PLServRealPlan");

            migrationBuilder.DropTable(
                name: "PLUsua");

            migrationBuilder.DropTable(
                name: "PLUtilInsuItem");

            migrationBuilder.DropTable(
                name: "PLEntrInsu");

            migrationBuilder.DropTable(
                name: "PLUtilInsu");

            migrationBuilder.DropTable(
                name: "PLForn");

            migrationBuilder.DropTable(
                name: "PLInsu");

            migrationBuilder.DropTable(
                name: "PLPlan");

            migrationBuilder.DropTable(
                name: "PLArePlan");

            migrationBuilder.DropTable(
                name: "PLEmpr");
        }
    }
}
