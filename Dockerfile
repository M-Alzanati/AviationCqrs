# Use the official Microsoft .NET Core runtime base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory in the image to '/app'
WORKDIR /app

# Copy the .csproj files and restore the .NET Core dependencies
COPY *.sln .
COPY AviationApp/*.csproj ./AviationApp/
COPY AviationApp.UnitTests/*.csproj ./AviationApp.UnitTests/
RUN dotnet restore

# Copy everything else and build the project
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "AviationApp.dll"]