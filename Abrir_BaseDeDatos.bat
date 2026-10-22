@echo off
title SQL Server - BDPedido
color 0B
echo ============================================================
echo   CONECTADO A LA BASE DE DATOS BDPedido (SQL Server)
echo   Servidor: . (localhost)
echo   Base de datos: BDPedido
echo.
echo   Escribe tus consultas SQL y presiona Enter, luego escribe GO
echo   Ejemplo:
echo     SELECT * FROM Usuario;
echo     GO
echo ============================================================
echo.
sqlcmd -S "." -d BDPedido
pause
