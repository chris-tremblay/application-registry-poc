FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/MyNexus.ApplicationRegistry.Web/MyNexus.ApplicationRegistry.Web.csproj", "src/MyNexus.ApplicationRegistry.Web/"]
RUN dotnet restore "src/MyNexus.ApplicationRegistry.Web/MyNexus.ApplicationRegistry.Web.csproj"
COPY . .
WORKDIR "/src/src/MyNexus.ApplicationRegistry.Web"
RUN dotnet build "MyNexus.ApplicationRegistry.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyNexus.ApplicationRegistry.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyNexus.ApplicationRegistry.Web.dll"]