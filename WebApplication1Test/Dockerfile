FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApplication1Test/WebApplication1Test.csproj", "WebApplication1Test/"]
RUN dotnet restore "WebApplication1Test/WebApplication1Test.csproj"
COPY . .
WORKDIR "/src/WebApplication1Test"
RUN dotnet build "WebApplication1Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication1Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1Test.dll"]
