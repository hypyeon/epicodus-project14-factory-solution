# Dr.Sillystringz's Factory 👩🏻‍🏭
by Hayeong Pyeon

## Table of Contents
1. [Technologies Used](#technologies-used)
2. [Description](#description)
3. [Setup Instructions](#setup-instructions)
4. [Known Bugs](#known-bugs)
5. [License](#license)

## Technologies Used
*to be updated*
- C#
- ASP.NET
- MySQL (Community Server, Workbench)

## Description
- This application is an independent project as a review of **Many-to-Many Relationships** chapter of **C#** course provided by Epicodus.
- As the factory manager (owner), you are able to do the followings:
> 1) To see a list of all engineers and a list of all machines. 
> 2) To select an engineer, see their details, and a list of all machines they are licensed to repair. 
> 3) To select a machine, see its details, and a list of all engineers licnesed to repair it. 
> 4) To add new engineers to the system when hired - even if no machines are installed yet. 
> 5) To add new machines to the system when installed - even if no engineers are hired yet. 
> 6) To *not* be able to create an engineer or a machine if a form being submitted has empty or invalid values. 
> 7) To add or remove machines that have engineers who are licensed to repair. 
> 8) To add or rmove engineers from machines they're licnesed to repair. 
> 9) To modify machine-engineer relationship. 
> 10) To *not* be able to add a machine to an engineer if there is no machine. 
> 11) To *not* be able to add an engineer to a machine if there is no engineer. 
> 12) To view a splash page listing all engineers and machines when accessing the application. 

## Setup Instructions
> [!IMPORTANT]
> Make sure you have [MySQL Community Server and Workbench installed](https://full-time.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql). 
1. Clone this repo. 
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory named **Factory**. 
3. Create a file named **appsettings.json**. 
> [!CAUTION]
> In the root directory, you should have a `.gitignore` file that has the following content:
```
obj
bin
appsettings.json
```
4. In the `appsettings.json` file, write the following code, replacing `uid` and the `pwd` values with your own username and password registered for MySQL. 
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=hayeong_pyeon;uid=[YOUR-USERNAME];pwd=[YOUR-PASSWORD];"
  }
}
```
5. Install tools in order to use `dotnet-ef` by running the following commands:
- Has to be run globally: 
```
dotnet tool install --global dotnet-ef --version 6.0.0
```
- Has to be run under the production directory: 
```
dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0
```
6. Run `dotnet ef migrations add [AddEntity]` to create a data migration for the database. *Replace `[AddEntity]` with your own choice. Check out how to name your migration [here](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli).*
7. To update the database after making a change, run `dotnet ef database update`. To remove the recent update, run `dotnet ef migrations remove` in the terminal. 
8. To compile and run the application in development mode with a watcher, run `dotnet watch run` which will open the browser automatically - if not - open the browser and navigate to https://localhost:5001. 

## Known Bugs
*currently under development as of March 13, 2024*

## License
[MIT](/LICENSE.txt) | Copyright © 2024 Hayeong Pyeon