#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/TestTemplate15.WorkerServices/TestTemplate15.WorkerServices.csproj", "src/TestTemplate15.WorkerServices/"]
COPY ["src/TestTemplate15.Core/TestTemplate15.Core.csproj", "src/TestTemplate15.Core/"]
COPY ["src/TestTemplate15.Common/TestTemplate15.Common.csproj", "src/TestTemplate15.Common/"]
RUN dotnet restore "src/TestTemplate15.WorkerServices/TestTemplate15.WorkerServices.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate15.WorkerServices"
RUN dotnet build "TestTemplate15.WorkerServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate15.WorkerServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/TestTemplate15.WorkerServices/entrypoint.sh", "src/entrypoint.sh"]
COPY ["src/TestTemplate15.WorkerServices/wait-for-it.sh", "src/wait-for-it.sh"]
CMD ["/bin/bash", "src/entrypoint.sh"]
