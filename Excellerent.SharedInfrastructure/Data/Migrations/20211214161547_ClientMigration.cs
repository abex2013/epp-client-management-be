using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excellerent.SharedInfrastructure.Data.Migrations
{
    public partial class ClientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ResumeUpload = table.Column<string>(type: "text", nullable: true),
                    ProfilePictureUpload = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientStatus = table.Column<string>(type: "text", nullable: true),
                    ManagerAssigned = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ClientStatus",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStatus", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    DataType = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDetails",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SubCategoryGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyDeviceCode = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "text", nullable: true),
                    BusinessUnit = table.Column<string>(type: "text", nullable: true),
                    IsWorking = table.Column<string>(type: "text", nullable: true),
                    AllocateTo = table.Column<string>(type: "text", nullable: true),
                    DeviceClassificationGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Purchaser = table.Column<string>(type: "text", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    Warranty = table.Column<string>(type: "text", nullable: true),
                    WarrantyEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDetails", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "EducationProgrammes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationProgrammes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyAddresses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    StateRegionProvice = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    SubCityZone = table.Column<string>(type: "text", nullable: true),
                    Woreda = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyAddresses", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContactsModel",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    FatherName = table.Column<string>(type: "text", nullable: true),
                    GrandFatherName = table.Column<string>(type: "text", nullable: true),
                    Relationship = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    phoneNumber2 = table.Column<string>(type: "text", nullable: true),
                    phoneNumber3 = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    email2 = table.Column<string>(type: "text", nullable: true),
                    email3 = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    stateRegionProvice = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    subCityZone = table.Column<string>(type: "text", nullable: true),
                    woreda = table.Column<string>(type: "text", nullable: true),
                    houseNumber = table.Column<string>(type: "text", nullable: true),
                    postalCode = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContactsModel", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "FieldOfStudie",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    EducationName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfStudie", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirment",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    JobDescriptionName = table.Column<string>(type: "text", nullable: true),
                    JobBrief = table.Column<string>(type: "text", nullable: true),
                    JobResponsiblity = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirment", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PositionToApply",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionToApply", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ProficiencyLevel",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProficiencyLevel", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusName = table.Column<string>(type: "text", nullable: true),
                    AllowResource = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "SkillSet",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSet", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheet",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ToDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalHours = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheet", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ClientDetails",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesPersonGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientStatusGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetails", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ClientDetails_ClientStatus_ClientStatusGuid",
                        column: x => x.ClientStatusGuid,
                        principalTable: "ClientStatus",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutyBranches",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyBranches", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_DutyBranches_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    FatherName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    GrandfatherName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    MobilePhone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Phone1 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Phone2 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    PersonalEmail = table.Column<string>(type: "text", nullable: false),
                    PersonalEmail2 = table.Column<string>(type: "text", nullable: true),
                    PersonalEmail3 = table.Column<string>(type: "text", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    EmergencyContactGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Employees_EmergencyContactsModel_EmergencyContactGuid",
                        column: x => x.EmergencyContactGuid,
                        principalTable: "EmergencyContactsModel",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    EducationProgrammeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Institution = table.Column<string>(type: "text", nullable: true),
                    FieldOfStudyId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    OtherFieldOfStudy = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Educations_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_EducationProgrammes_EducationProgrammeId",
                        column: x => x.EducationProgrammeId,
                        principalTable: "EducationProgrammes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_FieldOfStudie_FieldOfStudyId",
                        column: x => x.FieldOfStudyId,
                        principalTable: "FieldOfStudie",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantAreaOfInterest",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionToApplyID = table.Column<Guid>(type: "uuid", nullable: false),
                    LuPositionToApplyGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ProficiencyLevelID = table.Column<Guid>(type: "uuid", nullable: false),
                    YearsOfExpierence = table.Column<int>(type: "integer", nullable: false),
                    MonthOfExpierence = table.Column<int>(type: "integer", nullable: false),
                    PrimarySkillSetID = table.Column<string>(type: "text", nullable: true),
                    SecondarySkillSetID = table.Column<string>(type: "text", nullable: true),
                    OtherSkillSet = table.Column<string>(type: "text", nullable: true),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantAreaOfInterest", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ApplicantAreaOfInterest_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantAreaOfInterest_PositionToApply_LuPositionToApplyGu~",
                        column: x => x.LuPositionToApplyGuid,
                        principalTable: "PositionToApply",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantAreaOfInterest_ProficiencyLevel_ProficiencyLevelID",
                        column: x => x.ProficiencyLevelID,
                        principalTable: "ProficiencyLevel",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectName = table.Column<string>(type: "text", nullable: true),
                    ProjectType = table.Column<int>(type: "integer", nullable: false),
                    SupervisorGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectStatusGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Project_Client_ClientGuid",
                        column: x => x.ClientGuid,
                        principalTable: "Client",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_ProjectStatus_ProjectStatusGuid",
                        column: x => x.ProjectStatusGuid,
                        principalTable: "ProjectStatus",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LUPositionSkillSet",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    LUPositionToApplyId = table.Column<Guid>(type: "uuid", nullable: false),
                    LUSkillSetId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LUPositionSkillSet", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LUPositionSkillSet_PositionToApply_LUPositionToApplyId",
                        column: x => x.LUPositionToApplyId,
                        principalTable: "PositionToApply",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LUPositionSkillSet_SkillSet_LUSkillSetId",
                        column: x => x.LUSkillSetId,
                        principalTable: "SkillSet",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillPositionAssociation",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionToApplyID = table.Column<int>(type: "integer", nullable: false),
                    luPositionToApplyGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PrimarySkillSetID = table.Column<int>(type: "integer", nullable: false),
                    skillSetGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    SecondarySkillSetID = table.Column<int>(type: "integer", nullable: false),
                    OtherSkillSet = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillPositionAssociation", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_SkillPositionAssociation_PositionToApply_luPositionToApplyG~",
                        column: x => x.luPositionToApplyGuid,
                        principalTable: "PositionToApply",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillPositionAssociation_SkillSet_skillSetGuid",
                        column: x => x.skillSetGuid,
                        principalTable: "SkillSet",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeEntry",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Hour = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimesheetGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEntry", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TimeEntry_TimeSheet_TimesheetGuid",
                        column: x => x.TimesheetGuid,
                        principalTable: "TimeSheet",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetAprovals",
                columns: table => new
                {
                    TimesheetId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetAprovals", x => new { x.TimesheetId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_TimesheetAprovals_TimeSheet_TimesheetId",
                        column: x => x.TimesheetId,
                        principalTable: "TimeSheet",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingAddresses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Affliation = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ClientDetailsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddresses", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_BillingAddresses_ClientDetails_ClientDetailsGuid",
                        column: x => x.ClientDetailsGuid,
                        principalTable: "ClientDetails",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientContacts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactPersonName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberPrefix = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ClientDetailsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContacts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ClientContacts_ClientDetails_ClientDetailsGuid",
                        column: x => x.ClientDetailsGuid,
                        principalTable: "ClientDetails",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContacts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientDetailsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContacts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CompanyContacts_ClientDetails_ClientDetailsGuid",
                        column: x => x.ClientDetailsGuid,
                        principalTable: "ClientDetails",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperatingAddresses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ClientDetailsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingAddresses", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_OperatingAddresses_ClientDetails_ClientDetailsGuid",
                        column: x => x.ClientDetailsGuid,
                        principalTable: "ClientDetails",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOrganizations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    DutyBranch = table.Column<string>(type: "text", nullable: false),
                    BranchGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompaynEmail = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EmploymentType = table.Column<string>(type: "text", nullable: false),
                    BusinessUnit = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    ReportingManager = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOrganizations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_EmployeeOrganizations_DutyBranches_BranchGuid",
                        column: x => x.BranchGuid,
                        principalTable: "DutyBranches",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeOrganizations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDetails",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RelationshipId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    DoB = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetails", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FamilyDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyDetails_Relationship_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationship",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EmployeeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Nationalities_Employees_EmployeeGuid",
                        column: x => x.EmployeeGuid,
                        principalTable: "Employees",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalAddresses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    StateRegionProvice = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    SubCityZone = table.Column<string>(type: "text", nullable: true),
                    Woreda = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAddresses", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PersonalAddresses_Employees_EmployeeGuid",
                        column: x => x.EmployeeGuid,
                        principalTable: "Employees",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignResources",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignResources", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_AssignResources_Project_ProjectGuid",
                        column: x => x.ProjectGuid,
                        principalTable: "Project",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAreaOfInterest_ApplicantId",
                table: "ApplicantAreaOfInterest",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAreaOfInterest_LuPositionToApplyGuid",
                table: "ApplicantAreaOfInterest",
                column: "LuPositionToApplyGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAreaOfInterest_ProficiencyLevelID",
                table: "ApplicantAreaOfInterest",
                column: "ProficiencyLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignResources_ProjectGuid",
                table: "AssignResources",
                column: "ProjectGuid");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_ClientDetailsGuid",
                table: "BillingAddresses",
                column: "ClientDetailsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_ClientDetailsGuid",
                table: "ClientContacts",
                column: "ClientDetailsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetails_ClientStatusGuid",
                table: "ClientDetails",
                column: "ClientStatusGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContacts_ClientDetailsGuid",
                table: "CompanyContacts",
                column: "ClientDetailsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DutyBranches_CountryId",
                table: "DutyBranches",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ApplicantId",
                table: "Educations",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationProgrammeId",
                table: "Educations",
                column: "EducationProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FieldOfStudyId",
                table: "Educations",
                column: "FieldOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrganizations_BranchGuid",
                table: "EmployeeOrganizations",
                column: "BranchGuid");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrganizations_EmployeeId",
                table: "EmployeeOrganizations",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmergencyContactGuid",
                table: "Employees",
                column: "EmergencyContactGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_EmployeeId",
                table: "FamilyDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_RelationshipId",
                table: "FamilyDetails",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_LUPositionSkillSet_LUPositionToApplyId",
                table: "LUPositionSkillSet",
                column: "LUPositionToApplyId");

            migrationBuilder.CreateIndex(
                name: "IX_LUPositionSkillSet_LUSkillSetId",
                table: "LUPositionSkillSet",
                column: "LUSkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_EmployeeGuid",
                table: "Nationalities",
                column: "EmployeeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingAddresses_ClientDetailsGuid",
                table: "OperatingAddresses",
                column: "ClientDetailsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAddresses_EmployeeGuid",
                table: "PersonalAddresses",
                column: "EmployeeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientGuid",
                table: "Project",
                column: "ClientGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusGuid",
                table: "Project",
                column: "ProjectStatusGuid");

            migrationBuilder.CreateIndex(
                name: "IX_SkillPositionAssociation_luPositionToApplyGuid",
                table: "SkillPositionAssociation",
                column: "luPositionToApplyGuid");

            migrationBuilder.CreateIndex(
                name: "IX_SkillPositionAssociation_skillSetGuid",
                table: "SkillPositionAssociation",
                column: "skillSetGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntry_TimesheetGuid",
                table: "TimeEntry",
                column: "TimesheetGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantAreaOfInterest");

            migrationBuilder.DropTable(
                name: "AssignResources");

            migrationBuilder.DropTable(
                name: "BillingAddresses");

            migrationBuilder.DropTable(
                name: "ClientContacts");

            migrationBuilder.DropTable(
                name: "CompanyContacts");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "DeviceDetails");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "EmergencyAddresses");

            migrationBuilder.DropTable(
                name: "EmployeeOrganizations");

            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "JobRequirment");

            migrationBuilder.DropTable(
                name: "LUPositionSkillSet");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "OperatingAddresses");

            migrationBuilder.DropTable(
                name: "PersonalAddresses");

            migrationBuilder.DropTable(
                name: "SkillPositionAssociation");

            migrationBuilder.DropTable(
                name: "TimeEntry");

            migrationBuilder.DropTable(
                name: "TimesheetAprovals");

            migrationBuilder.DropTable(
                name: "ProficiencyLevel");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "EducationProgrammes");

            migrationBuilder.DropTable(
                name: "FieldOfStudie");

            migrationBuilder.DropTable(
                name: "DutyBranches");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "ClientDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PositionToApply");

            migrationBuilder.DropTable(
                name: "SkillSet");

            migrationBuilder.DropTable(
                name: "TimeSheet");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "ClientStatus");

            migrationBuilder.DropTable(
                name: "EmergencyContactsModel");
        }
    }
}
