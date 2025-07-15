###############################################################################
# 1) BUILD STAGE
###############################################################################
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy sln and project files
COPY Marketplace.sln .
COPY WebApi/WebApi.csproj WebApi/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Core/Application/Application.csproj Core/Application/
COPY Core/Domain/Domain.csproj Core/Domain/

# restore dependencies
RUN dotnet restore

# copy all and publish
COPY . .
WORKDIR /src/WebApi
RUN dotnet publish -c Release -o /app/publish

###############################################################################
# 2) RUNTIME STAGE
###############################################################################
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# copy over just the publish output
COPY --from=build /app/publish .

# will listen on port 80 inside container
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "WebApi.dll"]