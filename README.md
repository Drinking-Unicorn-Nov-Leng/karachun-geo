# Micro-Service отвечающий за геолокацию

Реализованные возможности:
* Отправка пользователям местоположения остальных пользователей
* Проверка для аудиогида на объекты рядом с пользователем

-------

Используемые технологии:
- .NET 5
- ASP.NET
- SignalR (отправка создана с помощью WebSockets)
- AutoMapper
- AutoFac
- Postgresql
- Nginx

-------

Развёртывание:

Нет докера. Нет ничего. БД не используется. В настройках линк для подключения к Micro-service карт.

Компилить и запустить. 