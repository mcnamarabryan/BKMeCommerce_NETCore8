#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BKMeCommerceWeb/BKMeCommerceWeb.csproj", "BKMeCommerceWeb/"]
COPY ["BKMeCommerce.DataAccess/BKMeCommerce.DataAccess.csproj", "BKMeCommerce.DataAccess/"]
COPY ["BKMeCommerce.Models/BKMeCommerce.Models.csproj", "BKMeCommerce.Models/"]
COPY ["BKMeCommerce.Utility/BKMeCommerce.Utility.csproj", "BKMeCommerce.Utility/"]
RUN dotnet restore "./BKMeCommerceWeb/BKMeCommerceWeb.csproj"
COPY . .
WORKDIR "/src/BKMeCommerceWeb"
RUN dotnet build "./BKMeCommerceWeb.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BKMeCommerceWeb.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BKMeCommerceWeb.dll"]