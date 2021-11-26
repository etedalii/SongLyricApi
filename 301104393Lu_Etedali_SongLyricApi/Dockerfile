#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["301104393Lu_Etedali_SongLyricApi/301104393Lu_Etedali_SongLyricApi.csproj", "301104393Lu_Etedali_SongLyricApi/"]
COPY ["SongLyricDataAccess/SongLyricDataAccess.csproj", "SongLyricDataAccess/"]
COPY ["SongLyricEntities/SongLyricEntities.csproj", "SongLyricEntities/"]
RUN dotnet restore "301104393Lu_Etedali_SongLyricApi/301104393Lu_Etedali_SongLyricApi.csproj"
COPY . .
WORKDIR "/src/301104393Lu_Etedali_SongLyricApi"
RUN dotnet build "301104393Lu_Etedali_SongLyricApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "301104393Lu_Etedali_SongLyricApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "301104393Lu_Etedali_SongLyricApi.dll"]