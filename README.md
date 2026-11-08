# ApiEcommerce

API REST de comercio electrónico con **ASP.NET Core 8**, **EF Core 9 + SQL Server**, **ASP.NET Core Identity + JWT**, **Mapster**, caché de respuestas, CORS, subida de imágenes y **versionado de API** (v1/v2).

## Requisitos

- .NET SDK 8
- Docker (para SQL Server 2022)
- Herramienta `dotnet-ef` 9.0.5

## Puesta en marcha

```bash
docker compose up -d                 # SQL Server en localhost:1433
dotnet tool install --global dotnet-ef --version 9.0.5   # solo la primera vez
dotnet ef database update            # crea la BD, aplica migraciones y carga datos semilla
dotnet run --launch-profile http     # http://localhost:5176/swagger
```

## Usuarios de demo

| Usuario | Contraseña | Rol |
|---|---|---|
| admin@admin.com | Admin123! | Admin |
| user@user.com | User123! | User |

## Estructura

```text
Constants/      constantes (perfiles de caché, nombres de políticas CORS)
Controllers/    endpoints HTTP (V1/ y V2/ para categorías versionadas)
Data/           ApplicationDbContext y DataSeeder
Mapping/        configuración de Mapster
Migrations/     migraciones de EF Core (generadas)
Models/         entidades y DTOs
Repository/     acceso a datos (interfaces en IRepository/)
wwwroot/        imágenes de productos subidas
```

Las peticiones de ejemplo están en `ApiEcommerce.http`.
