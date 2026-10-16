USE DBPedidos;
GO

/* =====================================================================
   DBPedidos - Configuración completa para funcionalidad de Login y Menú
   Crea los procedimientos faltantes (paOpcionLista, paUsuario_BuscaCodUserClave),
   registra los datos del menú en Opcion y asegura el usuario de prueba jchavez.
   ===================================================================== */

-- 1. Procedimiento para listar las opciones del menú dinámico
CREATE OR ALTER PROCEDURE dbo.paOpcionLista
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdOpcion, NombreOpcion, UrlOpcion, RutaImagen, NroOrden, IdOpcionRef
    FROM dbo.Opcion
    ORDER BY NroOrden;
END
GO

-- 2. Procedimiento para autenticación de usuario por código y clave encriptada
CREATE OR ALTER PROCEDURE dbo.paUsuario_BuscaCodUserClave
    @CodUsuario VARCHAR(50),
    @Clave      VARBINARY(256)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdUsuario, CodUsuario, Clave, Nombres
    FROM dbo.Usuario
    WHERE CodUsuario = @CodUsuario AND Clave = @Clave;
END
GO

-- 3. Inserción de opciones del menú (si la tabla está vacía)
IF NOT EXISTS (SELECT 1 FROM dbo.Opcion)
BEGIN
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
END
GO

-- 4. Inserción o actualización del usuario jchavez (Clave: 123456 encriptada)
IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE CodUsuario = 'jchavez')
BEGIN
    INSERT INTO dbo.Usuario (CodUsuario, Clave, Nombres)
    VALUES ('jchavez', 0x7A59847CAC0B59A20037BF4DA8CEF4C3, 'Juan Chavez');
END
ELSE
BEGIN
    UPDATE dbo.Usuario
    SET Clave = 0x7A59847CAC0B59A20037BF4DA8CEF4C3
    WHERE CodUsuario = 'jchavez';
END
GO

-- 5. Asignar clave por defecto (123456) a usuarios existentes que tengan Clave NULL
UPDATE dbo.Usuario
SET Clave = 0x7A59847CAC0B59A20037BF4DA8CEF4C3
WHERE Clave IS NULL;
GO

-- Verificación final
SELECT 'Usuario' AS Tabla, COUNT(*) AS TotalRegistros FROM dbo.Usuario
UNION ALL
SELECT 'Opcion', COUNT(*) FROM dbo.Opcion;
GO
