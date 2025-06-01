FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LeadManagement.API/LeadManagement.API.csproj", "LeadManagement.API/"]
COPY ["LeadManagement.Application/LeadManagement.Application.csproj", "LeadManagement.Application/"]
COPY ["LeadManagement.Domain/LeadManagement.Domain.csproj", "LeadManagement.Domain/"]
COPY ["LeadManagement.Infrastructure/LeadManagement.Infrastructure.csproj", "LeadManagement.Infrastructure/"]
RUN dotnet restore "LeadManagement.API/LeadManagement.API.csproj"
COPY . .
WORKDIR "/src/LeadManagement.API"
RUN dotnet build "LeadManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LeadManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LeadManagement.API.dll"]
