#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# for adding dotnet-ef/etc when needed
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BKMeCommerceWeb_Razor/BKMeCommerceWeb_Razor.csproj", "BKMeCommerceWeb_Razor/"]
RUN dotnet restore "./BKMeCommerceWeb_Razor/BKMeCommerceWeb_Razor.csproj"
COPY . .
WORKDIR "/src/BKMeCommerceWeb_Razor"
RUN dotnet build "./BKMeCommerceWeb_Razor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BKMeCommerceWeb_Razor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BKMeCommerceWeb_Razor.dll"]