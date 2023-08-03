#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/category/WebAPI/WebAPI.csproj", "src/category/WebAPI/"]
COPY ["src/corePackages/Core.Mailing/Core.Mailing.csproj", "src/corePackages/Core.Mailing/"]
COPY ["src/corePackages/Core.WebAPI/Core.WebAPI.csproj", "src/corePackages/Core.WebAPI/"]
COPY ["src/corePackages/Core.Application/Core.Application.csproj", "src/corePackages/Core.Application/"]
COPY ["src/corePackages/Core.CrossCuttingConcerns/Core.CrossCuttingConcerns.csproj", "src/corePackages/Core.CrossCuttingConcerns/"]
COPY ["src/corePackages/Core.Security/Core.Security.csproj", "src/corePackages/Core.Security/"]
COPY ["src/corePackages/Core.Persistence/Core.Persistence.csproj", "src/corePackages/Core.Persistence/"]
COPY ["src/category/Application/Application.csproj", "src/category/Application/"]
COPY ["src/corePackages/Core.ElasticSearch/Core.ElasticSearch.csproj", "src/corePackages/Core.ElasticSearch/"]
COPY ["src/category/Domain/Domain.csproj", "src/category/Domain/"]
COPY ["src/category/Infrastructure/Infrastructure.csproj", "src/category/Infrastructure/"]
COPY ["src/category/Persistence/Persistence.csproj", "src/category/Persistence/"]
RUN dotnet restore "src/category/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/src/category/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]