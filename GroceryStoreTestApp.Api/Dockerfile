FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GroceryStoreTestApp.Api/GroceryStoreTestApp.Api.csproj", "GroceryStoreTestApp.Api/"]
COPY ["BussinessLogic/BussinessLogic.csproj", "BussinessLogic/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "GroceryStoreTestApp.Api/GroceryStoreTestApp.Api.csproj"
COPY . .
WORKDIR "/src/GroceryStoreTestApp.Api"
RUN dotnet build "GroceryStoreTestApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GroceryStoreTestApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroceryStoreTestApp.Api.dll"]
