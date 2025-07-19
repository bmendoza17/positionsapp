FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Job/Jobs.API/Job.API.csproj", "Services/Job/Jobs.API/"]
COPY ["BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/"]
COPY ["Job.Application/Job.Application.csproj", "Job.Application/"]
COPY ["Job.Domain/Job.Domain.csproj", "Job.Domain/"]
COPY ["Job.Infrastructure/Job.Infrastructure.csproj", "Job.Infrastructure/"]
RUN dotnet restore "./Services/Job/Jobs.API/Job.API.csproj"
COPY . .
WORKDIR "/src/Services/Job/Jobs.API"
RUN dotnet build "./Job.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet dev-certs https -ep $env:userprofile\.aspnet\https\aspnetapp.pfx -p admin1234 --trust

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Job.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Job.API.dll"]