FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Pattern.Saga.Web.Api/Pattern.Saga.Web.Api.csproj", "Pattern.Saga.Web.Api/"]
RUN dotnet restore "Pattern.Saga.Web.Api/Pattern.Saga.Web.Api.csproj"
COPY . .
WORKDIR "/src/Pattern.Saga.Web.Api"
RUN dotnet build "Pattern.Saga.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pattern.Saga.Web.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pattern.Saga.Web.Api.dll"]
