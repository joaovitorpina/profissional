FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Profissional.API/Profissional.API.csproj", "./Profissional.API/"]
COPY ["Profissional.App/Profissional.App.csproj", "./Profissional.App/"]
COPY ["Profissional.Domain/Profissional.Domain.csproj", "./Profissional.Domain/"]
COPY ["Profissional.Infrastructure/Profissional.Infrastructure.csproj", "./Profissional.Infrastructure/"]
RUN dotnet restore "Profissional.API/Profissional.API.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Profissional.API/Profissional.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Profissional.API/Profissional.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Profissional.API.dll"]
