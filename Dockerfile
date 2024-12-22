# Базовый образ для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app

# Базовый образ для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /projectAPI

# Копирование файлов проекта и восстановление зависимостей
COPY ["projectAPI/projectAPI.csproj", "projectAPI/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "projectAPI/projectAPI.csproj"

# Копирование всех файлов проекта
COPY . .

# Публикация приложения
FROM build AS publish
RUN dotnet publish "projectAPI/projectAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ
FROM base AS final
WORKDIR /app

# Копирование опубликованных файлов
COPY --from=publish /app/publish .
COPY ./projectAPI/appsettings.json /app/appsettings.json

# Запуск приложения
ENTRYPOINT ["dotnet", "projectAPI.dll"]