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
                name: "tipos_midia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipos_midia", x => x.id);
                })
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
                    endereco_logradouro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco_numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco_bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco_cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco_estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco_cep = table.Column<long>(type: "bigint", nullable: true),
                    tipo_profissional_id = table.Column<int>(type: "int", nullable: false),
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
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_convenios", x => new { x.profissional_id, x.id });
                    table.ForeignKey(
                        name: "fk_convenios_profissionais_profissional_id",
                        column: x => x.profissional_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especialidade_profissional",
                columns: table => new
                {
                    especialidades_id = table.Column<int>(type: "int", nullable: false),
                    profissionais_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_especialidade_profissional", x => new { x.especialidades_id, x.profissionais_id });
                    table.ForeignKey(
                        name: "fk_especialidade_profissional_especialidades_especialidades_id",
                        column: x => x.especialidades_id,
                        principalTable: "especialidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_especialidade_profissional_profissionais_profissionais_id",
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
                    titulo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    _tipo_midia_id = table.Column<int>(type: "int", nullable: false),
                    discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    profissional_id = table.Column<int>(type: "int", nullable: true),
                    url_thumbnail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_midias", x => new { x.titulo, x.url });
                    table.ForeignKey(
                        name: "fk_midias_profissionais_profissional_id",
                        column: x => x.profissional_id,
                        principalTable: "profissionais",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_midias_tipos_midia_tipo_midia_temp_id",
                        column: x => x._tipo_midia_id,
                        principalTable: "tipos_midia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tratamentos",
                columns: table => new
                {
                    profissional_id = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tratamentos", x => new { x.profissional_id, x.id });
                    table.ForeignKey(
                        name: "fk_tratamentos_profissionais_profissional_id",
                        column: x => x.profissional_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "whatsapp",
                columns: table => new
                {
                    profissional_id = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<long>(type: "bigint", nullable: false),
                    principal = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_whatsapp", x => new { x.profissional_id, x.id });
                    table.ForeignKey(
                        name: "fk_whatsapp_profissionais_profissional_id",
                        column: x => x.profissional_id,
                        principalTable: "profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_especialidade_profissional_profissionais_id",
                table: "especialidade_profissional",
                column: "profissionais_id");

            migrationBuilder.CreateIndex(
                name: "ix_especialidades_tipo_profissional_id",
                table: "especialidades",
                column: "tipo_profissional_id");

            migrationBuilder.CreateIndex(
                name: "ix_midias__tipo_midia_id",
                table: "midias",
                column: "_tipo_midia_id");

            migrationBuilder.CreateIndex(
                name: "ix_midias_profissional_id",
                table: "midias",
                column: "profissional_id");

            migrationBuilder.CreateIndex(
                name: "ix_profissionais_tipo_profissional_id",
                table: "profissionais",
                column: "tipo_profissional_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "convenios");

            migrationBuilder.DropTable(
                name: "especialidade_profissional");

            migrationBuilder.DropTable(
                name: "midias");

            migrationBuilder.DropTable(
                name: "tratamentos");

            migrationBuilder.DropTable(
                name: "whatsapp");

            migrationBuilder.DropTable(
                name: "especialidades");

            migrationBuilder.DropTable(
                name: "tipos_midia");

            migrationBuilder.DropTable(
                name: "profissionais");

            migrationBuilder.DropTable(
                name: "tipos_profissional");
        }
    }
}
