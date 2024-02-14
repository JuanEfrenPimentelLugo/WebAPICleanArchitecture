#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Enterprice.Solution.Services.WebApi/Enterprice.Solution.Services.WebApi.csproj", "Enterprice.Solution.Services.WebApi/"]
COPY ["Enterprice.Solution.Application.DTO/Enterprice.Solution.Application.DTO.csproj", "Enterprice.Solution.Application.DTO/"]
COPY ["Enterprice.Solution.Application.Interface/Enterprice.Solution.Application.Interface.csproj", "Enterprice.Solution.Application.Interface/"]
COPY ["Enterprice.Solution.Domain.Entity/Enterprice.Solution.Domain.csproj", "Enterprice.Solution.Domain.Entity/"]
COPY ["Enterprice.Solution.Transversal.Common/Enterprice.Solution.Transversal.Common.csproj", "Enterprice.Solution.Transversal.Common/"]
COPY ["Enterprice.Solution.Application.Main/Enterprice.Solution.Application.UseCases.csproj", "Enterprice.Solution.Application.Main/"]
COPY ["Enterprice.Solution.Application.Validator/Enterprice.Solution.Application.Validator.csproj", "Enterprice.Solution.Application.Validator/"]
COPY ["Enterprice.Solution.Persistence/Enterprice.Solution.Persistence.csproj", "Enterprice.Solution.Persistence/"]
COPY ["Enterprice.Solution.Transversal.Logging/Enterprice.Solution.Transversal.Logging.csproj", "Enterprice.Solution.Transversal.Logging/"]
RUN dotnet restore "./Enterprice.Solution.Services.WebApi/./Enterprice.Solution.Services.WebApi.csproj"
COPY . .
WORKDIR "/src/Enterprice.Solution.Services.WebApi"
RUN dotnet build "./Enterprice.Solution.Services.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Enterprice.Solution.Services.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Enterprice.Solution.Services.WebApi.dll"]