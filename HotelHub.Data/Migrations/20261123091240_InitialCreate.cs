using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.EnsureSchema(
                name: "hotel");

            migrationBuilder.EnsureSchema(
                name: "nom");

            migrationBuilder.EnsureSchema(
                name: "booking");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "auth",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "auth",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "hotel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EIK = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_ID", x => x.ID);
                    table.CheckConstraint("CK_Companies_EIK", "LEN([EIK]) IN (9, 13) AND [EIK] NOT LIKE '%[^0-9]%'");
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                schema: "nom",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                schema: "nom",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "auth",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Role_ID_AspNetRoles_ID",
                        column: x => x.Role_ID,
                        principalSchema: "auth",
                        principalTable: "AspNetRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "auth",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_User_ID_AspNetUsers_ID",
                        column: x => x.User_ID,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "auth",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins_LoginProvider_ProviderKey", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_User_ID_AspNetUsers_ID",
                        column: x => x.User_ID,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "auth",
                columns: table => new
                {
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles_User_ID_Role_ID", x => new { x.User_ID, x.Role_ID });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Role_ID_AspNetRoles_ID",
                        column: x => x.Role_ID,
                        principalSchema: "auth",
                        principalTable: "AspNetRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_User_ID_AspNetUsers_ID",
                        column: x => x.User_ID,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "auth",
                columns: table => new
                {
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens_User_ID_LoginProvider_Name", x => new { x.User_ID, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_User_ID_AspNetUsers_ID",
                        column: x => x.User_ID,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "booking",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EGN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons_ID", x => x.ID);
                    table.CheckConstraint("CK_Persons_EGN", "LEN([EGN]) = 10 AND [EGN] NOT LIKE '%[^0-9]%'");
                    table.ForeignKey(
                        name: "FK_Persons_User_ID_AspNetUsers_ID",
                        column: x => x.User_ID,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                schema: "hotel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Stars = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels_ID", x => x.ID);
                    table.CheckConstraint("CK_Hotels_Stars", "[Stars] BETWEEN 1 AND 5");
                    table.ForeignKey(
                        name: "FK_Hotels_Company_ID_Companies_ID",
                        column: x => x.Company_ID,
                        principalSchema: "hotel",
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "hotel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Person_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hotel_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_ID", x => x.ID);
                    table.UniqueConstraint("UQ_Employees_Hotel_ID_ID", x => new { x.Hotel_ID, x.ID });
                    table.CheckConstraint("CK_Employees_EndDate", "[EndDate] >= [HireDate]");
                    table.ForeignKey(
                        name: "FK_Employees_Hotel_ID_Hotels_ID",
                        column: x => x.Hotel_ID,
                        principalSchema: "hotel",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Person_ID_Persons_ID",
                        column: x => x.Person_ID,
                        principalSchema: "booking",
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelMealPlans",
                schema: "hotel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hotel_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealPlan_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdultPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ChildPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelMealPlans_ID", x => x.ID);
                    table.UniqueConstraint("UQ_HotelMealPlans_Hotel_ID_ID", x => new { x.Hotel_ID, x.ID });
                    table.CheckConstraint("CK_HotelMealPlans_AdultPrice", "[AdultPrice] >= 0");
                    table.CheckConstraint("CK_HotelMealPlans_ChildPrice", "[ChildPrice] >= 0");
                    table.ForeignKey(
                        name: "FK_HotelMealPlans_Hotel_ID_Hotels_ID",
                        column: x => x.Hotel_ID,
                        principalSchema: "hotel",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelMealPlans_MealPlan_ID_MealPlans_ID",
                        column: x => x.MealPlan_ID,
                        principalSchema: "nom",
                        principalTable: "MealPlans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoomTypes",
                schema: "hotel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hotel_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomTypes_ID", x => x.ID);
                    table.UniqueConstraint("UQ_HotelRoomTypes_Hotel_ID_RoomType_ID", x => new { x.Hotel_ID, x.RoomType_ID });
                    table.CheckConstraint("CK_HotelRoomTypes_PricePerNight", "[PricePerNight] >= 0");
                    table.ForeignKey(
                        name: "FK_HotelRoomTypes_Hotel_ID_Hotels_ID",
                        column: x => x.Hotel_ID,
                        principalSchema: "hotel",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelRoomTypes_RoomType_ID_RoomTypes_ID",
                        column: x => x.RoomType_ID,
                        principalSchema: "nom",
                        principalTable: "RoomTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "hotel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hotel_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms_ID", x => x.ID);
                    table.UniqueConstraint("UQ_Rooms_Hotel_ID_ID", x => new { x.Hotel_ID, x.ID });
                    table.CheckConstraint("CK_Rooms_Capacity", "[Capacity] > 0");
                    table.ForeignKey(
                        name: "FK_Rooms_Hotel_ID_Hotels_ID",
                        column: x => x.Hotel_ID,
                        principalSchema: "hotel",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotel_ID_RoomType_ID_HotelRoomTypes_Hotel_ID_RoomType_ID",
                        columns: x => new { x.Hotel_ID, x.RoomType_ID },
                        principalSchema: "hotel",
                        principalTable: "HotelRoomTypes",
                        principalColumns: new[] { "Hotel_ID", "RoomType_ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "booking",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hotel_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Guest_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Room_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelMealPlan_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByEmployee_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CheckIn = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckOut = table.Column<DateOnly>(type: "date", nullable: false),
                    AdultsCount = table.Column<int>(type: "int", nullable: false),
                    ChildrenCount = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations_ID", x => x.ID);
                    table.CheckConstraint("CK_Reservations_AdultsCount", "[AdultsCount] >= 1");
                    table.CheckConstraint("CK_Reservations_CheckOut", "[CheckOut] > [CheckIn]");
                    table.CheckConstraint("CK_Reservations_ChildrenCount", "[ChildrenCount] >= 0");
                    table.CheckConstraint("CK_Reservations_TotalPrice", "[TotalPrice] >= 0");
                    table.ForeignKey(
                        name: "FK_Reservations_Guest_ID_Persons_ID",
                        column: x => x.Guest_ID,
                        principalSchema: "booking",
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Hotel_ID_CreatedByEmployee_ID_Employees_Hotel_ID_ID",
                        columns: x => new { x.Hotel_ID, x.CreatedByEmployee_ID },
                        principalSchema: "hotel",
                        principalTable: "Employees",
                        principalColumns: new[] { "Hotel_ID", "ID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Hotel_ID_HotelMealPlan_ID_HotelMealPlans_Hotel_ID_ID",
                        columns: x => new { x.Hotel_ID, x.HotelMealPlan_ID },
                        principalSchema: "hotel",
                        principalTable: "HotelMealPlans",
                        principalColumns: new[] { "Hotel_ID", "ID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Hotel_ID_Hotels_ID",
                        column: x => x.Hotel_ID,
                        principalSchema: "hotel",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Hotel_ID_Room_ID_Rooms_Hotel_ID_ID",
                        columns: x => new { x.Hotel_ID, x.Room_ID },
                        principalSchema: "hotel",
                        principalTable: "Rooms",
                        principalColumns: new[] { "Hotel_ID", "ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_Role_ID",
                schema: "auth",
                table: "AspNetRoleClaims",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_AspNetRoles_NormalizedName",
                schema: "auth",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_User_ID",
                schema: "auth",
                table: "AspNetUserClaims",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_User_ID",
                schema: "auth",
                table: "AspNetUserLogins",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_Role_ID",
                schema: "auth",
                table: "AspNetUserRoles",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NormalizedEmail",
                schema: "auth",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UQ_AspNetUsers_NormalizedUserName",
                schema: "auth",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_Companies_EIK",
                schema: "hotel",
                table: "Companies",
                column: "EIK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Person_ID_EndDate",
                schema: "hotel",
                table: "Employees",
                columns: new[] { "Person_ID", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "UQ_Employees_Person_ID",
                schema: "hotel",
                table: "Employees",
                column: "Person_ID",
                unique: true,
                filter: "[EndDate] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HotelMealPlans_MealPlan_ID",
                schema: "hotel",
                table: "HotelMealPlans",
                column: "MealPlan_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_HotelMealPlans_Hotel_ID_MealPlan_ID",
                schema: "hotel",
                table: "HotelMealPlans",
                columns: new[] { "Hotel_ID", "MealPlan_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomTypes_RoomType_ID",
                schema: "hotel",
                table: "HotelRoomTypes",
                column: "RoomType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Company_ID",
                schema: "hotel",
                table: "Hotels",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_MealPlans_Name",
                schema: "nom",
                table: "MealPlans",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Persons_EGN",
                schema: "booking",
                table: "Persons",
                column: "EGN",
                unique: true,
                filter: "[EGN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_Persons_User_ID",
                schema: "booking",
                table: "Persons",
                column: "User_ID",
                unique: true,
                filter: "[User_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Guest_ID",
                schema: "booking",
                table: "Reservations",
                column: "Guest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Hotel_ID_CreatedByEmployee_ID",
                schema: "booking",
                table: "Reservations",
                columns: new[] { "Hotel_ID", "CreatedByEmployee_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Hotel_ID_HotelMealPlan_ID",
                schema: "booking",
                table: "Reservations",
                columns: new[] { "Hotel_ID", "HotelMealPlan_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Hotel_ID_Room_ID",
                schema: "booking",
                table: "Reservations",
                columns: new[] { "Hotel_ID", "Room_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Hotel_ID_RoomType_ID",
                schema: "hotel",
                table: "Rooms",
                columns: new[] { "Hotel_ID", "RoomType_ID" });

            migrationBuilder.CreateIndex(
                name: "UQ_Rooms_Hotel_ID_Number",
                schema: "hotel",
                table: "Rooms",
                columns: new[] { "Hotel_ID", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_RoomTypes_Name",
                schema: "nom",
                table: "RoomTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "booking");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "hotel");

            migrationBuilder.DropTable(
                name: "HotelMealPlans",
                schema: "hotel");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "hotel");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "booking");

            migrationBuilder.DropTable(
                name: "MealPlans",
                schema: "nom");

            migrationBuilder.DropTable(
                name: "HotelRoomTypes",
                schema: "hotel");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Hotels",
                schema: "hotel");

            migrationBuilder.DropTable(
                name: "RoomTypes",
                schema: "nom");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "hotel");
        }
    }
}
