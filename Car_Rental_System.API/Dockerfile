# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Car_Rental_System.API/Car_Rental_System.API.csproj", "Car_Rental_System.API/"]
COPY ["Car_Rental_System.Infrastructure/Car_Rental_System.Infrastructure.csproj", "Car_Rental_System.Infrastructure/"]
COPY ["Car_Rental_System.Application/Car_Rental_System.Application.csproj", "Car_Rental_System.Application/"]
COPY ["Car_Rental_System.Domain/Car_Rental_System.Domain.csproj", "Car_Rental_System.Domain/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
RUN dotnet restore "./Car_Rental_System.API/Car_Rental_System.API.csproj"
COPY . .
WORKDIR "/src/Car_Rental_System.API"
RUN dotnet build "./Car_Rental_System.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Car_Rental_System.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Car_Rental_System.API.dll"]