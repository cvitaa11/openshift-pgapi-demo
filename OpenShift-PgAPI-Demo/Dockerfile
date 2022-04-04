FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OpenShift-PgAPI-Demo/OpenShift-PgAPI-Demo.csproj", "OpenShift-PgAPI-Demo/"]
RUN dotnet restore "OpenShift-PgAPI-Demo/OpenShift-PgAPI-Demo.csproj"
COPY . .
WORKDIR "/src/OpenShift-PgAPI-Demo"
RUN dotnet build "OpenShift-PgAPI-Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenShift-PgAPI-Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenShift-PgAPI-Demo.dll"]