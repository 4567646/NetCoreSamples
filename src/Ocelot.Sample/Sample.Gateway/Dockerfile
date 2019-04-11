FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Sample.Gateway/Sample.Gateway.csproj", "Sample.Gateway/"]
RUN dotnet restore "Sample.Gateway/Sample.Gateway.csproj"
COPY . .
WORKDIR "/src/Sample.Gateway"
RUN dotnet build "Sample.Gateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sample.Gateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sample.Gateway.dll"]