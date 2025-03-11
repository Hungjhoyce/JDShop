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
                    Description = table.Column<string>(type: "text", nullable: true),
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
                    { new Guid("719730c6-6e98-4300-a064-7c5673ce2f50"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(340), "Sweater", "HOODIES & SWEATSHIRTS" },
                    { new Guid("84947687-13e1-40c8-8b6e-28f1ae4c8931"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(342), "Áo sơ mi", "SHIRT" },
                    { new Guid("99c00af1-2be2-4c83-a4a3-35f2ad326bb5"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(329), "Áo Ngắn Tay", "T-SHIRTS" },
                    { new Guid("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(334), "Quần", "PANTS" },
                    { new Guid("a59e7340-2a4a-4384-8b9e-2264c462cdfa"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(337), "Áo khoác", "JACKETS" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "LastUpdated", "ProductId", "Stock" },
                values: new object[,]
                {
                    { new Guid("1dabe982-87f3-4c3c-9336-e4ed83fe4f88"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(550), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), 2000 },
                    { new Guid("20f7a0da-f1e8-457f-affa-3fac80ec6a25"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(561), new Guid("a742f0bd-6f85-4e50-9bc3-8b77b3061c77"), 2000 },
                    { new Guid("2bd3ef58-8159-4a63-bfe9-53a538104cc7"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(555), new Guid("ec16787e-f650-4a7e-839e-f034b52f9273"), 2000 },
                    { new Guid("3086fccd-0a69-49f3-b228-b8b42d381539"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(542), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), 2000 },
                    { new Guid("8ef43a2e-8d6b-459b-8d6a-5dd3ae601e9f"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(563), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 2000 },
                    { new Guid("a7b08cfb-37ff-449d-aee1-207900d212f3"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(557), new Guid("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"), 2000 },
                    { new Guid("dfec1b24-9d8e-44c2-a8a3-955a5c800c8b"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(553), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), 2000 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Color", "ImageUrl", "Price", "ProductId", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("09ef2f23-4d04-44a3-95a0-2be4da81a54d"), "Đỏ", "", 99000m, null, "L", 100 },
                    { new Guid("5b531801-cd30-4c7c-8977-b30a3bd14d83"), "Xanh", "", 99000m, null, "28", 100 },
                    { new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Trắng", "", 99000m, null, "L", 100 },
                    { new Guid("b259fcaa-e1f7-46f6-9310-b152694abdec"), "Trắng", "", 99000m, null, "L", 100 },
                    { new Guid("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"), "Trắng", "", 99000m, null, "L", 100 },
                    { new Guid("e2427b94-5cbc-4522-b53a-3279b5906220"), "Trắng", "", 99000m, null, "XL", 100 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Phone", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("556ee2c5-6eab-4e10-bfa0-8f2f99003ff8"), "Ha Noi", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(171), "jd.shopfashion1@gmail.com", "", "", "asdasd123123", "0123456789", "User", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(171), "jdshop" },
                    { new Guid("9e4c1467-1426-4b97-902c-bacb85f56cc0"), "Ha Noi", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(144), "jd.shopfashion@gmail.com", "", "", "asdasd123123", "0123456789", "Admin", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(147), "jdshop" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), new Guid("99c00af1-2be2-4c83-a4a3-35f2ad326bb5"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(382), "Chiếc áo được làm từ chất liệu vải tổng hợp giúp người mặc cảm thấy thoải mái", "aophong.png", "Áo phông nam ngắn tay", 999000m, 1000 },
                    { new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), new Guid("99c00af1-2be2-4c83-a4a3-35f2ad326bb5"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(400), "Chiếc áo được làm từ chất liệu vải tổng hợp giúp người mặc cảm thấy thoải mái", "aopolo.png", "Áo polo nam", 1999000m, 1000 },
                    { new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), new Guid("719730c6-6e98-4300-a064-7c5673ce2f50"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(405), "Chiếc áo hoodie với form dáng oversize, chất liệu vải dày dặn", "aohoodie.png", "Áo hoodie", 299000m, 1000 },
                    { new Guid("a742f0bd-6f85-4e50-9bc3-8b77b3061c77"), new Guid("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(415), "Quần nỉ ống rộng phong cách Unisex", "quanni.png", "Quần nỉ ống rộng", 599000m, 500 },
                    { new Guid("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"), new Guid("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(411), "Quần jeans ống rộng phong cách Unisex", "quanjeans.png", "Quần jeans ống rộng", 599000m, 500 },
                    { new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), new Guid("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(417), "Quần short phong cách Unisex", "quanshort.png", "Quần short", 99000m, 500 },
                    { new Guid("ec16787e-f650-4a7e-839e-f034b52f9273"), new Guid("a59e7340-2a4a-4384-8b9e-2264c462cdfa"), new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(408), "Chiếu áo này mặc vào là đẹp", "aokhoacgio.png", "Áo khoác gió 2 lớp", 599000m, 100 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Color", "ImageUrl", "Price", "ProductId", "Size", "Stock" },
                values: new object[,]
                {
                    { new Guid("74b16dcb-996f-4e78-8022-f73895c71e23"), "Trắng", "", 99000m, new Guid("ec16787e-f650-4a7e-839e-f034b52f9273"), "L", 100 },
                    { new Guid("ae58d05b-70f8-4a27-8d32-d9ccf322a5ea"), "Xanh", "", 99000m, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "XXL", 100 },
                    { new Guid("c0671087-a8f4-4d64-8a5d-7d40572242f7"), "Đen", "", 99000m, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "M", 100 },
                    { new Guid("d3568a6a-a713-424d-b5a0-f277cc066cb6"), "Đen", "", 99000m, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "L", 100 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "ProductId", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c80b9da-40c9-445f-9ec3-643298d46852"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(640), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("3975f174-2468-4e35-8fc2-11da5346984a"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(628), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("426457ca-07cf-4253-9e93-b019935dcfbf"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(644), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("4417baae-c61a-4864-b01d-d74f8eb1a26a"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(651), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("5286b304-0ebb-4e5c-8812-d1e18c0bac4d"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(635), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("5d4c03c8-40ac-4af3-a1ef-4fcc5017caac"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(633), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("6acd78af-1067-44d2-ac56-6c3f05f031d0"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(648), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("9454169e-2209-4548-85db-abf641707ede"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(637), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("c203576d-97e6-45e4-be00-7003ebb26d97"), "Nice", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(646), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 4, null },
                    { new Guid("e8f5e153-b4b5-4ff4-b319-634ce211f9ca"), "Áo đẹp lắm", new DateTime(2025, 3, 10, 9, 48, 51, 583, DateTimeKind.Utc).AddTicks(622), new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), 5, null }
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
