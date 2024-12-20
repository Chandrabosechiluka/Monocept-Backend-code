using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsurancePolicy.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsurancePlans",
                columns: table => new
                {
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PlanName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePlans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "TaxSettings",
                columns: table => new
                {
                    TaxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TaxPercentage = table.Column<double>(type: "float", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxSettings", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceSchemes",
                columns: table => new
                {
                    SchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    SchemeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SchemeImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MinAmount = table.Column<double>(type: "float", nullable: false),
                    MaxAmount = table.Column<double>(type: "float", nullable: false),
                    MinInvestTime = table.Column<int>(type: "int", nullable: false),
                    MaxInvestTime = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    ProfitRatio = table.Column<double>(type: "float", nullable: false),
                    RegistrationCommRatio = table.Column<double>(type: "float", nullable: false),
                    InstallmentCommRatio = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimDeductionPercentage = table.Column<double>(type: "float", nullable: false),
                    PenaltyDeductionPercentage = table.Column<double>(type: "float", nullable: false),
                    RequiredDocuments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceSchemes", x => x.SchemeId);
                    table.ForeignKey(
                        name: "FK_InsuranceSchemes_InsurancePlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "InsurancePlans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    AdminFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdminPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    AgentFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AgentLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionEarned = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                    table.ForeignKey(
                        name: "FK_Agents_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Agents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "AgentEarnings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    WithdrawalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentEarnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentEarnings_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId");
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CustomersQueries",
                columns: table => new
                {
                    QueryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QueryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    ResolvedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersQueries", x => x.QueryId);
                    table.ForeignKey(
                        name: "FK_CustomersQueries_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersQueries_Employees_ResolvedByEmployeeId",
                        column: x => x.ResolvedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicies",
                columns: table => new
                {
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    InsuranceSchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiumType = table.Column<int>(type: "int", nullable: false),
                    SumAssured = table.Column<double>(type: "float", nullable: false),
                    PolicyTerm = table.Column<long>(type: "bigint", nullable: false),
                    PremiumAmount = table.Column<double>(type: "float", nullable: false),
                    InstallmentAmount = table.Column<double>(type: "float", nullable: true),
                    TotalPaidAmount = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxSettingsTaxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicies", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId");
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_InsuranceSchemes_InsuranceSchemeId",
                        column: x => x.InsuranceSchemeId,
                        principalTable: "InsuranceSchemes",
                        principalColumn: "SchemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_TaxSettings_TaxSettingsTaxId",
                        column: x => x.TaxSettingsTaxId,
                        principalTable: "TaxSettings",
                        principalColumn: "TaxId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalRequests",
                columns: table => new
                {
                    WithdrawalRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalRequests", x => x.WithdrawalRequestId);
                    table.ForeignKey(
                        name: "FK_WithdrawalRequests_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId");
                    table.ForeignKey(
                        name: "FK_WithdrawalRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimAmount = table.Column<double>(type: "float", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankIFSCCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Claim = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claims_Agents_Claim",
                        column: x => x.Claim,
                        principalTable: "Agents",
                        principalColumn: "AgentId");
                    table.ForeignKey(
                        name: "FK_Claims_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claims_InsurancePolicies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CommissionType = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNo = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.CommissionId);
                    table.ForeignKey(
                        name: "FK_Commissions_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_InsurancePolicies_PolicyNo",
                        column: x => x.PolicyNo,
                        principalTable: "InsurancePolicies",
                        principalColumn: "PolicyId");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentName = table.Column<int>(type: "int", maxLength: 250, nullable: false),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RejectedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Employees_VerifiedById",
                        column: x => x.VerifiedById,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Documents_InsurancePolicies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "PolicyId");
                });

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    InstallmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountDue = table.Column<double>(type: "float", nullable: false),
                    AmountPaid = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.InstallmentId);
                    table.ForeignKey(
                        name: "FK_Installments_InsurancePolicies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "PolicyId");
                });

            migrationBuilder.CreateTable(
                name: "Nomines",
                columns: table => new
                {
                    NomineeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    NomineeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Relationship = table.Column<int>(type: "int", nullable: false),
                    PolicyNo = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomines", x => x.NomineeId);
                    table.ForeignKey(
                        name: "FK_Nomines_InsurancePolicies_PolicyNo",
                        column: x => x.PolicyNo,
                        principalTable: "InsurancePolicies",
                        principalColumn: "PolicyId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    paymentType = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    TotalPayment = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_InsurancePolicies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "PolicyId");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b6caab0-955d-402b-8f4f-bd0e0dcaf8a9"), "Admin" },
                    { new Guid("66dd3fd6-6cc9-434d-8172-d580438749ab"), "Agent" },
                    { new Guid("d08d4b5e-e0df-447c-9c5f-0021944107c3"), "Customer" },
                    { new Guid("d23d8230-efcc-4b4c-8bd0-49ac422da626"), "Employee" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "StateName" },
                values: new object[,]
                {
                    { new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a"), "Karnataka" },
                    { new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d"), "Assam" },
                    { new Guid("1618e27f-2159-4187-980b-e85fbd70a16e"), "Maharashtra" },
                    { new Guid("20f2748b-1711-4541-be08-29425412b213"), "Chhattisgarh" },
                    { new Guid("3d1fac27-be1e-4813-98cc-f4ab59eb64e0"), "Odisha" },
                    { new Guid("490d2ee9-00ff-441d-b581-6796b1db432c"), "Uttarakhand" },
                    { new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d"), "Arunachal Pradesh" },
                    { new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2"), "Jharkhand" },
                    { new Guid("580efb0d-9fa7-40eb-b988-47951c082025"), "Haryana" },
                    { new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826"), "Telangana" },
                    { new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff"), "West Bengal" },
                    { new Guid("84fb85ed-ef7a-4a12-8ee4-713565eb331c"), "Tripura" },
                    { new Guid("8994fa5c-e415-4266-8567-efd7fd35a523"), "Manipur" },
                    { new Guid("8cd0226a-a867-4f7b-8459-ce2fee644973"), "Meghalaya" },
                    { new Guid("90bd12e5-cc33-4d16-a358-d3e8add698f2"), "Mizoram" },
                    { new Guid("9239dade-6063-49f3-94e5-da900488e22e"), "Uttar Pradesh" },
                    { new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0"), "Rajasthan" },
                    { new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f"), "Andhra Pradesh" },
                    { new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e"), "Gujarat" },
                    { new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b"), "Bihar" },
                    { new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669"), "Goa" },
                    { new Guid("a89fee57-d30b-4133-935c-201a6cf44b01"), "Tamil Nadu" },
                    { new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d"), "Himachal Pradesh" },
                    { new Guid("c47663a9-22f2-420e-bcaf-f5e30817c5fc"), "Punjab" },
                    { new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9"), "Kerala" },
                    { new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245"), "Madhya Pradesh" },
                    { new Guid("d52e70a6-68f4-4add-b63e-6cbd2fa6bac8"), "Sikkim" },
                    { new Guid("e2f9b41b-eb4b-40a8-bb22-6249c226478b"), "Nagaland" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "StateId" },
                values: new object[,]
                {
                    { new Guid("021b74a5-81b7-4039-a528-6a4fbf5e989e"), "Ponda", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("0274c77e-db94-4a56-b659-1219e6090477"), "Kanpur", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("072501f3-29d5-4a59-837c-2a44ea1357fd"), "Adilabad", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("07277838-2868-4fd6-9c5f-4cc80ffa8954"), "Alwar", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("0ac5b5d1-500c-44eb-8ed4-600a3ca74c61"), "Malda", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("0c32be6b-80dc-4489-8dfc-6bdc3b78b90f"), "Hubli", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("0d7bcebf-92bf-4351-afdc-31ec59ebbe6b"), "Mangalore", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("0d902723-7158-470d-b45f-1c6a7592ca09"), "Jamnagar", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("0dbab96d-f954-4c63-8853-0fa74f9b9833"), "Gurgaon", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("0e0cd725-1189-4eed-b03e-38872c7b2f24"), "Goalpara", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("0f207e2a-a41c-4ae8-8c36-2d997bb5ca58"), "Changlang", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("11354018-2e2a-4de2-9c2a-fe918b3c0e17"), "Hyderabad", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("12eb46b5-2df5-436e-8428-cae3e070ef3d"), "Mahasamund", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("154e75e7-f326-4726-a850-8ff6c983f91e"), "Kollam", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("1895db25-3fb6-4eaf-8da0-b4251d691096"), "Manali", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("1b9c8674-7507-4678-941a-6eb562119434"), "Mehsana", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("1c51b6a4-736b-4478-9cdf-9ff2403c7f95"), "Palakkad", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("205206a3-a451-4601-b69c-45b3aac17a11"), "Rajahmundry", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("22fcc8ca-9783-428f-b523-8a7a3a644a78"), "Begusarai", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("23b00740-6472-425e-b92f-eaaf7be1531d"), "Guwahati", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("24a0b285-1f8d-414c-8387-5424ecd66dd8"), "Kannur", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("264674dc-9b46-4e78-ad11-713e69846647"), "Jalpaiguri", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("284ef07f-c03a-47d8-8b59-c0eebdc71087"), "Dindigul", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("28fb2ca2-3682-4ddc-aa15-a24437b46954"), "Barpeta", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("2939e1ae-7e65-4d06-8237-f1d7d9e7ba3b"), "Itanagar", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("2a71bf2b-76a4-48ee-9d5a-14bb06759ee4"), "Chhindwara", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("2b20d58e-7fe0-4902-9474-82a77feeb040"), "Thrissur", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("2b3a5c4c-ff3e-497a-bc94-451d702aba07"), "Kolhapur", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("2c3af4bc-ecbb-4eb9-b521-d78e6f3152e2"), "Margao", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("2efe7eb9-ee9c-4b02-9a03-9a1d69c40577"), "Sirsa", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("32179729-2fe6-4639-8599-0e26a4137497"), "Godda", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("343bff25-075f-4983-a276-0dcd026b0f67"), "Kochi", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("34adbc40-6630-48f4-b917-7b9c429c8004"), "Jodhpur", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("377268e9-99c7-4a0b-bc02-8c60936550e6"), "Satna", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("38d814e8-f94b-43c5-9ef9-6f1270e4cab5"), "Sagar", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("3b36589a-d9c9-49ff-ba94-5cdb37f8b1a0"), "Korba", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("3c407a8e-6af3-4080-bcfd-f05bb567582b"), "Thiruvananthapuram", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("3c522925-33fe-413a-bae6-1192f80e19a5"), "Mapusa", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("3d7fa156-ea8d-4f0e-9ab7-a6dab2fd44cf"), "Durgapur", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("3d8b0d7c-1306-429d-8be2-c85ff486399d"), "Dibrugarh", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("3dc86fc5-0cf4-4ceb-b042-ae9c0b6b6519"), "Canacona", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("3e150277-dab4-4e97-b5e6-846702609783"), "Jamshedpur", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("3e1b6ebe-975d-462b-b963-a527c3d1d369"), "Bhopal", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("3e9ca2af-df60-4806-85ca-d769f3f36332"), "Kozhikode", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("416bc2e1-963f-469d-b5a8-d581f011ec41"), "Anand", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("4235026f-54ea-4370-b622-ee9200269e0c"), "Karnal", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("43a02a5e-331c-4ed2-b262-a789eae46115"), "Pune", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("45be33d6-42e2-4012-bfc3-55aa5e312fdf"), "Nashik", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("469879bd-1493-43b5-9ede-91cbf789a056"), "Tezpur", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("4abdeb3d-352b-4feb-85b7-aebe0d6556e4"), "Calangute", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("4b31ea80-5b16-4b09-bde5-edb1a0be7e41"), "Sikar", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("4f56adca-32e6-4100-83d5-858d31d0a33e"), "Sasaram", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("519a6143-cd3c-44d1-9add-0237bd6c0c23"), "Ara", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("51aafc35-e27c-4806-8b9f-820000ebf450"), "Ziro", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("51e67f5b-8964-4711-837a-579825b642b0"), "Rewa", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("51fb1e23-14e7-4c01-9bd3-e6d68f1e5760"), "Mumbai", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("525a6c72-32b4-47d3-8217-36f06b1cb60c"), "Jorhat", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("52eeffd2-573b-4991-a5cb-978986cceccf"), "Yamunanagar", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("55690c45-d072-48f6-9d6d-95b626b300d6"), "Nizamabad", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("58cc3dfe-2d34-4749-8acf-9576efe1911d"), "Amravati", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("5becf835-e449-4ad8-b879-eda50ca665dd"), "Nagpur", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("5d4dbdcd-26e5-4d07-8f60-14db47fa5792"), "Tirupati", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("5dc6eb7f-5526-4aaf-8847-fee103ee0ef8"), "Howrah", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("5f8bb607-1d90-41a3-962b-b01634a2a94b"), "Kullu", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("5fe038fc-eba6-4fc2-bc36-5cb913941f47"), "Siliguri", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("6033a8ac-fec7-48d8-b67e-38a3ab1d1d98"), "Hamirpur", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("609ffa5f-ed22-439c-9ee1-af3bcf3cc74f"), "Hazaribagh", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("62331b1d-dd63-403d-ac65-af1490ab4d4c"), "Kakinada", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("63eabb9b-3bd7-4712-a4f5-49b8ea68f160"), "Bardhaman", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("65e7c910-06c0-40b9-afb4-4b2279b6efcf"), "Shimoga", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("66b28e70-698f-4636-9ce3-06a7913cb328"), "Anini", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("66db2be9-f60b-4fa5-8cd7-05595cac1977"), "Mysore", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("675bb79d-2d8b-4df4-a3fb-f94d1245e624"), "Gaya", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("6b3f98c0-de37-4692-8f69-31238d136446"), "Deoghar", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("6cdbeba1-6278-4921-bef0-07ac873ecfe3"), "Rajkot", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("6dd32dd2-dec3-458b-abcd-db69e41ff0cd"), "Hajipur", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("6ed0f5dc-5c99-4a0e-909d-38dcc1f228e7"), "Nahan", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("747266ba-b075-43ac-be4c-7f641d4ac492"), "Ghaziabad", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("76637e2b-1496-4eb8-ab69-3cc677bf9f14"), "Varanasi", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("78b9ad08-be9d-4283-a5f7-17615b7bb6cd"), "Faridabad", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("790e69e0-4534-4816-91bf-8b501ab17cc7"), "Pakur", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("7d216948-a546-4172-a1a5-aeaedc246788"), "Khammam", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("7e3148a1-db0c-4668-9f8e-4d4be5546dd6"), "Bomdila", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("868ea801-846a-4650-87ff-ba52fdab32fa"), "Aurangabad", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("87473665-6eda-4411-9b81-7fe36d27baef"), "Bhagalpur", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("87b26165-ebef-42ff-b272-62f6991991c1"), "Jaipur", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("87b89dcf-5eee-42b5-8a9f-eac05f25b96d"), "Thane", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("88cf1364-81b6-420d-a780-210095d70f0f"), "Ratlam", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("8a86be29-ab91-45cf-bdd3-5ec615a0646a"), "Kolkata", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("8ad81e67-330e-451c-b37f-e744df42b9b9"), "Siddipet", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("8b70010c-7969-4515-a203-b99ac94136b0"), "Along", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("8c5c1f9f-10ba-4857-9862-6268a505758d"), "Bongaigaon", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("8e4b1bae-3606-42fb-a73f-1668db422063"), "Idukki", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("9179ec06-3a66-468a-ac33-3a3c8cf803c5"), "Bhilai", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("9190e840-5545-4ada-9801-b1948d37ca6c"), "Ambala", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("9266548e-1d78-47ba-a9c2-83b546434513"), "Kota", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("92e97b6b-8ddd-4d48-aca1-faff6679c036"), "Bilaspur", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("92ef49d5-2e7a-47c5-9fb1-98666f5279b0"), "Dhanbad", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("944fa7ea-7f77-4497-b1cc-2f8980ebc7b9"), "Roing", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("94865abc-40d7-4c34-aea7-6372cfd59f5f"), "Ujjain", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("95594bd9-a3ec-4376-8bd7-c85dfed43e4d"), "Haldia", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("95c1ce8e-84f9-4fe4-aafe-b18d51f32436"), "Nagaon", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("96b48128-0c00-4458-8010-07ec5b3ad5a2"), "Bangalore", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("986a2171-dfef-49a6-88da-34fff586e8b6"), "Gandhinagar", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("99202dee-1c33-4835-b4b8-40612573562f"), "Madurai", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("9bb609a5-8ce8-49d1-890a-63b56e11b1c3"), "Bhiwani", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("9bf4837b-0cea-4cb7-b225-06831918a73d"), "Guntur", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("9d3a522d-5b98-462e-8b77-f1a4ff6a091a"), "Dona Paula", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("9e132814-52fe-4380-946c-2e23146b1c59"), "Rajnandgaon", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("a03b1b2d-2f84-4e78-b73a-e1d37459bf09"), "Panipat", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("a042fbb9-f5f2-4878-b2a8-08bfa1a525c8"), "Darbhanga", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("a150eea1-8bb9-463e-9d00-82f8405e0635"), "Jaisalmer", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("a1cfbeb8-0b15-4829-acee-a409045e09a8"), "Porvorim", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("a299a6c9-e418-4f3d-a434-0779d05b8515"), "Muzaffarpur", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("a3f0071e-709a-48b9-bff7-edd460807879"), "Sangli", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("a8adf0da-a755-42bf-a592-bee1725099f6"), "Vijayawada", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("a8ae7b94-37ca-4502-9d20-cf683e72a7cd"), "Ajmer", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("a9a6d986-6e6a-4154-81ba-3a7c06c711ac"), "Purnia", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("a9f608ab-9191-4e16-98e3-8dbef4afd8bb"), "Jabalpur", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("aa2ec39a-955f-4e37-8fdf-f9a48b2803d6"), "Thoothukudi", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("ad730902-aef4-4a0c-b459-66b9da45babc"), "Chittoor", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("aef12973-1f64-4c5f-be5f-43321bb000c8"), "Durg", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("b0f61563-fee7-498b-a945-e6da74db88ba"), "Patna", new Guid("a176e7fa-fa3c-41ff-a464-6d855b1fc73b") },
                    { new Guid("b0fe2e6e-a6a2-46c5-a43d-2c1cecf9ef89"), "Malappuram", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("b302fe26-a3c6-41c6-8d06-5374a3f8bcff"), "Dharamshala", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("b354d6d2-1c88-451d-8827-0e7e73915c08"), "Salem", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("b3ac1ed9-db98-4fb2-b34d-c2eaa154719b"), "Raigarh", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("b4239745-40f4-401a-aad7-3f9efc88d870"), "Ranchi", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("b4a7f15a-6fd3-4c2c-8fad-4f1e61783bed"), "Ramagundam", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("b617a5b1-cb8d-4f04-8c7e-d095d0ffd242"), "Meerut", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("b79d49ce-c557-4a6b-9ce4-521a40bbe106"), "Ahmedabad", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("b80d5a9c-1326-4044-ba8b-e3402e95a0ee"), "Surat", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("b8d85564-e6d8-491a-b33a-7c6c4d346dff"), "Shimla", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("baa067d3-d4c7-4db0-a7af-46fa2c3abaa8"), "Bikaner", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("bb584d4d-11c0-4a69-a0d0-f187b8b9d876"), "Bilaspur", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("bc1e48cc-d956-4c74-8c38-d0c6eb2dbf8c"), "Mahbubnagar", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("bd3f838d-dd34-4d44-9b10-1109a1c7aa39"), "Tawang", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("bde1ae43-4828-4f31-9a11-127c937d5731"), "Karimnagar", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("bed2813a-ee08-4ebb-897d-fb0be9570628"), "Indore", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("bf80b0ba-e8ce-42bc-a6e3-a141befc86b2"), "Aligarh", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("c0a2940e-f490-4081-84f3-6613188060e9"), "Asansol", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("c124d8a7-3740-49c9-8e44-c27b0d1a38b3"), "Erode", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("c214caea-440d-4f63-b90f-cf9afde83121"), "Bellary", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("c2b50d80-3228-425c-9c32-5ae531568b48"), "Giridih", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("c36da14f-c478-4dbd-bcfe-8e8e7ab01949"), "Darjeeling", new Guid("7780b158-8a52-4fad-b5e9-ddf18ba6e5ff") },
                    { new Guid("c4965fdb-63bf-4aa6-b88d-0cb49854b2b4"), "Belgaum", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("c503439a-15b3-4a5b-8084-4f74b8e1cf3f"), "Alappuzha", new Guid("c6caf065-fbb3-455c-8a2a-4caa10c941d9") },
                    { new Guid("c6bce787-71ae-418a-8122-adfe18614ca9"), "Tiruchirappalli", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("c7bbce87-4049-41f0-b745-8f0550f9e1dd"), "Chennai", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("cee376fb-86e8-4db5-a76a-b286328fc60a"), "Lucknow", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("d2c3726a-1da4-4550-a5f0-acbccd8a1b7b"), "Silchar", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("d3e7382f-726e-42e8-88b9-71d85a4fe808"), "Allahabad", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("d4b82c6c-2543-4266-87dc-c62f08a76811"), "Anantapur", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("d4f0d565-00fa-4153-b5b9-58b3026951a7"), "Kadapa", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("d525d213-bca8-4f72-9531-5bce2ecb3c9f"), "Warangal", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("d88742cb-d8a4-4a9d-960f-b2ef9d938526"), "Gwalior", new Guid("c8bed916-d1b7-4853-9da2-2271d5ebf245") },
                    { new Guid("deb1c83a-c971-46b3-aced-f9fd9a59f72e"), "Moradabad", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("df2ddbc5-9d25-49c0-8120-81e193600e77"), "Davanagere", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("dfe81de3-d983-4401-a91a-438c2d176804"), "Udupi", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") },
                    { new Guid("e054b3b3-d2d8-4eed-a491-bf11eedbeb57"), "Rohtak", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("e363e930-44dc-49d8-8b38-01f869f6cc0a"), "Nellore", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("e5d78bc6-b807-4040-85c3-76ccf021eb50"), "Raipur", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("e7752e6b-d091-467f-a26c-34b88de2752e"), "Solan", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("e8450fdb-42eb-4d5b-bb91-4bc216979f84"), "Ramgarh", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("e8af2ea8-2363-4395-97ca-4d35471ada51"), "Visakhapatnam", new Guid("9eb71cad-5eaf-4e8e-85ed-4c85e2501f9f") },
                    { new Guid("e95cdcc1-968d-423a-8f79-d3b1180e8056"), "Ambikapur", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("e9cef963-8b91-4d6e-a987-d0518240316a"), "Tinsukia", new Guid("05159922-16b3-4acc-a0b1-addd681dbd2d") },
                    { new Guid("eaa4f13f-b02e-4980-80e6-7ad2b1dee332"), "Vellore", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("ec87af97-9a04-4784-b002-38c2bc51ff4f"), "Coimbatore", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("ed12e699-d9ec-4b19-b43b-0bfcd327d05c"), "Bareilly", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("edb51012-eb89-48e7-a662-bdc1d1e4ddfd"), "Hisar", new Guid("580efb0d-9fa7-40eb-b988-47951c082025") },
                    { new Guid("eddc1548-3297-45e2-b417-e0f3f87535c9"), "Tezu", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("ee5019ad-0d93-4a63-ba5c-267b2bceacb4"), "Solapur", new Guid("1618e27f-2159-4187-980b-e85fbd70a16e") },
                    { new Guid("ef394fc0-a1bc-4dd3-8ee5-756f010d5a80"), "Mandi", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("f00478ae-16ab-4574-b63e-9632a9eba8b2"), "Pasighat", new Guid("4f11b811-85d5-4e06-8c9c-fd9c015c677d") },
                    { new Guid("f1db5b54-79cf-4966-89ee-cfa63c3deb13"), "Bokaro", new Guid("578b9130-2b65-4cdd-a0b5-2613a48160e2") },
                    { new Guid("f2a3b26a-75aa-4aad-a60a-66250ebf4c1c"), "Tirunelveli", new Guid("a89fee57-d30b-4133-935c-201a6cf44b01") },
                    { new Guid("f3ea33cb-9fb1-4f62-9316-7cf986c997db"), "Vadodara", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("f6093799-82d4-484e-8eaf-8a8a9049e67a"), "Navsari", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("f741f733-67d0-4f3d-a2a5-aadca08c6360"), "Panaji", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("f78909a8-6d23-4acd-b988-a0b3d054ab60"), "Jagdalpur", new Guid("20f2748b-1711-4541-be08-29425412b213") },
                    { new Guid("f87c5a29-a019-48a2-b2e7-d64450e09204"), "Bhavnagar", new Guid("a00fb082-6a1f-40f3-9ce0-68944815ac4e") },
                    { new Guid("f891a9e5-5c0c-4e2c-9902-0eee25f332e3"), "Bicholim", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("fa004160-59f2-429d-a510-4d89471f381b"), "Bharatpur", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("fa73b7e6-5051-4b20-bbd2-af5d21c1180b"), "Udaipur", new Guid("9b6c97fd-c8b6-47d1-a57b-077131214bd0") },
                    { new Guid("fb269474-bffe-4615-b0be-dda2ed70acb4"), "Agra", new Guid("9239dade-6063-49f3-94e5-da900488e22e") },
                    { new Guid("fd2188d9-9958-4ccc-94fe-8906e17b592b"), "Vasco da Gama", new Guid("a45ab9e6-3378-48ff-bc1a-58ab14af3669") },
                    { new Guid("fd4c945d-bbb9-4b6c-8e81-3ab1f5603b04"), "Mancherial", new Guid("5eced7cb-1515-4e4d-8f17-e53ef8993826") },
                    { new Guid("fe2c1377-67e4-4aae-9313-9d2f57adaaa3"), "Chamba", new Guid("b9d9be61-f009-4c47-a38c-cbe25c4cef8d") },
                    { new Guid("ffcc5574-a86e-4b82-ba12-476e00c4ab4d"), "Bijapur", new Guid("040fd1a4-9f12-494c-a7dd-5bf9df67fb0a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AgentEarnings_AgentId",
                table: "AgentEarnings",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AddressId",
                table: "Agents",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_Claim",
                table: "Claims",
                column: "Claim");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CustomerId",
                table: "Claims",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PolicyId",
                table: "Claims",
                column: "PolicyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_AgentId",
                table: "Commissions",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_PolicyNo",
                table: "Commissions",
                column: "PolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AgentId",
                table: "Customers",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersQueries_CustomerId",
                table: "CustomersQueries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersQueries_ResolvedByEmployeeId",
                table: "CustomersQueries",
                column: "ResolvedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CustomerId",
                table: "Documents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PolicyId",
                table: "Documents",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_VerifiedById",
                table: "Documents",
                column: "VerifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_PolicyId",
                table: "Installments",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_AgentId",
                table: "InsurancePolicies",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_CustomerId",
                table: "InsurancePolicies",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_InsuranceSchemeId",
                table: "InsurancePolicies",
                column: "InsuranceSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_TaxSettingsTaxId",
                table: "InsurancePolicies",
                column: "TaxSettingsTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceSchemes_PlanId",
                table: "InsuranceSchemes",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomines_PolicyNo",
                table: "Nomines",
                column: "PolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PolicyId",
                table: "Payments",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalRequests_AgentId",
                table: "WithdrawalRequests",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalRequests_CustomerId",
                table: "WithdrawalRequests",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AgentEarnings");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "CustomersQueries");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "Nomines");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "WithdrawalRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "InsuranceSchemes");

            migrationBuilder.DropTable(
                name: "TaxSettings");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "InsurancePlans");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
