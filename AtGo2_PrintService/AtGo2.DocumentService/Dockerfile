#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AtGo2.DocumentService/AtGo2.DocumentService.csproj", "AtGo2.DocumentService/"]
RUN dotnet restore "./AtGo2.DocumentService/AtGo2.DocumentService.csproj"
COPY . .
WORKDIR "/src/AtGo2.DocumentService"
RUN dotnet build "./AtGo2.DocumentService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AtGo2.DocumentService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AtGo2.DocumentService.dll"]