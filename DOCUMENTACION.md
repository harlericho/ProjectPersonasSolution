# Documentación Técnica

## Estructura del Proyecto

- **Domain**: Entidades y contratos (interfaces) del dominio.
- **Application**: Servicios de aplicación, DTOs y validadores.
- **Infrastructure**: Implementación de repositorios, seguridad y acceso a datos.
- **WebApplicationAPI**: Controladores, configuración de servicios, autenticación y Swagger.

## Principales Componentes

- **Entidades**: `Persona`, `Especialidad`, `Usuario`.
- **Repositorios**: Interfaces en Domain, implementación en Infrastructure.
- **Servicios**: Lógica de negocio en Application.
- **Controladores**: API REST en WebApplicationAPI.
- **Seguridad**: Autenticación JWT y gestión de contraseñas.
- **Validación**: FluentValidation para datos de entrada.

## Flujo de Datos

1. El usuario realiza una petición HTTP a la API.
2. El controlador recibe la petición y valida los datos.
3. El controlador invoca el servicio de aplicación correspondiente.
4. El servicio usa los repositorios para acceder o modificar datos.
5. Se devuelve la respuesta al usuario.

## Endpoints Principales

- `POST /api/auth/login` — Autenticación y obtención de token JWT.
- `GET /api/personas` — Listar personas.
- `POST /api/personas` — Crear persona.
- `PUT /api/personas/{id}` — Actualizar persona.
- `DELETE /api/personas/{id}` — Eliminar persona.
- `GET /api/especialidades` — Listar especialidades.

## Seguridad

- Autenticación JWT.
- Validación de token en endpoints protegidos.
- Gestión segura de contraseñas.

## Pruebas y Desarrollo

- Swagger disponible en desarrollo para probar la API.
- Validaciones automáticas en los endpoints.

---

# Documentación de Usuario

## Requisitos

- Tener .NET 8 instalado.
- Acceso a una base de datos SQL Server.

## Instalación y Ejecución

1. Clona el repositorio.
2. Configura la cadena de conexión en `appsettings.json`.
3. Restaura paquetes NuGet: `dotnet restore`.
4. Ejecuta migraciones: `dotnet ef database update --project ProjectPersonas.Infrastructure`.
5. Ejecuta la API: `dotnet run --project ProjectPersonas.WebApplicationAPI`.
6. Accede a Swagger en `https://localhost:<puerto>/swagger`.

## Uso de la API

1. **Autenticación**: Usa el endpoint `/api/auth/login` para obtener un token JWT.
2. **Personas**: Usa los endpoints para crear, consultar, modificar y eliminar personas.
3. **Especialidades**: Consulta las especialidades disponibles.
4. **Validaciones**: Si los datos son incorrectos, recibirás mensajes descriptivos de error.

## Ejemplo de flujo

1. Inicia sesión y obtén el token JWT.
2. Usa el token en la cabecera `Authorization: Bearer <token>` para acceder a los endpoints protegidos.
3. Realiza operaciones CRUD sobre personas y especialidades.

## Soporte

Para dudas o problemas, contacta al equipo de desarrollo o abre un issue en el repositorio.

---

## Diagrama de Arquitectura

```
+-----------------------------+
|      WebApplicationAPI      |  <-- Presentación (Controladores, Swagger, Auth)
+-----------------------------+
              |
              v
+-----------------------------+
|        Application          |  <-- Servicios de aplicación, DTOs, Validadores
+-----------------------------+
              |
              v
+-----------------------------+
|          Domain             |  <-- Entidades, Interfaces, Contratos
+-----------------------------+
              ^
              |
+-----------------------------+
|       Infrastructure        |  <-- Repositorios, Seguridad, Persistencia
+-----------------------------+
```

Este diagrama representa la relación y flujo entre las capas del proyecto siguiendo Clean Architecture.
