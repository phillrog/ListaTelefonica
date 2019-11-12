# --===\\ BASE // ===-- #
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9 AS base
WORKDIR /app
EXPOSE 80
# TimeZone
RUN apk add tzdata
RUN cp /usr/share/zoneinfo/Etc/GMT+3 /etc/localtime
RUN echo "Etc/GMT+3" > /etc/timezone
ENV TZ Etc/GMT+3
# Locale/Globalization
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false
RUN apk add --no-cache icu-libs
ENV LC_ALL pt_BR.UTF-8
ENV LANG pt_BR.UTF-8

# --===\\ BASESDK // ===-- #
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS basesdk
RUN apk update
# TimeZone
RUN apk add tzdata
RUN cp /usr/share/zoneinfo/Etc/GMT+3 /etc/localtime
RUN echo "Etc/GMT+3" > /etc/timezone
ENV TZ Etc/GMT+3
# Locale/Globalization
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false
RUN apk add --no-cache icu-libs
ENV LC_ALL pt_BR.UTF-8
ENV LANG pt_BR.UTF-8

# --===\\ BASEBUILD // ===-- #
FROM basesdk AS basebuild

WORKDIR /src

COPY Nuget.config Nuget.config
# Projects
COPY ListaTelefonica.API/ListaTelefonica.API.csproj ListaTelefonica.API/
COPY ListaTelefonica.Applications/ListaTelefonica.Applications.csproj ListaTelefonica.Applications/
COPY ListaTelefonica.Domain/ListaTelefonica.Domain.csproj ListaTelefonica.Domain/
COPY ListaTelefonica.Infra.Data/ListaTelefonica.Infra.Data.csproj ListaTelefonica.Infra.Data/
COPY ListaTelefonica.CrossCutting/ListaTelefonica.Infra.CrossCutting.csproj ListaTelefonica.CrossCutting/

# Test Projects


RUN dotnet restore --configfile Nuget.config ListaTelefonica.API/ListaTelefonica.API.csproj


COPY . .

# --===\\ BUILD // ===-- #
FROM basebuild as build
ARG ASSEMBLY_VERSION="1.0.0"

# Build and Static Analysis
WORKDIR /src/ListaTelefonica.API

RUN dotnet build ListaTelefonica.API.csproj --no-restore -c Release /p:Version=${ASSEMBLY_VERSION}

# --===\\ PUBLISH // ===-- #
FROM build AS publish
RUN dotnet publish ListaTelefonica.API.csproj --no-build -c Release -o /app

# --===\\ FINAL // ===-- #
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ListaTelefonica.API.dll"]