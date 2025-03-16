# Тестовое задание 
Написать одностраничный сайт на ASP.NET Core с одной кнопкой "Отправить данные".
Добавить на странице js код, который собирает координаты движения мышки при ее движении в формате [X,Y,T], где X,Y - координаты, T - время события.
При нажатии по кнопке "Отправить данные" массив координат движения мышки, сохраненный ранее, должен отправляться на бекенд и сохраняться через Entity в таблицу произвольной базы данных в формате json.
Написать unit test к методу.
Предпочтение будет отдаваться решениям с использованием Clean Architecture.

# Quick start
Из директории UserActivities.WebApi - откроется index.html 
```
dotnet watch run --launch-profile https 
```
Либо запуск отладки из студии

# Комментарии

Сохраняемые данные можно наблюдать в коноли браузера при нажалии кнопки в index.html, так же ef логирует сообщения о сохранении.
При запуске unit теста так же видно что все корректно работает

В остальном - проект разбил на слои согласно clean architecture. Сущность для хранения данных движений мыши вынесена в ValueObjects, хранение в json настроено в конфигурации ef. Постарался не переусложнять ненужной логикой.
