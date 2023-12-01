﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Catalog.Api/Catalog.Api.scproj" --disable-parallel
RUN dotnet publish "./Catalog.Api/Catalog.Api.scproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 5000
ENTRYPOINT["dotnet", "Catalog.Api.dll"]