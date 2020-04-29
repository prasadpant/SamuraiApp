using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SamuraiApp.Data.Migrations
{
    public partial class NewStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE PROCEDURE dbo.GetSamurais
                @text VARCHAR(20)
                AS
                SELECT      Samurais.Id, Samurais.Name
                FROM        Samurais 
                WHERE      (Samurais.Name LIKE '%'+@text+'%')");

            migrationBuilder.Sql(
                @"CREATE PROCEDURE dbo.DeleteQuotesForSamurai
                 @samuraiId int
                 AS
                 DELETE FROM Quotes
                 WHERE Quotes.SamuraiId=@samuraiId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
