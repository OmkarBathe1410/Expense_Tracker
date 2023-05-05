# Expense_Tracker
A project built using ASP.NET Core

STEP-1:
We created a project using ASP.NET Web Template (MVC).
STEP-2:
We install some packages: 
-	Microsoft.EntityFrameworkCore (6.0.15)
-	Microsoft.EntityFrameworkCore.SqlServer (6.0.15)
-	Microsoft.EntityFrameworkCore.Tools (6.0.15)
STEP-3:
Now we create model classes for required entities, in our case we have:
Category:
-	Salary, medicine, fuel, gadgets, etc.
Transaction:
-	Transactions that are made in various categories.
STEP-4:
Create a DbContext for Entity Core by creating a class called “ApplicationDbContext” which inherits the base class called “DbContext” from Entity Core Framework.
During DB Migration the model classes: Category.cs and Transaction.cs will be converted into corresponding SQL Server Tables and this can only happen if we have a properties corresponding to above classes in our ApplicationDbContext class.
In ApplicationDbContext constructor we have to pass the DbProvider that we are going to use, such as: MySQL or SQL Server, and also we have to pass the DbConnection String.
Now an instance of ApplicationDbContext class will be created through Dependency Injection (DI), that we can do by modifying Program.cs file.
CODE:
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
Builder is an object, Services is a collection, and we are defining that we are using MicrosoftSQLServer for that database and after defining the connection string in the appsettings.json file we have passed that connection name to the above mentioned GetConnectionString method.

Now for DbMigration we use package manager console and in that we first have to create a migration
PM> Add-Migration "Initial Create"
As a result of this command execution, there will be a new folder created named Migrations, within thay we would be having a c-sharp file with the migration name initial create, it contains c-sharp code for creating the SQLServer DB or Tables with the models that we have created.
Now to create physical db according to our models we have execute one more command:
PM> Update-Database


FINAL PROJECT SCREENS:
![Screenshot (61)](https://user-images.githubusercontent.com/92221952/236481642-eba5a2f1-8223-4116-b265-7f7477e3438f.png)
![Screenshot (59)](https://user-images.githubusercontent.com/92221952/236481796-f664f8dc-8cbc-4f89-9849-43b7b1ea6840.png)
![Screenshot (60)](https://user-images.githubusercontent.com/92221952/236481909-fedb74ce-6711-4083-bde0-e3ae75e509eb.png)
![Screenshot (57)](https://user-images.githubusercontent.com/92221952/236482028-d49f5867-3f68-485a-b3e0-e5a1d4358fbc.png)
![Screenshot (58)](https://user-images.githubusercontent.com/92221952/236482115-7777bd13-1372-4596-9f87-6678d62637e3.png)




