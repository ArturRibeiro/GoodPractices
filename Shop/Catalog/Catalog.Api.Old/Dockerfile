FROM mcr.microsoft.com/dotnet/sdk:7.0 AS  build
WORKDIR /app
COPY . .
RUN #!/bin/sh -c dotnet restore
RUN #!/bin/sh -c dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build /published-app .
#COPY --from=build /App/out .
ENTRYPOINT [ "dotnet", "/app/Catalog.Api.dll" ]


#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS  build-env
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
## Copy everything
#COPY . ./
## Restore as distinct layers
#RUN #!/bin/sh -c dotnet restore
#RUN #!/bin/sh -c dotnet publish -c Release -o /app/publish /p:UseAppHost=false
##RUN dotnet restore
##RUN dotnet publish "Catalog.Api.csproj" -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/sdk:7.0
#WORKDIR /app
#COPY --from=build /App/out .
#ENTRYPOINT ["dotnet", "Catalog.Api.dll"]

##FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
##WORKDIR /src
##COPY ["Catalog.Api.csproj", "Shop/Catalog/Catalog.Api/"]
##RUN dotnet restore "Shop/Catalog/Catalog.Api/Catalog.Api.csproj"
##COPY . .
##WORKDIR "/src/Shop/Catalog/Catalog.Api"
##RUN dotnet build "Catalog.Api.csproj" -c Release -o /app/build
##
##FROM build AS publish
##RUN dotnet publish "Catalog.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false
##
##FROM base AS final
##WORKDIR /app
##COPY --from=publish /app/publish .
##ENTRYPOINT ["dotnet", "Catalog.Api.dll"]
