# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /BookTok/
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_ENVIRONMENT "Development"
WORKDIR /BookTok/
COPY --from=build-env /BookTok/out .
COPY --from=build-env /BookTok/*.db .
ENTRYPOINT ["dotnet", "BookTok.dll"]
