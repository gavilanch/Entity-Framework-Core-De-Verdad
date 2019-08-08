SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[EstudiantesConCursosActivos]
AS
SELECT        stu.Id, stu.Nombre, COUNT(*) AS CantidadDeCursos
FROM            dbo.Estudiantes AS stu INNER JOIN
                         dbo.EstudiantesCursos AS sco ON stu.Id = sco.EstudianteId
WHERE        (sco.EstaActivo = 'true')
GROUP BY stu.Id, stu.Nombre
GO
