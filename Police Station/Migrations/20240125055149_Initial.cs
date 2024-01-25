using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Police_Station.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseApplications",
                columns: table => new
                {
                    CaseApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VictimName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VictimAge = table.Column<int>(type: "int", nullable: false),
                    VictimAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VictimProfession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VictimGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VictimMaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VictimNID = table.Column<long>(type: "bigint", nullable: true),
                    VictimPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrimeSpot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectAge = table.Column<int>(type: "int", nullable: true),
                    SuspectAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectProfession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WitnessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WitnessAge = table.Column<int>(type: "int", nullable: true),
                    WitnessAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WitnessGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WitnessProfession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WitnessPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseApplications", x => x.CaseApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "PoliceOfficers",
                columns: table => new
                {
                    PoliceOfficerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BadgeNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BadgeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: true),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Supervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceOfficers", x => x.PoliceOfficerId);
                });

            migrationBuilder.CreateTable(
                name: "Prisons",
                columns: table => new
                {
                    PrisonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrisonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisons", x => x.PrisonId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Criminals",
                columns: table => new
                {
                    CriminalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseApplicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criminals", x => x.CriminalId);
                    table.ForeignKey(
                        name: "FK_Criminals_CaseApplications_CaseApplicationId",
                        column: x => x.CaseApplicationId,
                        principalTable: "CaseApplications",
                        principalColumn: "CaseApplicationId");
                });

            migrationBuilder.CreateTable(
                name: "InvestigationInfos",
                columns: table => new
                {
                    InvestigationInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseApplicationId = table.Column<int>(type: "int", nullable: true),
                    PoliceOfficerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationInfos", x => x.InvestigationInfoId);
                    table.ForeignKey(
                        name: "FK_InvestigationInfos_CaseApplications_CaseApplicationId",
                        column: x => x.CaseApplicationId,
                        principalTable: "CaseApplications",
                        principalColumn: "CaseApplicationId");
                    table.ForeignKey(
                        name: "FK_InvestigationInfos_PoliceOfficers_PoliceOfficerId",
                        column: x => x.PoliceOfficerId,
                        principalTable: "PoliceOfficers",
                        principalColumn: "PoliceOfficerId");
                });

            migrationBuilder.CreateTable(
                name: "ReportAnalysis",
                columns: table => new
                {
                    ReportAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalysisResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingDate = table.Column<DateTime>(type: "date", nullable: false),
                    Conclusions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseApplicationId = table.Column<int>(type: "int", nullable: true),
                    PoliceOfficerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAnalysis", x => x.ReportAnalysisId);
                    table.ForeignKey(
                        name: "FK_ReportAnalysis_CaseApplications_CaseApplicationId",
                        column: x => x.CaseApplicationId,
                        principalTable: "CaseApplications",
                        principalColumn: "CaseApplicationId");
                    table.ForeignKey(
                        name: "FK_ReportAnalysis_PoliceOfficers_PoliceOfficerId",
                        column: x => x.PoliceOfficerId,
                        principalTable: "PoliceOfficers",
                        principalColumn: "PoliceOfficerId");
                });

            migrationBuilder.CreateTable(
                name: "PrisonRecords",
                columns: table => new
                {
                    PrisonRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriminalId = table.Column<int>(type: "int", nullable: true),
                    PrisonId = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: true),
                    ReasonForImprisonment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonRecords", x => x.PrisonRecordId);
                    table.ForeignKey(
                        name: "FK_PrisonRecords_Criminals_CriminalId",
                        column: x => x.CriminalId,
                        principalTable: "Criminals",
                        principalColumn: "CriminalId");
                    table.ForeignKey(
                        name: "FK_PrisonRecords_Prisons_PrisonId",
                        column: x => x.PrisonId,
                        principalTable: "Prisons",
                        principalColumn: "PrisonId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70cecf66-f00e-406f-ae29-0feb2183689c", null, "Admin", "ADMIN" },
                    { "f672f1be-450b-4899-b9a5-13a0ff856015", null, "Police", "Police" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0442b285-375d-48a0-8f47-d6e21bf342c9", 0, "e07b5879-a435-408f-b60d-392f4f04afab", "Sajib@example.com", false, false, null, "SAJIB@EXAMPLE.COM", "SAJIB@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEsTh0JaJT1CjokGeyw/93XtM7xsqI3ZnPa3QOGpwokdnCuJKZAi5atxYq+EzDu8JQ==", null, false, "05fb5df2-58ad-4bb9-8671-090c2d98c7e9", false, "Sajib@example.com" },
                    { "4b9d054d-bcb0-475e-96be-7e07d5ee3b85", 0, "7fefed17-02e8-4157-9ba3-89933ed37345", "Police1@gmail.com", false, false, null, "POLICE1@GMAIL.COM", "POLICE1@GMAIL.COM", "AQAAAAIAAYagAAAAELrjzpr1yEX8N/XGGu+gLZeEF9RJCPfGUDejnOepYAq5kI7yXsR/mQseJhS+xGC/8g==", null, false, "493bdc10-858f-437c-898b-d063e03bc109", false, "Police1@gmail.com" },
                    { "b7f46612-41d2-47ba-af30-f957a680d92a", 0, "efe5f48c-1d7f-4953-aec7-fd8fc4a38ff4", "Ibrahim@example.com", false, false, null, "IBRAHIM@EXAMPLE.COM", "IBRAHIM@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKJqNaTOyfGv7SBSEbepjImVHMBiYXS6VOY0LdUeBKfo2AQaqYUICRAV/VNCj0Wimg==", null, false, "646d6950-0d0b-4d07-8e73-b78335961b26", false, "Ibrahim@example.com" },
                    { "c02f71c8-a822-4b3a-900c-5c62478b32f0", 0, "fa52cb74-1b19-4279-bf1a-136be9f25bf6", "Admin1@gmail.com", false, false, null, "ADMIN1@GMAIL.COM", "ADMIN1@GMAIL.COM", "AQAAAAIAAYagAAAAELpEJwt9NoW60ir+opL5fhT759S6YNST7PWxQIanp0MNBHte1fB/82FeVokXLbJV9g==", null, false, "edc9265a-3705-4213-919e-f3fe836bec06", false, "Admin1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "PoliceOfficers",
                columns: new[] { "PoliceOfficerId", "BadgeNumber", "BadgeType", "DateOfBirth", "Department", "JoinDate", "Name", "Rank", "Salary", "Shift", "Supervisor" },
                values: new object[,]
                {
                    { 1, 123, "Metal", new DateTime(1980, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Homicide", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer A", "Sergeant", 50000.0, "Day", "Chief B" },
                    { 2, 124, "Plastic", new DateTime(1981, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robbery", new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer B", "Lieutenant", 60000.0, "Night", "Chief A" },
                    { 3, 125, "Metal", new DateTime(1982, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fraud", new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer C", "Captain", 70000.0, "Day", "Chief B" },
                    { 4, 126, "Plastic", new DateTime(1983, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Narcotics", new DateTime(2003, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer D", "Detective", 80000.0, "Night", "Chief A" },
                    { 5, 127, "Metal", new DateTime(1984, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrol", new DateTime(2004, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer E", "Inspector", 90000.0, "Day", "Chief B" },
                    { 6, 128, "Plastic", new DateTime(1985, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Traffic", new DateTime(2005, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer F", "Sergeant", 100000.0, "Night", "Chief A" },
                    { 7, 129, "Metal", new DateTime(1986, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Homicide", new DateTime(2006, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer G", "Lieutenant", 110000.0, "Day", "Chief B" },
                    { 8, 130, "Plastic", new DateTime(1987, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robbery", new DateTime(2007, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer H", "Captain", 120000.0, "Night", "Chief A" },
                    { 9, 131, "Metal", new DateTime(1988, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fraud", new DateTime(2008, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer I", "Detective", 130000.0, "Day", "Chief B" },
                    { 10, 132, "Plastic", new DateTime(1989, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Narcotics", new DateTime(2009, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officer J", "Inspector", 140000.0, "Night", "Chief A" }
                });

            migrationBuilder.InsertData(
                table: "Prisons",
                columns: new[] { "PrisonId", "Capacity", "ContactInfo", "Location", "PrisonName" },
                values: new object[,]
                {
                    { 1, 8000, "+8801712345678", "Keraniganj, Dhaka", "Dhaka Central Jail" },
                    { 2, 2000, "+8801812312345", "Chittagong", "Chittagong Central Jail" },
                    { 3, 1500, "+8801912341234", "Rajshahi", "Rajshahi Central Jail" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "70cecf66-f00e-406f-ae29-0feb2183689c", "0442b285-375d-48a0-8f47-d6e21bf342c9" },
                    { "f672f1be-450b-4899-b9a5-13a0ff856015", "4b9d054d-bcb0-475e-96be-7e07d5ee3b85" },
                    { "70cecf66-f00e-406f-ae29-0feb2183689c", "b7f46612-41d2-47ba-af30-f957a680d92a" },
                    { "70cecf66-f00e-406f-ae29-0feb2183689c", "c02f71c8-a822-4b3a-900c-5c62478b32f0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Criminals_CaseApplicationId",
                table: "Criminals",
                column: "CaseApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationInfos_CaseApplicationId",
                table: "InvestigationInfos",
                column: "CaseApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationInfos_PoliceOfficerId",
                table: "InvestigationInfos",
                column: "PoliceOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrisonRecords_CriminalId",
                table: "PrisonRecords",
                column: "CriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrisonRecords_PrisonId",
                table: "PrisonRecords",
                column: "PrisonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAnalysis_CaseApplicationId",
                table: "ReportAnalysis",
                column: "CaseApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAnalysis_PoliceOfficerId",
                table: "ReportAnalysis",
                column: "PoliceOfficerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "InvestigationInfos");

            migrationBuilder.DropTable(
                name: "PrisonRecords");

            migrationBuilder.DropTable(
                name: "ReportAnalysis");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Criminals");

            migrationBuilder.DropTable(
                name: "Prisons");

            migrationBuilder.DropTable(
                name: "PoliceOfficers");

            migrationBuilder.DropTable(
                name: "CaseApplications");
        }
    }
}
