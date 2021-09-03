# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

RUN dotnet new sln -n ServicoMisto

COPY ./ServicoMisto/. ./ServicoMisto/

RUN dotnet sln ServicoMisto.sln add ./ServicoMisto/ServicoMisto.csproj

RUN dotnet restore

RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ServicoMisto.dll"]