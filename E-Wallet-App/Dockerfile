#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["E-Wallet-App/E-Wallet-App.csproj", "E-Wallet-App/"]
COPY ["E-Wallet-App.Core/E-Wallet-App.Core.csproj", "E-Wallet-App.Core/"]
COPY ["E-Wallet-App.Entity/E-Wallet-App.Entity.csproj", "E-Wallet-App.Entity/"]
COPY ["E-Wallet-App.Domain/E-Wallet-App.Domain.csproj", "E-Wallet-App.Domain/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "E-Wallet-App/E-Wallet-App.csproj"
COPY . .
WORKDIR "/src/E-Wallet-App"
RUN dotnet build "E-Wallet-App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "E-Wallet-App.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E-Wallet-App.dll"]