FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY Lapka.Notification.Api/Lapka.Notification.Api.csproj Lapka.Notification.Api/Lapka.Notification.Api.csproj
COPY Lapka.Notification.Application/Lapka.Notification.Application.csproj Lapka.Notification.Application/Lapka.Notification.Application.csproj
COPY Lapka.Notification.Core/Lapka.Notification.Core.csproj Lapka.Notification.Core/Lapka.Notification.Core.csproj
COPY Lapka.Notification.Infrastructure/Lapka.Notification.Infrastructure.csproj Lapka.Notification.Infrastructure/Lapka.Notification.Infrastructure.csproj
RUN dotnet restore Lapka.Notification.Api

COPY . .
RUN dotnet publish Lapka.Notification.Api -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

ARG BUILD_VERSION
ENV BUILD_VERSION $BUILD_VERSION

ENV ASPNETCORE_URLS=http://+:5030
ENV ASPNETCORE_URLS=http://+:5031

ENTRYPOINT ["dotnet", "Lapka.Notification.Api.dll"]