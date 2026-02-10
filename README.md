# ⚙️ Prerequisites

### Make sure u have installed: <br>
[.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) <br>
This API uses an SQL database. Additional setup might be needed when using some different databases.

# Installation
### Restore Dependencies
`dotnet restore`
### Configure Environment Variables
Update appsettings.json<br>
`"DefaultConnectionString"` and `"AuthConnectionString"` to your Connection String
### Run Database Migrations
`dotnet ef database update`
### Run API
`dotnet run`
### Run Swagger UI
Open swagger http://localhost:5018/swagger
