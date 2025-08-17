# ProjectPersonasSolution

## Descripción

Sistema de gestión de personas y especialidades, con autenticación y API RESTful, desarrollado en .NET siguiendo Clean Architecture y principios SOLID.

---

## Arquitectura

El proyecto está organizado en cuatro capas principales:

- **Domain**: Entidades, interfaces de repositorio y servicios de seguridad. No depende de otras capas.
- **Application**: Casos de uso, servicios de aplicación, DTOs y validadores. Depende solo de Domain.
- **Infrastructure**: Implementación de persistencia y seguridad. Depende de Domain y puede depender de Application.
- **WebApplicationAPI**: Presentación, controladores, configuración de servicios, autenticación y Swagger.

---

## Principios SOLID

- **S**ingle Responsibility: Cada clase tiene una única responsabilidad.
- **O**pen/Closed: Las clases pueden extenderse sin modificar el código existente.
- **L**iskov Substitution: Las interfaces y clases base permiten sustitución sin romper funcionalidad.
- **I**nterface Segregation: Interfaces específicas, sin métodos innecesarios.
- **D**ependency Inversion: Los servicios dependen de abstracciones.

---

## Instrucciones de instalación

1. Clona el repositorio:
   ```
   git clone https://github.com/harlericho/ProjectPersonasSolution.git
   ```
2. Configura la cadena de conexión SQL Server en `ProjectPersonas.WebApplicationAPI/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BD;Trusted_Connection=True;"
   }
   ```
3. Restaura los paquetes NuGet:
   ```
   dotnet restore
   ```
4. Ejecuta las migraciones (opcional):
   ```
   dotnet ef database update --project ProjectPersonas.Infrastructure
   ```
5. Ejecuta la API:
   ```
   dotnet run --project ProjectPersonas.WebApplicationAPI
   ```
6. Accede a Swagger en `https://localhost:<puerto>/swagger` para probar los endpoints.

---

## Documentación técnica

- **Controladores**: Ubicados en `ProjectPersonas.WebApplicationAPI/Controllers`. Exponen endpoints para personas, especialidades y autenticación.
- **Servicios**: En `ProjectPersonas.Application/Services`. Implementan la lógica de negocio.
- **Repositorios**: En `ProjectPersonas.Infrastructure/Repositories`. Gestionan la persistencia de datos.
- **Validadores**: En `ProjectPersonas.Application/Validatiors`. Validan los datos de entrada usando FluentValidation.
- **Seguridad**: Autenticación JWT y gestión de contraseñas en `ProjectPersonas.Infrastructure/Security`.
- **Swagger**: Documenta y permite probar la API.

### Endpoints principales

- `POST /api/auth/login` — Autenticación y obtención de token JWT.
- `GET /api/personas` — Listar personas.
- `POST /api/personas` — Crear persona.
- `PUT /api/personas/{id}` — Actualizar persona.
- `DELETE /api/personas/{id}` — Eliminar persona.
- `GET /api/especialidades` — Listar especialidades.

---

## Documentación de usuario

1. **Acceso**: Ingresa a la URL de Swagger para explorar y probar la API.
2. **Autenticación**: Obtén un token JWT usando el endpoint de login y úsalo en los endpoints protegidos.
3. **Gestión de personas y especialidades**: Usa los endpoints para crear, consultar, modificar y eliminar registros.
4. **Validaciones**: Los datos enviados son validados automáticamente; si hay errores, se devuelve un mensaje descriptivo.

---

## Contacto y soporte

Para dudas o soporte, contacta al equipo de desarrollo o abre un issue en el repositorio.

---

## Mejoras futuras

- Implementar pruebas unitarias y de integración para aumentar la confiabilidad.
- Agregar paginación y filtros avanzados en los endpoints de consulta.
- Mejorar la gestión de errores y mensajes para usuarios finales.
- Documentar ejemplos de uso en Swagger y agregar tutoriales.
- Integrar autenticación OAuth2 y roles avanzados.
- Optimizar el rendimiento de consultas en base de datos.
- Desplegar el sistema en contenedores Docker para facilitar la instalación.
