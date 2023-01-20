#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Graphir.API/Graphir.API.csproj", "Graphir.API/"]
RUN dotnet restore "Graphir.API/Graphir.API.csproj"
COPY . .
WORKDIR "/src/Graphir.API"
RUN dotnet build "Graphir.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Graphir.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Graphir.API.dll"]