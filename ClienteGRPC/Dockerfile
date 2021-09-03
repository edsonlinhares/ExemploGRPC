# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

RUN dotnet new sln -n ClienteGRPC

COPY ./ClienteGRPC/. ./ClienteGRPC/

RUN dotnet sln ClienteGRPC.sln add ./ClienteGRPC/ClienteGRPC.csproj

RUN dotnet restore

RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./


#RUN curl http://servico-misto:5000/api/teste

#ENTRYPOINT ["dotnet", "ClienteGRPC.dll"]
#ENTRYPOINT ["bash"]