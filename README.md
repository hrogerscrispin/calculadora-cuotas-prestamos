# Calculadora de Cuotas para Préstamos

Aplicación web desarrollada en ASP.NET Web API MVC y Vistas en ASP.Net Core MVC para calcular cuotas de préstamos según la edad del solicitante.

## Tecnologías
- ASP.NET Web API -- .NET10
- ASP.NET Core MVC -- .NET10
- SQL Server
- Bootstrap 5

## Estructura
- `CapaDatos` — acceso a datos con stored procedures
- `CapaNegocio` — lógica de negocio
- `CapaAPI` — expone endpoint utilizado para calcular las cuotas
- `CapaPresentacion` — interfaz web MVC simple


## Configuración
En `appsettings.json` configurar el connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=CalculadoraPrestamos;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## Base de datos
Ejecutar los scripts SQL incluidos en la carpeta `/Database` para crear las tablas y stored procedures.
