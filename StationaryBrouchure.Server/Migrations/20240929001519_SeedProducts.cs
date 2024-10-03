using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StationaryBrouchure.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Blue", "A blue ink pen.", "images/pen.jpg", "Pen", 1.99 },
                    { 2, "White", "A ruled notebook.", "images/notebook.jpg", "Notebook", 2.9900000000000002 },
                    { 3, "Yellow", "A wooden pencil.", "images/pencil.jpg", "Pencil", 0.98999999999999999 },
                    { 4, "Pink", "A pink rubber eraser.", "images/eraser.jpg", "Eraser", 0.5 },
                    { 5, "Yellow", "A fluorescent yellow highlighter.", "images/highlighter.jpg", "Highlighter", 1.49 },
                    { 6, "Assorted", "Colorful sticky notes.", "images/sticky-notes.jpg", "Sticky Notes", 3.9900000000000002 },
                    { 7, "Assorted", "Assorted binder clips.", "images/binder-clips.jpg", "Binder Clips", 2.5 },
                    { 8, "Black", "A standard tape dispenser.", "images/tape-dispenser.jpg", "Tape Dispenser", 4.9900000000000002 },
                    { 9, "Silver", "A pair of scissors.", "images/scissors.jpg", "Scissors", 3.4900000000000002 },
                    { 10, "Transparent", "A plastic ruler.", "images/ruler.jpg", "Ruler", 1.1899999999999999 },
                    { 11, "Black", "A black permanent marker.", "images/marker.jpg", "Marker", 1.29 },
                    { 12, "Multicolor", "A world globe for reference.", "images/globe.jpg", "Globe", 15.99 },
                    { 13, "Brown", "A standard clipboard.", "images/clipboard.jpg", "Clipboard", 2.75 },
                    { 14, "Black", "A luxury fountain pen.", "images/fountain-pen.jpg", "Fountain Pen", 25.989999999999998 },
                    { 15, "White", "An A4 sketch pad.", "images/sketch-pad.jpg", "Sketch Pad", 5.9900000000000002 },
                    { 16, "Gray", "A basic calculator.", "images/calculator.jpg", "Calculator", 10.0 },
                    { 17, "Multicolor", "An art set with various colors.", "images/art-set.jpg", "Art Set", 20.0 },
                    { 18, "Assorted", "A set of colored pencils.", "images/color-pencils.jpg", "Color Pencils", 7.9900000000000002 },
                    { 19, "White", "A small whiteboard.", "images/whiteboard.jpg", "Whiteboard", 12.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
