# AG.CsvImporter.API
API import csv to SQL Server DB


Se realizo sistema de importacion de csv desde un repositorio azure hacia una base de datos SQL Server

Para esto se utilizaron los siguientes Nuguet

	- LinqToCsv
	- Serilog
	- Microsoft.Extensions
	- Microsoft.AspNetCore
	- xunit

Se utilizo para la migracion BulkInsert que permite migrar gran cantidad de registros de manera rapida y sin mucho consumo de recursos.
Se agrego log en los lugares mas representativos para que desde la consola se pueda ver el avance del proceso.
Se realizo una arquitectura limpia y estructurada.
Se utilizo inyeccion de dependencias.
Se deja Script para la creacion de la BD y se incluye un csv pequeño usado para test.






