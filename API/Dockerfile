FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY "EntityFrameworkCoreQuery.sln" "EntityFrameworkCoreQuery.sln"
COPY "API/API.csproj" "API/API.csproj"
COPY "Domain/Domain.csproj" "Domain/Domain.csproj"
COPY "Infrastructure/Infrastructure.csproj" "Infrastructure/Infrastructure.csproj"
COPY "Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj" "Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj"
RUN dotnet restore

COPY . .
WORKDIR /src/API
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "API.dll"]