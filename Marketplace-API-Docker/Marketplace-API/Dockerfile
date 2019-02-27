FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Marketplace-API/MarketplaceAPI.csproj", "Marketplace-API/"]
RUN dotnet restore "Marketplace-API/MarketplaceAPI.csproj"
COPY . .
WORKDIR "/src/Marketplace-API"
RUN dotnet build "MarketplaceAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MarketplaceAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MarketplaceAPI.dll"]