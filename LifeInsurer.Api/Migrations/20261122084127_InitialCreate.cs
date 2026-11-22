using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsurer.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimantId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedOfficerId = table.Column<int>(type: "INTEGER", nullable: true),
                    PolicyNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MarketCode = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: false),
                    IncidentDescription = table.Column<string>(type: "TEXT", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstimatedLiability = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Users_AssignedOfficerId",
                        column: x => x.AssignedOfficerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claims_Users_ClaimantId",
                        column: x => x.ClaimantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimActivities_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimActivities_Users_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimId = table.Column<int>(type: "INTEGER", nullable: false),
                    OfficerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Recommendation = table.Column<string>(type: "TEXT", nullable: false),
                    AssessmentRemarks = table.Column<string>(type: "TEXT", nullable: false),
                    RecommendedAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    AssessedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimAssessments_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimAssessments_Users_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimId = table.Column<int>(type: "INTEGER", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentType = table.Column<string>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    UploadedByUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimDocuments_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimDocuments_Users_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimInformationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestedByUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimInformationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimInformationRequests_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimInformationRequests_Users_RequestedByUserId",
                        column: x => x.RequestedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApproverId = table.Column<int>(type: "INTEGER", nullable: false),
                    Decision = table.Column<string>(type: "TEXT", nullable: false),
                    ErrorSource = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimReviews_ClaimAssessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "ClaimAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimReviews_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimReviews_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimActivities_ActorId",
                table: "ClaimActivities",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimActivities_ClaimId",
                table: "ClaimActivities",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimAssessments_ClaimId",
                table: "ClaimAssessments",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimAssessments_OfficerId",
                table: "ClaimAssessments",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocuments_ClaimId",
                table: "ClaimDocuments",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocuments_UploadedByUserId",
                table: "ClaimDocuments",
                column: "UploadedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimInformationRequests_ClaimId",
                table: "ClaimInformationRequests",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimInformationRequests_RequestedByUserId",
                table: "ClaimInformationRequests",
                column: "RequestedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimReviews_ApproverId",
                table: "ClaimReviews",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimReviews_AssessmentId",
                table: "ClaimReviews",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimReviews_ClaimId",
                table: "ClaimReviews",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_AssignedOfficerId",
                table: "Claims",
                column: "AssignedOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimantId",
                table: "Claims",
                column: "ClaimantId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimNumber",
                table: "Claims",
                column: "ClaimNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimActivities");

            migrationBuilder.DropTable(
                name: "ClaimDocuments");

            migrationBuilder.DropTable(
                name: "ClaimInformationRequests");

            migrationBuilder.DropTable(
                name: "ClaimReviews");

            migrationBuilder.DropTable(
                name: "ClaimAssessments");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
