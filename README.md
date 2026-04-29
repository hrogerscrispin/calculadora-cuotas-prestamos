# Calculadora de Cuotas para Préstamos

Aplicación web desarrollada en ASP.NET Core MVC para calcular cuotas de préstamos según la edad del solicitante.

## Tecnologías
- ASP.NET Core MVC .NET 8
- SQL Server
- Bootstrap 5

## Estructura
- `CapaDatos` — acceso a datos con stored procedures
- `CapaNegocio` — lógica de negocio 
- `CapaPresentacion` — interfaz web MVC simple

## Funcionalidades
- Cálculo de cuota según edad, monto y plazo
- Validación de edad mínima (18) y máxima (25)
- Registro de consultas en base de datos
- Validaciones en formulario

## Configuración
En `appsettings.json` configurar el connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=CalculadoraPrestamos;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## Base de datos
Ejecutar los scripts SQL incluidos en la carpeta `/Database` para crear las tablas y stored procedures.
