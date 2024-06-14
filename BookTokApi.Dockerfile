# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /BookTokApi/
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_ENVIRONMENT "Development"
ENV ASPNETCORE_HTTP_PORTS "3000"
WORKDIR /BookTokApi/
COPY --from=build-env /BookTokApi/out .
ENTRYPOINT ["dotnet", "BookTokApi.dll"]
EXPOSE 3000