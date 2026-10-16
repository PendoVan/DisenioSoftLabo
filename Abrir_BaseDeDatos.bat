@echo off
title SQL Server - DBPedidos
color 0B
echo ============================================================
echo   CONECTADO A LA BASE DE DATOS DBPedidos (SQL Server)
echo   Servidor: (localdb)\MSSQLLocalDB
echo   Base de datos: DBPedidos
echo.
echo   Escribe tus consultas SQL y presiona Enter, luego escribe GO
echo   Ejemplo:
echo     SELECT * FROM Usuario;
echo     GO
echo ============================================================
echo.
sqlcmd -S "(localdb)\MSSQLLocalDB" -d DBPedidos
pause
