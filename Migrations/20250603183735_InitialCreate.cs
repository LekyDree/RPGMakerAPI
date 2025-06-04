using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGMakerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbilityTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PointCost = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityTemplates_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnumDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnumDefinitions_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbilityTags",
                columns: table => new
                {
                    AbilityTemplateId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityTags", x => new { x.AbilityTemplateId, x.TagId });
                    table.ForeignKey(
                        name: "FK_AbilityTags_AbilityTemplates_AbilityTemplateId",
                        column: x => x.AbilityTemplateId,
                        principalTable: "AbilityTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbilityTemplateLineages",
                columns: table => new
                {
                    ChildAbilityTemplateId = table.Column<int>(type: "int", nullable: false),
                    ParentAbilityTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityTemplateLineages", x => new { x.ChildAbilityTemplateId, x.ParentAbilityTemplateId });
                    table.ForeignKey(
                        name: "FK_AbilityTemplateLineages_AbilityTemplates_ChildAbilityTemplat~",
                        column: x => x.ChildAbilityTemplateId,
                        principalTable: "AbilityTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityTemplateLineages_AbilityTemplates_ParentAbilityTempla~",
                        column: x => x.ParentAbilityTemplateId,
                        principalTable: "AbilityTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AttributeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AbilityTemplateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeTemplates_AbilityTemplates_AbilityTemplateId",
                        column: x => x.AbilityTemplateId,
                        principalTable: "AbilityTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbilityInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    AbilityTemplateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PointCost = table.Column<int>(type: "int", nullable: false),
                    PointsAllocated = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityInstances_AbilityTemplates_AbilityTemplateId",
                        column: x => x.AbilityTemplateId,
                        principalTable: "AbilityTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityInstances_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnumOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnumDefinitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnumOptions_EnumDefinitions_EnumDefinitionId",
                        column: x => x.EnumDefinitionId,
                        principalTable: "EnumDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BoolAttributeValueTemplates",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoolAttributeValueTemplates", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_BoolAttributeValueTemplates_AttributeTemplates_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FloatAttributeValueTemplates",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloatAttributeValueTemplates", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_FloatAttributeValueTemplates_AttributeTemplates_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StringAttributeValueTemplates",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringAttributeValueTemplates", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_StringAttributeValueTemplates_AttributeTemplates_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AttributeInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AbilityInstanceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeInstances_AbilityInstances_AbilityInstanceId",
                        column: x => x.AbilityInstanceId,
                        principalTable: "AbilityInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnumAttributeValueTemplates",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    EnumDefinitionId = table.Column<int>(type: "int", nullable: false),
                    DefaultOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumAttributeValueTemplates", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_EnumAttributeValueTemplates_AttributeTemplates_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnumAttributeValueTemplates_EnumDefinitions_EnumDefinitionId",
                        column: x => x.EnumDefinitionId,
                        principalTable: "EnumDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnumAttributeValueTemplates_EnumOptions_DefaultOptionId",
                        column: x => x.DefaultOptionId,
                        principalTable: "EnumOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BoolAttributeValueInstances",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CurrentValue = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoolAttributeValueInstances", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_BoolAttributeValueInstances_AttributeInstances_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnumAttributeValueInstances",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    DefaultOptionId = table.Column<int>(type: "int", nullable: false),
                    CurrentOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumAttributeValueInstances", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_EnumAttributeValueInstances_AttributeInstances_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnumAttributeValueInstances_EnumOptions_CurrentOptionId",
                        column: x => x.CurrentOptionId,
                        principalTable: "EnumOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnumAttributeValueInstances_EnumOptions_DefaultOptionId",
                        column: x => x.DefaultOptionId,
                        principalTable: "EnumOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FloatAttributeValueInstances",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<float>(type: "float", nullable: false),
                    CurrentValue = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloatAttributeValueInstances", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_FloatAttributeValueInstances_AttributeInstances_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StringAttributeValueInstances",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentValue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringAttributeValueInstances", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_StringAttributeValueInstances_AttributeInstances_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityInstances_AbilityTemplateId",
                table: "AbilityInstances",
                column: "AbilityTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityInstances_CharacterId",
                table: "AbilityInstances",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityTags_TagId",
                table: "AbilityTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityTemplateLineages_ParentAbilityTemplateId",
                table: "AbilityTemplateLineages",
                column: "ParentAbilityTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityTemplates_CreatedByUserId",
                table: "AbilityTemplates",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeInstances_AbilityInstanceId",
                table: "AttributeInstances",
                column: "AbilityInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTemplates_AbilityTemplateId",
                table: "AttributeTemplates",
                column: "AbilityTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumAttributeValueInstances_CurrentOptionId",
                table: "EnumAttributeValueInstances",
                column: "CurrentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumAttributeValueInstances_DefaultOptionId",
                table: "EnumAttributeValueInstances",
                column: "DefaultOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumAttributeValueTemplates_DefaultOptionId",
                table: "EnumAttributeValueTemplates",
                column: "DefaultOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumAttributeValueTemplates_EnumDefinitionId",
                table: "EnumAttributeValueTemplates",
                column: "EnumDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumDefinitions_CreatedByUserId",
                table: "EnumDefinitions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumOptions_EnumDefinitionId",
                table: "EnumOptions",
                column: "EnumDefinitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityTags");

            migrationBuilder.DropTable(
                name: "AbilityTemplateLineages");

            migrationBuilder.DropTable(
                name: "BoolAttributeValueInstances");

            migrationBuilder.DropTable(
                name: "BoolAttributeValueTemplates");

            migrationBuilder.DropTable(
                name: "EnumAttributeValueInstances");

            migrationBuilder.DropTable(
                name: "EnumAttributeValueTemplates");

            migrationBuilder.DropTable(
                name: "FloatAttributeValueInstances");

            migrationBuilder.DropTable(
                name: "FloatAttributeValueTemplates");

            migrationBuilder.DropTable(
                name: "StringAttributeValueInstances");

            migrationBuilder.DropTable(
                name: "StringAttributeValueTemplates");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "EnumOptions");

            migrationBuilder.DropTable(
                name: "AttributeInstances");

            migrationBuilder.DropTable(
                name: "AttributeTemplates");

            migrationBuilder.DropTable(
                name: "EnumDefinitions");

            migrationBuilder.DropTable(
                name: "AbilityInstances");

            migrationBuilder.DropTable(
                name: "AbilityTemplates");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
