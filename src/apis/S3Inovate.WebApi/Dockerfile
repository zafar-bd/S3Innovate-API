#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/apis/S3Inovate.WebApi/S3Inovate.WebApi.csproj", "src/apis/S3Inovate.WebApi/"]
COPY ["src/libraries/S3Inovate.Core/S3Inovate.Core.csproj", "src/libraries/S3Inovate.Core/"]
RUN dotnet restore "src/apis/S3Inovate.WebApi/S3Inovate.WebApi.csproj"
COPY . .
WORKDIR "/src/src/apis/S3Inovate.WebApi"
RUN dotnet build "S3Inovate.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "S3Inovate.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "S3Inovate.WebApi.dll"]