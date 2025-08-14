namespace ProjectPersonas.Application.DTOs
{
    public record PersonaDto(
        int Id,
        string Cedula,
        string Nombres,
        string? Direccion,
        string? Telefono,
        bool Estado,
        int EspecialidadId,
        string? EspecialidadDescripcion
    );

    public record CreatePersonaDto(
        string Cedula,
        string Nombres,
        string? Direccion,
        string? Telefono,
        bool Estado,
        int EspecialidadId
    );

    public record UpdatePersonaDto(
        string Nombres,
        string? Direccion,
        string? Telefono,
        bool Estado,
        int EspecialidadId
    );

}
