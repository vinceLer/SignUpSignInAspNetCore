
# SignUpSignInAspNetCore

This project is a login page where it's possible to register and login.  
Users are saved with SQL Server.  
Session system is used for user connection.



## Authors

- [@vinceLer](https://www.github.com/vinceLer)


## Prerequisites

- ASP .NET Core
- Visual Studio
- SQL Server
## Run Locally

Clone the project

```bash
  git clone https://github.com/vinceLer/SignUpSignInAspNetCore
```

Go to the project directory

```bash
  cd SignUpSignInAspNetCore
```



## Installation

Database Initialization  
Check if Database and DataContext (DbContext) are connected, and run this command from the project.

```bash
  dotnet ef database update
```
or run this one from the Package Manager Console  
```bash
  update-database
```
