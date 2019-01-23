using BooksOrganizer.Model;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using static System.Net.WebRequestMethods;

namespace BooksOrganizer.Migrations
{

    //Add-Migration InitialCreate
    //Update-Database <Comment>

    public class ContextMigrationConfiguration : DbMigrationsConfiguration<DataContext>
        {
            public ContextMigrationConfiguration()
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
                SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
            }
        }
   }
    
