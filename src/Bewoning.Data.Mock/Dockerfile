# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    TZ=Europe/Amsterdam
WORKDIR /app

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Bewoning.Data.Mock/Bewoning.Data.Mock.csproj", "Bewoning.Data.Mock/"]
COPY ["Brp.Shared.Infrastructure/Brp.Shared.Infrastructure.csproj", "Brp.Shared.Infrastructure/"]
COPY ["Serilog.Sinks.PersistentFile/Serilog.Sinks.PersistentFile.csproj", "Serilog.Sinks.PersistentFile/"]
RUN dotnet restore "./Bewoning.Data.Mock/Bewoning.Data.Mock.csproj"
COPY . .
COPY config/BewoningService/test-data.json Bewoning.Data.Mock/Data/test-data.json
RUN rm Bewoning.Informatie.Service/appsettings.json && rm Bewoning.Informatie.Service/appsettings.Development.json
WORKDIR "/src/Bewoning.Data.Mock"
RUN dotnet build "./Bewoning.Data.Mock.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
RUN dotnet publish "./Bewoning.Data.Mock.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN groupadd -g 1000 brp-api && \
    useradd -m -u 1000 -g brp-api brp-api-user
USER brp-api-user

# See https://github.com/Contrast-Security-OSS/agent-operator/blob/master/docs/public/08-tips.md
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false

ENTRYPOINT ["dotnet", "Bewoning.Data.Mock.dll"]