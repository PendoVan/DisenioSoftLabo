/* =====================================================================
   DBPedidos - Estado de la base de datos HASTA EL PASO 54
   (Laboratorios 01 a 04). Se puede ejecutar varias veces: recrea todo.

   Ejecutar en SSMS (servidor: localhost, Autenticación de Windows)
   o por consola:
       sqlcmd -S localhost -E -C -i 01_DBPedidos_hasta_paso54.sql

   NO incluye paOpcionLista ni paUsuario_BuscaCodUserClave:
   esos se crean en el paso 59 (ver GUIA_PASOS_55_59.md).
   ===================================================================== */

IF DB_ID('DBPedidos') IS NULL
    CREATE DATABASE DBPedidos;
GO

USE DBPedidos;
GO

/* ---------- Tablas (Laboratorio 01) ---------- */
IF OBJECT_ID('dbo.Usuario', 'U') IS NOT NULL DROP TABLE dbo.Usuario;
IF OBJECT_ID('dbo.Opcion', 'U') IS NOT NULL DROP TABLE dbo.Opcion;
GO

CREATE TABLE dbo.Opcion
(
    IdOpcion     INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    NombreOpcion VARCHAR(50) NULL,
    UrlOpcion    VARCHAR(50) NULL,
    RutaImagen   VARCHAR(50) NULL,
    NroOrden     INT NULL,
    IdOpcionRef  INT NULL
);
GO

CREATE TABLE dbo.Usuario
(
    IdUsuario  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CodUsuario VARCHAR(50) NULL,
    Clave      VARBINARY(256) NULL,
    Nombres    VARCHAR(50) NULL
);
GO

/* ---------- Procedimientos de Usuario (Laboratorios 01 y 02) ---------- */
CREATE OR ALTER PROCEDURE dbo.paUsuarioLista
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdUsuario, CodUsuario, Clave, Nombres FROM dbo.Usuario;
END
GO

CREATE OR ALTER PROCEDURE dbo.paUsuarioInsertar
    @CodUsuario VARCHAR(50),
    @Clave      VARBINARY(256),
    @Nombres    VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Usuario (CodUsuario, Clave, Nombres)
    VALUES (@CodUsuario, @Clave, @Nombres);
END
GO

CREATE OR ALTER PROCEDURE dbo.paUsuarioModificar
    @IdUsuario  INT,
    @CodUsuario VARCHAR(50),
    @Nombres    VARCHAR(50),
    @Clave      VARBINARY(256)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Usuario
       SET CodUsuario = @CodUsuario,
           Nombres    = @Nombres,
           Clave      = ISNULL(@Clave, Clave)
     WHERE IdUsuario = @IdUsuario;
END
GO

CREATE OR ALTER PROCEDURE dbo.paUsuarioEliminar
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Usuario WHERE IdUsuario = @IdUsuario;
END
GO

CREATE OR ALTER PROCEDURE dbo.paUsuario_ObtenerPorId
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdUsuario, CodUsuario, Clave, Nombres
      FROM dbo.Usuario
     WHERE IdUsuario = @IdUsuario;
END
GO

/* ---------- Datos de prueba ----------
   Clave = EncriptacionHelper.EncriptarByte("123456")  (usuario de la guía)
   Usuario: jchavez   Clave: 123456                                   */
INSERT INTO dbo.Usuario (CodUsuario, Clave, Nombres)
VALUES ('jchavez', 0x7A59847CAC0B59A20037BF4DA8CEF4C3, 'Juan Chavez');
GO

/* ---------- Opciones del menú (Paso 48) ----------
   Raíz: IdOpcionRef = 0.  Hijas: IdOpcionRef = IdOpcion del padre.
   UrlOpcion = '#' para agrupadores, 'Controlador/Accion' para enlaces. */
SET IDENTITY_INSERT dbo.Opcion ON;
INSERT INTO dbo.Opcion (IdOpcion, NombreOpcion, UrlOpcion, RutaImagen, NroOrden, IdOpcionRef) VALUES
 (1, 'Mantenimiento', '#',              'fa fa-cogs',          1, 0),
 (2, 'Seguridad',     '#',              'fa fa-lock',          2, 0),
 (3, 'Pedido',        '#',              'fa fa-shopping-cart', 3, 0),
 (4, 'Inicio',        'Home/Index',     'fa fa-home',          1, 1),
 (5, 'Usuarios',      'Usuario/Index',  'fa fa-user',          1, 2),
 (6, 'Nuevo Usuario', 'Usuario/Create', 'fa fa-user-plus',     2, 2),
 (7, 'Acerca de',     'Home/About',     'fa fa-info-circle',   1, 3),
 (8, 'Contacto',      'Home/Contact',   'fa fa-envelope',      2, 3);
SET IDENTITY_INSERT dbo.Opcion OFF;
GO

SELECT 'Usuario' AS Tabla, COUNT(*) AS Filas FROM dbo.Usuario
UNION ALL
SELECT 'Opcion', COUNT(*) FROM dbo.Opcion;
GO
