FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Pruebas/Pruebas.csproj", "Pruebas/"]
RUN dotnet restore "Pruebas/Pruebas.csproj"
COPY . .
WORKDIR "/src/Pruebas"
RUN dotnet build "Pruebas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pruebas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pruebas.dll"]
