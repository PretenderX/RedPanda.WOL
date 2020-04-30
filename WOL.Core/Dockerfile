#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RedPanda.WOL.Core/RedPanda.WOL.Core.csproj", "RedPanda.WOL.Core/"]
RUN dotnet restore "RedPanda.WOL.Core/RedPanda.WOL.Core.csproj"
COPY . .
WORKDIR "/src/RedPanda.WOL.Core"
RUN dotnet build "RedPanda.WOL.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedPanda.WOL.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedPanda.WOL.Core.dll"]