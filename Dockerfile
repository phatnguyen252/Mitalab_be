# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY UserManagement.API/UserManagement.API.csproj UserManagement.API/
RUN dotnet restore UserManagement.API/UserManagement.API.csproj

# Copy everything else and build
COPY . .
WORKDIR /src/UserManagement.API
RUN dotnet build UserManagement.API.csproj -c Release -o /app/build
RUN dotnet publish UserManagement.API.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Railway provides PORT environment variable
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
EXPOSE ${PORT:-8080}

ENTRYPOINT ["dotnet", "UserManagement.API.dll"]
