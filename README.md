\# AppCrudCore – ASP.NET Core MVC



Proyecto en progreso desarrollado con \*\*ASP.NET Core MVC\*\* y \*\*Entity Framework Core\*\*, enfocado en reforzar buenas prácticas de backend, arquitectura MVC y modelado de datos con Code First.



\## Objetivo del proyecto

Evolucionar un CRUD base hacia un sistema más completo (tipo biblioteca), incorporando:

\- Modelado correcto de entidades
\- Uso de Fluent API
\- Migraciones con EF Core
\- Buenas prácticas en controladores MVC
\- Separación de responsabilidades



\## Estado actual

\- CRUD funcional de Empleados
\- DbContext configurado con Fluent API
\- Migraciones aplicadas a base de datos
\- Campo de contraseña preparado como `PasswordHash`
\- Uso de appsettings de ejemplo (sin credenciales reales)



\## La seguridad se implementa de forma incremental:

\- Hashing de contraseñas con BCrypt en la creación de empleados
\- Cambio de contraseña opcional en la edición de empleados
\- Separación entre entidad de dominio y ViewModel para formularios
\- Validaciones básicas en vistas MVC

Las validaciones avanzadas y flujos de autenticación se abordarán en etapas posteriores.



\## 🛠️ Tecnologías

\- ASP.NET Core MVC
\- Entity Framework Core
\- SQL Server
\- Fluent API
\- Razor Views
\- Bootstrap



\## Próximos pasos

\- Implementar hashing de contraseñas al crear/editar usuarios
\- Agregar entidades de dominio (Libros, Clientes, Préstamos)
\- Definir relaciones con Code First
\- Mejorar validaciones y UX



\## Notas

Este repositorio es retomando viejos conceptos y conocimientos y adecuándolo al entorno actual. Blessings c:.



