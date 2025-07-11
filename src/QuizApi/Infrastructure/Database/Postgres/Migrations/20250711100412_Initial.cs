using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApi.Infrastructure.Database.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quiz",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    type = table.Column<string>(type: "text", nullable: false),
                    visibility = table.Column<string>(type: "text", nullable: false),
                    access_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    is_anonymous_allowed = table.Column<bool>(type: "boolean", nullable: false),
                    duration_minutes = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quiz", x => x.id);
                    table.ForeignKey(
                        name: "fk_quiz_user_author_id",
                        column: x => x.author_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quiz_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_text = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false),
                    time_limit_seconds = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_quiz_quiz_id",
                        column: x => x.quiz_id,
                        principalTable: "quiz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quiz_analytic",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quiz_id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_responses = table.Column<int>(type: "integer", nullable: false),
                    average_completion_time = table.Column<double>(type: "double precision", nullable: false),
                    completion_rate = table.Column<double>(type: "double precision", nullable: false),
                    last_calculated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quiz_analytic", x => x.id);
                    table.ForeignKey(
                        name: "fk_quiz_analytic_quiz_quiz_id",
                        column: x => x.quiz_id,
                        principalTable: "quiz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "response",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quiz_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    session_id = table.Column<Guid>(type: "uuid", nullable: true),
                    ip_address_hash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    completed_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_response", x => x.id);
                    table.ForeignKey(
                        name: "fk_response_quiz_quiz_id",
                        column: x => x.quiz_id,
                        principalTable: "quiz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answer_option",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    option_text = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    question_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_answer_option", x => x.id);
                    table.ForeignKey(
                        name: "fk_answer_option_question_question_id",
                        column: x => x.question_id,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_answer_option_question_question_id1",
                        column: x => x.question_id1,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "response_answer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    response_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    selected_answer_ids = table.Column<Guid[]>(type: "uuid[]", nullable: false),
                    text_answer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    rating_value = table.Column<int>(type: "integer", nullable: false),
                    answered_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    response_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_response_answer", x => x.id);
                    table.ForeignKey(
                        name: "fk_response_answer_question_question_id",
                        column: x => x.question_id,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_response_answer_question_question_id1",
                        column: x => x.question_id1,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_response_answer_response_response_id",
                        column: x => x.response_id,
                        principalTable: "response",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_response_answer_response_response_id1",
                        column: x => x.response_id1,
                        principalTable: "response",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_answer_option_question_id",
                table: "answer_option",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_answer_option_question_id1",
                table: "answer_option",
                column: "question_id1");

            migrationBuilder.CreateIndex(
                name: "ix_question_quiz_id",
                table: "question",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "ix_quiz_author_id",
                table: "quiz",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_quiz_analytic_quiz_id",
                table: "quiz_analytic",
                column: "quiz_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_response_quiz_id",
                table: "response",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "ix_response_answer_question_id",
                table: "response_answer",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_response_answer_question_id1",
                table: "response_answer",
                column: "question_id1");

            migrationBuilder.CreateIndex(
                name: "ix_response_answer_response_id",
                table: "response_answer",
                column: "response_id");

            migrationBuilder.CreateIndex(
                name: "ix_response_answer_response_id1",
                table: "response_answer",
                column: "response_id1");

            migrationBuilder.CreateIndex(
                name: "ix_user_user_name",
                table: "user",
                column: "user_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer_option");

            migrationBuilder.DropTable(
                name: "quiz_analytic");

            migrationBuilder.DropTable(
                name: "response_answer");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "response");

            migrationBuilder.DropTable(
                name: "quiz");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
