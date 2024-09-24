using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternPipeline.Migrations
{
    /// <inheritdoc />
    public partial class Demo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JD",
                columns: table => new
                {
                    jd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jd_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    jd_text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JD__36903D523DA0531D", x => x.jd_id);
                });

            migrationBuilder.CreateTable(
                name: "tst",
                columns: table => new
                {
                    test = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    task_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    task_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    task_desc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Task__0492148D8E76A02C", x => x.task_id);
                    table.ForeignKey(
                        name: "FK_Task_JD",
                        column: x => x.task_desc,
                        principalTable: "JD",
                        principalColumn: "jd_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    task_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subject__5004F660390E5C32", x => x.subject_id);
                    table.ForeignKey(
                        name: "FK_Subject_Task",
                        column: x => x.task_id,
                        principalTable: "Task",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    topic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    topic_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    subject_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Topic__D5DAA3E96AAD713E", x => x.topic_id);
                    table.ForeignKey(
                        name: "FK_Topic_Subject",
                        column: x => x.subject_id,
                        principalTable: "Subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_task_id",
                table: "Subject",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_Task_task_desc",
                table: "Task",
                column: "task_desc");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_subject_id",
                table: "Topic",
                column: "subject_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "tst");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "JD");
        }
    }
}
