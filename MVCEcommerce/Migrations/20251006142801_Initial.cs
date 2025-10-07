using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCEcommerce.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_EntityBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EntityBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GivenName = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<byte[]>(type: "bytea", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Brands__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarouselImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    CatalogId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarouselImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarouselImages__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Catalogs__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ShippingNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: true),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionTr = table.Column<string>(type: "text", nullable: true),
                    DescriptionEn = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProduct",
                columns: table => new
                {
                    CatalogsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProduct", x => new { x.CatalogsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CatalogProduct_Catalogs_CatalogsId",
                        column: x => x.CatalogsId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductImages__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecifications",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecifications", x => new { x.ProductId, x.SpecificationId });
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 2, "Adıyaman" },
                    { 3, "Afyonkarahisar" },
                    { 4, "Ağrı" },
                    { 5, "Amasya" },
                    { 6, "Ankara" },
                    { 7, "Antalya" },
                    { 8, "Artvin" },
                    { 9, "Aydın" },
                    { 10, "Balıkesir" },
                    { 11, "Bilecik" },
                    { 12, "Bingöl" },
                    { 13, "Bitlis" },
                    { 14, "Bolu" },
                    { 15, "Burdur" },
                    { 16, "Bursa" },
                    { 17, "Çanakkale" },
                    { 18, "Çankırı" },
                    { 19, "Çorum" },
                    { 20, "Denizli" },
                    { 21, "Diyarbakır" },
                    { 22, "Edirne" },
                    { 23, "Elazığ" },
                    { 24, "Erzincan" },
                    { 25, "Erzurum" },
                    { 26, "Eskişehir" },
                    { 27, "Gaziantep" },
                    { 28, "Giresun" },
                    { 29, "Gümüşhane" },
                    { 30, "Hakkâri" },
                    { 31, "Hatay" },
                    { 32, "Isparta" },
                    { 33, "Mersin" },
                    { 34, "İstanbul" },
                    { 35, "İzmir" },
                    { 36, "Kars" },
                    { 37, "Kastamonu" },
                    { 38, "Kayseri" },
                    { 39, "Kırklareli" },
                    { 40, "Kırşehir" },
                    { 41, "Kocaeli" },
                    { 42, "Konya" },
                    { 43, "Kütahya" },
                    { 44, "Malatya" },
                    { 45, "Manisa" },
                    { 46, "Kahramanmaraş" },
                    { 47, "Mardin" },
                    { 48, "Muğla" },
                    { 49, "Muş" },
                    { 50, "Nevşehir" },
                    { 51, "Niğde" },
                    { 52, "Ordu" },
                    { 53, "Rize" },
                    { 54, "Sakarya" },
                    { 55, "Samsun" },
                    { 56, "Siirt" },
                    { 57, "Sinop" },
                    { 58, "Sivas" },
                    { 59, "Tekirdağ" },
                    { 60, "Tokat" },
                    { 61, "Trabzon" },
                    { 62, "Tunceli" },
                    { 63, "Şanlıurfa" },
                    { 64, "Uşak" },
                    { 65, "Van" },
                    { 66, "Yozgat" },
                    { 67, "Zonguldak" },
                    { 68, "Aksaray" },
                    { 69, "Bayburt" },
                    { 70, "Karaman" },
                    { 71, "Kırıkkale" },
                    { 72, "Batman" },
                    { 73, "Şırnak" },
                    { 74, "Bartın" },
                    { 75, "Ardahan" },
                    { 76, "Iğdır" },
                    { 77, "Yalova" },
                    { 78, "Karabük" },
                    { 79, "Kilis" },
                    { 80, "Osmaniye" },
                    { 81, "Düzce" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "ALADAĞ", 1 },
                    { 2, "CEYHAN", 1 },
                    { 3, "ÇUKUROVA", 1 },
                    { 4, "FEKE", 1 },
                    { 5, "İMAMOĞLU", 1 },
                    { 6, "KARAİSALI", 1 },
                    { 7, "KARATAŞ", 1 },
                    { 8, "KOZAN", 1 },
                    { 9, "POZANTI", 1 },
                    { 10, "SAİMBEYLİ", 1 },
                    { 11, "SARIÇAM", 1 },
                    { 12, "SEYHAN", 1 },
                    { 13, "TUFANBEYLİ", 1 },
                    { 14, "YUMURTALIK", 1 },
                    { 15, "YÜREĞİR", 1 },
                    { 16, "ADIYAMAN MERKEZ", 2 },
                    { 17, "BESNİ", 2 },
                    { 18, "ÇELİKHAN", 2 },
                    { 19, "GERGER", 2 },
                    { 20, "GÖLBAŞI", 2 },
                    { 21, "KAHTA", 2 },
                    { 22, "SAMSAT", 2 },
                    { 23, "SİNCİK", 2 },
                    { 24, "TUT", 2 },
                    { 25, "AFYON MERKEZ", 3 },
                    { 26, "BAŞMAKÇI", 3 },
                    { 27, "BAYAT", 3 },
                    { 28, "BOLVADİN", 3 },
                    { 29, "ÇAY", 3 },
                    { 30, "ÇOBANLAR", 3 },
                    { 31, "DAZKIRI", 3 },
                    { 32, "DİNAR", 3 },
                    { 33, "EMİRDAĞ", 3 },
                    { 34, "EVCİLER", 3 },
                    { 35, "HOCALAR", 3 },
                    { 36, "İHSANİYE", 3 },
                    { 37, "İSCEHİSAR", 3 },
                    { 38, "KIZILÖREN", 3 },
                    { 39, "SANDIKLI", 3 },
                    { 40, "SİNCANLI", 3 },
                    { 41, "SULTANDAĞI", 3 },
                    { 42, "ŞUHUT", 3 },
                    { 43, "AĞRI MERKEZ", 4 },
                    { 44, "DİYADİN", 4 },
                    { 45, "DOĞUBAYAZIT", 4 },
                    { 46, "ELEŞKİRT", 4 },
                    { 47, "HAMUR", 4 },
                    { 48, "PATNOS", 4 },
                    { 49, "TAŞLIÇAY", 4 },
                    { 50, "TUTAK", 4 },
                    { 51, "AMASYA MERKEZ", 5 },
                    { 52, "GÖYNÜCEK", 5 },
                    { 53, "GÜMÜŞHACIKÖY", 5 },
                    { 54, "HAMAMÖZÜ", 5 },
                    { 55, "MERZİFON", 5 },
                    { 56, "SULUOVA", 5 },
                    { 57, "TAŞOVA", 5 },
                    { 58, "AKYURT", 6 },
                    { 59, "ALTINDAĞ", 6 },
                    { 60, "ANKARA", 6 },
                    { 61, "AYAŞ", 6 },
                    { 62, "BALÂ", 6 },
                    { 63, "BEYPAZARI", 6 },
                    { 64, "ÇAMLIDERE", 6 },
                    { 65, "ÇANKAYA", 6 },
                    { 66, "ÇUBUK", 6 },
                    { 67, "ELMADAĞ", 6 },
                    { 68, "ETİMESGUT", 6 },
                    { 69, "EVREN", 6 },
                    { 70, "GÖLBAŞI", 6 },
                    { 71, "GÜDÜL", 6 },
                    { 72, "HAYMANA", 6 },
                    { 73, "KALECİK", 6 },
                    { 74, "KAZAN", 6 },
                    { 75, "KEÇİÖREN", 6 },
                    { 76, "KIZILCAHAMAM", 6 },
                    { 77, "MAMAK", 6 },
                    { 78, "NALLIHAN", 6 },
                    { 79, "POLATLI", 6 },
                    { 80, "PURSAKLAR", 6 },
                    { 81, "SİNCAN", 6 },
                    { 82, "ŞEREFLİKOÇHİSAR", 6 },
                    { 83, "YENİMAHALLE", 6 },
                    { 84, "AKSEKİ", 7 },
                    { 85, "AKSU/ANTALYA", 7 },
                    { 86, "ALANYA", 7 },
                    { 87, "ANTALYA MERKEZ", 7 },
                    { 88, "DÖŞEMEALTI", 7 },
                    { 89, "ELMALI", 7 },
                    { 90, "FİNİKE", 7 },
                    { 91, "GAZİPAŞA", 7 },
                    { 92, "GÜNDOĞMUŞ", 7 },
                    { 93, "İBRADI", 7 },
                    { 94, "KALE", 7 },
                    { 95, "KAŞ", 7 },
                    { 96, "KEMER", 7 },
                    { 97, "KEPEZ", 7 },
                    { 98, "KONYAALTI", 7 },
                    { 99, "KORKUTELİ", 7 },
                    { 100, "KUMLUCA", 7 },
                    { 101, "MANAVGAT", 7 },
                    { 102, "MURATPAŞA", 7 },
                    { 103, "SERİK", 7 },
                    { 104, "ARDANUÇ", 8 },
                    { 105, "ARHAVİ", 8 },
                    { 106, "ARTVİN MERKEZ", 8 },
                    { 107, "BORÇKA", 8 },
                    { 108, "HOPA", 8 },
                    { 109, "MURGUL", 8 },
                    { 110, "ŞAVŞAT", 8 },
                    { 111, "YUSUFELİ", 8 },
                    { 112, "AYDIN MERKEZ", 9 },
                    { 113, "BOZDOĞAN", 9 },
                    { 114, "BUHARKENT", 9 },
                    { 115, "ÇİNE", 9 },
                    { 116, "DİDİM (YENİHİSAR)", 9 },
                    { 117, "GERMENCİK", 9 },
                    { 118, "İNCİRLİOVA", 9 },
                    { 119, "KARACASU", 9 },
                    { 120, "KARPUZLU", 9 },
                    { 121, "KOÇARLI", 9 },
                    { 122, "KÖŞK", 9 },
                    { 123, "KUŞADASI", 9 },
                    { 124, "KUYUCAK", 9 },
                    { 125, "NAZİLLİ", 9 },
                    { 126, "SÖKE", 9 },
                    { 127, "SULTANHİSAR", 9 },
                    { 128, "YENİPAZAR", 9 },
                    { 129, "AYVALIK", 10 },
                    { 130, "BALIKESİR MERKEZ", 10 },
                    { 131, "BALYA", 10 },
                    { 132, "BANDIRMA", 10 },
                    { 133, "BİGADİÇ", 10 },
                    { 134, "BURHANİYE", 10 },
                    { 135, "DURSUNBEY", 10 },
                    { 136, "EDREMİT", 10 },
                    { 137, "ERDEK", 10 },
                    { 138, "GÖMEÇ", 10 },
                    { 139, "GÖNEN", 10 },
                    { 140, "HAVRAN", 10 },
                    { 141, "İVRİNDİ", 10 },
                    { 142, "KEPSUT", 10 },
                    { 143, "MANYAS", 10 },
                    { 144, "MARMARA", 10 },
                    { 145, "SAVAŞTEPE", 10 },
                    { 146, "SINDIRGI", 10 },
                    { 147, "SUSURLUK", 10 },
                    { 148, "BİLECİK MERKEZ", 11 },
                    { 149, "BOZÜYÜK", 11 },
                    { 150, "GÖLPAZARI", 11 },
                    { 151, "İNHİSAR", 11 },
                    { 152, "OSMANELİ", 11 },
                    { 153, "PAZARYERİ", 11 },
                    { 154, "SÖĞÜT", 11 },
                    { 155, "YENİPAZAR", 11 },
                    { 156, "ADAKLI", 12 },
                    { 157, "BİNGÖL MERKEZ", 12 },
                    { 158, "GENÇ", 12 },
                    { 159, "KARLIOVA", 12 },
                    { 160, "KİĞI", 12 },
                    { 161, "SOLHAN", 12 },
                    { 162, "YAYLADERE", 12 },
                    { 163, "YEDİSU", 12 },
                    { 164, "ADİLCEVAZ", 13 },
                    { 165, "AHLAT", 13 },
                    { 166, "BİTLİS MERKEZ", 13 },
                    { 167, "GÜROYMAK", 13 },
                    { 168, "HİZAN", 13 },
                    { 169, "MUTKİ", 13 },
                    { 170, "TATVAN", 13 },
                    { 171, "BOLU MERKEZ", 14 },
                    { 172, "DÖRTDİVAN", 14 },
                    { 173, "GEREDE", 14 },
                    { 174, "GÖYNÜK", 14 },
                    { 175, "KIBRISCIK", 14 },
                    { 176, "MENGEN", 14 },
                    { 177, "MUDURNU", 14 },
                    { 178, "SEBEN", 14 },
                    { 179, "YENİÇAĞA", 14 },
                    { 180, "AĞLASUN", 15 },
                    { 181, "ALTINYAYLA", 15 },
                    { 182, "BUCAK", 15 },
                    { 183, "BURDUR MERKEZ", 15 },
                    { 184, "ÇAVDIR", 15 },
                    { 185, "ÇELTİKÇİ", 15 },
                    { 186, "GÖLHİSAR", 15 },
                    { 187, "KARAMANLI", 15 },
                    { 188, "KEMER", 15 },
                    { 189, "TEFENNİ", 15 },
                    { 190, "YEŞİLOVA", 15 },
                    { 191, "BURSA MERKEZ", 16 },
                    { 192, "BÜYÜKORHAN", 16 },
                    { 193, "GEMLİK", 16 },
                    { 194, "GÜRSU", 16 },
                    { 195, "HARMANCIK", 16 },
                    { 196, "İNEGÖL", 16 },
                    { 197, "İZNİK", 16 },
                    { 198, "KARACABEY", 16 },
                    { 199, "KELES", 16 },
                    { 200, "KESTEL", 16 },
                    { 201, "MUDANYA", 16 },
                    { 202, "MUSTAFA KEMAL PAŞA", 16 },
                    { 203, "NİLÜFER", 16 },
                    { 204, "ORHANELİ", 16 },
                    { 205, "ORHANGAZİ", 16 },
                    { 206, "OSMANGAZİ", 16 },
                    { 207, "YENİŞEHİR", 16 },
                    { 208, "YILDIRIM", 16 },
                    { 209, "AYVACIK", 17 },
                    { 210, "BAYRAMİÇ", 17 },
                    { 211, "BİGA", 17 },
                    { 212, "BOZCAADA", 17 },
                    { 213, "ÇAN", 17 },
                    { 214, "ÇANAKKALE MERKEZ", 17 },
                    { 215, "ECEABAT", 17 },
                    { 216, "EZİNE", 17 },
                    { 217, "GELİBOLU", 17 },
                    { 218, "GÖKÇEADA (İMROZ)", 17 },
                    { 219, "LAPSEKİ", 17 },
                    { 220, "YENİCE", 17 },
                    { 221, "ATKARACALAR", 18 },
                    { 222, "BAYRAMÖREN", 18 },
                    { 223, "ÇANKIRI MERKEZ", 18 },
                    { 224, "ÇERKEŞ", 18 },
                    { 225, "ELDİVAN", 18 },
                    { 226, "ILGAZ", 18 },
                    { 227, "KIZILIRMAK", 18 },
                    { 228, "KORGUN", 18 },
                    { 229, "KURŞUNLU", 18 },
                    { 230, "ORTA", 18 },
                    { 231, "ŞABANÖZÜ", 18 },
                    { 232, "YAPRAKLI", 18 },
                    { 233, "ALACA", 19 },
                    { 234, "BAYAT", 19 },
                    { 235, "BOĞAZKALE", 19 },
                    { 236, "ÇORUM MERKEZ", 19 },
                    { 237, "DODURGA", 19 },
                    { 238, "İSKİLİP", 19 },
                    { 239, "KARGI", 19 },
                    { 240, "LAÇİN", 19 },
                    { 241, "MECİTÖZÜ", 19 },
                    { 242, "OĞUZLAR", 19 },
                    { 243, "ORTAKÖY", 19 },
                    { 244, "OSMANCIK", 19 },
                    { 245, "SUNGURLU", 19 },
                    { 246, "UĞURLUDAĞ", 19 },
                    { 247, "ACIPAYAM", 20 },
                    { 248, "AKKÖY", 20 },
                    { 249, "BABADAĞ", 20 },
                    { 250, "BAKLAN", 20 },
                    { 251, "BEKİLLİ", 20 },
                    { 252, "BEYAĞAÇ", 20 },
                    { 253, "BOZKURT", 20 },
                    { 254, "BULDAN", 20 },
                    { 255, "ÇAL", 20 },
                    { 256, "ÇAMELİ", 20 },
                    { 257, "ÇARDAK", 20 },
                    { 258, "ÇİVRİL", 20 },
                    { 259, "DENİZLİ MERKEZ", 20 },
                    { 260, "GÜNEY", 20 },
                    { 261, "HONAZ", 20 },
                    { 262, "KALE", 20 },
                    { 263, "SARAYKÖY", 20 },
                    { 264, "SERİNHİSAR", 20 },
                    { 265, "TAVAS", 20 },
                    { 266, "BAĞLAR", 21 },
                    { 267, "BİSMİL", 21 },
                    { 268, "ÇERMİK", 21 },
                    { 269, "ÇINAR", 21 },
                    { 270, "ÇÜNGÜŞ", 21 },
                    { 271, "DİCLE", 21 },
                    { 272, "DİYARBAKIR MERKEZ", 21 },
                    { 273, "EĞİL", 21 },
                    { 274, "ERGANİ", 21 },
                    { 275, "HANİ", 21 },
                    { 276, "HAZRO", 21 },
                    { 277, "KAYAPINAR", 21 },
                    { 278, "KOCAKÖY", 21 },
                    { 279, "KULP", 21 },
                    { 280, "LİCE", 21 },
                    { 281, "SİLVAN", 21 },
                    { 282, "SUR", 21 },
                    { 283, "YENİŞEHİR/DİYARBAKIR", 21 },
                    { 284, "EDİRNE MERKEZ", 22 },
                    { 285, "ENEZ", 22 },
                    { 286, "HAVSA", 22 },
                    { 287, "İPSALA", 22 },
                    { 288, "KEŞAN", 22 },
                    { 289, "LALAPAŞA", 22 },
                    { 290, "MERİÇ", 22 },
                    { 291, "SÜLOĞLU", 22 },
                    { 292, "UZUNKÖPRÜ", 22 },
                    { 293, "AĞIN", 23 },
                    { 294, "ALACAKAYA", 23 },
                    { 295, "ARICAK", 23 },
                    { 296, "BASKİL", 23 },
                    { 297, "ELAZIĞ MERKEZ", 23 },
                    { 298, "KARAKOÇAN", 23 },
                    { 299, "KEBAN", 23 },
                    { 300, "KOVANCILAR", 23 },
                    { 301, "MADEN", 23 },
                    { 302, "PALU", 23 },
                    { 303, "SİVRİCE", 23 },
                    { 304, "ÇAYIRLI", 24 },
                    { 305, "ERZİNCAN MERKEZ", 24 },
                    { 306, "İLİÇ", 24 },
                    { 307, "KEMAH", 24 },
                    { 308, "KEMALİYE", 24 },
                    { 309, "OTLUKBELİ", 24 },
                    { 310, "REFAHİYE", 24 },
                    { 311, "TERCAN", 24 },
                    { 312, "ÜZÜMLÜ", 24 },
                    { 313, "AŞKALE", 25 },
                    { 314, "ÇAT", 25 },
                    { 315, "ERZURUM MERKEZ", 25 },
                    { 316, "HINIS", 25 },
                    { 317, "HORASAN", 25 },
                    { 318, "ILICA", 25 },
                    { 319, "İSPİR", 25 },
                    { 320, "KARAÇOBAN", 25 },
                    { 321, "KARAYAZI", 25 },
                    { 322, "KÖPRÜKÖY", 25 },
                    { 323, "NARMAN", 25 },
                    { 324, "OLTU", 25 },
                    { 325, "OLUR", 25 },
                    { 326, "PALANDÖKEN", 25 },
                    { 327, "PASİNLER", 25 },
                    { 328, "PAZARYOLU", 25 },
                    { 329, "ŞENKAYA", 25 },
                    { 330, "TEKMAN", 25 },
                    { 331, "TORTUM", 25 },
                    { 332, "UZUNDERE", 25 },
                    { 333, "YAKUTİYE", 25 },
                    { 334, "ALPU", 26 },
                    { 335, "BEYLİKOVA", 26 },
                    { 336, "ÇİFTELER", 26 },
                    { 337, "ESKİŞEHİR MERKEZ", 26 },
                    { 338, "GÜNYÜZÜ", 26 },
                    { 339, "HAN", 26 },
                    { 340, "İNÖNÜ", 26 },
                    { 341, "MAHMUDİYE", 26 },
                    { 342, "MİHALGAZİ", 26 },
                    { 343, "MİHALIÇÇIK", 26 },
                    { 344, "ODUNPAZARI", 26 },
                    { 345, "SARICAKAYA", 26 },
                    { 346, "SEYİTGAZİ", 26 },
                    { 347, "SİVRİHİSAR", 26 },
                    { 348, "TEPEBAŞI", 26 },
                    { 349, "ARABAN", 27 },
                    { 350, "GAZİANTEP MERKEZ", 27 },
                    { 351, "İSLAHİYE", 27 },
                    { 352, "KARKAMIŞ", 27 },
                    { 353, "NİZİP", 27 },
                    { 354, "NURDAĞI", 27 },
                    { 355, "OĞUZELİ", 27 },
                    { 356, "ŞAHİNBEY", 27 },
                    { 357, "ŞEHİTKAMİL", 27 },
                    { 358, "YAVUZELİ", 27 },
                    { 359, "ALUCRA", 28 },
                    { 360, "BULANCAK", 28 },
                    { 361, "ÇAMOLUK", 28 },
                    { 362, "ÇANAKÇI", 28 },
                    { 363, "DERELİ", 28 },
                    { 364, "DOĞANKENT", 28 },
                    { 365, "ESPİYE", 28 },
                    { 366, "EYNESİL", 28 },
                    { 367, "GİRESUN MERKEZ", 28 },
                    { 368, "GÖRELE", 28 },
                    { 369, "GÜCE", 28 },
                    { 370, "KEŞAP", 28 },
                    { 371, "PİRAZİZ", 28 },
                    { 372, "ŞEBİNKARAHİSAR", 28 },
                    { 373, "TİREBOLU", 28 },
                    { 374, "YAĞLIDERE", 28 },
                    { 375, "GÜMÜŞHANE MERKEZ", 29 },
                    { 376, "KELKİT", 29 },
                    { 377, "KÖSE", 29 },
                    { 378, "KÜRTÜN", 29 },
                    { 379, "ŞİRAN", 29 },
                    { 380, "TORUL", 29 },
                    { 381, "ÇUKURCA", 30 },
                    { 382, "HAKKARİ MERKEZ", 30 },
                    { 383, "ŞEMDİNLİ", 30 },
                    { 384, "YÜKSEKOVA", 30 },
                    { 385, "ALTINÖZÜ", 31 },
                    { 386, "BELEN", 31 },
                    { 387, "DÖRTYOL", 31 },
                    { 388, "ERZİN", 31 },
                    { 389, "HASSA", 31 },
                    { 390, "HATAY MERKEZ", 31 },
                    { 391, "İSKENDERUN", 31 },
                    { 392, "KIRIKHAN", 31 },
                    { 393, "KUMLU", 31 },
                    { 394, "REYHANLI", 31 },
                    { 395, "SAMANDAĞ", 31 },
                    { 396, "YAYLADAĞI", 31 },
                    { 397, "AKSU", 32 },
                    { 398, "ATABEY", 32 },
                    { 399, "EĞİRDİR", 32 },
                    { 400, "GELENDOST", 32 },
                    { 401, "GÖNEN", 32 },
                    { 402, "ISPARTA MERKEZ", 32 },
                    { 403, "KEÇİBORLU", 32 },
                    { 404, "SENİRKENT", 32 },
                    { 405, "SÜTÇÜLER", 32 },
                    { 406, "ŞARKİKARAAĞAÇ", 32 },
                    { 407, "ULUBORLU", 32 },
                    { 408, "YALVAÇ", 32 },
                    { 409, "YENİŞARBADEMLİ", 32 },
                    { 410, "AKDENİZ", 33 },
                    { 411, "ANAMUR", 33 },
                    { 412, "AYDINCIK", 33 },
                    { 413, "BOZYAZI", 33 },
                    { 414, "ÇAMLIYAYLA", 33 },
                    { 415, "ERDEMLİ", 33 },
                    { 416, "GÜLNAR", 33 },
                    { 417, "İÇEL MERKEZ", 33 },
                    { 418, "MEZİTLİ", 33 },
                    { 419, "MUT", 33 },
                    { 420, "SİLİFKE", 33 },
                    { 421, "TARSUS", 33 },
                    { 422, "TOROSLAR", 33 },
                    { 423, "YENİŞEHİR/MERSİN", 33 },
                    { 424, "ADALAR", 34 },
                    { 425, "ARNAVUTKÖY", 34 },
                    { 426, "ATAŞEHİR", 34 },
                    { 427, "AVCILAR", 34 },
                    { 428, "BAĞCILAR", 34 },
                    { 429, "BAHÇELİEVLER", 34 },
                    { 430, "BAKIRKÖY", 34 },
                    { 431, "BAŞAKŞEHİR", 34 },
                    { 432, "BAYRAMPAŞA", 34 },
                    { 433, "BEŞİKTAŞ", 34 },
                    { 434, "BEYKOZ", 34 },
                    { 435, "BEYLİKDÜZÜ", 34 },
                    { 436, "BEYOĞLU", 34 },
                    { 437, "BÜYÜKÇEKMECE", 34 },
                    { 438, "ÇATALCA", 34 },
                    { 439, "ÇEKMEKÖY", 34 },
                    { 440, "EMİNÖNÜ", 34 },
                    { 441, "ESENLER", 34 },
                    { 442, "ESENYURT", 34 },
                    { 443, "EYÜP", 34 },
                    { 444, "FATİH", 34 },
                    { 445, "GAZİOSMANPAŞA", 34 },
                    { 446, "GÜNGÖREN", 34 },
                    { 447, "İSTANBUL MERKEZ", 34 },
                    { 448, "KADIKÖY", 34 },
                    { 449, "KAĞITHANE", 34 },
                    { 450, "KARTAL", 34 },
                    { 451, "KÜÇÜKÇEKMECE", 34 },
                    { 452, "MALTEPE", 34 },
                    { 453, "PENDİK", 34 },
                    { 454, "SANCAKTEPE", 34 },
                    { 455, "SARIYER", 34 },
                    { 456, "SİLİVRİ", 34 },
                    { 457, "SULTANBEYLİ", 34 },
                    { 458, "SULTANGAZİ", 34 },
                    { 459, "ŞİLE", 34 },
                    { 460, "ŞİŞLİ", 34 },
                    { 461, "TUZLA", 34 },
                    { 462, "ÜMRANİYE", 34 },
                    { 463, "ÜSKÜDAR", 34 },
                    { 464, "ZEYTİNBURNU", 34 },
                    { 465, "ALİAĞA", 35 },
                    { 466, "BALÇOVA", 35 },
                    { 467, "BAYINDIR", 35 },
                    { 468, "BAYRAKLI", 35 },
                    { 469, "BERGAMA", 35 },
                    { 470, "BEYDAĞ", 35 },
                    { 471, "BORNOVA", 35 },
                    { 472, "BUCA", 35 },
                    { 473, "ÇEŞME", 35 },
                    { 474, "ÇİĞLİ", 35 },
                    { 475, "DİKİLİ", 35 },
                    { 476, "FOÇA", 35 },
                    { 477, "GAZİEMİR", 35 },
                    { 478, "GÜZELBAHÇE", 35 },
                    { 479, "İZMİR MERKEZ", 35 },
                    { 480, "KARABAĞLAR", 35 },
                    { 481, "KARABURUN", 35 },
                    { 482, "KARŞIYAKA", 35 },
                    { 483, "KEMALPAŞA", 35 },
                    { 484, "KINIK", 35 },
                    { 485, "KİRAZ", 35 },
                    { 486, "KONAK", 35 },
                    { 487, "MENDERES", 35 },
                    { 488, "MENEMEN", 35 },
                    { 489, "NARLIDERE", 35 },
                    { 490, "ÖDEMİŞ", 35 },
                    { 491, "SEFERİHİSAR", 35 },
                    { 492, "SELÇUK", 35 },
                    { 493, "TİRE", 35 },
                    { 494, "TORBALI", 35 },
                    { 495, "URLA", 35 },
                    { 496, "AKYAKA", 36 },
                    { 497, "ARPAÇAY", 36 },
                    { 498, "DİGOR", 36 },
                    { 499, "KAĞIZMAN", 36 },
                    { 500, "KARS MERKEZ", 36 },
                    { 501, "SARIKAMIŞ", 36 },
                    { 502, "SELİM", 36 },
                    { 503, "SUSUZ", 36 },
                    { 504, "ABANA", 37 },
                    { 505, "AĞLI", 37 },
                    { 506, "ARAÇ", 37 },
                    { 507, "AZDAVAY", 37 },
                    { 508, "BOZKURT", 37 },
                    { 509, "CİDE", 37 },
                    { 510, "ÇATALZEYTİN", 37 },
                    { 511, "DADAY", 37 },
                    { 512, "DEVREKÂNİ", 37 },
                    { 513, "DOĞANYURT", 37 },
                    { 514, "HANÖNÜ", 37 },
                    { 515, "İHSANGAZİ", 37 },
                    { 516, "İNEBOLU", 37 },
                    { 517, "KASTAMONU MERKEZ", 37 },
                    { 518, "KÜRE", 37 },
                    { 519, "PINARBAŞI", 37 },
                    { 520, "SEYDİLER", 37 },
                    { 521, "ŞENPAZAR", 37 },
                    { 522, "TAŞKÖPRÜ", 37 },
                    { 523, "TOSYA", 37 },
                    { 524, "AKKIŞLA", 38 },
                    { 525, "BÜNYAN", 38 },
                    { 526, "DEVELİ", 38 },
                    { 527, "FELAHİYE", 38 },
                    { 528, "HACILAR", 38 },
                    { 529, "İNCESU", 38 },
                    { 530, "KAYSERİ MERKEZ", 38 },
                    { 531, "KOCASİNAN", 38 },
                    { 532, "MELİKGAZİ", 38 },
                    { 533, "ÖZVATAN", 38 },
                    { 534, "PINARBAŞI", 38 },
                    { 535, "SARIOĞLAN", 38 },
                    { 536, "SARIZ", 38 },
                    { 537, "TALAS", 38 },
                    { 538, "TOMARZA", 38 },
                    { 539, "YAHYALI", 38 },
                    { 540, "YEŞİLHİSAR", 38 },
                    { 541, "BABAESKİ", 39 },
                    { 542, "DEMİRKÖY", 39 },
                    { 543, "KIRKLARELİ MERKEZ", 39 },
                    { 544, "KOFÇAZ", 39 },
                    { 545, "LÜLEBURGAZ", 39 },
                    { 546, "PEHLİVANKÖY", 39 },
                    { 547, "PINARHİSAR", 39 },
                    { 548, "VİZE", 39 },
                    { 549, "AKÇAKENT", 40 },
                    { 550, "AKPINAR", 40 },
                    { 551, "BOZTEPE", 40 },
                    { 552, "ÇİÇEKDAĞI", 40 },
                    { 553, "KAMAN", 40 },
                    { 554, "KIRŞEHİR MERKEZ", 40 },
                    { 555, "MUCUR", 40 },
                    { 556, "BAŞİSKELE", 41 },
                    { 557, "ÇAYIROVA", 41 },
                    { 558, "DARICA", 41 },
                    { 559, "DERİNCE", 41 },
                    { 560, "DİLOVASI", 41 },
                    { 561, "GEBZE", 41 },
                    { 562, "GÖLCÜK", 41 },
                    { 563, "İZMİT", 41 },
                    { 564, "KANDIRA", 41 },
                    { 565, "KARAMÜRSEL", 41 },
                    { 566, "KARTEPE", 41 },
                    { 567, "KOCAELİ MERKEZ (İZMİT)", 41 },
                    { 568, "KÖRFEZ", 41 },
                    { 569, "AHIRLI", 42 },
                    { 570, "AKÖREN", 42 },
                    { 571, "AKŞEHİR", 42 },
                    { 572, "ALTINEKİN", 42 },
                    { 573, "BEYŞEHİR", 42 },
                    { 574, "BOZKIR", 42 },
                    { 575, "CİHANBEYLİ", 42 },
                    { 576, "ÇELTİK", 42 },
                    { 577, "ÇUMRA", 42 },
                    { 578, "DERBENT", 42 },
                    { 579, "DEREBUCAK", 42 },
                    { 580, "DOĞANHİSAR", 42 },
                    { 581, "EMİRGAZİ", 42 },
                    { 582, "EREĞLİ", 42 },
                    { 583, "GÜNEYSINIR", 42 },
                    { 584, "HADIM", 42 },
                    { 585, "HALKAPINAR", 42 },
                    { 586, "HÜYÜK", 42 },
                    { 587, "ILGIN", 42 },
                    { 588, "KADINHANI", 42 },
                    { 589, "KARAPINAR", 42 },
                    { 590, "KARATAY", 42 },
                    { 591, "KONYA MERKEZ", 42 },
                    { 592, "KULU", 42 },
                    { 593, "MERAM", 42 },
                    { 594, "SARAYÖNÜ", 42 },
                    { 595, "SELÇUKLU", 42 },
                    { 596, "SEYDİŞEHİR", 42 },
                    { 597, "TAŞKENT", 42 },
                    { 598, "TUZLUKÇU", 42 },
                    { 599, "YALIHÜYÜK", 42 },
                    { 600, "YUNAK", 42 },
                    { 601, "ALTINTAŞ", 43 },
                    { 602, "ASLANAPA", 43 },
                    { 603, "ÇAVDARHİSAR", 43 },
                    { 604, "DOMANİÇ", 43 },
                    { 605, "DUMLUPINAR", 43 },
                    { 606, "EMET", 43 },
                    { 607, "GEDİZ", 43 },
                    { 608, "HİSARCIK", 43 },
                    { 609, "KÜTAHYA MERKEZ", 43 },
                    { 610, "PAZARLAR", 43 },
                    { 611, "SİMAV", 43 },
                    { 612, "ŞAPHANE", 43 },
                    { 613, "TAVŞANLI", 43 },
                    { 614, "AKÇADAĞ", 44 },
                    { 615, "ARAPGİR", 44 },
                    { 616, "ARGUVAN", 44 },
                    { 617, "BATTALGAZİ", 44 },
                    { 618, "DARENDE", 44 },
                    { 619, "DOĞANŞEHİR", 44 },
                    { 620, "DOĞANYOL", 44 },
                    { 621, "HEKİMHAN", 44 },
                    { 622, "KALE", 44 },
                    { 623, "KULUNCAK", 44 },
                    { 624, "MALATYA MERKEZ", 44 },
                    { 625, "PÜTÜRGE", 44 },
                    { 626, "YAZIHAN", 44 },
                    { 627, "YEŞİLYURT", 44 },
                    { 628, "AHMETLİ", 45 },
                    { 629, "AKHİSAR", 45 },
                    { 630, "ALAŞEHİR", 45 },
                    { 631, "DEMİRCİ", 45 },
                    { 632, "GÖLMARMARA", 45 },
                    { 633, "GÖRDES", 45 },
                    { 634, "KIRKAĞAÇ", 45 },
                    { 635, "KÖPRÜBAŞI", 45 },
                    { 636, "KULA", 45 },
                    { 637, "MANİSA MERKEZ", 45 },
                    { 638, "SALİHLİ", 45 },
                    { 639, "SARIGÖL", 45 },
                    { 640, "SARUHANLI", 45 },
                    { 641, "SELENDİ", 45 },
                    { 642, "SOMA", 45 },
                    { 643, "TURGUTLU", 45 },
                    { 644, "AFŞİN", 46 },
                    { 645, "ANDIRIN", 46 },
                    { 646, "ÇAĞLIYANCERİT", 46 },
                    { 647, "EKİNÖZÜ", 46 },
                    { 648, "ELBİSTAN", 46 },
                    { 649, "GÖKSUN", 46 },
                    { 650, "KAHRAMANMARAŞ MERKEZ", 46 },
                    { 651, "NURHAK", 46 },
                    { 652, "PAZARCIK", 46 },
                    { 653, "TÜRKOĞLU", 46 },
                    { 654, "DARGEÇİT", 47 },
                    { 655, "DERİK", 47 },
                    { 656, "KIZILTEPE", 47 },
                    { 657, "MARDİN MERKEZ", 47 },
                    { 658, "MAZIDAĞI", 47 },
                    { 659, "MİDYAT", 47 },
                    { 660, "NUSAYBİN", 47 },
                    { 661, "ÖMERLİ", 47 },
                    { 662, "SAVUR", 47 },
                    { 663, "YEŞİLLİ", 47 },
                    { 664, "BODRUM", 48 },
                    { 665, "DALAMAN", 48 },
                    { 666, "DATÇA", 48 },
                    { 667, "FETHİYE", 48 },
                    { 668, "KAVAKLIDERE", 48 },
                    { 669, "KÖYCEĞİZ", 48 },
                    { 670, "MARMARİS", 48 },
                    { 671, "MİLAS", 48 },
                    { 672, "MUĞLA MERKEZ", 48 },
                    { 673, "ORTACA", 48 },
                    { 674, "ULA", 48 },
                    { 675, "YATAĞAN", 48 },
                    { 676, "BULANIK", 49 },
                    { 677, "HASKÖY", 49 },
                    { 678, "KORKUT", 49 },
                    { 679, "MALAZGİRT", 49 },
                    { 680, "MUŞ MERKEZ", 49 },
                    { 681, "VARTO", 49 },
                    { 682, "ACIGÖL", 50 },
                    { 683, "AVANOS", 50 },
                    { 684, "DERİNKUYU", 50 },
                    { 685, "GÜLŞEHİR", 50 },
                    { 686, "HACIBEKTAŞ", 50 },
                    { 687, "KOZAKLI", 50 },
                    { 688, "NEVŞEHİR MERKEZ", 50 },
                    { 689, "ÜRGÜP", 50 },
                    { 690, "ALTUNHİSAR", 51 },
                    { 691, "BOR", 51 },
                    { 692, "ÇAMARDI", 51 },
                    { 693, "ÇİFTLİK", 51 },
                    { 694, "NİĞDE MERKEZ", 51 },
                    { 695, "ULUKIŞLA", 51 },
                    { 696, "AKKUŞ", 52 },
                    { 697, "AYBASTI", 52 },
                    { 698, "ÇAMAŞ", 52 },
                    { 699, "ÇATALPINAR", 52 },
                    { 700, "ÇAYBAŞI", 52 },
                    { 701, "FATSA", 52 },
                    { 702, "GÖLKÖY", 52 },
                    { 703, "GÜLYALI", 52 },
                    { 704, "GÜRGENTEPE", 52 },
                    { 705, "İKİZCE", 52 },
                    { 706, "KABADÜZ", 52 },
                    { 707, "KABATAŞ", 52 },
                    { 708, "KORGAN", 52 },
                    { 709, "KUMRU", 52 },
                    { 710, "MESUDİYE", 52 },
                    { 711, "ORDU MERKEZ", 52 },
                    { 712, "PERŞEMBE", 52 },
                    { 713, "ULUBEY", 52 },
                    { 714, "ÜNYE", 52 },
                    { 715, "ARDEŞEN", 53 },
                    { 716, "ÇAMLIHEMŞİN", 53 },
                    { 717, "ÇAYELİ", 53 },
                    { 718, "DEREPAZARI", 53 },
                    { 719, "FINDIKLI", 53 },
                    { 720, "GÜNEYSU", 53 },
                    { 721, "HEMŞİN", 53 },
                    { 722, "İKİZDERE", 53 },
                    { 723, "İYİDERE", 53 },
                    { 724, "KALKANDERE", 53 },
                    { 725, "PAZAR", 53 },
                    { 726, "RİZE MERKEZ", 53 },
                    { 727, "ADAPAZARI", 54 },
                    { 728, "AKYAZI", 54 },
                    { 729, "ARİFİYE", 54 },
                    { 730, "ERENLER", 54 },
                    { 731, "FERİZLİ", 54 },
                    { 732, "GEYVE", 54 },
                    { 733, "HENDEK", 54 },
                    { 734, "KARAPÜRÇEK", 54 },
                    { 735, "KARASU", 54 },
                    { 736, "KAYNARCA", 54 },
                    { 737, "KOCAALİ", 54 },
                    { 738, "PAMUKOVA", 54 },
                    { 739, "SAKARYA MERKEZ (ADAPAZARI)", 54 },
                    { 740, "SAPANCA", 54 },
                    { 741, "SERDİVAN", 54 },
                    { 742, "SÖĞÜTLÜ", 54 },
                    { 743, "TARAKLI", 54 },
                    { 744, "ALAÇAM", 55 },
                    { 745, "ASARCIK", 55 },
                    { 746, "ATAKUM", 55 },
                    { 747, "AYVACIK", 55 },
                    { 748, "BAFRA", 55 },
                    { 749, "CANİK", 55 },
                    { 750, "ÇARŞAMBA", 55 },
                    { 751, "HAVZA", 55 },
                    { 752, "İLKADIM", 55 },
                    { 753, "KAVAK", 55 },
                    { 754, "LADİK", 55 },
                    { 755, "ONDOKUZMAYIS", 55 },
                    { 756, "SALIPAZARI", 55 },
                    { 757, "SAMSUN MERKEZ", 55 },
                    { 758, "TEKKEKÖY", 55 },
                    { 759, "TERME", 55 },
                    { 760, "VEZİRKÖPRÜ", 55 },
                    { 761, "YAKAKENT", 55 },
                    { 762, "AYDINLAR", 56 },
                    { 763, "BAYKAN", 56 },
                    { 764, "ERUH", 56 },
                    { 765, "KURTALAN", 56 },
                    { 766, "PERVARİ", 56 },
                    { 767, "SİİRT MERKEZ", 56 },
                    { 768, "ŞİRVAN", 56 },
                    { 769, "AYANCIK", 57 },
                    { 770, "BOYABAT", 57 },
                    { 771, "DİKMEN", 57 },
                    { 772, "DURAĞAN", 57 },
                    { 773, "ERFELEK", 57 },
                    { 774, "GERZE", 57 },
                    { 775, "SARAYDÜZÜ", 57 },
                    { 776, "SİNOP MERKEZ", 57 },
                    { 777, "TÜRKELİ", 57 },
                    { 778, "AKINCILAR", 58 },
                    { 779, "ALTINYAYLA", 58 },
                    { 780, "DİVRİĞİ", 58 },
                    { 781, "DOĞANŞAR", 58 },
                    { 782, "GEMEREK", 58 },
                    { 783, "GÖLOVA", 58 },
                    { 784, "GÜRÜN", 58 },
                    { 785, "HAFİK", 58 },
                    { 786, "İMRANLI", 58 },
                    { 787, "KANGAL", 58 },
                    { 788, "KOYULHİSAR", 58 },
                    { 789, "SİVAS MERKEZ", 58 },
                    { 790, "SUŞEHRİ", 58 },
                    { 791, "ŞARKIŞLA", 58 },
                    { 792, "ULAŞ", 58 },
                    { 793, "YILDIZELİ", 58 },
                    { 794, "ZARA", 58 },
                    { 795, "ÇERKEZKÖY", 59 },
                    { 796, "ÇORLU", 59 },
                    { 797, "HAYRABOLU", 59 },
                    { 798, "MALKARA", 59 },
                    { 799, "MARMARAEREĞLİSİ", 59 },
                    { 800, "MURATLI", 59 },
                    { 801, "SARAY", 59 },
                    { 802, "ŞARKÖY", 59 },
                    { 803, "TEKİRDAĞ MERKEZ", 59 },
                    { 804, "ALMUS", 60 },
                    { 805, "ARTOVA", 60 },
                    { 806, "BAŞÇİFTLİK", 60 },
                    { 807, "ERBAA", 60 },
                    { 808, "NİKSAR", 60 },
                    { 809, "PAZAR", 60 },
                    { 810, "REŞADİYE", 60 },
                    { 811, "SULUSARAY", 60 },
                    { 812, "TOKAT MERKEZ", 60 },
                    { 813, "TURHAL", 60 },
                    { 814, "YEŞİLYURT", 60 },
                    { 815, "ZİLE", 60 },
                    { 816, "AKÇAABAT", 61 },
                    { 817, "ARAKLI", 61 },
                    { 818, "ARSİN", 61 },
                    { 819, "BEŞİKDÜZÜ", 61 },
                    { 820, "ÇARŞIBAŞI", 61 },
                    { 821, "ÇAYKARA", 61 },
                    { 822, "DERNEKPAZARI", 61 },
                    { 823, "DÜZKÖY", 61 },
                    { 824, "HAYRAT", 61 },
                    { 825, "KÖPRÜBAŞI", 61 },
                    { 826, "MAÇKA", 61 },
                    { 827, "OF", 61 },
                    { 828, "SÜRMENE", 61 },
                    { 829, "ŞALPAZARI", 61 },
                    { 830, "TONYA", 61 },
                    { 831, "TRABZON MERKEZ", 61 },
                    { 832, "VAKFIKEBİR", 61 },
                    { 833, "YOMRA", 61 },
                    { 834, "ÇEMİŞGEZEK", 62 },
                    { 835, "HOZAT", 62 },
                    { 836, "MAZGİRT", 62 },
                    { 837, "NAZIMİYE", 62 },
                    { 838, "OVACIK", 62 },
                    { 839, "PERTEK", 62 },
                    { 840, "PÜLÜMÜR", 62 },
                    { 841, "TUNCELİ MERKEZ", 62 },
                    { 842, "AKÇAKALE", 63 },
                    { 843, "BİRECİK", 63 },
                    { 844, "BOZOVA", 63 },
                    { 845, "CEYLANPINAR", 63 },
                    { 846, "HALFETİ", 63 },
                    { 847, "HARRAN", 63 },
                    { 848, "HİLVAN", 63 },
                    { 849, "SİVEREK", 63 },
                    { 850, "SURUÇ", 63 },
                    { 851, "ŞANLIURFA MERKEZ", 63 },
                    { 852, "VİRANŞEHİR", 63 },
                    { 853, "BANAZ", 64 },
                    { 854, "EŞME", 64 },
                    { 855, "KARAHALLI", 64 },
                    { 856, "SİVASLI", 64 },
                    { 857, "ULUBEY", 64 },
                    { 858, "UŞAK MERKEZ", 64 },
                    { 859, "BAHÇESARAY", 65 },
                    { 860, "BAŞKALE", 65 },
                    { 861, "ÇALDIRAN", 65 },
                    { 862, "ÇATAK", 65 },
                    { 863, "EDREMİT", 65 },
                    { 864, "ERCİŞ", 65 },
                    { 865, "GEVAŞ", 65 },
                    { 866, "GÜRPINAR", 65 },
                    { 867, "MURADİYE", 65 },
                    { 868, "ÖZALP", 65 },
                    { 869, "SARAY", 65 },
                    { 870, "VAN MERKEZ", 65 },
                    { 871, "AKDAĞMADENİ", 66 },
                    { 872, "AYDINCIK", 66 },
                    { 873, "BOĞAZLIYAN", 66 },
                    { 874, "ÇANDIR", 66 },
                    { 875, "ÇAYIRALAN", 66 },
                    { 876, "ÇEKEREK", 66 },
                    { 877, "KADIŞEHRİ", 66 },
                    { 878, "SARAYKENT", 66 },
                    { 879, "SARIKAYA", 66 },
                    { 880, "SORGUN", 66 },
                    { 881, "ŞEFAATLİ", 66 },
                    { 882, "YENİFAKILI", 66 },
                    { 883, "YERKÖY", 66 },
                    { 884, "YOZGAT MERKEZ", 66 },
                    { 885, "ALAPLI", 67 },
                    { 886, "ÇAYCUMA", 67 },
                    { 887, "DEVREK", 67 },
                    { 888, "EREĞLİ", 67 },
                    { 889, "GÖKÇEBEY", 67 },
                    { 890, "ZONGULDAK MERKEZ", 67 },
                    { 891, "AĞAÇÖREN", 68 },
                    { 892, "AKSARAY MERKEZ", 68 },
                    { 893, "ESKİL", 68 },
                    { 894, "GÜLAĞAÇ", 68 },
                    { 895, "GÜZELYURT", 68 },
                    { 896, "ORTAKÖY", 68 },
                    { 897, "SARIYAHŞİ", 68 },
                    { 898, "AYDINTEPE", 69 },
                    { 899, "BAYBURT MERKEZ", 69 },
                    { 900, "DEMİRÖZÜ", 69 },
                    { 901, "AYRANCI", 70 },
                    { 902, "BAŞYAYLA", 70 },
                    { 903, "ERMENEK", 70 },
                    { 904, "KARAMAN MERKEZ", 70 },
                    { 905, "KÂZIMKARABEKİR", 70 },
                    { 906, "SARIVELİLER", 70 },
                    { 907, "BAHŞİLİ", 71 },
                    { 908, "BALIŞEYH", 71 },
                    { 909, "ÇELEBİ", 71 },
                    { 910, "DELİCE", 71 },
                    { 911, "KARAKEÇİLİ", 71 },
                    { 912, "KESKİN", 71 },
                    { 913, "KIRIKKALE MERKEZ", 71 },
                    { 914, "SULAKYURT", 71 },
                    { 915, "YAHŞİHAN", 71 },
                    { 916, "BATMAN MERKEZ", 72 },
                    { 917, "BEŞİRİ", 72 },
                    { 918, "GERCÜŞ", 72 },
                    { 919, "HASANKEYF", 72 },
                    { 920, "KOZLUK", 72 },
                    { 921, "SASON", 72 },
                    { 922, "BEYTÜŞŞEBAP", 73 },
                    { 923, "CİZRE", 73 },
                    { 924, "GÜÇLÜKONAK", 73 },
                    { 925, "İDİL", 73 },
                    { 926, "SİLOPİ", 73 },
                    { 927, "ŞIRNAK MERKEZ", 73 },
                    { 928, "ULUDERE", 73 },
                    { 929, "AMASRA", 74 },
                    { 930, "BARTIN MERKEZ", 74 },
                    { 931, "KURUCAŞİLE", 74 },
                    { 932, "ULUS", 74 },
                    { 933, "ARDAHAN MERKEZ", 75 },
                    { 934, "ÇILDIR", 75 },
                    { 935, "DAMAL", 75 },
                    { 936, "GÖLE", 75 },
                    { 937, "HANAK", 75 },
                    { 938, "POSOF", 75 },
                    { 939, "ARALIK", 76 },
                    { 940, "IĞDIR MERKEZ", 76 },
                    { 941, "KARAKOYUNLU", 76 },
                    { 942, "TUZLUCA", 76 },
                    { 943, "ALTINOVA", 77 },
                    { 944, "ARMUTLU", 77 },
                    { 945, "ÇINARCIK", 77 },
                    { 946, "ÇİFTLİKKÖY", 77 },
                    { 947, "TERMAL", 77 },
                    { 948, "YALOVA MERKEZ", 77 },
                    { 949, "EFLÂNİ", 78 },
                    { 950, "ESKİPAZAR", 78 },
                    { 951, "KARABÜK MERKEZ", 78 },
                    { 952, "OVACIK", 78 },
                    { 953, "SAFRANBOLU", 78 },
                    { 954, "YENİCE", 78 },
                    { 955, "ELBEYLİ", 79 },
                    { 956, "KİLİS MERKEZ", 79 },
                    { 957, "MUSABEYLİ", 79 },
                    { 958, "POLATELİ", 79 },
                    { 959, "BAHÇE", 80 },
                    { 960, "DÜZİÇİ", 80 },
                    { 961, "HASANBEYLİ", 80 },
                    { 962, "KADİRLİ", 80 },
                    { 963, "OSMANİYE MERKEZ", 80 },
                    { 964, "SUMBAS", 80 },
                    { 965, "TOPRAKKALE", 80 },
                    { 966, "AKÇAKOCA", 81 },
                    { 967, "CUMAYERİ", 81 },
                    { 968, "ÇİLİMLİ", 81 },
                    { 969, "DÜZCE MERKEZ", 81 },
                    { 970, "GÖLYAKA", 81 },
                    { 971, "GÜMÜŞOVA", 81 },
                    { 972, "KAYNAŞLI", 81 },
                    { 973, "YIĞILCA", 81 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserId",
                table: "Brands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselImages_UserId",
                table: "CarouselImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProduct_ProductsId",
                table: "CatalogProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_NameEn",
                table: "Catalogs",
                column: "NameEn");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_NameTr",
                table: "Catalogs",
                column: "NameTr");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_UserId",
                table: "Catalogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameEn",
                table: "Categories",
                column: "NameEn");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameTr",
                table: "Categories",
                column: "NameTr");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId_Name",
                table: "Cities",
                columns: new[] { "ProvinceId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Date",
                table: "Comments",
                column: "Date",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_UserId",
                table: "ProductImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameEn",
                table: "Products",
                column: "NameEn");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameTr",
                table: "Products",
                column: "NameTr");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_SpecificationId",
                table: "ProductSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_Name",
                table: "Provinces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_CategoryId",
                table: "Specifications",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_NameEn",
                table: "Specifications",
                column: "NameEn");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_NameTr",
                table: "Specifications",
                column: "NameTr");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_UserId",
                table: "Specifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

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
                name: "CarouselImages");

            migrationBuilder.DropTable(
                name: "CatalogProduct");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "_EntityBase");
        }
    }
}
