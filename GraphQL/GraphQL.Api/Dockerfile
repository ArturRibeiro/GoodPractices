FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GraphQL/GraphQL.Api/GraphQL.Api.csproj", "GraphQL/GraphQL.Api/"]
RUN dotnet restore "GraphQL/GraphQL.Api/GraphQL.Api.csproj"
COPY . .
WORKDIR "/src/GraphQL/GraphQL.Api"
RUN dotnet build "GraphQL.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQL.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQL.Api.dll"]
