
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY profile.sln ./
COPY profile.data/*.csproj ./profile.data/
COPY profile.api/*.csproj ./profile.api/
COPY profile.unit-tests/*.csproj ./profile.unit-tests/

RUN dotnet restore
COPY . .
WORKDIR /src/profile.data
RUN dotnet build -c Release -o /app

WORKDIR /src/profile.api
RUN dotnet build -c Release -o /app

WORKDIR /src/profile.unit-tests
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "profile.api.dll"]