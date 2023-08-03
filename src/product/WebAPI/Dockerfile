#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/product/WebAPI/WebAPI.csproj", "src/product/WebAPI/"]
COPY ["src/corePackages/Core.Mailing/Core.Mailing.csproj", "src/corePackages/Core.Mailing/"]
COPY ["src/corePackages/Core.WebAPI/Core.WebAPI.csproj", "src/corePackages/Core.WebAPI/"]
COPY ["src/corePackages/Core.Application/Core.Application.csproj", "src/corePackages/Core.Application/"]
COPY ["src/corePackages/Core.CrossCuttingConcerns/Core.CrossCuttingConcerns.csproj", "src/corePackages/Core.CrossCuttingConcerns/"]
COPY ["src/corePackages/Core.Security/Core.Security.csproj", "src/corePackages/Core.Security/"]
COPY ["src/corePackages/Core.Persistence/Core.Persistence.csproj", "src/corePackages/Core.Persistence/"]
COPY ["src/product/Application/Application.csproj", "src/product/Application/"]
COPY ["src/corePackages/Core.ElasticSearch/Core.ElasticSearch.csproj", "src/corePackages/Core.ElasticSearch/"]
COPY ["src/product/Domain/Domain.csproj", "src/product/Domain/"]
COPY ["src/product/Infrastructure/Infrastructure.csproj", "src/product/Infrastructure/"]
COPY ["src/product/Persistence/Persistence.csproj", "src/product/Persistence/"]
RUN dotnet restore "src/product/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/src/product/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]