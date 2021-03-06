#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Forum/Forum.API/Forum.API.csproj", "Services/Forum/Forum.API/"]
COPY ["Services/Forum/Forum.Infrastructure/Forum.Infrastructure.csproj", "Services/Forum/Forum.Infrastructure/"]
RUN dotnet restore "Services/Forum/Forum.API/Forum.API.csproj"
COPY . .
WORKDIR "/src/Services/Forum/Forum.API"
RUN dotnet build "Forum.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Forum.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountyRP.Services.Forum.API.dll"]