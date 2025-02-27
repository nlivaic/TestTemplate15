#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/TestTemplate15.Api/TestTemplate15.Api.csproj", "src/TestTemplate15.Api/"]
COPY ["src/TestTemplate15.Data/TestTemplate15.Data.csproj", "src/TestTemplate15.Data/"]
COPY ["src/TestTemplate15.Common/TestTemplate15.Common.csproj", "src/TestTemplate15.Common/"]
COPY ["src/TestTemplate15.Core/TestTemplate15.Core.csproj", "src/TestTemplate15.Core/"]
RUN dotnet restore "src/TestTemplate15.Api/TestTemplate15.Api.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate15.Api"
RUN dotnet build "TestTemplate15.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate15.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTemplate15.Api.dll"]