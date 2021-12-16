#Install .Net Core SDK 6.0

#Open the "\FutrexConnect" directory in vs code terminal

#Restore required .Net Core nuget packages with below command
dotnet restore 

#Make sure the connection string mentioned in "FutrexConnect\FutrexConnect.Core\appsettings.json" is correct
#Create Initial database with sample data using EF Core migrations with below commands. This will create FutrexDb database in local SQL server with sample data in Customer table
dotnet ef migrations add "CreateFCDb" --project FutrexConnect.Infrastructure --startup-project FutrexConnect.Core --output-dir Persistence\Migrations
dotnet ef database update  --project FutrexConnect.Infrastructure --startup-project FutrexConnect.Core

#Change current directory to the Startup project ie, Futrex Core Web API
cd FutrexConnect.Core

#Build the project
dotnet build

#Run the project
dotnet run

#Note the API URL and port no mentioned in the console and replace in below URL, if different. Access Get Customer API in browser to view the API output
http://localhost:5015/Customer 
