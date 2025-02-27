using System;
using System.IO;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestTemplate15.Migrations
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var connectionString = string.Empty;
            var dbUser = string.Empty;
            var dbPassword = string.Empty;
            var scriptsPath = string.Empty;
            var sqlUsersGroupName = string.Empty;

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Production";
            Console.WriteLine($"Environment: {env}.");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            InitializeParameters();
            var connectionStringBuilderTestTemplate15 = new SqlConnectionStringBuilder(connectionString);
            if (env.Equals("Development"))
            {
                connectionStringBuilderTestTemplate15.UserID = dbUser;
                connectionStringBuilderTestTemplate15.Password = dbPassword;
            }
            else
            {
                connectionStringBuilderTestTemplate15.UserID = dbUser;
                connectionStringBuilderTestTemplate15.Password = dbPassword;
                connectionStringBuilderTestTemplate15.Authentication = SqlAuthenticationMethod.ActiveDirectoryPassword;
            }
            var upgraderTestTemplate15 =
                DeployChanges.To
                    .SqlDatabase(connectionStringBuilderTestTemplate15.ConnectionString)
                    .WithVariable("SqlUsersGroupNameVariable", sqlUsersGroupName)    // This is necessary to perform template variable replacement in the scripts.
                    .WithScriptsFromFileSystem(
                        !string.IsNullOrWhiteSpace(scriptsPath)
                                ? Path.Combine(scriptsPath, "TestTemplate15Scripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate15Scripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate15.");
            if (env == "Development")
            {
                upgraderTestTemplate15.MarkAsExecuted("0000_AzureSqlContainedUser.sql");
            }
            var resultTestTemplate15 = upgraderTestTemplate15.PerformUpgrade();

            if (!resultTestTemplate15.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate15 upgrade error: {resultTestTemplate15.Error}");
                Console.ResetColor();
                return -1;
            }

            // Uncomment the below sections if you also have an Identity Server project in the solution.
            /*
            var connectionStringTestTemplate15Identity = string.IsNullOrWhiteSpace(args.FirstOrDefault())
                ? config["ConnectionStrings:TestTemplate15IdentityDb"]
                : args.FirstOrDefault();

            var upgraderTestTemplate15Identity =
                DeployChanges.To
                    .SqlDatabase(connectionStringTestTemplate15Identity)
                    .WithScriptsFromFileSystem(
                        scriptsPath != null
                            ? Path.Combine(scriptsPath, "TestTemplate15IdentityScripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate15IdentityScripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate15 Identity.");
            if (env != "Development")
            {
                upgraderTestTemplate15Identity.MarkAsExecuted("0004_InitialData.sql");
                Console.WriteLine($"Skipping 0004_InitialData.sql since we are not in Development environment.");
                upgraderTestTemplate15Identity.MarkAsExecuted("0005_Initial_Configuration_Data.sql");
                Console.WriteLine($"Skipping 0005_Initial_Configuration_Data.sql since we are not in Development environment.");
            }
            var resultTestTemplate15Identity = upgraderTestTemplate15Identity.PerformUpgrade();

            if (!resultTestTemplate15Identity.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate15 Identity upgrade error: {resultTestTemplate15Identity.Error}");
                Console.ResetColor();
                return -1;
            }
            */

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;

            void InitializeParameters()
            {
                // Local database, populated from .env file.
                if (args.Length == 0)
                {
                    connectionString = config["TestTemplate15Db_Migrations_Connection"];
                    dbUser = config["DbUser"];
                    dbPassword = config["DbPassword"];
                }

                // Deployed database
                else if (args.Length == 5)
                {
                    connectionString = args[0];
                    dbUser = args[1];
                    dbPassword = args[2];
                    scriptsPath = args[3];
                    sqlUsersGroupName = args[4];
                }
            }
        }
    }
}
