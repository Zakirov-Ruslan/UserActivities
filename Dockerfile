# Этап сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы проекта и восстанавливаем зависимости
COPY src/UserActivities.WebApi/UserActivities.WebApi.csproj src/UserActivities.WebApi/
COPY src/UserActivities.Core/UserActivities.Core.csproj src/UserActivities.Core/
COPY src/UserActivities.Infrastructure/UserActivities.Infrastructure.csproj src/UserActivities.Infrastructure/
COPY src/UserActivities.UseCases/UserActivities.UseCases.csproj src/UserActivities.UseCases/

RUN dotnet restore src/UserActivities.WebApi/UserActivities.WebApi.csproj

# Копируем исходный код и собираем приложение
COPY src/ src/
RUN dotnet publish src/UserActivities.WebApi/UserActivities.WebApi.csproj -c Release -o /app/publish

# Этап сборки Nginx
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Копируем собранное приложение
COPY --from=build /app/publish /app
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

# Копируем конфигурацию Nginx
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Открываем порты
EXPOSE 80

# Запускаем Nginx
CMD ["nginx", "-g", "daemon off;"] 