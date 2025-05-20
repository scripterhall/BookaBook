using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookaBook.Migrations
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                name: "Livres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auteur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneePublication = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NombreExemplaires = table.Column<int>(type: "int", nullable: false),
                    Langue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livres_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Emprunts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateRetourPrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRetourEffective = table.Column<DateTime>(type: "datetime2", nullable: true),
                    etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateAction = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprunts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprunts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emprunts_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteUtilisateur = table.Column<int>(type: "int", nullable: true),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateAction = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoris_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favoris_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[,]
                {
                    { new Guid("2038c213-a15f-46d3-b813-e03292370924"), "Livres d'aventure", "Aventure" },
                    { new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "Livres comiques", "Comédie" },
                    { new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "Livres d'action", "Action" }
                });

            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "AnneePublication", "Auteur", "CategorieId", "Description", "ISBN", "ImageUrl", "Langue", "NombreExemplaires", "Titre" },
                values: new object[,]
                {
                    { new Guid("0005468b-3f65-4e95-a27c-5a68b8b96ee1"), 2001, "Terry Pratchett", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0061040967.01.LZZZZZZZ.jpg", "Français", 5, "The Last Hero : A Discworld Fable (Discworld Novels (Hardcover))" },
                    { new Guid("00439590-7100-44b2-bef9-e2cee323033f"), 1994, "Dan Quayle", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060177586.01.LZZZZZZZ.jpg", "Français", 5, "Standing Firm: A Vice-Presidential Memoir" },
                    { new Guid("005bcafc-57c8-418e-b0ed-9ecf9305963f"), 2002, "Mordecai Richler", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3404921038.01.LZZZZZZZ.jpg", "Français", 5, "Wie Barney es sieht." },
                    { new Guid("00963c66-0c0a-48d1-992d-42237454f588"), 1990, "Tom Clancy", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0425120279.01.LZZZZZZZ.jpg", "Français", 5, "The Hunt for Red October" },
                    { new Guid("01161aed-d1c0-454b-8f72-9763aafae50c"), 1999, "The Onion", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0609804618.01.LZZZZZZZ.jpg", "Français", 5, "Our Dumb Century: The Onion Presents 100 Years of Headlines from America's Finest News Source" },
                    { new Guid("01574b0c-032f-4b3c-b5fa-c9802c099aa8"), 2001, "Anita Shreve", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0316782505.01.LZZZZZZZ.jpg", "Français", 5, "The Weight of Water" },
                    { new Guid("01a88e6c-2f50-4481-9696-699a992748e3"), 1995, "Robert James Waller", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/044651747X.01.LZZZZZZZ.jpg", "Français", 5, "Puerto Vallarta Squeeze" },
                    { new Guid("021a210b-6b21-4dde-a5f3-0742674e1e91"), 1997, "Mary Higgins Clark", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0671867113.01.LZZZZZZZ.jpg", "Français", 5, "Moonlight Becomes You" },
                    { new Guid("02888faf-f80b-4293-84e7-5b46723029c6"), 1997, "Thomas Hardy", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1853260673.01.LZZZZZZZ.jpg", "Français", 5, "Far from the Madding Crowd (Wordsworth Classics)" },
                    { new Guid("03a62276-711b-43f7-aac1-546986102e3c"), 2000, "Ruth Rendell", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0375704965.01.LZZZZZZZ.jpg", "Français", 5, "A Judgement in Stone" },
                    { new Guid("05b10bbc-7dd7-4a7e-8da7-14c9e8a60efe"), 1998, "Robert Westall", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0688163726.01.LZZZZZZZ.jpg", "Français", 5, "The Watch House" },
                    { new Guid("07c4936f-8b16-45b6-95a7-9da6ccbc0d1b"), 1991, "Renan Demirkan", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3462021095.01.LZZZZZZZ.jpg", "Français", 5, "Schwarzer Tee mit drei StÃ¼ck Zucker" },
                    { new Guid("08421905-c6dc-4aa7-a508-1fc445cf20d8"), 1999, "JOHN IRVING", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0345424719.01.LZZZZZZZ.jpg", "Français", 5, "A Widow for One Year" },
                    { new Guid("08927ba5-24e3-4533-9197-d46b8740af12"), 1994, "Richard North Patterson", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0345311396.01.LZZZZZZZ.jpg", "Français", 5, "Private Screening" },
                    { new Guid("091c542e-fbfb-46f2-9959-458803d36e1e"), 1996, "Kiana Davenport", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3426605686.01.LZZZZZZZ.jpg", "Français", 5, "Haifischfrauen." },
                    { new Guid("092a50d4-b4c5-4988-bba4-82c84dcf2432"), 1991, "John Grisham", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0385416342.01.LZZZZZZZ.jpg", "Français", 5, "The Firm" },
                    { new Guid("09933fed-64e7-44bc-989e-ab0de00cb015"), 2001, "Sandra Dallas", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0312283784.01.LZZZZZZZ.jpg", "Français", 5, "Alice's Tulips" },
                    { new Guid("09f138ad-3fec-4e23-bd7d-62ade3e1a11c"), 1996, "John Irving", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1559703237.01.LZZZZZZZ.jpg", "Français", 5, "Trying to Save Piggy Sneed" },
                    { new Guid("09f779fe-8fbe-4b38-bb85-22825ec1ba3e"), 2004, "Mary Jane Clark", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0312988699.01.LZZZZZZZ.jpg", "Français", 5, "Nowhere To Run" },
                    { new Guid("0a84b5cc-7e0c-43b1-a0ba-5265bc1099e2"), 2003, "Michael Moore", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3492045642.01.LZZZZZZZ.jpg", "Français", 5, "QuerschÃ?Â¼sse - Downsize This!" },
                    { new Guid("0abb2304-a785-4b6c-8c73-a81b3bdbadb0"), 1995, "Glendon Swarthout", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0671521519.01.LZZZZZZZ.jpg", "Français", 5, "Bless The Beasts And Children : Bless The Beasts And Children" },
                    { new Guid("0b02ae23-1990-4be5-949a-f43e1790ddca"), 2003, "IAN MCEWAN", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/038572179X.01.LZZZZZZZ.jpg", "Français", 5, "Atonement : A Novel" },
                    { new Guid("0b17eadc-e9da-4435-afaf-d5e1ec5bc68f"), 1997, "Stephanie Maze", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0152012966.01.LZZZZZZZ.jpg", "Français", 5, "I Want to Be...a Veterinarian (I Want to Be... Series)" },
                    { new Guid("0bddfb2e-0b56-4c42-8d58-f4c178f8d129"), 2003, "John Grisham", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0385511612.01.LZZZZZZZ.jpg", "Français", 5, "Bleachers" },
                    { new Guid("0c74c70c-b10e-4d2a-9a7d-2669c2ef2962"), 1991, "Charlotte Link", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3442410665.01.LZZZZZZZ.jpg", "Français", 5, "Sturmzeit. Roman." },
                    { new Guid("0d47d6a8-a511-4a0f-aa1e-daa59a5f1af7"), 2000, "Mary-Kate &amp; Ashley Olsen", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0061076031.01.LZZZZZZZ.jpg", "Français", 5, "Mary-Kate &amp; Ashley Switching Goals (Mary-Kate and Ashley Starring in)" },
                    { new Guid("0e01786d-e1f1-468e-9641-74a801644c5a"), 2001, "Dan Brown", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0671027360.01.LZZZZZZZ.jpg", "Français", 5, "Angels &amp; Demons" },
                    { new Guid("0eb1208b-eb74-4b12-9889-c8d223523722"), 1999, "Dorothy Allison", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0452279690.01.LZZZZZZZ.jpg", "Français", 5, "Cavedweller" },
                    { new Guid("0f330a4a-2e64-4758-8c76-26d8772d524b"), 1988, "Betty Smith", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060801263.01.LZZZZZZZ.jpg", "Français", 5, "Tree Grows In Brooklyn" },
                    { new Guid("0fe69dfd-bb55-4ce8-b50f-783382a9abba"), 1999, "Kathleen E. Woodiwiss", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0380807866.01.LZZZZZZZ.jpg", "Français", 5, "The Elusive Flame" },
                    { new Guid("0ff2f00b-66d1-4d3d-833c-343918e3a010"), 1996, "Kenneth Grahame", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0312148267.01.LZZZZZZZ.jpg", "Français", 5, "The Wind in the Willows" },
                    { new Guid("0ff5aab3-2447-4026-8ba1-081a9344a5ab"), 2000, "Deepak Chopra", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0312970242.01.LZZZZZZZ.jpg", "Français", 5, "The Angel Is Near" },
                    { new Guid("1190794a-8895-4150-98f9-3471b8ed9d14"), 1999, "DANA REEVE", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0375500766.01.LZZZZZZZ.jpg", "Français", 5, "Care Packages : Letters to Christopher Reeve from Strangers and Other Friends" },
                    { new Guid("1258ead3-8923-4de1-8620-a01396efe0f3"), 1998, "Jack Canfield", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1558746218.01.LZZZZZZZ.jpg", "Français", 5, "A Second Chicken Soup for the Woman's Soul (Chicken Soup for the Soul Series)" },
                    { new Guid("1355eacb-d872-4f19-8aac-09b46640a6fe"), 1995, "Franklin W. Dixon", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0671504282.01.LZZZZZZZ.jpg", "Français", 5, "LAW OF THE JUNGLE (HARDY BOYS CASE FILE 105) : LAW OF THE JUNGLE (Hardy Boys, The)" },
                    { new Guid("144d6bc4-21ca-420c-b4bf-22a5f229d944"), 1998, "Roy", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/9724119378.01.LZZZZZZZ.jpg", "Français", 5, "O Deus Das Pequenas Coisas" },
                    { new Guid("14b2695b-ca4e-414c-b555-3c819e293ea4"), 1996, "Marc Gascoigne", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0140382658.01.LZZZZZZZ.jpg", "Français", 5, "You Can Surf the Net: Your Guide to the World of the Internet" },
                    { new Guid("14dc12b5-48b5-4d06-a8ce-22a39aa5cbbe"), 1998, "Terry Pratchett", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0061050474.01.LZZZZZZZ.jpg", "Français", 5, "Jingo: A Discworld Novel (Discworld Series/Terry Pratchett)" },
                    { new Guid("157794ef-5ff8-49a6-9820-96d0ccf6e967"), 1958, "Mary Barnard", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0520011171.01.LZZZZZZZ.jpg", "Français", 5, "Sappho: A New Translation" },
                    { new Guid("170ce650-206c-43b7-8b78-5e5fe075ab5d"), 2000, "Steve Thayer", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0451186648.01.LZZZZZZZ.jpg", "Français", 5, "Silent Snow" },
                    { new Guid("176b8b62-80f7-4f68-be41-8898d4365306"), 2003, "ANN BRASHARES", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0385730586.01.LZZZZZZZ.jpg", "Français", 5, "Sisterhood of the Traveling Pants" },
                    { new Guid("18341bf7-0d16-406a-8968-8639b3e5913f"), 2000, "Nevada Barr", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0380728273.01.LZZZZZZZ.jpg", "Français", 5, "Liberty Falling (Anna Pigeon Mysteries (Paperback))" },
                    { new Guid("1923c464-1193-46ab-b1fc-cb787603a946"), 2002, "Ann Rule", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0743439740.01.LZZZZZZZ.jpg", "Français", 5, "Every Breath You Take : A True Story of Obsession, Revenge, and Murder" },
                    { new Guid("1a722ab5-b017-4d25-9fbc-199a9cf90f10"), 2002, "Louise Rennison", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0064472264.01.LZZZZZZZ.jpg", "Français", 5, "On the Bright Side, I'm Now the Girlfriend of a Sex God: Further Confessions of Georgia Nicolson" },
                    { new Guid("1a9daf40-84cf-43cf-a4a5-69825334434b"), 1998, "Arabella Weir", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3423241489.01.LZZZZZZZ.jpg", "Français", 5, "Ist mein Hintern wirklich so dick? Tagebuch einer empfindsamen Frau." },
                    { new Guid("1b1c7e10-ef36-4e54-b860-ce8b9d550d01"), 2003, "Dan Brown", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0743486226.01.LZZZZZZZ.jpg", "Français", 5, "Angels &amp; Demons" },
                    { new Guid("1b4c19c5-b503-4ed6-9255-80076ecb029a"), 1994, "Julia Oliver", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1881320189.01.LZZZZZZZ.jpg", "Français", 5, "Goodbye to the Buttermilk Sky" },
                    { new Guid("1c1156a9-0722-4bc6-9032-3b3fb9748c4c"), 2001, "Tracy Chevalier", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0452282152.01.LZZZZZZZ.jpg", "Français", 5, "Girl with a Pearl Earring" },
                    { new Guid("1c6e3c22-d408-4a92-8c93-34532b3058ca"), 2002, "Susan Grant", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0505524996.01.LZZZZZZZ.jpg", "Français", 5, "Contact" },
                    { new Guid("1ca0c052-c02d-4e09-a0b9-ae8280b834f8"), 2004, "ALEXANDER MCCALL SMITH", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/140003180X.01.LZZZZZZZ.jpg", "Français", 5, "The Kalahari Typing School for Men (No. 1 Ladies' Detective Agency)" },
                    { new Guid("1e675641-0824-453e-b6d2-50d7ce8588b9"), 1994, "A.S. BYATT", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0679751343.01.LZZZZZZZ.jpg", "Français", 5, "Angels &amp; Insects : Two Novellas" },
                    { new Guid("1e8ef5b7-9203-4137-81b0-dbb47f0d9607"), 0, "Barbara Kingsolver", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0571197639.01.LZZZZZZZ.jpg", "Français", 5, "Poisonwood Bible Edition Uk" },
                    { new Guid("1f058e53-48a0-4a85-ae60-c6574bbc4fd9"), 1997, "Leo Tolstoy", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1853260622.01.LZZZZZZZ.jpg", "Français", 5, "War and Peace (Wordsworth Classics)" },
                    { new Guid("213e10aa-8893-47b3-a25f-335b874b8e64"), 2003, "Mary Lawson", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0385337639.01.LZZZZZZZ.jpg", "Français", 5, "Crow Lake (Today Show Book Club #7)" },
                    { new Guid("21981d30-ccf7-413f-8de2-542b73ac776a"), 2003, "Laura Wolf", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0385336772.01.LZZZZZZZ.jpg", "Français", 5, "Diary of a Mad Mom-To-Be" },
                    { new Guid("21a49bf2-289d-4da1-962a-99ad256d7647"), 1995, "Paul Lester", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0600586898.01.LZZZZZZZ.jpg", "Français", 5, "Blur (Melody Maker)" },
                    { new Guid("220dd322-cc5e-4245-ad59-8765cd4fd399"), 1997, "Michael Crichton", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0345402871.01.LZZZZZZZ.jpg", "Français", 5, "Airframe" },
                    { new Guid("230cb3de-091b-479c-8c67-6a13cdda8c06"), 1986, "LOIS DUNCAN", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0440949424.01.LZZZZZZZ.jpg", "Français", 5, "Locked in Time (Laurel Leaf Books)" },
                    { new Guid("24792613-4c7d-453d-8727-852b22c61467"), 2002, "Paolo Coelho", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3257233051.01.LZZZZZZZ.jpg", "Français", 5, "Veronika Deschliesst Zu Sterben / Vernika Decides to Die" },
                    { new Guid("2503d9e1-641e-4699-97b9-ee2e41d5c945"), 1999, "Sarah Payne Stuart", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0060930365.01.LZZZZZZZ.jpg", "Français", 5, "My First Cousin Once Removed: Money, Madness, and the Family of Robert Lowell" },
                    { new Guid("259c423b-4e55-4314-9adf-f2a3b83d902d"), 2002, "Anne Frasier", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0451410319.01.LZZZZZZZ.jpg", "Français", 5, "Hush" },
                    { new Guid("25d3d7c7-bff0-400d-b81a-8ec8a90a3fc7"), 2004, "IRIS JOHANSEN", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0553584383.01.LZZZZZZZ.jpg", "Français", 5, "Dead Aim" },
                    { new Guid("26858ff7-d02b-4961-906a-99b98a8643a3"), 1998, "Kathleen Duey", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0689821166.01.LZZZZZZZ.jpg", "Français", 5, "Flood : Mississippi 1927" },
                    { new Guid("26b0b6e1-351e-47bb-b494-da064ab90869"), 1984, "RAY BRADBURY", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0553278223.01.LZZZZZZZ.jpg", "Français", 5, "The Martian Chronicles" },
                    { new Guid("270f64b1-bf74-4695-9411-34c8f747e544"), 0, "Schiller", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3150000335.01.LZZZZZZZ.jpg", "Français", 5, "Kabale Und Liebe" },
                    { new Guid("29b36565-0ce7-416d-98a2-3ad51738f624"), 1996, "David Cordingly", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0679425608.01.LZZZZZZZ.jpg", "Français", 5, "Under the Black Flag: The Romance and the Reality of Life Among the Pirates" },
                    { new Guid("29ee8807-6c5b-486a-8378-7fb487a387ae"), 1988, "Harper Lee", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0446310786.01.LZZZZZZZ.jpg", "Français", 5, "To Kill a Mockingbird" },
                    { new Guid("2b3c4ae6-0d55-4e98-b539-b32030eb692c"), 2002, "Michael Rips", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0316748641.01.LZZZZZZZ.jpg", "Français", 5, "Pasquale's Nose: Idle Days in an Italian Town" },
                    { new Guid("2bec82b1-9cc0-4f6f-9080-69f2cd1c3ef2"), 1996, "LORNA LANDVIK", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0449911004.01.LZZZZZZZ.jpg", "Français", 5, "Patty Jane's House of Curl (Ballantine Reader's Circle)" },
                    { new Guid("2c256e25-8308-4e09-a952-46369dd016e3"), 1988, "M.D. Bernie S. Siegel", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060914068.01.LZZZZZZZ.jpg", "Français", 5, "Love, Medicine and Miracles" },
                    { new Guid("2c857484-ea4e-4528-98eb-e07106551770"), 2002, "Mark P. O. Morford", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0195153448.01.LZZZZZZZ.jpg", "Français", 5, "Classical Mythology" },
                    { new Guid("2d19c45e-5e33-4ad4-9799-229e8d8c5cde"), 1999, "Ted Hughes", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0375801677.01.LZZZZZZZ.jpg", "Français", 5, "The Iron Giant" },
                    { new Guid("2d734d9b-4cd7-45f7-a4bb-c2a6d34a654b"), 2001, "J. R. R. Tolkien", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/8445071769.01.LZZZZZZZ.jpg", "Français", 5, "El Senor De Los Anillos: Las DOS Torres (Lord of the Rings (Paperback))" },
                    { new Guid("2e84b19d-5d5d-457f-8825-9ca5778f7621"), 2000, "Joan Anderson", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0767905938.01.LZZZZZZZ.jpg", "Français", 5, "A Year by the Sea: Thoughts of an Unfinished Woman" },
                    { new Guid("2f46a8a6-1b90-4849-8593-df6457283e8a"), 2001, "J. R. R. Tolkien", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8445071777.01.LZZZZZZZ.jpg", "Français", 5, "El Senor De Los Anillos: El Retorno Del Rey (Tolkien, J. R. R. Lord of the Rings. 3.)" },
                    { new Guid("2f61a3c7-945d-4b10-85ea-c5c0fa85eaac"), 1991, "LEWIS GRIZZARD", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0345372700.01.LZZZZZZZ.jpg", "Français", 5, "If I Ever Get Back to Georgia, I'm Gonna Nail My Feet to the Ground" },
                    { new Guid("2f7af1d6-c2b9-4e74-b821-0b3bbfa770f4"), 1990, "MÃ rius Serra", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8478091246.01.LZZZZZZZ.jpg", "Français", 5, "L'home del sac" },
                    { new Guid("308629ca-cf7a-4290-8df0-45f3049cbe41"), 2002, "PHILIP PULLMAN", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/037582345X.01.LZZZZZZZ.jpg", "Français", 5, "The Golden Compass (His Dark Materials, Book 1)" },
                    { new Guid("30c6360d-03c3-4faa-b516-edb4a1def57e"), 2000, "Anna Sewell", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0866119531.01.LZZZZZZZ.jpg", "Français", 5, "Black Beauty (Great Illustrated Classics (Playmore))" },
                    { new Guid("30d26f5b-ae5f-46f9-8327-9643d0c94eb4"), 1996, "Kevin Sullivan", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0451154916.01.LZZZZZZZ.jpg", "Français", 5, "The Crystal Handbook" },
                    { new Guid("3118b695-c8a3-49f3-be52-8a75f2995414"), 1988, "Carol J. Farley", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0380754509.01.LZZZZZZZ.jpg", "Français", 5, "The Case of the Lost Look-Alike (An Avon Camelot Book)" },
                    { new Guid("31d623b3-0ace-4a9e-89ab-4166a89a9a4f"), 1999, "JOHN GRISHAM", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0440225701.01.LZZZZZZZ.jpg", "Français", 5, "The Street Lawyer" },
                    { new Guid("321df115-8121-4bb0-8b83-7e63f75fc9f1"), 1997, "Don Miguel Ruiz", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1878424319.01.LZZZZZZZ.jpg", "Français", 5, "The Four Agreements: A Practical Guide to Personal Freedom" },
                    { new Guid("32a43318-fd3f-4c7c-882c-2040a9d983b3"), 1999, "DAVID EDDINGS", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0345435869.01.LZZZZZZZ.jpg", "Français", 5, "The Rivan Codex : Ancient Texts of THE BELGARIAD and THE MALLOREON" },
                    { new Guid("3362a538-470a-487b-a5f4-227d21e5f2dd"), 1996, "Norman Bridwell", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0590629719.01.LZZZZZZZ.jpg", "Français", 5, "Clifford's Sports Day" },
                    { new Guid("33e66902-334e-48ba-a42a-418dc087fdce"), 2002, "Sarah Waters", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1573228737.01.LZZZZZZZ.jpg", "Français", 5, "Affinity" },
                    { new Guid("342946cd-482b-47c5-8de4-a17fccde6ce8"), 1997, "Helen Fielding", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0330332775.01.LZZZZZZZ.jpg", "Français", 5, "Bridget Jones's Diary" },
                    { new Guid("3505a4f6-73c2-459c-86d5-772adc095220"), 2002, "Irene Gonzalez Frei", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8472238822.01.LZZZZZZZ.jpg", "Français", 5, "Tu Nombre Escrito En El Agua (La Sonrisa Vertical)" },
                    { new Guid("35dedded-8ac3-4fe3-9612-70ac737af764"), 2002, "Lorenzo Carcaterra", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0345425294.01.LZZZZZZZ.jpg", "Français", 5, "Gangster" },
                    { new Guid("369997b8-269f-4912-8002-c3a481dc67a1"), 1997, "Paula Danziger", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0590947257.01.LZZZZZZZ.jpg", "Français", 5, "Forever Amber Brown (Amber Brown (Paperback))" },
                    { new Guid("36dda130-f2d6-4679-bd03-722fceb835d7"), 1974, "Vance Havner", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0800706544.01.LZZZZZZZ.jpg", "Français", 5, "Though I walk through the valley" },
                    { new Guid("36e378d7-31fb-40c8-ab0e-2ba8d5387423"), 1988, "Colleen McCullough", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0380704587.01.LZZZZZZZ.jpg", "Français", 5, "The Ladies of Missalonghi" },
                    { new Guid("37104f41-142d-4509-afa8-c3029d573835"), 1993, "Jack Canfield", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/155874262X.01.LZZZZZZZ.jpg", "Français", 5, "Chicken Soup for the Soul (Chicken Soup for the Soul)" },
                    { new Guid("37948494-e771-4ed2-bc09-7a5286c0d4c7"), 1992, "Patricia Cornwell", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0684193957.01.LZZZZZZZ.jpg", "Français", 5, "ALL THAT REMAINS" },
                    { new Guid("37f9688c-4919-415e-84bd-96d274b6fcf5"), 1998, "Stephan Jaramillo", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0425163091.01.LZZZZZZZ.jpg", "Français", 5, "Chocolate Jesus" },
                    { new Guid("38579110-040c-4af5-8571-a16c3ca694b8"), 2001, "James Patterson", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0446605484.01.LZZZZZZZ.jpg", "Français", 5, "Roses Are Red (Alex Cross Novels)" },
                    { new Guid("388f08fd-bcdb-405c-b7de-cf4d23796bed"), 2004, "Rich Shapero", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0971880107.01.LZZZZZZZ.jpg", "Français", 5, "Wild Animus" },
                    { new Guid("3932e9d6-992e-4843-9c3a-8032709a98ff"), 1987, "Antoni Serra", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8474103347.01.LZZZZZZZ.jpg", "Français", 5, "Espurnes de sang (La Negra)" },
                    { new Guid("39631c8e-a745-43a5-a23b-8167a47f1b15"), 1992, "Spalding Gray", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/039456894X.01.LZZZZZZZ.jpg", "Français", 5, "Impossible Vacation" },
                    { new Guid("39721272-5938-43ae-92c0-c194611cdff4"), 2001, "Jane Heller", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0312261594.01.LZZZZZZZ.jpg", "Français", 5, "Female Intelligence" },
                    { new Guid("3a777a3a-d7ca-4a21-abb9-ee6c64aa8078"), 1997, "Maeve Binchy", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0440223571.01.LZZZZZZZ.jpg", "Français", 5, "This Year It Will Be Different: And Other Stories" },
                    { new Guid("3abfb57b-8410-436e-9af4-bbcdebca506f"), 1992, "Bill Hand", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0840734530.01.LZZZZZZZ.jpg", "Français", 5, "The Oneprince (The Redaemian Chronicles, Book 1)" },
                    { new Guid("3ac2cbef-f22b-435d-91db-b9f5c1819736"), 1988, "Ray Bradbury", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3257216416.01.LZZZZZZZ.jpg", "Français", 5, "Der Tod kommt schnell in Mexico. ErzÃ?Â¤hlungen." },
                    { new Guid("3bc3f2c0-2e3b-4f2a-8ccc-6a54fe56ab18"), 2003, "Cheryl St. John", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0373245580.01.LZZZZZZZ.jpg", "Français", 5, "Marry Me ... Again   Montana Mavericks (Silhouette Special Edition, 1558)" },
                    { new Guid("3bf53044-1a2e-4228-8936-3f10d0c4bd45"), 1983, "Arthur William Upfield", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0684180200.01.LZZZZZZZ.jpg", "Français", 5, "NEW SHOE" },
                    { new Guid("3d12e1ea-0303-40ac-9605-b6a99b96217e"), 1998, "Andrea Kane", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/067153484X.01.LZZZZZZZ.jpg", "Français", 5, "The Music Box" },
                    { new Guid("3dca23ed-6c1e-4f35-8bc3-b8a36993a968"), 1981, "Ray Bradbury", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3257208634.01.LZZZZZZZ.jpg", "Français", 5, "Die Mars- Chroniken. Roman in ErzÃ?Â¤hlungen." },
                    { new Guid("3f719e6c-6e03-42be-b178-0321470d0459"), 1995, "Bob Thiele", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0195086295.01.LZZZZZZZ.jpg", "Français", 5, "What a Wonderful World: A Lifetime of Recordings" },
                    { new Guid("3f795af3-bf6c-4dca-80f2-e13acf6d0d83"), 2003, "J. M. Barrie", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060563079.01.LZZZZZZZ.jpg", "Français", 5, "Peter Pan: The Original Story (Peter Pan)" },
                    { new Guid("406cb8f9-3d0e-4c3f-961e-8cf5134d6965"), 1996, "T. Coraghessan Boyle", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/014023828X.01.LZZZZZZZ.jpg", "Français", 5, "The Tortilla Curtain" },
                    { new Guid("40b2b4f1-6ad8-4506-9ede-429b3d072b3a"), 1979, "Dolores Krieger", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/067176537X.01.LZZZZZZZ.jpg", "Français", 5, "The Therapeutic Touch: How to Use Your Hands to Help or to Heal" },
                    { new Guid("410e2974-881f-4978-a273-c0bd83b93488"), 1993, "DONNA TARTT", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0804111359.01.LZZZZZZZ.jpg", "Français", 5, "Secret History" },
                    { new Guid("418af486-0098-4ec9-b3e2-5784cebfd1ac"), 1993, "Shirley Rousseau Murphy", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0451452755.01.LZZZZZZZ.jpg", "Français", 5, "The Catswold Portal" },
                    { new Guid("4232874c-4892-41ca-b6cf-612eabb80f72"), 1977, "Anne McCaffrey", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0553258524.01.LZZZZZZZ.jpg", "Français", 5, "Dragonsong (Harper Hall Trilogy)" },
                    { new Guid("432fbd75-3e31-410c-9cf9-eb02ba576d7c"), 1976, "Richard Bach", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0380012863.01.LZZZZZZZ.jpg", "Français", 5, "Jonathan Livingston Seagull" },
                    { new Guid("43e1f93f-7e04-44f0-807c-f02ae8ced96a"), 1994, "Mary Higgins Clark", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0671888587.01.LZZZZZZZ.jpg", "Français", 5, "I'll Be Seeing You" },
                    { new Guid("452d1313-f090-4cc5-8015-78f51b2d874c"), 2003, "John Grisham", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0385508042.01.LZZZZZZZ.jpg", "Français", 5, "The King of Torts" },
                    { new Guid("48ca2232-b52d-4c51-bae9-175af5f53e03"), 2002, "ROALD DAHL", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0375814248.01.LZZZZZZZ.jpg", "Français", 5, "James and the Giant Peach" },
                    { new Guid("4905eabe-b57e-42ff-8c79-8bf14ea213f4"), 1998, "Loren D. Estleman", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1567407781.01.LZZZZZZZ.jpg", "Français", 5, "The Witchfinder (Amos Walker Mystery Series)" },
                    { new Guid("49305934-859f-4f6b-9b25-8c06270f8f70"), 2002, "Yann Martel", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0151008116.01.LZZZZZZZ.jpg", "Français", 5, "Life of Pi" },
                    { new Guid("493f36b1-a0ca-4ba6-8dfe-1d05adf5ebf9"), 2002, "Judith Kelman", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/051513290X.01.LZZZZZZZ.jpg", "Français", 5, "Summer of Storms" },
                    { new Guid("49cfdbcf-39d8-448f-bf3c-cd41de80c459"), 1997, "Elizabeth Wurtzel", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1573225126.01.LZZZZZZZ.jpg", "Français", 5, "Prozac Nation: Young and Depressed in America : A Memoir" },
                    { new Guid("4a3ef785-c198-465d-9eb1-ef37e6c48777"), 1996, "Rebecca Wells", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0060173289.01.LZZZZZZZ.jpg", "Français", 5, "Divine Secrets of the Ya-Ya Sisterhood : A Novel" },
                    { new Guid("4a443c99-ed54-4e6e-80db-1d23720ed111"), 1991, "Elena Castedo", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8440616252.01.LZZZZZZZ.jpg", "Français", 5, "El paraÃ­so (Tiempos modernos)" },
                    { new Guid("4b77d478-b0bc-4906-9dec-e2f779d2e30b"), 2002, "JOHN SAUL", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0449006522.01.LZZZZZZZ.jpg", "Français", 5, "Manhattan Hunt Club" },
                    { new Guid("4caf5839-94bc-42ce-ae28-e1b8faad87fe"), 1985, "Hans Johannes Hoefer", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0245542957.01.LZZZZZZZ.jpg", "Français", 5, "Pacific Northwest" },
                    { new Guid("4cbe4439-2257-4520-82d9-f7d85ee91f94"), 1988, "John G. Neihardt", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0803233019.01.LZZZZZZZ.jpg", "Français", 5, "Black Elk Speaks: Being the Life Story of a Holy Man of the Oglala Sioux" },
                    { new Guid("4d582549-6c0c-4ddc-8210-29043f0a6d81"), 1994, "Barry Neil Kaufman", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0915811537.01.LZZZZZZZ.jpg", "Français", 5, "Son Rise: The Miracle Continues" },
                    { new Guid("4e2069ea-b5ce-4fa3-a56d-fb6338db2f92"), 1994, "Ray Bradbury", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3257208626.01.LZZZZZZZ.jpg", "Français", 5, "Fahrenheit 451" },
                    { new Guid("4e639d8e-1280-4bb3-b794-8bb5f99962a3"), 1952, "Niccolo Machiavelli", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0451625889.01.LZZZZZZZ.jpg", "Français", 5, "The Prince" },
                    { new Guid("4eabeb16-d51f-48b5-b8df-aaff12999dfa"), 1987, "Jaume CapÃ³", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8477830029.01.LZZZZZZZ.jpg", "Français", 5, "TrÃ nsit (Area contemporÃ nia)" },
                    { new Guid("4f83d1f7-fe05-4fb1-98c8-8754a3d857cd"), 1997, "Kathleen E. Woodiwiss", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/038076654X.01.LZZZZZZZ.jpg", "Français", 5, "Petals on the River" },
                    { new Guid("4f888dba-9050-4003-bdef-a0c30eb8482f"), 1998, "Paul Reiser", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0380728729.01.LZZZZZZZ.jpg", "Français", 5, "Babyhood" },
                    { new Guid("4f9808df-d352-4057-abf9-3110460b63bd"), 1995, "Ferran Torrent", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/8478097732.01.LZZZZZZZ.jpg", "Français", 5, "GrÃ cies per la propina (Columna)" },
                    { new Guid("50f862b8-d5ef-4eda-8825-c0f1b6ff5ef5"), 2001, "Nicholas Sparks", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0446610399.01.LZZZZZZZ.jpg", "Français", 5, "The Rescue" },
                    { new Guid("5186420d-39ea-42f3-85a2-8fe2cbde61d4"), 1999, "Ray Bradbury", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3257210450.01.LZZZZZZZ.jpg", "Français", 5, "LÃ?Â¶wenzahnwein. Roman." },
                    { new Guid("5212e78b-b436-4407-bf78-bae328a4de61"), 1997, "Ferran Torrent", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8483002523.01.LZZZZZZZ.jpg", "Français", 5, "La mirada del tafur (ColÂ¨lecciÃ³ clÃ ssica)" },
                    { new Guid("522f38f1-a983-45d9-8fbe-f05ef5374fd2"), 1988, "Louisa May Alcott", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0451523415.01.LZZZZZZZ.jpg", "Français", 5, "Little Women (Signet Classic)" },
                    { new Guid("528373b2-45ed-45ce-a639-22c0ef81f795"), 1989, "H. Norman Wright", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0830714014.01.LZZZZZZZ.jpg", "Français", 5, "Always Daddy's Girl: Understanding Your Father's Impact on Who You Are" },
                    { new Guid("52a42076-89ec-4aee-8a4a-54aa0d676d86"), 1989, "Charles Dickens", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0866119566.01.LZZZZZZZ.jpg", "Français", 5, "Oliver Twist (Great Illustrated Classics)" },
                    { new Guid("53293002-5f80-4f00-8499-243b53a56060"), 1999, "Isabel-Clara SimÃ³", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8483007010.01.LZZZZZZZ.jpg", "Français", 5, "El gust amarg de la cervesa (CollecciÃ³ ClÃ ssica)" },
                    { new Guid("53b6824c-0974-4793-99df-edb5e110e49c"), 1992, "Mary Wollstonecraft Shelley", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1561561428.01.LZZZZZZZ.jpg", "Français", 5, "Frankenstein (Illustrated Classics Series)" },
                    { new Guid("5563b751-fcea-4301-8ade-e02c635ab078"), 1990, "Dick Francis", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0449207544.01.LZZZZZZZ.jpg", "Français", 5, "Proof" },
                    { new Guid("55f16886-0ee3-4645-a890-74198b4fee9a"), 2000, "Frank M. Robinson", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0812541642.01.LZZZZZZZ.jpg", "Français", 5, "Waiting" },
                    { new Guid("562fe2d6-e3cb-43b7-8992-e9166165fa54"), 2003, "Sue Monk Kidd", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0142001740.01.LZZZZZZZ.jpg", "Français", 5, "The Secret Life of Bees" },
                    { new Guid("56a6984a-3dd5-4eb9-9dfe-4ad0a6909745"), 1998, "Sebastian Junger", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/006101351X.01.LZZZZZZZ.jpg", "Français", 5, "The Perfect Storm : A True Story of Men Against the Sea" },
                    { new Guid("56b2d1ca-f4ca-46f9-b147-9a9275998aa3"), 1991, "Carlo D'Este", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060973129.01.LZZZZZZZ.jpg", "Français", 5, "Decision in Normandy" },
                    { new Guid("56fc8734-eacd-4022-aa59-33e1301a01f6"), 2002, "Michel Tournier", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/2070423204.01.LZZZZZZZ.jpg", "Français", 5, "Lieux dits" },
                    { new Guid("57d2a113-3871-483a-94cb-ddfa024b67c0"), 0, "Gabriel Garcia Marquez", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/342311360X.01.LZZZZZZZ.jpg", "Français", 5, "Die Liebe in Den Zelten" },
                    { new Guid("57da0120-07c2-4c97-9c8d-9be8d7b9fc33"), 1994, "Robert B. Parker", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0385313748.01.LZZZZZZZ.jpg", "Français", 5, "All Our Yesterdays (Large Print)" },
                    { new Guid("580f8478-2264-4813-bf60-cfc6db22dff7"), 2002, "John Galsworthy", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0743245024.01.LZZZZZZZ.jpg", "Français", 5, "The Forsyte Saga : The Man of Property and In Chancery" },
                    { new Guid("58bf0787-6dc3-4545-b0c3-e4e63e1531b2"), 1998, "Gabriel Garcia Marquez", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0060929790.01.LZZZZZZZ.jpg", "Français", 5, "One Hundred Years of Solitude" },
                    { new Guid("58db7711-8957-4353-aff2-63b0d470f71c"), 1991, "Anne McCaffrey", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0345335465.01.LZZZZZZZ.jpg", "Français", 5, "Dragonflight (Dragonriders of Pern Trilogy (Paperback))" },
                    { new Guid("59e474d0-99c8-4434-ab63-07ca78f6d89c"), 1995, "Anna Sewell", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1569871213.01.LZZZZZZZ.jpg", "Français", 5, "Black Beauty (Illustrated Classics)" },
                    { new Guid("5a3132f2-97c1-40f2-a8a1-9838d643b008"), 1989, "Scott, Cunningham", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0875421288.01.LZZZZZZZ.jpg", "Français", 5, "The Complete Book of Incense, Oils &amp; Brews (Llewellyn's Practical Magick)" },
                    { new Guid("5b3a7017-bf75-4e18-87ad-3b838670e64f"), 2002, "LAURA HILLENBRAND", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0449005615.01.LZZZZZZZ.jpg", "Français", 5, "Seabiscuit: An American Legend" },
                    { new Guid("5bb198ab-8ea8-493d-9307-75cef2225114"), 2003, "ARTHUR PHILLIPS", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0375759778.01.LZZZZZZZ.jpg", "Français", 5, "Prague : A Novel" },
                    { new Guid("5c8e62e5-5371-4540-a558-7deaf3aeaa88"), 2002, "Sue Townsend", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3453212150.01.LZZZZZZZ.jpg", "Français", 5, "Die Cappuccino- Jahre. Aus dem Tagebuch des Adrian Mole." },
                    { new Guid("5d1f4a4f-fb3d-45c1-ac85-a491685f3d63"), 1998, "Tom Wolfe", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0374270325.01.LZZZZZZZ.jpg", "Français", 5, "A Man in Full" },
                    { new Guid("5d641369-f808-420b-ba7b-b6e89ff3e14d"), 2000, "Franklin W. Dixon", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0671047612.01.LZZZZZZZ.jpg", "Français", 5, "Skin And Bones" },
                    { new Guid("5d8883ef-d83b-45f0-af40-33cd79c71c1a"), 1994, "Daphne Du Maurier", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0380778556.01.LZZZZZZZ.jpg", "Français", 5, "Rebecca" },
                    { new Guid("5e57c4fc-a6eb-4677-977d-c0ab02ee72da"), 2001, "Carrie Bebris", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0786913878.01.LZZZZZZZ.jpg", "Français", 5, "Pool of Radiance: The Ruins of Myth Drannor (Forgotten Realms)" },
                    { new Guid("5e66a836-dba0-4672-bff5-76d44d23c36d"), 2000, "Ray Bradbury", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3257212054.01.LZZZZZZZ.jpg", "Français", 5, "Das Kind von morgen. ErzÃ?Â¤hlungen." },
                    { new Guid("5ed562bb-bddb-4cfd-92a5-ebb54610b238"), 1988, "Lawrence J Crabb", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0891091963.01.LZZZZZZZ.jpg", "Français", 5, "Inside out" },
                    { new Guid("5fff008f-a43c-4488-8dd8-aae03d3c9ed5"), 2001, "Michael Palmer", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0553580388.01.LZZZZZZZ.jpg", "Français", 5, "The Patient" },
                    { new Guid("60915104-97b8-4255-9760-038175a3803d"), 2002, "J.D. Robb", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/042518630X.01.LZZZZZZZ.jpg", "Français", 5, "Purity in Death" },
                    { new Guid("633fa9c7-80f5-4b47-ae40-60e14ff7bc9e"), 1998, "Arundhati Roy", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0060977493.01.LZZZZZZZ.jpg", "Français", 5, "The God of Small Things" },
                    { new Guid("63493b22-b67d-49d7-8893-611662e74409"), 2003, "Dan Brown", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0312995423.01.LZZZZZZZ.jpg", "Français", 5, "Digital Fortress : A Thriller" },
                    { new Guid("65ba29f0-ef44-4587-bec3-372975da07ec"), 2000, "JOHN GRISHAM", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0385497466.01.LZZZZZZZ.jpg", "Français", 5, "The Brethren" },
                    { new Guid("65bc1714-830e-47c5-924c-6052a7649767"), 1994, "Eugeni Perea SimÃ³n", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8423324311.01.LZZZZZZZ.jpg", "Français", 5, "Gastronomia divina (L'Ã¡ncora)" },
                    { new Guid("6726c568-e32e-4919-a2e5-c91d1324239d"), 2000, "Mark Salzman", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0375406328.01.LZZZZZZZ.jpg", "Français", 5, "Lying Awake" },
                    { new Guid("67802fe1-40d1-4ed2-82d9-1ba07b722b98"), 1996, "Walter Wick", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0590481371.01.LZZZZZZZ.jpg", "Français", 5, "I Spy Spooky Night: A Book of Picture Riddles (I Spy Books)" },
                    { new Guid("67d4e84c-e3a9-440b-a772-315c7caa832e"), 1999, "John Grisham", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0440234743.01.LZZZZZZZ.jpg", "Français", 5, "The Testament" },
                    { new Guid("6811c76b-87fc-4462-b6f9-1a2835c491c0"), 2003, "LAURA HILLENBRAND", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0345465083.01.LZZZZZZZ.jpg", "Français", 5, "Seabiscuit" },
                    { new Guid("698a637f-a1c3-49e8-965f-56f8b69a78cb"), 2000, "Sandra Brown", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0446608653.01.LZZZZZZZ.jpg", "Français", 5, "The Alibi" },
                    { new Guid("69fa4f08-dc05-410b-b89c-0ea8333c063e"), 2000, "Robert S. Levinson", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0312872682.01.LZZZZZZZ.jpg", "Français", 5, "The James Dean Affair: A Neil Gulliver &amp; Stevie Marriner Novel" },
                    { new Guid("6b037871-2cad-410a-9454-26375283d33a"), 1990, "Paul Theroux", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0380619458.01.LZZZZZZZ.jpg", "Français", 5, "The Mosquito Coast" },
                    { new Guid("6b0553ab-978f-430a-9f0d-f14bbec184ab"), 2002, "Stephen King", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8484509141.01.LZZZZZZZ.jpg", "Français", 5, "Mientras Escribo" },
                    { new Guid("6b2ce33c-acb3-4f4e-b49f-c0277d45269d"), 1982, "Thomas Hauser", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8427007450.01.LZZZZZZZ.jpg", "Français", 5, "Desaparecido: LA Autentica Historia De LA Ejecucion De Charles Horman" },
                    { new Guid("6b5b74d4-6ede-48f0-b300-fdf882b07521"), 2002, "Terry Pratchett", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/006102063X.01.LZZZZZZZ.jpg", "Français", 5, "Moving Pictures (Discworld Novels (Paperback))" },
                    { new Guid("6c3209c5-ea89-4db0-8f23-e9af575345e4"), 1991, "H. Jackson Brown", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1558531025.01.LZZZZZZZ.jpg", "Français", 5, "Life's Little Instruction Book (Life's Little Instruction Books (Paperback))" },
                    { new Guid("6c63b143-8a78-4827-b976-bca9adbb1f4c"), 1996, "Thomas Cahill", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0385418493.01.LZZZZZZZ.jpg", "Français", 5, "How the Irish Saved Civilization: The Untold Story of Ireland's Heroic Role from the Fall of Rome to the Rise of Medieval Europe (Hinges of History)" },
                    { new Guid("6ceccc41-3808-4dc7-bcbc-75725f52ea30"), 1988, "Stephen McCauley", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0671649949.01.LZZZZZZZ.jpg", "Français", 5, "OBJECT AFFECTION" },
                    { new Guid("6cf4f354-565e-47c1-968c-01ce5e346441"), 1999, "Lorna Landvik", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0345433173.01.LZZZZZZZ.jpg", "Français", 5, "The Tall Pine Polka" },
                    { new Guid("6d097182-37f1-45b0-8154-4d715243c0d4"), 1993, "Chuck Hill", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0961769947.01.LZZZZZZZ.jpg", "Français", 5, "Northwest Wines and Wineries" },
                    { new Guid("6d499042-407e-4e80-a115-d8f120cc40c6"), 2003, "Holly Virden", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0785263292.01.LZZZZZZZ.jpg", "Français", 5, "If Singleness Is a Gift, What's the Return Policy?" },
                    { new Guid("6e5be11c-86a7-40d3-bb8f-8b48c150fadf"), 2002, "Terry Pratchett", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060013117.01.LZZZZZZZ.jpg", "Français", 5, "Night Watch" },
                    { new Guid("6f01eb51-82ac-4b95-972e-eed60210fe06"), 1991, "William Sleator", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0140345809.01.LZZZZZZZ.jpg", "Français", 5, "House of Stairs" },
                    { new Guid("6f7ed63c-63c6-4ef2-9281-d1940e364731"), 2003, "Alan Moore", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1401201172.01.LZZZZZZZ.jpg", "Français", 5, "League of Extraordinary Gentlemen, Vol. 2 (Comic)" },
                    { new Guid("6fe3e0de-401b-48eb-8e63-b1ccd74b751d"), 0, "Golding", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3596214629.01.LZZZZZZZ.jpg", "Français", 5, "Herr Der Fliegen (Fiction, Poetry and Drama)" },
                    { new Guid("6fffc96e-93e3-4690-9887-5f3f26009d50"), 2003, "Melissa McClone", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0373196989.01.LZZZZZZZ.jpg", "Français", 5, "Santa Brought A Son : Marrying The Boss's Daughter (Silhouette Romance, 1698)" },
                    { new Guid("705bbea3-daa0-4433-88d4-34dbee39033e"), 2001, "Jose Ortega Y Gaset", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8476409419.01.LZZZZZZZ.jpg", "Français", 5, "Estudios sobre el amor" },
                    { new Guid("7078da82-7831-4eeb-9c0a-c6a54d8609aa"), 2002, "Brady Udall", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0375719180.01.LZZZZZZZ.jpg", "Français", 5, "The Miracle Life of Edgar Mint: A Novel" },
                    { new Guid("70c7beee-ac8a-4dfa-b0da-e5f5ab55646b"), 2003, "Al Franken", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0525947647.01.LZZZZZZZ.jpg", "Français", 5, "Lies and the Lying Liars Who Tell Them: A Fair and Balanced Look at the Right" },
                    { new Guid("70e4d3be-b42c-4271-8c1d-b4eb78c6fbcd"), 1998, "Neil Gaiman", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1563892278.01.LZZZZZZZ.jpg", "Français", 5, "Preludes and Nocturnes (Sandman, Book 1)" },
                    { new Guid("710d46dc-5ecd-441a-a4a7-145b2e11badd"), 1989, "Isabel Allende", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0553280589.01.LZZZZZZZ.jpg", "Français", 5, "Eva Luna" },
                    { new Guid("71592da8-9c6e-4323-9da9-5e4d990c66f3"), 1982, "Piers Anthony", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0345297709.01.LZZZZZZZ.jpg", "Français", 5, "Centaur Aisle" },
                    { new Guid("7171649d-99ce-4b38-8a04-0826c42ccb5b"), 1994, "Lewis Grizzard", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0446325805.01.LZZZZZZZ.jpg", "Français", 5, "If Love Were Oil, I'd Be About a Quart Low" },
                    { new Guid("7173e579-c387-424b-ba97-81c9dbd0ee89"), 1999, "Richard Zimler", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1900850303.01.LZZZZZZZ.jpg", "Français", 5, "The Angelic Darkness" },
                    { new Guid("71be591d-4ebe-4d08-adbc-056d334cb6f3"), 1992, "Douglas Adams", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0517577402.01.LZZZZZZZ.jpg", "Français", 5, "Mostly Harmless" },
                    { new Guid("720419da-2bb2-4149-bea5-933c4fb12bdc"), 1994, "Stephen King", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0451162072.01.LZZZZZZZ.jpg", "Français", 5, "Pet Sematary" },
                    { new Guid("72517f70-42bf-4c7c-8483-6f6c2807c991"), 1996, "Charles Hickey", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0451406923.01.LZZZZZZZ.jpg", "Français", 5, "Goodbye, My Little Ones: The True Story of a Murderous Mother and Five Innocent Victims" },
                    { new Guid("726a484d-1d4e-4f69-a9af-62b16656ace8"), 1994, "Amy Tan", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0804106304.01.LZZZZZZZ.jpg", "Français", 5, "The Joy Luck Club" },
                    { new Guid("7317841a-b5b5-48ea-82e9-181bef035dc2"), 2000, "Milan Kundera", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3596292646.01.LZZZZZZZ.jpg", "Français", 5, "Das Buch der lÃ?Â¤cherlichen Liebe." },
                    { new Guid("736edd16-6fdd-4ac0-80b0-8376175bf1f5"), 1993, "Charles Dickens", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0679423079.01.LZZZZZZZ.jpg", "Français", 5, "Nicholas Nickleby (Everyman's Library)" },
                    { new Guid("73f5db42-d669-4162-89eb-c8cb5c48fde4"), 1993, "VÃ­ctor Mora", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8429736131.01.LZZZZZZZ.jpg", "Français", 5, "La dona dels ulls de pluja: Barcelona anys 90 (El BalancÃ­)" },
                    { new Guid("744e6301-f174-4ceb-b108-9613e0eb35fa"), 2000, "Lewis Carroll", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0451527747.01.LZZZZZZZ.jpg", "Français", 5, "Alice's Adventures in Wonderland and Through the Looking Glass" },
                    { new Guid("7455ba5d-a669-47b2-ae05-f0cc666f0d0d"), 2000, "Bill Bradley", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1579651658.01.LZZZZZZZ.jpg", "Français", 5, "The Journey From Here" },
                    { new Guid("7573224c-b2b2-4fa0-ae88-11323d024daa"), 1997, "Muriel Whitaker", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0771088191.01.LZZZZZZZ.jpg", "Français", 5, "The Best Canadian Animal Stories: Classic Tales by Master Storytellers" },
                    { new Guid("76d9f676-050a-4585-82e8-a9e4b8800d1d"), 2001, "Soren Kierkegaard", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/8420639133.01.LZZZZZZZ.jpg", "Français", 5, "Temor y Temblor" },
                    { new Guid("79eab7b4-99c9-4346-8b7c-a1b15e67009a"), 1994, "Anne Tyler", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/042511774X.01.LZZZZZZZ.jpg", "Français", 5, "Breathing Lessons" },
                    { new Guid("7a761684-f0cd-4320-8e36-1e14cc3e884c"), 1996, "Joseph Heller", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0684833395.01.LZZZZZZZ.jpg", "Français", 5, "Catch 22" },
                    { new Guid("7a7c5f2f-f82a-4f86-8aa7-6d29e281b2dd"), 1990, "Margaret Atwood", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0449213773.01.LZZZZZZZ.jpg", "Français", 5, "Life Before Man" },
                    { new Guid("7b0beb66-dbec-4387-af02-fcff4b354686"), 1997, "Bernard Cornwell", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0312156960.01.LZZZZZZZ.jpg", "Français", 5, "The Winter King: A Novel of Arthur (The Warlord Chronicles: I)" },
                    { new Guid("7b0e6d99-b82f-4e6e-a0db-e4bbef8d4af2"), 2001, "Ann Patchett", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0060188731.01.LZZZZZZZ.jpg", "Français", 5, "Bel Canto" },
                    { new Guid("7b774f02-a57f-49e0-807a-6881d032d573"), 1995, "Francine Hughes", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0590598848.01.LZZZZZZZ.jpg", "Français", 5, "Demona's Revenge (Gargoyles, No. 2)" },
                    { new Guid("7bc0ac90-e3ce-4118-94c4-96b17326eb3c"), 1961, "Mari Sandoz", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0803251718.01.LZZZZZZZ.jpg", "Français", 5, "Crazy Horse" },
                    { new Guid("7c24c441-1ef9-4a41-9ff4-f708253c4328"), 1995, "Joan Agut", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8478098267.01.LZZZZZZZ.jpg", "Français", 5, "El dia que es va cremar el Liceu (La primera Columna)" },
                    { new Guid("7d0366bd-511e-4c47-83d3-54298769b5b0"), 1990, "P.J. O'Rourke", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/087113375X.01.LZZZZZZZ.jpg", "Français", 5, "Modern Manners: An Etiquette Book for Rude People" },
                    { new Guid("7d647137-90ed-4c12-a0be-9d9c79227b89"), 1987, "Michael Hudson", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0425098109.01.LZZZZZZZ.jpg", "Français", 5, "Thieves of Light (Photon : the Ultimate Game on Planet Earth)" },
                    { new Guid("7f0a3627-4f05-4983-8cc0-e7f4919427db"), 1997, "Max Lucado", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0849953014.01.LZZZZZZZ.jpg", "Français", 5, "Life Lessons: Book Of Hebrews" },
                    { new Guid("7f802a4e-c916-4882-81d5-3b0101679b77"), 2003, "Ben Mezrich", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0743249992.01.LZZZZZZZ.jpg", "Français", 5, "Bringing Down the House: The Inside Story of Six M.I.T. Students Who Took Vegas for Millions" },
                    { new Guid("806a050b-e49a-4786-9f8a-192ee3325132"), 1997, "Ray Bradbury", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0380973839.01.LZZZZZZZ.jpg", "Français", 5, "Martian Chronicles" },
                    { new Guid("813d427c-838b-4da2-8015-46ec2fcf00ba"), 1990, "Margaret Truman", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0449212084.01.LZZZZZZZ.jpg", "Français", 5, "Murder at the Kennedy Center (Capital Crime Mysteries)" },
                    { new Guid("8161f0c4-df34-4097-ab2d-3631d30becee"), 2001, "Karen Armstrong", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0345391691.01.LZZZZZZZ.jpg", "Français", 5, "The Battle for God" },
                    { new Guid("8177720c-6b25-4aa2-86de-95c7e9bb9dea"), 1983, "OfÃ¨lia Dracs", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/8472224260.01.LZZZZZZZ.jpg", "Français", 5, "Negra i consentida (ColÂ¨lecciÃ³ El Mirall)" },
                    { new Guid("824599d9-7d90-4c6f-8045-f1ce677b7e67"), 1998, "A. Manette Ansay", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0380730138.01.LZZZZZZZ.jpg", "Français", 5, "Vinegar Hill (Oprah's Book Club (Paperback))" },
                    { new Guid("8334dd1b-ebfd-4d82-8152-7a22976dd5d8"), 1995, "Michael Crichton", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0345378490.01.LZZZZZZZ.jpg", "Français", 5, "Congo" },
                    { new Guid("8357ab08-b3d1-4ef4-b431-7e473df336c6"), 1994, "Lilian Jackson Braun", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0399138684.01.LZZZZZZZ.jpg", "Français", 5, "The Cat Who Came to Breakfast (Cat Who... (Hardcover))" },
                    { new Guid("839b91eb-b95a-40d5-bd92-dd96b7782b6a"), 1999, "Martin Schenk", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0345430476.01.LZZZZZZZ.jpg", "Français", 5, "A Small Dark Place" },
                    { new Guid("83fdb52b-adc1-467e-9cd2-e3f0d04a631d"), 1994, "Jane Austen", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0140620664.01.LZZZZZZZ.jpg", "Français", 5, "Mansfield Park (Penguin Popular Classics)" },
                    { new Guid("850e18f0-da59-4ec9-8cb6-74e9cc0fce39"), 1990, "A. S. Byatt", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0394586239.01.LZZZZZZZ.jpg", "Français", 5, "Possession: A Romance" },
                    { new Guid("85722e9f-42c1-442e-b6f7-57e3cc2cde14"), 1987, "William Abrahams", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0385235941.01.LZZZZZZZ.jpg", "Français", 5, "Prize Stories, 1987: The O'Henry Awards" },
                    { new Guid("85ec43f9-4766-46d0-8bc9-0ca25e5f6820"), 1997, "John R. Holt", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/055329198X.01.LZZZZZZZ.jpg", "Français", 5, "Wolf Moon" },
                    { new Guid("8662b211-b98d-44e6-808f-03899f881a8d"), 2001, "Rachel Harris", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0330484516.01.LZZZZZZZ.jpg", "Français", 5, "Twenty Minute Retreats: Revive Your Spirits in Just Minutes a Day (A Pan Self-discovery Title)" },
                    { new Guid("86d30ed1-f5d6-4b8e-8405-436c0734c062"), 1995, "Margaret Atwood", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0553569058.01.LZZZZZZZ.jpg", "Français", 5, "The Robber Bride" },
                    { new Guid("87f0a79d-03d3-4142-bdb5-1ed51249d209"), 2000, "Anne Frank", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/9681500555.01.LZZZZZZZ.jpg", "Français", 5, "Diario de Ana Frank" },
                    { new Guid("8801a7e6-3655-4533-baca-c895a1ec4756"), 2003, "Stuart Woods", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0451208080.01.LZZZZZZZ.jpg", "Français", 5, "The Short Forever" },
                    { new Guid("8862337f-c455-4cbe-ad8a-9b99313eaf84"), 2001, "William Shakespeare", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0198320264.01.LZZZZZZZ.jpg", "Français", 5, "Julius Caesar (Oxford School Shakespeare)" },
                    { new Guid("88ab2e31-82c2-45a0-91d1-1163463a33c2"), 1987, "Robert A. Heinlein", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0441783589.01.LZZZZZZZ.jpg", "Français", 5, "Starship Troopers" },
                    { new Guid("88ca5cf5-0199-4ec6-8e8a-2ed0b3ae1afb"), 1986, "M. Carme Junyent", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/8475960936.01.LZZZZZZZ.jpg", "Français", 5, "Les llengÃ¼es d'Africa (Biblioteca universal EmpÃºries)" },
                    { new Guid("891a82d5-33ae-4e17-b3f9-dff9e3407946"), 1997, "Sue Townsend", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0380730448.01.LZZZZZZZ.jpg", "Français", 5, "The Adrian Mole Diaries : The Secret Diary of Adrian Mole, Aged 13 3/4 : The Growing Pains of Adrian Mole" },
                    { new Guid("89a5015a-287f-4a90-af11-e3e1ab6a62d4"), 1996, "Ken Follett", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0451166892.01.LZZZZZZZ.jpg", "Français", 5, "The Pillars of the Earth" },
                    { new Guid("89baf946-a617-43e8-aad8-577e471761e8"), 2001, "John Grisham", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/044023722X.01.LZZZZZZZ.jpg", "Français", 5, "A Painted House" },
                    { new Guid("8a252788-b7d9-4b4e-99b2-aee0d4633650"), 2000, "David Allen Hulse", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1567184294.01.LZZZZZZZ.jpg", "Français", 5, "The Western Mysteries: An Encyclopedic Guide to the Sacred Languages &amp; Magickal Systems of the World : The Key of It All, Book II (Key of It All)" },
                    { new Guid("8a364fea-1428-4566-9079-a065851f36f4"), 1999, "Sebastian Junger", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060977477.01.LZZZZZZZ.jpg", "Français", 5, "The Perfect Storm : A True Story of Men Against the Sea" },
                    { new Guid("8b1017af-3d46-4d47-972d-e72ecbbfd753"), 1986, "Larry McMurtry", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0671623249.01.LZZZZZZZ.jpg", "Français", 5, "LONESOME DOVE" },
                    { new Guid("8b72aa9e-6395-44a2-9e00-e9211b4dcb6b"), 2000, "Isabel Wolff", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0451409256.01.LZZZZZZZ.jpg", "Français", 5, "Making Minty Malone" },
                    { new Guid("8b75c307-38a1-47cf-8397-ae8d099e4a48"), 1993, "LTD", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0671847546.01.LZZZZZZZ.jpg", "Français", 5, "REAL GUIDE: CALIFORNIA AND THE WEST COAST (The Real guides)" },
                    { new Guid("8ba7104c-1b29-466f-b084-f1164623832e"), 1994, "Mary Wollstonecraft Shelley", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0486282112.01.LZZZZZZZ.jpg", "Français", 5, "Frankenstein (Dover Thrift Editions)" },
                    { new Guid("8c0fa908-0a89-4292-bb59-57d2d5597417"), 1990, "Barry Lopez", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0380711109.01.LZZZZZZZ.jpg", "Français", 5, "Desert Notes/River Notes" },
                    { new Guid("8c6a3905-f1d4-4b93-bff6-735bcfaa08a2"), 1994, "Toni Morrison", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0452264464.01.LZZZZZZZ.jpg", "Français", 5, "Beloved (Plume Contemporary Fiction)" },
                    { new Guid("8ce6f75a-14ca-4049-b662-acf95e39c580"), 2001, "David G. Hartwell", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/038081840X.01.LZZZZZZZ.jpg", "Français", 5, "Year's Best Fantasy (Year's Best Fantasy)" },
                    { new Guid("8dc0b43a-aa8a-460e-94bb-fb36db3305f8"), 1997, "Johnny Molloy", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0897322339.01.LZZZZZZZ.jpg", "Français", 5, "The Best in Tent Camping: Smoky Mountains : A Guide for Campers Who Hate Rvs, Concrete Slabs, and Loud Portable Stereos (Best in Tent Camping Colorado)" },
                    { new Guid("8e2c2877-e9fb-4a33-a904-fbfd89a36000"), 2002, "Enid Blyton", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0749748028.01.LZZZZZZZ.jpg", "Français", 5, "The Folk of the Faraway Tree" },
                    { new Guid("8e5872ce-d278-4b81-975a-e4f96f3fd65d"), 2004, "Sheila Heti", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0887841740.01.LZZZZZZZ.jpg", "Français", 5, "The Middle Stories" },
                    { new Guid("8f48d6ab-5b54-494f-8ee9-2cf83b1e8693"), 1996, "Jack Canfield", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1558744150.01.LZZZZZZZ.jpg", "Français", 5, "Chicken Soup for the Woman's Soul (Chicken Soup for the Soul Series (Paper))" },
                    { new Guid("90298ce8-d710-4cc3-97b9-f79bf0ab21bd"), 2003, "Barbara Delinsky", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0743411269.01.LZZZZZZZ.jpg", "Français", 5, "An Accidental Woman" },
                    { new Guid("903e300a-7371-4223-9a6a-d843d9d0de45"), 1993, "Mary Brave Bird", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0802114369.01.LZZZZZZZ.jpg", "Français", 5, "Ohitika Woman" },
                    { new Guid("90412caa-6d1f-48cd-a032-574d5e6d89f9"), 2000, "Adam Lebor", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/080652121X.01.LZZZZZZZ.jpg", "Français", 5, "Hitler's Secret Bankers: The Myth of Swiss Neutrality During the Holocaust" },
                    { new Guid("905485a4-7a25-4be7-9ce6-522197b2e6ff"), 2000, "Nora Roberts", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0515128554.01.LZZZZZZZ.jpg", "Français", 5, "Heart of the Sea (Irish Trilogy)" },
                    { new Guid("908649ff-0dd0-4aef-8a39-c8163ea53c90"), 1997, "Terry Pratchett", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0061052523.01.LZZZZZZZ.jpg", "Français", 5, "Interesting Times: A Novel of Discworld" },
                    { new Guid("90a51934-6279-49c5-8895-e622fc30d45a"), 1999, "Robert Hendrickson", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1575663937.01.LZZZZZZZ.jpg", "Français", 5, "More Cunning Than Man: A Social History of Rats and Man" },
                    { new Guid("92228ab1-7261-4786-98af-e6b9b97b6259"), 1998, "Joseph Conrad", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1853262404.01.LZZZZZZZ.jpg", "Français", 5, "Heart of Darkness (Wordsworth Collection)" },
                    { new Guid("9233b26e-a429-4cb1-9823-549eba3a6c48"), 2002, "James Patterson", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0316693006.01.LZZZZZZZ.jpg", "Français", 5, "Four Blind Mice" },
                    { new Guid("92963f02-ec4e-4c40-9b48-68401579d613"), 1991, "SUZANNE FISHER STAPLES", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0679810307.01.LZZZZZZZ.jpg", "Français", 5, "Shabanu: Daughter of the Wind (Border Trilogy)" },
                    { new Guid("92f64d16-3a94-46f1-9f28-dd16cfe3480b"), 1992, "Jean Marzollo", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0590450875.01.LZZZZZZZ.jpg", "Français", 5, "I Spy: A Book of Picture Riddles" },
                    { new Guid("940961ed-4f64-471a-b648-f39e0b085b91"), 1998, "Ellen Gilchrist", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0316314927.01.LZZZZZZZ.jpg", "Français", 5, "Sarah Conley" },
                    { new Guid("94352275-3058-41cf-bc60-d9a79059f327"), 1999, "Frank McCourt", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0684848783.01.LZZZZZZZ.jpg", "Français", 5, "Tis : A Memoir" },
                    { new Guid("94416bd7-a3dc-4c16-8ff7-3e6d8fcd5c9e"), 1998, "Franklin W. Dixon", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0671021745.01.LZZZZZZZ.jpg", "Français", 5, "EYE ON CRIME: HARDY BOYS #153" },
                    { new Guid("95e6022d-cbf3-452c-91aa-9e49e85f8178"), 1978, "Carl Sagan", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0345260317.01.LZZZZZZZ.jpg", "Français", 5, "The Dragons of Eden: Speculations on the Evolution of Human Intelligence" },
                    { new Guid("95eda5eb-d5d3-47b4-89f9-0c71017fa734"), 1993, "MAYA ANGELOU", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0679427430.01.LZZZZZZZ.jpg", "Français", 5, "Wouldn't Take Nothing for My Journey Now" },
                    { new Guid("9646af04-8646-4277-b601-d726122188c4"), 1986, "Luis Racionero", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/8401351421.01.LZZZZZZZ.jpg", "Français", 5, "El desarrollo de Leonardo da Vinci (BiografÃ­as y memorias)" },
                    { new Guid("965d83a9-7223-4f6c-be75-ce6d18cbfc90"), 2003, "Valerie Frankel", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0060938412.01.LZZZZZZZ.jpg", "Français", 5, "The Accidental Virgin" },
                    { new Guid("969501e4-3420-4df9-9938-405242cbe944"), 1965, "NATHANIEL HAWTHORNE", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0553210092.01.LZZZZZZZ.jpg", "Français", 5, "The Scarlet Letter" },
                    { new Guid("96c870cb-42d1-433e-bbf9-439fc3e31f1d"), 1999, "Homer Hickam", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0440235502.01.LZZZZZZZ.jpg", "Français", 5, "October Sky: A Memoir" },
                    { new Guid("96c94508-b66e-4d51-a9ac-c946b13bea01"), 2001, "Joanne Harris", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0380815923.01.LZZZZZZZ.jpg", "Français", 5, "Blackberry Wine : A Novel" },
                    { new Guid("973e6bf9-c3c3-40fb-be7c-73caa28a5a94"), 1994, "Robert James Waller", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0446601640.01.LZZZZZZZ.jpg", "Français", 5, "Slow Waltz in Cedar Bend" },
                    { new Guid("9773eef4-359f-4cc9-9cf8-74d6c4a2ecbb"), 1998, "Erich Segal", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0425164403.01.LZZZZZZZ.jpg", "Français", 5, "Only Love (Magical Love)" },
                    { new Guid("977ec3eb-befd-49ac-a637-1dda90cdd48e"), 1996, "Rebecca Wells", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060976845.01.LZZZZZZZ.jpg", "Français", 5, "Little Altars Everywhere: A Novel" },
                    { new Guid("981bf6c6-c189-4f2f-9463-6b2d94e1f360"), 2000, "Elizabeth Adler", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0440234964.01.LZZZZZZZ.jpg", "Français", 5, "All or Nothing (Wheeler Large Print Books)" },
                    { new Guid("98e30084-47e4-45a5-a6ef-17021a7ad325"), 2001, "Mary Higgins Clark", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0671004573.01.LZZZZZZZ.jpg", "Français", 5, "Before I Say Good-Bye" },
                    { new Guid("98e5856b-7851-426f-82dd-985d85fd4e7a"), 2002, "Dan Brown", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0671027387.01.LZZZZZZZ.jpg", "Français", 5, "Deception Point" },
                    { new Guid("99498ee7-36dc-4b4f-a1db-4c6863c2633a"), 1998, "EDWARD RUTHERFURD", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0449002632.01.LZZZZZZZ.jpg", "Français", 5, "London : The Novel" },
                    { new Guid("9956957a-9746-4ee3-9bcb-627459d316e6"), 2001, "J. R. R. Tolkien", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8445071408.01.LZZZZZZZ.jpg", "Français", 5, "El Senor De Los Anillos: LA Comunidad Del Anillo (Lord of the Rings (Spanish))" },
                    { new Guid("9a2e6d68-df09-4700-b727-4ba0344ef32b"), 1995, "John Milne", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0435272683.01.LZZZZZZZ.jpg", "Français", 5, "Great Expectations (Heinemann Guided Readers)" },
                    { new Guid("9a374e88-4551-460f-bb5f-9bb86a8682ca"), 1996, "Pam Proctor", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0684822733.01.LZZZZZZZ.jpg", "Français", 5, "Love, Miracles, and Animal Healing : A heartwarming look at the spiritual bond between animals and humans" },
                    { new Guid("9a70d293-55a2-4775-9d8d-3da55c61e978"), 2003, "Donna Jo Napoli", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0385327773.01.LZZZZZZZ.jpg", "Français", 5, "The Great God Pan" },
                    { new Guid("9a862fc5-d895-4f2d-9652-903cef61dc9c"), 1988, "PHILIP PULLMAN", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0394895894.01.LZZZZZZZ.jpg", "Français", 5, "The Ruby in the Smoke (Sally Lockhart Trilogy, Book 1)" },
                    { new Guid("9aec55e5-6a7f-4fcd-9daa-3fb66588dd3d"), 2000, "Stephen King", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0671042858.01.LZZZZZZZ.jpg", "Français", 5, "The Girl Who Loved Tom Gordon" },
                    { new Guid("9b01a2f3-11cc-4982-9876-9bc426677fa7"), 2000, "Joe Hutsko", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0812575954.01.LZZZZZZZ.jpg", "Français", 5, "The Deal" },
                    { new Guid("9b4259a1-db8c-482b-a19f-f85aeaa39205"), 2002, "PHILIP PULLMAN", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0375823352.01.LZZZZZZZ.jpg", "Français", 5, "The Amber Spyglass (His Dark Materials, Book 3)" },
                    { new Guid("9bd1218b-4117-4170-9ddc-de394a9d42c0"), 2001, "Charles Dickens", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0486415864.01.LZZZZZZZ.jpg", "Français", 5, "Great Expectations (Dover Thrift Editions)" },
                    { new Guid("9c81901c-1a2c-4a22-b9c4-e36aea05e3e5"), 2002, "Ann Beattie", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/074322678X.01.LZZZZZZZ.jpg", "Français", 5, "Where You'll Find Me: And Other Stories" },
                    { new Guid("9d7a68c5-5d17-4476-b8d7-255acf28ffbe"), 1997, "Thomas Hardy", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1853260053.01.LZZZZZZZ.jpg", "Français", 5, "Tess of the D'Urbervilles (Wordsworth Classics)" },
                    { new Guid("9dc81ad5-ccbd-496b-8c76-2727a1a29feb"), 1999, "Laura J. Mixon", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0812523873.01.LZZZZZZZ.jpg", "Français", 5, "Proxies" },
                    { new Guid("9e149984-6c65-479d-a2e1-063371a5a8e7"), 2000, "Lurlene McDaniel", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0553571486.01.LZZZZZZZ.jpg", "Français", 5, "Angel of Hope (Mercy Trilogy)" },
                    { new Guid("9f57695e-c5a2-4777-96f8-2378a8d4d3e7"), 1998, "Mary Higgins Clark", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0671867156.01.LZZZZZZZ.jpg", "Français", 5, "Pretend You Don't See Her" },
                    { new Guid("9f74c232-7875-4b88-ad74-095394eb3c00"), 1998, "Valerie Block", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1569471096.01.LZZZZZZZ.jpg", "Français", 5, "Was It Something I Said?" },
                    { new Guid("9fa9c885-5e48-474e-a2d8-f2ef3d88e094"), 2001, "Jennifer Crusie", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0312252617.01.LZZZZZZZ.jpg", "Français", 5, "Fast Women" },
                    { new Guid("9fc09e3f-65ec-45d5-8282-2d97994ec4e1"), 2002, "David Iglehart", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0964778319.01.LZZZZZZZ.jpg", "Français", 5, "An Atmosphere of Eternity: Stories of India" },
                    { new Guid("a2fe822e-019d-49c8-b74a-2d13b4c782dd"), 2003, "James Patterson", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0316602906.01.LZZZZZZZ.jpg", "Français", 5, "The Big Bad Wolf: A Novel" },
                    { new Guid("a4c604df-d65a-4d23-83a0-0f142622463d"), 1993, "Candice F. Ransom", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0816729913.01.LZZZZZZZ.jpg", "Français", 5, "Why Are Boys So Weird (Tales from Third Grade)" },
                    { new Guid("a6c175f6-2ee2-4d83-8de1-3e7b6b5dd163"), 2000, "Robert Cowley", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0425176428.01.LZZZZZZZ.jpg", "Français", 5, "What If?: The World's Foremost Military Historians Imagine What Might Have Been" },
                    { new Guid("a7327333-fd28-4249-8e38-242cc414b54b"), 1982, "Robert Penn Warren", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0156047624.01.LZZZZZZZ.jpg", "Français", 5, "All the King's Men" },
                    { new Guid("a8c26e97-52b0-4c8a-8acd-5f4e4abf4998"), 2001, "Terry Pratchett", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0060199563.01.LZZZZZZZ.jpg", "Français", 5, "Thief of Time" },
                    { new Guid("a9036279-24d6-4483-adc9-03514c17851c"), 2001, "Celia Brooks Brown", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1841721522.01.LZZZZZZZ.jpg", "Français", 5, "New Vegetarian: Bold and Beautiful Recipes for Every Occasion" },
                    { new Guid("a9810427-03d4-4713-a41a-5696e08f99c1"), 1996, "Florence King", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0312143370.01.LZZZZZZZ.jpg", "Français", 5, "The Florence King Reader" },
                    { new Guid("a9ab36c7-1b88-4187-bedc-6a48f97d3a36"), 1992, "Douglas Adams", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0345371984.01.LZZZZZZZ.jpg", "Français", 5, "Last Chance to See" },
                    { new Guid("a9f23656-5b6c-4c12-b143-ae3216c2b7b7"), 1985, "Dick Francis", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0449202631.01.LZZZZZZZ.jpg", "Français", 5, "Danger" },
                    { new Guid("aab859f5-afad-4b5f-88fe-b87d8084db99"), 1981, "James Joyce", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3518111000.01.LZZZZZZZ.jpg", "Français", 5, "Ulysses (Ã?Â?bersetzg. WollschlÃ?Â¤ger). ( Neue Folge, 100)." },
                    { new Guid("acae786a-e197-4504-b14e-f90ee1d59416"), 1968, "Antoine de Saint-ExupÃ©ry", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0156528207.01.LZZZZZZZ.jpg", "Français", 5, "The Little Prince" },
                    { new Guid("acc0654b-a44a-4771-a226-03585ba227da"), 2004, "Anita Shreve", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0316735736.01.LZZZZZZZ.jpg", "Français", 5, "All He Ever Wanted: A Novel" },
                    { new Guid("ad047f6c-4169-4af7-a68b-dc7c61b47dfd"), 1993, "HarperReference", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0062770500.01.LZZZZZZZ.jpg", "Français", 5, "Seattle Access" },
                    { new Guid("ad8ea7a7-597a-4dd9-b3d0-6ce0641fb802"), 1993, "Scott Turow", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0671870432.01.LZZZZZZZ.jpg", "Français", 5, "PLEADING GUILTY" },
                    { new Guid("add48a3d-610f-4987-b36b-2d87bdfcd4f8"), 1991, "Amy Tan", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0399135782.01.LZZZZZZZ.jpg", "Français", 5, "The Kitchen God's Wife" },
                    { new Guid("add7f67f-51c2-44d8-b491-bf892a881325"), 1980, "Aleksandr Zinoviev", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0394743741.01.LZZZZZZZ.jpg", "Français", 5, "The yawning heights" },
                    { new Guid("ae337d2d-efe2-4727-9b11-bf6f47709337"), 2002, "Sue Townsend", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3570300099.01.LZZZZZZZ.jpg", "Français", 5, "Das Intimleben des Adrian Mole, 13 3/4 Jahre. cbt. ( Ab 14 J.)." },
                    { new Guid("af2d2d6f-fb88-4500-8668-8890f86519d3"), 2003, "Trudy Suggs", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1592571301.01.LZZZZZZZ.jpg", "Français", 5, "Alpha Teach Yourself American Sign Language in 24 Hours (Alpha Teach Yourself in 24 Hours)" },
                    { new Guid("b00e4955-ecb7-4155-8312-62542f49cf39"), 1998, "Malachy McCourt", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0786863986.01.LZZZZZZZ.jpg", "Français", 5, "A Monk Swimming" },
                    { new Guid("b0b561c0-d65f-4f07-8a01-87092c2954f8"), 1985, "Piers Anthony", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0345313097.01.LZZZZZZZ.jpg", "Français", 5, "Crewel Lye" },
                    { new Guid("b0b90e05-5cf8-42ef-a4ba-ee28a1e24648"), 2004, "Georgette Heyer", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0373836023.01.LZZZZZZZ.jpg", "Français", 5, "Powder and Patch" },
                    { new Guid("b13af27f-3f26-4f02-8251-44e63bdcc386"), 2002, "Jane Lindskold", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0812575482.01.LZZZZZZZ.jpg", "Français", 5, "Through Wolf's Eyes (Wolf)" },
                    { new Guid("b193d9d3-30cb-4284-80fb-ba8bffc8fb66"), 1999, "Nick Page", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0002740230.01.LZZZZZZZ.jpg", "Français", 5, "Keep It Simple: And Get More Out of Life" },
                    { new Guid("b28300d2-fa02-4928-83b7-a3e62258d416"), 1992, "Patricia D. Cornwell", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0380717018.01.LZZZZZZZ.jpg", "Français", 5, "Body of Evidence (Kay Scarpetta Mysteries (Paperback))" },
                    { new Guid("b2d97ce9-e70c-4c66-a700-8809e172d4a4"), 1989, "Mark Twain", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0812504208.01.LZZZZZZZ.jpg", "Français", 5, "The Adventures of Tom Sawyer" },
                    { new Guid("b2dd4e7f-b647-4615-90f4-d57d853b45d3"), 2003, "MARK HADDON", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0385509456.01.LZZZZZZZ.jpg", "Français", 5, "The Curious Incident of the Dog in the Night-Time : A Novel" },
                    { new Guid("b401051a-8166-4a40-b0da-88221eaddaf6"), 2000, "David Baldacci", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0446527165.01.LZZZZZZZ.jpg", "Français", 5, "Wish You Well" },
                    { new Guid("b47cd6c5-01f5-4e55-9de2-baabf675c90c"), 1998, "Patricia Cornwell", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0671023616.01.LZZZZZZZ.jpg", "Français", 5, "Postmortem (Kay Scarpetta Mysteries (Paperback))" },
                    { new Guid("b625cf0d-63fb-470d-831f-044f6599c87f"), 2002, "Michele Morgan", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0785815147.01.LZZZZZZZ.jpg", "Français", 5, "Simple Wicca (Simple Wisdom Book)" },
                    { new Guid("b686e208-1d87-4913-a142-16b07c256550"), 1997, "John Darnton", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0312963009.01.LZZZZZZZ.jpg", "Français", 5, "Neanderthal: A Novel" },
                    { new Guid("b7134a4d-666f-4c4f-91c2-6d74841bbf9b"), 1999, "E. J. W. Barber", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0393045218.01.LZZZZZZZ.jpg", "Français", 5, "The Mummies of Urumchi" },
                    { new Guid("b7805a14-076a-4bc7-8aec-7d2f3c2a5ff5"), 2002, "Stel Pavlou", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0743403843.01.LZZZZZZZ.jpg", "Français", 5, "Decipher" },
                    { new Guid("b9462926-aaf4-4961-8857-39d0c84dd853"), 2003, "James Patterson", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0446612545.01.LZZZZZZZ.jpg", "Français", 5, "The Beach House" },
                    { new Guid("b95e4206-a97e-413b-b312-0879557837b9"), 2002, "Neil Gaiman", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/156971620X.01.LZZZZZZZ.jpg", "Français", 5, "Harlequin Valentine" },
                    { new Guid("b992b4e6-8d22-4e4c-b574-1c7f2875c40d"), 1968, "Jerome D. Salinger", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3499110695.01.LZZZZZZZ.jpg", "Français", 5, "Neun ErzÃ?Â¤hlungen." },
                    { new Guid("b9d345d2-f97f-4873-909e-7bf0e1b3b063"), 2002, "Kay Hooper", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0553583468.01.LZZZZZZZ.jpg", "Français", 5, "Whisper of Evil (Hooper, Kay. Evil Trilogy.)" },
                    { new Guid("ba84e116-9136-42ef-9908-68e458ea752f"), 2003, "J. R. Parrish", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1879384493.01.LZZZZZZZ.jpg", "Français", 5, "If I'd Known Then What I Know Now: Why Not Learn from the Mistakes of Others? : You Can't Afford to Make Them All Yourself" },
                    { new Guid("bac28998-c56d-41b1-9461-4ad23e1d202f"), 2002, "Jonathan Franzen", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3498020862.01.LZZZZZZZ.jpg", "Français", 5, "Die Korrekturen." },
                    { new Guid("bb5db781-666a-4c2e-89b1-114a1157cbd5"), 1996, "Paul Auster", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8433914545.01.LZZZZZZZ.jpg", "Français", 5, "El Palacio de La Luna" },
                    { new Guid("bbc6744b-09d5-4eb9-822e-220b2e77ac22"), 1996, "Simon Nye", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1857938011.01.LZZZZZZZ.jpg", "Français", 5, "A-Z of Behaving Badly" },
                    { new Guid("bca679c5-06ff-4c47-8a3a-f398df048c36"), 1995, "Stewart O'Nan", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0140250964.01.LZZZZZZZ.jpg", "Français", 5, "Snow Angels" },
                    { new Guid("bdfd1bf8-d176-42b5-a759-7832e0e2d354"), 1993, "John Grisham", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/038542471X.01.LZZZZZZZ.jpg", "Français", 5, "The Client" },
                    { new Guid("be0cc221-b050-4094-8ef2-c47abe8e7de4"), 2002, "Tom Clancy", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0425184226.01.LZZZZZZZ.jpg", "Français", 5, "The Sum of All Fears" },
                    { new Guid("be5f945e-d828-4f90-9f42-4fbb09a29e1f"), 1995, "Anne Rivers Siddons", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0061099686.01.LZZZZZZZ.jpg", "Français", 5, "Downtown" },
                    { new Guid("be928bb8-4955-4645-9973-e2ab02645bf9"), 1999, "Edward John Moreton Drax Plunkett Dunsany", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/034543191X.01.LZZZZZZZ.jpg", "Français", 5, "The King of Elfland's Daughter (Del Rey Impact)" },
                    { new Guid("bed5aebd-ad08-4b18-91a0-e801b1046724"), 1993, "Nathaniel Hawthorne", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0451525221.01.LZZZZZZZ.jpg", "Français", 5, "Scarlet Letter" },
                    { new Guid("c08a6061-9d64-40b9-aa86-203b1a007329"), 2002, "Richard Russo", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0375726403.01.LZZZZZZZ.jpg", "Français", 5, "Empire Falls" },
                    { new Guid("c097e8f2-6613-42d4-bfb0-4c26b1d48e24"), 1977, "Robert A Johnson", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060804157.01.LZZZZZZZ.jpg", "Français", 5, "He Understanding Masculine Psychology" },
                    { new Guid("c2b358d6-703e-4234-943b-c4d05a0ce57e"), 2003, "Richard A. Lupoff", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/074345829X.01.LZZZZZZZ.jpg", "Français", 5, "Philip Jose Farmer's The Dungeon" },
                    { new Guid("c35469d5-5817-4eef-ae14-fad7bd400ee9"), 2000, "Luanne Rice", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/055358099X.01.LZZZZZZZ.jpg", "Français", 5, "Cloud Nine" },
                    { new Guid("c36d8e31-209d-4174-a289-56b439691579"), 2002, "Alan Moore", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1563898586.01.LZZZZZZZ.jpg", "Français", 5, "The League of Extraordinary Gentlemen, Vol. 1" },
                    { new Guid("c4bb688f-bb88-4fa3-a92a-1234c690c0dc"), 1999, "Rita Chapman Works", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1575843366.01.LZZZZZZZ.jpg", "Français", 5, "What Shall I Be (Barbie Carryalong)" },
                    { new Guid("c4dc3f59-bc2c-40b8-ac3d-a8d712b309d2"), 1992, "O. Carol Simonton Md", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0553280333.01.LZZZZZZZ.jpg", "Français", 5, "Getting Well Again" },
                    { new Guid("c59152d6-e6eb-40e0-95a6-5a8b6b7ef0c0"), 1975, "Donna K Grosvenor", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0870441663.01.LZZZZZZZ.jpg", "Français", 5, "The wild ponies of Assateague Island (Books for young explorers)" },
                    { new Guid("c6e21dcd-5dc3-4d35-97e8-800585cb2aed"), 2000, "MICHAEL CRICHTON", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0345417623.01.LZZZZZZZ.jpg", "Français", 5, "Timeline" },
                    { new Guid("c742687e-3b37-49ec-8f0e-92a66a2fd2d8"), 2002, "Olivia Goldsmith", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0451206673.01.LZZZZZZZ.jpg", "Français", 5, "Pen Pals" },
                    { new Guid("c7a0ef34-8567-4ca2-8d8c-577fc508dd88"), 2002, "Joanna Trollope", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3548254268.01.LZZZZZZZ.jpg", "Français", 5, "Eine ganz normale AffÃ?Â¤re." },
                    { new Guid("c7dc930e-8dec-445e-b127-712b932db54b"), 2001, "Dean Koontz", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0553582747.01.LZZZZZZZ.jpg", "Français", 5, "From the Corner of His Eye" },
                    { new Guid("c7f5aa71-1199-45e0-b34a-60cc8844a1ab"), 2001, "Jane Smiley", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0449005410.01.LZZZZZZZ.jpg", "Français", 5, "Horse Heaven (Ballantine Reader's Circle)" },
                    { new Guid("c816d813-392e-4025-b92c-5d59dc4d7601"), 1999, "Gina Bari Kolata", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0374157065.01.LZZZZZZZ.jpg", "Français", 5, "Flu: The Story of the Great Influenza Pandemic of 1918 and the Search for the Virus That Caused It" },
                    { new Guid("c895d5d0-30bc-4b11-8815-744fbad15c62"), 2003, "E. B. White", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/006052779X.01.LZZZZZZZ.jpg", "Français", 5, "Charlotte's Web Book and Charm (Charming Classics)" },
                    { new Guid("c8fbbc79-8c28-4dc9-bb6b-ac0e558c956b"), 2002, "Horacio Vazquez-Rial", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8466601090.01.LZZZZZZZ.jpg", "Français", 5, "Las DOS Muertes De Gardel (Ficcionario)" },
                    { new Guid("c9f67caf-b164-4698-982c-abd52c36cf26"), 2003, "TIM GAUTREAUX", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0375414746.01.LZZZZZZZ.jpg", "Français", 5, "The Clearing" },
                    { new Guid("ca9205db-a9ba-482b-855b-f1bc856f5393"), 1999, "Robynn Clairday", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0439095026.01.LZZZZZZZ.jpg", "Français", 5, "Tell Me This Isn't Happening" },
                    { new Guid("cae3f843-7429-4cae-bb65-3e105b67436a"), 2002, "Brian Kaufman", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0972044205.01.LZZZZZZZ.jpg", "Français", 5, "The Breach" },
                    { new Guid("cb13d9b5-7d42-45ab-b0ae-72cd192e186f"), 2000, "Norman Jetmundsen", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1903019699.01.LZZZZZZZ.jpg", "Français", 5, "The Soulbane Stratagem" },
                    { new Guid("cb39d1b1-f014-4931-bea0-7a845ab7749b"), 1989, "Paul Woodruff", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0872200760.01.LZZZZZZZ.jpg", "Français", 5, "Symposium" },
                    { new Guid("cb9ecd3a-4153-4a63-81d7-192305f42207"), 1983, "Jane Austen", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/055321215X.01.LZZZZZZZ.jpg", "Français", 5, "Pride and Prejudice" },
                    { new Guid("cce18692-2538-49be-970c-662ea3f62e3e"), 2000, "Dean R. Koontz", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0553582909.01.LZZZZZZZ.jpg", "Français", 5, "Icebound" },
                    { new Guid("cdf9a86d-5ca5-4557-a17b-1bd7f6fe63a3"), 1990, "Carmen Rico-Godoy", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8478800336.01.LZZZZZZZ.jpg", "Français", 5, "CÃ³mo ser una mujer y no morir en el intento (ColecciÃ³n El Papagayo)" },
                    { new Guid("ce850264-e916-418c-a831-ffbe9c5830f2"), 1989, "Linda Gordon", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0140104682.01.LZZZZZZZ.jpg", "Français", 5, "Heroes of Their Own Lives: The Politics and History of Family Violence, Boston 1880-1960" },
                    { new Guid("ce9650be-7a8f-4813-b873-4f29b811ab68"), 1999, "R. J. Kaiser", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1552041778.01.LZZZZZZZ.jpg", "Français", 5, "Jane Doe" },
                    { new Guid("ceff49b1-38da-4d61-ac8c-a6b25f2616e1"), 1991, "Dog Mary Crow", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060973897.01.LZZZZZZZ.jpg", "Français", 5, "Lakota Woman" },
                    { new Guid("cfe23061-f768-4640-a4e2-99ee39d41848"), 1998, "OSCAR WILDE", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0375751513.01.LZZZZZZZ.jpg", "Français", 5, "The Picture of Dorian Gray (Modern Library (Paperback))" },
                    { new Guid("d0195721-9c71-427f-8d4e-ac62e8efbce1"), 1999, "Margaret Maron", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0446606197.01.LZZZZZZZ.jpg", "Français", 5, "Killer Market (Deborah Knott Mysteries (Paperback))" },
                    { new Guid("d08c36b5-bbb9-4fc3-83b5-8d401218a2ff"), 2003, "Tanuja Desai Hidier", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0439510112.01.LZZZZZZZ.jpg", "Français", 5, "Born Confused" },
                    { new Guid("d0a8fbae-1d2f-4eda-b964-1eeac13f3c5c"), 1971, "Pat Hutchins", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0020437501.01.LZZZZZZZ.jpg", "Français", 5, "Rosie'S Walk" },
                    { new Guid("d1136c5e-a936-45db-94a7-fc80b47df791"), 1999, "Sandra Levy Ceren", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0966986105.01.LZZZZZZZ.jpg", "Français", 5, "Prescription for Terror" },
                    { new Guid("d1937544-8533-4aac-9dde-aaf5d635040b"), 2002, "Ellen Datlow", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0670035262.01.LZZZZZZZ.jpg", "Français", 5, "The Green Man : Tales from the Mythic Forest" },
                    { new Guid("d2fa43c0-d145-428e-91b3-beb5c37ddb85"), 1987, "Robert Westall", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0670815373.01.LZZZZZZZ.jpg", "Français", 5, "Urn Burial" },
                    { new Guid("d3687b47-3c9c-40c7-a205-2816acfb2ebe"), 1995, "Willa Cather", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/039575514X.01.LZZZZZZZ.jpg", "Français", 5, "My Antonia" },
                    { new Guid("d36deebb-853a-4477-9f04-5cc4272b6514"), 2000, "Ray Bradbury", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3257212429.01.LZZZZZZZ.jpg", "Français", 5, "Die Mechanismen der Freude. ErzÃ?Â¤hlungen." },
                    { new Guid("d471c20a-457a-4f14-aeba-36e484ca2be8"), 2000, "Theodore Beale", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0671018930.01.LZZZZZZZ.jpg", "Français", 5, "The War in Heaven (Eternal Warriors)" },
                    { new Guid("d5c0dd9b-f199-4930-883f-f3e5ea9de9aa"), 1988, "Bob Sjogren", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0927545373.01.LZZZZZZZ.jpg", "Français", 5, "Unveiled at Last" },
                    { new Guid("d625ce92-eef0-4fc1-9e15-f9a66e9b9c32"), 2004, "Christopher Rice", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0743470389.01.LZZZZZZZ.jpg", "Français", 5, "The Snow Garden" },
                    { new Guid("d6358692-66c9-413c-90f0-414131202bc1"), 1995, "SUZANNE FISHER STAPLES", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0679865691.01.LZZZZZZZ.jpg", "Français", 5, "Haveli (Laurel Leaf Books)" },
                    { new Guid("d686d33d-93c5-4791-8d87-32a4b0ebf26b"), 2002, "Alice Sebold", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0316666343.01.LZZZZZZZ.jpg", "Français", 5, "The Lovely Bones: A Novel" },
                    { new Guid("d68b845e-93ad-43e6-afae-e197ecda457e"), 1998, "Anne Perry", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0804117934.01.LZZZZZZZ.jpg", "Français", 5, "The Silent Cry (William Monk Novels (Paperback))" },
                    { new Guid("d6ba5842-c237-4596-8a02-3fed5eafee6b"), 1996, "Pearl Abraham", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/1573225487.01.LZZZZZZZ.jpg", "Français", 5, "The Romance Reader" },
                    { new Guid("d6d07649-ba25-431f-a366-930fbbc8534a"), 1994, "David Morrell", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0312953453.01.LZZZZZZZ.jpg", "Français", 5, "Blood Oath" },
                    { new Guid("d7051f27-45bd-4b70-b80d-0ad40248dbff"), 2000, "Rex Stout", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/076218857X.01.LZZZZZZZ.jpg", "Français", 5, "The Doorbell Rang (The Best Mysteries of All Time)" },
                    { new Guid("d7c9b12f-3706-4db3-8ec2-cd240dd8d723"), 1998, "Richard Webster", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/156718796X.01.LZZZZZZZ.jpg", "Français", 5, "Astral Travel for Beginners (For Beginners)" },
                    { new Guid("d8922932-8f38-49c8-a85b-4225cbd92185"), 1994, "John Berendt", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0679429220.01.LZZZZZZZ.jpg", "Français", 5, "Midnight in the Garden of Good and Evil: A Savannah Story" },
                    { new Guid("d8efd22a-d9e8-4635-94cd-40aea4433bab"), 1991, "J.D. Salinger", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0316769487.01.LZZZZZZZ.jpg", "Français", 5, "The Catcher in the Rye" },
                    { new Guid("d92f8a65-4051-4785-adfc-2b1b08c5d504"), 2003, "Greg Palast", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0452283914.01.LZZZZZZZ.jpg", "Français", 5, "The Best Democracy Money Can Buy: The Truth About Corporate Cons, Globalization and High-Finance Fraudsters" },
                    { new Guid("da81f792-ad30-45fb-8dec-411ce6f93951"), 2003, "DAVID FRUM", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0375509038.01.LZZZZZZZ.jpg", "Français", 5, "The Right Man : The Surprise Presidency of George W. Bush" },
                    { new Guid("da90bb0a-f6f3-4411-a79a-40d47e5219bd"), 1984, "Warren W. Wiersbe", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0801096677.01.LZZZZZZZ.jpg", "Français", 5, "Victorious Christians You Should Know" },
                    { new Guid("dae9b7ba-312f-4f7b-8626-ef36a2a802c0"), 1997, "Dave Barry", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0449912302.01.LZZZZZZZ.jpg", "Français", 5, "Dave Barry in Cyberspace" },
                    { new Guid("db7654ad-845b-46d1-9072-ad35d502c640"), 2003, "Donald F. Kettl", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0071416331.01.LZZZZZZZ.jpg", "Français", 5, "Team Bush : Leadership Lessons from the Bush White House" },
                    { new Guid("dbacbb53-c1e2-492c-bc36-e86dba18f250"), 1981, "Louis Lamour", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0553062042.01.LZZZZZZZ.jpg", "Français", 5, "Daybreakers Louis Lamour Collection" },
                    { new Guid("dc4743ad-7851-42f9-b1ec-54214c631077"), 1996, "Jo Dereske", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/038078243X.01.LZZZZZZZ.jpg", "Français", 5, "Miss Zukas and the Raven's Dance" },
                    { new Guid("dd50c87d-4d15-48a5-a089-8bbe5cb42cc4"), 2003, "Sandra Brown", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0446612618.01.LZZZZZZZ.jpg", "Français", 5, "A Kiss Remembered" },
                    { new Guid("dd6c988d-af32-46db-b406-cda8e20456c0"), 2000, "Bernard King", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1862047626.01.LZZZZZZZ.jpg", "Français", 5, "New Perspectives: Runes" },
                    { new Guid("ddbf6594-a198-4b66-b7b7-09b6b883ecab"), 1996, "Gregory Maguire", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0060987103.01.LZZZZZZZ.jpg", "Français", 5, "Wicked: The Life and Times of the Wicked Witch of the West" },
                    { new Guid("de0800a2-c5bb-42ad-92d7-82c5d8c7e201"), 2002, "James McCourt", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0940322978.01.LZZZZZZZ.jpg", "Français", 5, "Mawrdew Czgowchwz (New York Review Books Classics)" },
                    { new Guid("de0937c7-e5e9-4201-82fc-bc1c55abea9f"), 1987, "Lynda Madaras", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0937858994.01.LZZZZZZZ.jpg", "Français", 5, "The What's Happening to My Body? Book for Boys: A Growing Up Guide for Parents and Sons" },
                    { new Guid("de809427-e71d-4631-b03f-3b53052ce4f9"), 2000, "Richard North Patterson", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3442446937.01.LZZZZZZZ.jpg", "Français", 5, "Tage der Unschuld." },
                    { new Guid("df46f94a-1b05-4112-8115-12543dfc3470"), 2000, "Nic Kynaston", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0553582682.01.LZZZZZZZ.jpg", "Français", 5, "Guinness World Records 2000 (Guinness Book of Records, 2000)" },
                    { new Guid("df85b161-372b-4d70-ad92-b1d86560f4b5"), 2004, "Alice Sebold", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0316168815.01.LZZZZZZZ.jpg", "Français", 5, "The Lovely Bones" },
                    { new Guid("e0d21548-d4bd-4c39-8d59-a43583ff8fcd"), 1993, "Neil Gaiman", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0963094424.01.LZZZZZZZ.jpg", "Français", 5, "Angels and Visitations: A Miscellany" },
                    { new Guid("e10dc8e4-e167-421b-a07f-3e6a42df3531"), 2001, "Michael Lewis", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0393020371.01.LZZZZZZZ.jpg", "Français", 5, "Next: The Future Just Happened" },
                    { new Guid("e14e5236-969b-4280-a60a-4dca4514141f"), 2000, "Mike Gayle", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0340767936.01.LZZZZZZZ.jpg", "Français", 5, "Turning Thirty" },
                    { new Guid("e18c6ae1-873a-41d2-bcdb-72dd007d43e0"), 1990, "David Brin", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0553278746.01.LZZZZZZZ.jpg", "Français", 5, "The Postman (Bantam Classics)" },
                    { new Guid("e1f2a9ff-7fe6-4fbc-b658-2db877243dde"), 1982, "Douglas Adams", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0671461494.01.LZZZZZZZ.jpg", "Français", 5, "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("e38b8f12-9f04-41f0-a7b0-e5b17ca517ca"), 2000, "Tim Lahaye", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0842342702.01.LZZZZZZZ.jpg", "Français", 5, "Left Behind: A Novel of the Earth's Last Days (Left Behind #1)" },
                    { new Guid("e3dd1f6b-b2e2-44d9-89d4-06e7d6ba4db5"), 1980, "Raymond Chandler", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3257207522.01.LZZZZZZZ.jpg", "Français", 5, "Der KÃ?Â¶nig in Gelb." },
                    { new Guid("e47143cf-645a-40c9-9788-1c5855f41462"), 1995, "John F. Love", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0553347594.01.LZZZZZZZ.jpg", "Français", 5, "McDonald's: Behind the Arches" },
                    { new Guid("e4e62fe2-963f-4535-9bec-238b7631fab7"), 1990, "Piers Anthony", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0345354931.01.LZZZZZZZ.jpg", "Français", 5, "Night Mare (Xanth Novels (Paperback))" },
                    { new Guid("e4e71b0d-ec22-47e3-a755-db04f10c08e0"), 1990, "Pam Conrad", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0064470113.01.LZZZZZZZ.jpg", "Français", 5, "Taking the Ferry Home" },
                    { new Guid("e517f43b-644a-47c0-a1dc-4730d1d5f76f"), 2001, "Cybill Shepherd", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0061030147.01.LZZZZZZZ.jpg", "Français", 5, "Cybill Disobedience: How I Survived Beauty Pageants, Elvis, Sex, Bruce Willis, Lies, Marriage, Motherhood, Hollywood, and the Irrepressible Urge to Say What I Think" },
                    { new Guid("e5e64bea-774c-4cbf-9a74-4ce63ce696e7"), 1988, "Mary O'Hara", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0060809027.01.LZZZZZZZ.jpg", "Français", 5, "My Friend Flicka" },
                    { new Guid("e5eaac9d-4ba4-433f-8d22-9db7466fce58"), 1997, "David Gemmell", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0345416848.01.LZZZZZZZ.jpg", "Français", 5, "Last Sword of Power (Stones of Power)" },
                    { new Guid("e6811ddb-554d-410a-a047-b25aa4718a5b"), 1993, "Fay Weldon", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3423116714.01.LZZZZZZZ.jpg", "Français", 5, "Die Klone der Joanna May. Roman." },
                    { new Guid("e7426363-ca53-4798-be31-b3ae93396b1a"), 2000, "Robert T. Kiyosaki", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0446677450.01.LZZZZZZZ.jpg", "Français", 5, "Rich Dad, Poor Dad: What the Rich Teach Their Kids About Money--That the Poor and Middle Class Do Not!" },
                    { new Guid("e7514e2b-6ae9-4062-997c-1914205652f7"), 1995, "T. Coraghessan Boyle", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0670856045.01.LZZZZZZZ.jpg", "Français", 5, "The Tortilla Curtain" },
                    { new Guid("e7661ec7-5a61-4cd1-968a-1f33c099f925"), 1997, "Barbara Vine", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0140252800.01.LZZZZZZZ.jpg", "Français", 5, "The Brimstone Wedding" },
                    { new Guid("e78910b5-589f-48c4-b655-feaa3c8db252"), 1982, "P. D. James", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0684177730.01.LZZZZZZZ.jpg", "Français", 5, "The SKULL BENEATH THE SKIN" },
                    { new Guid("e7f449e8-ad0a-4702-b0e8-09349b7c82bd"), 2001, "Richard North Patterson", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0345404793.01.LZZZZZZZ.jpg", "Français", 5, "Protect and Defend" },
                    { new Guid("e80abf0c-807d-484d-9e4c-7033cba4495a"), 1992, "Tony Hillerman", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0061099325.01.LZZZZZZZ.jpg", "Français", 5, "Coyote Waits (Joe Leaphorn/Jim Chee Novels)" },
                    { new Guid("e8d8dea1-c782-4d0a-99bc-c63fd19cc603"), 1992, "John Grisham", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/044021145X.01.LZZZZZZZ.jpg", "Français", 5, "The Firm" },
                    { new Guid("e9ad3a19-748a-40d3-b546-bf78bc52b35c"), 1996, "Neal Barrett Jr.", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0440222303.01.LZZZZZZZ.jpg", "Français", 5, "The Touch of Your Shadow, the Whisper of Your Name (Babylon 5, Book 5)" },
                    { new Guid("e9ed7f43-6a2b-4de9-bd4c-cd2b2b6dd8fd"), 2000, "MICHAEL ONDAATJE", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0375410538.01.LZZZZZZZ.jpg", "Français", 5, "Anil's Ghost" },
                    { new Guid("ea8193d9-30b7-42c5-856f-e0ae6ecf47ea"), 1993, "Barbara Kingsolver", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0060168013.01.LZZZZZZZ.jpg", "Français", 5, "Pigs in Heaven" },
                    { new Guid("ea9477f9-14e4-4a27-ad40-ba566dde6277"), 2003, "Mitch Albom", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0786868716.01.LZZZZZZZ.jpg", "Français", 5, "The Five People You Meet in Heaven" },
                    { new Guid("eab4634d-304f-45bb-8406-4a630f100d27"), 1985, "OfÃ¨lia Dracs", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/8472227421.01.LZZZZZZZ.jpg", "Français", 5, "Essa efa (ColÂ¨lecciÃ³ El Mirall i el temps)" },
                    { new Guid("eb1c39a1-a0d8-4930-b1dc-7d6662cea310"), 2000, "Ray Bradbury", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3257214154.01.LZZZZZZZ.jpg", "Français", 5, "Familientreffen. ErzÃ?Â¤hlungen." },
                    { new Guid("eb52d76b-9ea0-40c0-a1a2-3c2de8752d41"), 1988, "David Adams Richards", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0771074670.01.LZZZZZZZ.jpg", "Français", 5, "Nights Below Station Street" },
                    { new Guid("eb6bddfb-b7c2-4311-b208-3d6f2d97efef"), 2000, "Roald Dahl", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0140374248.01.LZZZZZZZ.jpg", "Français", 5, "James and the Giant Peach" },
                    { new Guid("ebf761ae-ff9e-4efd-84df-22fd92414707"), 2004, "George Orwell", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0451526341.01.LZZZZZZZ.jpg", "Français", 5, "Animal Farm" },
                    { new Guid("ec02b31a-55a5-4da6-971d-ab6b2dcdf803"), 1992, "Mark Helprin", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0380715899.01.LZZZZZZZ.jpg", "Français", 5, "A Soldier of the Great War" },
                    { new Guid("ec27435c-3185-4f1a-9e04-51e8a697b5b7"), 2002, "PHILIP PULLMAN", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0375823468.01.LZZZZZZZ.jpg", "Français", 5, "The Subtle Knife (His Dark Materials, Book 2)" },
                    { new Guid("ecf53e02-4587-455e-82c5-8f6cdb4de09c"), 1993, "Patricia D. Cornwell", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0380718332.01.LZZZZZZZ.jpg", "Français", 5, "All That Remains (Kay Scarpetta Mysteries (Paperback))" },
                    { new Guid("ed119345-f83e-4404-86ee-862e30346e2e"), 1998, "Belva Plain", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0385316895.01.LZZZZZZZ.jpg", "Français", 5, "Legacy of Silence" },
                    { new Guid("ed628be5-5483-4bda-9202-70ed6243f855"), 2002, "Barbara Metzger", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0451205197.01.LZZZZZZZ.jpg", "Français", 5, "Lady in Green/Minor Indiscretions (Signet Regency Romance)" },
                    { new Guid("ed72b5be-a673-439f-a3a6-46222276666d"), 1986, "Maria JaÃ©n", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/8486433193.01.LZZZZZZZ.jpg", "Français", 5, "Amorrada al pilÃ³ (Columna)" },
                    { new Guid("ed7faf38-8c15-4515-b88a-5ccd809a1d89"), 1993, "Isabelle Holland", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0590431110.01.LZZZZZZZ.jpg", "Français", 5, "The Journey Home" },
                    { new Guid("ed8e5926-0782-4e9e-8dcf-9907f6dda828"), 2003, "SOPHIE KINSELLA", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0440241413.01.LZZZZZZZ.jpg", "Français", 5, "Confessions of a Shopaholic" },
                    { new Guid("ef554bb2-9ddd-4960-abbe-edc4c4a1a629"), 1987, "Roland Warren", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0819154946.01.LZZZZZZZ.jpg", "Français", 5, "The Community in America" },
                    { new Guid("f0610b41-a7f0-4ef2-9b4e-3f0a4acd7175"), 2002, "Ray Bradbury", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3257203659.01.LZZZZZZZ.jpg", "Français", 5, "Der illustrierte Mann. ErzÃ?Â¤hlungen." },
                    { new Guid("f15e74e7-efe5-4405-8a23-0275aaae479b"), 2000, "Thomas Harris", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0440224675.01.LZZZZZZZ.jpg", "Français", 5, "Hannibal" },
                    { new Guid("f170eac4-ea90-4166-94c0-1c9fdf88b5da"), 1996, "Jane Austen", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0451526279.01.LZZZZZZZ.jpg", "Français", 5, "Emma (Signet Classics (Paperback))" },
                    { new Guid("f2474aaf-d860-4972-988d-74320784459d"), 2002, "Patricia Cornwell", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0425182908.01.LZZZZZZZ.jpg", "Français", 5, "Isle of Dogs" },
                    { new Guid("f25ae2a0-364f-4c01-a635-b0da60d6e27d"), 1992, "VicenÃ§ Villatoro", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/8429734996.01.LZZZZZZZ.jpg", "Français", 5, "Hotel Europa (El BalancÃ­)" },
                    { new Guid("f326dbd4-879d-47db-8d71-50822e32e587"), 1995, "LOUIS DE BERNIERES", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/067976397X.01.LZZZZZZZ.jpg", "Français", 5, "Corelli's Mandolin : A Novel" },
                    { new Guid("f39b3726-b923-4da8-b0a8-a0bf80cd1331"), 1994, "Sam Bobrick", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0843136685.01.LZZZZZZZ.jpg", "Français", 5, "Sheldon &amp; Mrs. Levine: An Excruciating Correspondence" },
                    { new Guid("f3f6d6ee-d77e-4415-bd9a-68f7fa2b85c0"), 1986, "Robert G. Allen", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0671621009.01.LZZZZZZZ.jpg", "Français", 5, "Creating Wealth : Retire in Ten Years Using Allen's Seven Principles of Wealth!" },
                    { new Guid("f4e85136-0b84-4b9b-b357-83f94f434487"), 1983, "Benjamin Hoff", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0140067477.01.LZZZZZZZ.jpg", "Français", 5, "The Tao of Pooh" },
                    { new Guid("f4e8b5cc-73d7-4355-b8fa-4f9c15d41fbb"), 1994, "Charles de Lint", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0312890044.01.LZZZZZZZ.jpg", "Français", 5, "Moonheart (Newford)" },
                    { new Guid("f53850a6-8720-4097-ac0b-bd7ea40f52a6"), 2000, "Barbara Delinsky", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/067103619X.01.LZZZZZZZ.jpg", "Français", 5, "Lake News" },
                    { new Guid("f565737a-ec1f-4491-aa8a-90dd087c2fab"), 2002, "Simon Mawer", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0316973742.01.LZZZZZZZ.jpg", "Français", 5, "The Gospel of Judas: A Novel" },
                    { new Guid("f5ec61a0-2377-4b28-87a3-8282d24576f7"), 2003, "Ray Bradbury", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/3257208669.01.LZZZZZZZ.jpg", "Français", 5, "Das BÃ?Â¶se kommt auf leisen Sohlen." },
                    { new Guid("f60df425-ba12-42ad-8bbb-404598ce7c4b"), 2003, "Charles Noland", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1414035004.01.LZZZZZZZ.jpg", "Français", 5, "The Adventures of Drew and Ellie: The Magical Dress" },
                    { new Guid("f669f589-581c-4751-a48f-82fde73369bd"), 1980, "Ellen Carol Dubois", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0801491827.01.LZZZZZZZ.jpg", "Français", 5, "Feminism and Suffrage: The Emergence of an Independent Women's Movement in America, 1848-1869" },
                    { new Guid("f695be2b-b06a-4381-8afc-2a73df4fa7ee"), 2001, "Eleanor Cooney", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/3442353866.01.LZZZZZZZ.jpg", "Français", 5, "Der Fluch der Kaiserin. Ein Richter- Di- Roman." },
                    { new Guid("f6b82e0e-be0c-4d52-80b1-df2b61380dc5"), 1997, "Arthur Golden", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0375400117.01.LZZZZZZZ.jpg", "Français", 5, "Memoirs of a Geisha" },
                    { new Guid("f708b51d-ba9a-485c-bc84-deec8de899c1"), 1997, "Terry Pratchett", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0061052515.01.LZZZZZZZ.jpg", "Français", 5, "Maskerade: A Novel of Discworld (Pratchett, Terry. Discworld Series (New York, N.Y.).)" },
                    { new Guid("f87d0fe7-84b0-4b13-9e47-4562e093dddf"), 1996, "C.S. Lewis", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0684823802.01.LZZZZZZZ.jpg", "Français", 5, "OUT OF THE SILENT PLANET" },
                    { new Guid("f88999cd-4087-47dd-81ec-cee5b84255f1"), 1995, "Jane Austen", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0486284735.01.LZZZZZZZ.jpg", "Français", 5, "Pride and Prejudice (Dover Thrift Editions)" },
                    { new Guid("f960c5e2-65e0-4ad9-a9c2-63e281799301"), 1992, "Michael Jan Friedman", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0671864769.01.LZZZZZZZ.jpg", "Français", 5, "Relics (Star Trek: The Next Generation)" },
                    { new Guid("f978afdc-afd1-4dbf-afa2-aef8cb40fa6a"), 2001, "Richard Bruce Wright", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0002005018.01.LZZZZZZZ.jpg", "Français", 5, "Clara Callan" },
                    { new Guid("f9aafd94-98a5-4ba5-bdae-c4acbb6b644b"), 2000, "KENT HARUF", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/0375705856.01.LZZZZZZZ.jpg", "Français", 5, "Plainsong (Vintage Contemporaries)" },
                    { new Guid("fa01b2e8-843a-4ba6-b1bc-22920005095a"), 1998, "Jerome D. Salinger", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/3499151502.01.LZZZZZZZ.jpg", "Français", 5, "Hebt den Dachbalken hoch, Zimmerleute / Seymour wird vorgestellt." },
                    { new Guid("fa148ee4-9be6-4f1d-a304-c96dd25d7bdf"), 2002, "EDNA BARKER", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0771076002.01.LZZZZZZZ.jpg", "Français", 5, "Remembering Peter Gzowski : A Book of Tributes" },
                    { new Guid("fb15774e-f880-41f2-b02e-2459d1d8577c"), 2000, "Laura Zigman", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0385333404.01.LZZZZZZZ.jpg", "Français", 5, "Dating Big Bird" },
                    { new Guid("fb22e335-b301-4a26-8a32-c363ea8184d5"), 1999, "Maeve Binchy", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/8478884963.01.LZZZZZZZ.jpg", "Français", 5, "Una casa en Irlanda" },
                    { new Guid("fbc8dca5-db6b-4684-a331-479dae839ed3"), 2002, "Enid Blyton", new Guid("2038c213-a15f-46d3-b813-e03292370924"), "", "", "http://images.amazon.com/images/P/0749748001.01.LZZZZZZZ.jpg", "Français", 5, "The Enchanted Wood" },
                    { new Guid("fd065ead-fe84-4894-a99c-c784056dd5c6"), 1997, "Frederick J. Moody", new Guid("6b38a2eb-76c0-4a71-81ee-da12243bc60b"), "", "", "http://images.amazon.com/images/P/1575024179.01.LZZZZZZZ.jpg", "Français", 5, "The Day I Almost Quit" },
                    { new Guid("fd59ec3b-76f5-4e8f-b566-454fb41c81ec"), 1990, "Edith Wharton", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/0679725393.01.LZZZZZZZ.jpg", "Français", 5, "The House of Mirth (Library of America)" },
                    { new Guid("fea7ff59-0dee-49e4-aca1-c8dbbb1e8dc7"), 1991, "Neal Pirolo", new Guid("2b08c46b-b715-4b0b-96dc-d1c5a4a0add9"), "", "", "http://images.amazon.com/images/P/1880185008.01.LZZZZZZZ.jpg", "Français", 5, "Serving As Senders: How to Care for Your Missionaries While They Are Preparing to Go, While They Are on the Field, When They Return Home" }
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
                name: "IX_Emprunts_LivreId",
                table: "Emprunts",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_UserId",
                table: "Emprunts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_LivreId",
                table: "Favoris",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_UserId",
                table: "Favoris",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Livres_CategorieId",
                table: "Livres",
                column: "CategorieId");
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
                name: "Emprunts");

            migrationBuilder.DropTable(
                name: "Favoris");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Livres");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
