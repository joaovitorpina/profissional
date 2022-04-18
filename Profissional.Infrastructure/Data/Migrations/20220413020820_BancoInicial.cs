using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profissional.Infrastructure.Data.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipos_profissional",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipos_profissional", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especialidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo_profissional_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_especialidades", x => x.id);
                    table.ForeignKey(
                        name: "fk_especialidades_tipos_profissional_tipo_profissional_id",
                        column: x => x.tipo_profissional_id,
                        principalTable: "tipos_profissional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profissionais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url_amigavel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sobre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    unidade_id = table.Column<int>(type: "int", nullable: false),
                    imagem_url_perfil = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    conselho = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero_identificacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<long>(type: "bigint", nullable: true),
                    celular = table.Column<long>(type: "bigint", nullable: true),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    site = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    facebook = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    instagram = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    youtube = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    linkedin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    recomendado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tipo_profissional_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profissionais", x => x.id);
                    table.ForeignKey(
                        name: "fk_profissionais_tipos_profissional_tipo_profissional_id",
                        column: x => x.tipo_profissional_id,
                        principalTable: "tipos_profissional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "convenios",
                columns: table => new
                {
                    profissional_id = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    profissional_model_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_convenios", x => new { x.profissional_id, x.descricao });
                    table.ForeignKey(
                        name: "fk_convenios_profissionais_profissional_model_id",
                        column: x => x.profissional_model_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    profissional_id = table.Column<int>(type: "int", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cep = table.Column<long>(type: "bigint", nullable: false),
                    bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enderecos", x => new { x.profissional_id, x.numero, x.cep, x.logradouro });
                    table.ForeignKey(
                        name: "fk_enderecos_profissionais_profissional_model_id",
                        column: x => x.profissional_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especialidade_profissional_model",
                columns: table => new
                {
                    especialidades_id = table.Column<int>(type: "int", nullable: false),
                    profissionais_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_especialidade_profissional_model", x => new { x.especialidades_id, x.profissionais_id });
                    table.ForeignKey(
                        name: "fk_especialidade_profissional_model_especialidades_especialidad",
                        column: x => x.especialidades_id,
                        principalTable: "especialidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_especialidade_profissional_model_profissionais_profissionais",
                        column: x => x.profissionais_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "midias",
                columns: table => new
                {
                    profissional_id = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo_midia = table.Column<int>(type: "int", nullable: false),
                    profissional_model_id = table.Column<int>(type: "int", nullable: false),
                    discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url_thumbnail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_midias", x => new { x.profissional_id, x.titulo, x.url, x.tipo_midia });
                    table.ForeignKey(
                        name: "fk_midias_profissionais_profissional_model_id",
                        column: x => x.profissional_model_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tratamentos",
                columns: table => new
                {
                    profissional_id = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    profissional_model_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tratamentos", x => new { x.descricao, x.profissional_id });
                    table.ForeignKey(
                        name: "fk_tratamentos_profissionais_profissional_model_id",
                        column: x => x.profissional_model_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "whatsapps",
                columns: table => new
                {
                    profissional_id = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<long>(type: "bigint", nullable: false),
                    principal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    profissional_model_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_whatsapps", x => new { x.profissional_id, x.principal, x.numero });
                    table.ForeignKey(
                        name: "fk_whatsapps_profissionais_profissional_model_id",
                        column: x => x.profissional_model_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_convenios_profissional_model_id",
                table: "convenios",
                column: "profissional_model_id");

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_profissional_id",
                table: "enderecos",
                column: "profissional_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_especialidade_profissional_model_profissionais_id",
                table: "especialidade_profissional_model",
                column: "profissionais_id");

            migrationBuilder.CreateIndex(
                name: "ix_especialidades_tipo_profissional_id",
                table: "especialidades",
                column: "tipo_profissional_id");

            migrationBuilder.CreateIndex(
                name: "ix_midias_profissional_model_id",
                table: "midias",
                column: "profissional_model_id");

            migrationBuilder.CreateIndex(
                name: "ix_profissionais_tipo_profissional_id",
                table: "profissionais",
                column: "tipo_profissional_id");

            migrationBuilder.CreateIndex(
                name: "ix_tratamentos_profissional_model_id",
                table: "tratamentos",
                column: "profissional_model_id");

            migrationBuilder.CreateIndex(
                name: "ix_whatsapps_profissional_model_id",
                table: "whatsapps",
                column: "profissional_model_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "convenios");

            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "especialidade_profissional_model");

            migrationBuilder.DropTable(
                name: "midias");

            migrationBuilder.DropTable(
                name: "tratamentos");

            migrationBuilder.DropTable(
                name: "whatsapps");

            migrationBuilder.DropTable(
                name: "especialidades");

            migrationBuilder.DropTable(
                name: "profissionais");

            migrationBuilder.DropTable(
                name: "tipos_profissional");
        }
    }
}
