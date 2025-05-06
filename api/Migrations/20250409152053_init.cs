using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    TotolPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    ShippingMethod = table.Column<string>(type: "text", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TrackingNumber = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wishlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductVariantId = table.Column<Guid>(type: "uuid", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProducId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductVariantId = table.Column<Guid>(type: "uuid", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("719730c6-6e98-4300-a064-7c5673ce2f50"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5359), "Sweater", "HOODIES & SWEATSHIRTS" },
                    { new Guid("84947687-13e1-40c8-8b6e-28f1ae4c8931"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5361), "Áo sơ mi", "SHIRT" },
                    { new Guid("99c00af1-2be2-4c83-a4a3-35f2ad326bb5"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5347), "Áo Ngắn Tay", "T-SHIRTS" },
                    { new Guid("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5352), "Quần", "PANTS" },
                    { new Guid("a59e7340-2a4a-4384-8b9e-2264c462cdfa"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5354), "Áo khoác", "JACKETS" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "LastUpdated", "ProductId", "Stock" },
                values: new object[,]
                {
                    { new Guid("074e2e23-f0ad-4e76-80bc-23363f0b8da6"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5566), new Guid("a742f0bd-6f85-4e50-9bc3-8b77b3061c77"), 2000 },
                    { new Guid("33229381-9474-44c9-a8b0-89d4b89697d2"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5555), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), 2000 },
                    { new Guid("6b3ee517-ccf8-49e1-a209-acc4684b29ed"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5568), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 2000 },
                    { new Guid("b7430380-19f5-4591-b708-cb11d5da6d3c"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5548), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), 2000 },
                    { new Guid("b761b899-f763-4c80-90c3-c2642060ddff"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5557), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), 2000 },
                    { new Guid("d914cf21-3b10-41ab-bf44-90ecd169cd83"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5563), new Guid("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"), 2000 },
                    { new Guid("ff2766df-fdf0-4084-a8a0-331d3c182c77"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5559), new Guid("ec16787e-f650-4a7e-839e-f034b52f9273"), 2000 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Color", "ImageUrl", "Price", "ProductId", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("165b3f25-1df3-4027-b420-ce2814ad7adf"), "Xanh", "", 99000m, null, "28", 100 },
                    { new Guid("3661a452-e6ec-4321-8b67-2573e3e832c3"), "Trắng", "", 99000m, null, "XL", 100 },
                    { new Guid("3e10e4f2-60fb-49ba-9d69-bd045a7bfd5f"), "Trắng", "", 99000m, null, "L", 100 },
                    { new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Trắng", "", 99000m, null, "L", 100 },
                    { new Guid("a70d8fdb-d661-4165-9c70-d649838e016a"), "Đỏ", "", 99000m, null, "L", 100 },
                    { new Guid("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"), "Trắng", "", 99000m, null, "L", 100 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Phone", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("556ee2c5-6eab-4e10-bfa0-8f2f99003ff8"), "Ha Noi", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5213), "jd.shopfashion1@gmail.com", "", "", "asdasd123123", "0123456789", "User", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5213), "jdshop" },
                    { new Guid("9e4c1467-1426-4b97-902c-bacb85f56cc0"), "Ha Noi", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5183), "jd.shopfashion@gmail.com", "", "", "asdasd123123", "0123456789", "Admin", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5186), "jdshop" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), new Guid("99c00af1-2be2-4c83-a4a3-35f2ad326bb5"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5407), "Chiếc áo được làm từ chất liệu vải tổng hợp giúp người mặc cảm thấy thoải mái", "aophong.png", "Áo phông nam ngắn tay", 999000m, 1000 },
                    { new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), new Guid("99c00af1-2be2-4c83-a4a3-35f2ad326bb5"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5422), "Chiếc áo được làm từ chất liệu vải tổng hợp giúp người mặc cảm thấy thoải mái", "aopolo.png", "Áo polo nam", 1999000m, 1000 },
                    { new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), new Guid("719730c6-6e98-4300-a064-7c5673ce2f50"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5425), "Chiếc áo hoodie với form dáng oversize, chất liệu vải dày dặn", "aohoodie.png", "Áo hoodie", 299000m, 1000 },
                    { new Guid("a742f0bd-6f85-4e50-9bc3-8b77b3061c77"), new Guid("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5441), "Quần nỉ ống rộng phong cách Unisex", "quanni.png", "Quần nỉ ống rộng", 599000m, 500 },
                    { new Guid("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"), new Guid("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5437), "Quần jeans ống rộng phong cách Unisex", "quanjeans.png", "Quần jeans ống rộng", 599000m, 500 },
                    { new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), new Guid("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5444), "Quần short phong cách Unisex", "quanshort.png", "Quần short", 99000m, 500 },
                    { new Guid("ec16787e-f650-4a7e-839e-f034b52f9273"), new Guid("a59e7340-2a4a-4384-8b9e-2264c462cdfa"), new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5429), "Chiếu áo này mặc vào là đẹp", "aokhoacgio.png", "Áo khoác gió 2 lớp", 599000m, 100 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Color", "ImageUrl", "Price", "ProductId", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("8667ad5a-8a69-41cc-9086-39d9b2913bc1"), "Trắng", "", 99000m, new Guid("ec16787e-f650-4a7e-839e-f034b52f9273"), "L", 100 },
                    { new Guid("950a5a81-1b72-4051-b2dd-6c8d8d14c826"), "Xanh", "", 99000m, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "XXL", 100 },
                    { new Guid("c0671087-a8f4-4d64-8a5d-7d40572242f7"), "Đen", "", 99000m, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "M", 100 },
                    { new Guid("e73e7945-1ed3-411a-acdb-03d0a22f62b1"), "Đen", "", 99000m, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "L", 100 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "ProductId", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("002c9902-54d9-499d-a044-6ed6822326bf"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5659), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("08e3e86c-0ee8-46d4-b55a-f2a695410d21"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5656), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("0c6a110f-57e1-4867-99ef-e3db5f402276"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5661), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("40da1610-c1bb-45ea-951d-b9f2dd9a10f4"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5649), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("54265749-7400-41f5-a49f-74f4b134ad0d"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5665), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("5714531a-a8e7-43cd-a8e0-1485cf5bcd61"), "Áo đẹp lắm", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5635), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 5, null },
                    { new Guid("63303959-e830-4b1c-92fd-e359ee68179e"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5642), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("75ae32cf-877a-47a2-a65e-3d12f6852157"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5647), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("d0aea518-4ca9-479e-89ac-85eb8a3772f4"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5644), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("da5a54d9-823e-41d5-9204-25520287e7cb"), "Nice", new DateTime(2025, 4, 9, 15, 20, 53, 696, DateTimeKind.Utc).AddTicks(5654), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductVariantId",
                table: "Carts",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ProductId",
                table: "Wishlists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
