FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Presentation/", "Presentation/"]
COPY ["Infrastructure/", "Infrastructure/"]
COPY ["Application/", "Application/"]
COPY ["Domain/", "Domain/"]

WORKDIR "/src/Presentation"

RUN dotnet restore "Presentation.csproj"
RUN dotnet build "Presentation.csproj" -c Debug -o /app/build


FROM build AS publish

RUN dotnet publish "Presentation.csproj" -c Debug -o /app/publish


FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Presentation.dll"]