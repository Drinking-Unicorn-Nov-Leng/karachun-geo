#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["karachun_geo.API/karachun_geo.API.API/karachun_geo.API.API.csproj", "karachun_geo.API/karachun_geo.API.API/"]
COPY ["karachun_geo.API/karachun_geo.API.BI/karachun_geo.API.BI.csproj", "karachun_geo.API/karachun_geo.API.BI/"]
COPY ["karachun_geo.API/karachun_geo.API.Data/karachun_geo.API.Data.csproj", "karachun_geo.API/karachun_geo.API.Data/"]
COPY ["karachun_geo.API/karachun_geo.API.General/karachun_geo.API.General.csproj", "karachun_geo.API/karachun_geo.API.General/"]
RUN dotnet restore "karachun_geo.API/karachun_geo.API.API/karachun_geo.API.API.csproj"
COPY . .
WORKDIR "/src/karachun_geo.API/karachun_geo.API.API"
RUN dotnet build "karachun_geo.API.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "karachun_geo.API.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "karachun_geo.API.API.dll"]