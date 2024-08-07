CREATE DATABASE [BdiExamen ]
 
USE [BdiExamen ]
GO

CREATE TABLE [dbo].[tblExamen](
	[idExamen] [int] NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](255) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tblExamen] ([idExamen], [Nombre], [Descripcion]) VALUES (1, N'Examen Matemáticas', N'Examen de álgebra y geometría')
GO
INSERT [dbo].[tblExamen] ([idExamen], [Nombre], [Descripcion]) VALUES (2, N'Examen Geografía', N'Examen de geografia')
GO

CREATE PROCEDURE [dbo].[spActualizar]
    @Id INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @CodigoRetorno INT OUTPUT,
    @DescripcionRetorno NVARCHAR(255) OUTPUT
AS
BEGIN
    BEGIN TRY
        UPDATE tblExamen
        SET nombre = @Nombre,
            descripcion = @Descripcion
        WHERE idExamen = @Id;

        IF @@ROWCOUNT = 0
        BEGIN
            SET @CodigoRetorno = -1;
            SET @DescripcionRetorno = 'No se encontró el registro para actualizar.';
        END
        ELSE
        BEGIN
            SET @CodigoRetorno = 0;
            SET @DescripcionRetorno = 'Registro actualizado satisfactoriamente.';
        END
    END TRY
    BEGIN CATCH
        SET @CodigoRetorno = ERROR_NUMBER();
        SET @DescripcionRetorno = ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[spAgregar]
    @Id INT,
    @Nombre NVARCHAR(100),-- Se coloca en 100 por performance ya que la probabilidad de un nombre 255 caracteres dentro del contexto es muy poco probable
    @Descripcion NVARCHAR(255),
    @CodigoRetorno INT OUTPUT,
    @DescripcionRetorno NVARCHAR(255) OUTPUT
AS
BEGIN
    BEGIN TRY
        INSERT INTO tblExamen (idExamen, nombre, descripcion)
        VALUES (@Id, @Nombre, @Descripcion);

        SET @CodigoRetorno = 0;
        SET @DescripcionRetorno = 'Registro insertado satisfactoriamente.';
    END TRY
    BEGIN CATCH
        SET @CodigoRetorno = ERROR_NUMBER();
        SET @DescripcionRetorno = ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[spConsultar]
    @Nombre NVARCHAR(100) = NULL,
    @Descripcion NVARCHAR(255) = NULL
AS
BEGIN
    SELECT idExamen, nombre, descripcion
    FROM tblExamen
    WHERE (@Nombre IS NULL OR nombre LIKE '%' + @Nombre + '%')
      AND (@Descripcion IS NULL OR descripcion LIKE '%' + @Descripcion + '%');
END;
GO

CREATE PROCEDURE [dbo].[spEliminar]
    @Id INT,
    @CodigoRetorno INT OUTPUT,
    @DescripcionRetorno NVARCHAR(255) OUTPUT
AS
BEGIN
    BEGIN TRY
        DELETE FROM tblExamen
        WHERE idExamen = @Id;

        IF @@ROWCOUNT = 0
        BEGIN
            SET @CodigoRetorno = -1;
            SET @DescripcionRetorno = 'No se encontró el registro para eliminar.';
        END
        ELSE
        BEGIN
            SET @CodigoRetorno = 0;
            SET @DescripcionRetorno = 'Registro eliminado satisfactoriamente.';
        END
    END TRY
    BEGIN CATCH
        SET @CodigoRetorno = ERROR_NUMBER();
        SET @DescripcionRetorno = ERROR_MESSAGE();
    END CATCH
END;
GO