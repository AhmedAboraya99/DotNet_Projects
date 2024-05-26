using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WASMWebAPI.Migration
{
    /// <inheritdoc />
    public partial class AddData : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Employees( FirstName, LastName, Gender, MaritalStatus, comment, JoinedDate, CountryId  ) VALUES ('Ahmed','Marawan',1,1,'Developer','2018-04-28', 1)");
            migrationBuilder.Sql(
                "INSERT INTO WASMAPIDb.dbo.Employees( FirstName, LastName, Gender, MaritalStatus, comment, JoinedDate, CountryId  ) VALUES ( 'Mohamed', 'Messi',1, 1,'Footballer', '2022-07-08', 2)");
            migrationBuilder.Sql(" INSERT INTO WASMAPIDb.dbo.Employees( FirstName, LastName, Gender, MaritalStatus, comment, JoinedDate, CountryId  ) VALUES ( 'Wael', 'Ibrahim', 1, 1, 'Content Creator', '2019-07-08' , 4)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
