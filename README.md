# AviationApp

This is a brief description of the AviationApp. It's a C# application that...

## Installation

To install the project, clone the repository and navigate into the project directory:

```bash
git clone https://github.com/M-Alzanati/AviationApp.git
cd AviationApp
```

To create database, please change connection string in *appsettings.json*, run the following command:

```bash
cd src
dotnet ef database update --project AviationApp.Infrastructure --startup-project AviationApp.Api
```
